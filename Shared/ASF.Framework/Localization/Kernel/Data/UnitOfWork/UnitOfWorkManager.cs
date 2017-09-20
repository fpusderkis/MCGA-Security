using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ASF.Framework.Utilities;
using Kuntur.Framework.Kernel.Constants;
using Kuntur.Framework.Kernel.Data.Context;
using Kuntur.Framework.Kernel.Interfaces.Services;
using Kuntur.Framework.Kernel.Interfaces.Services.UnitOfWork;
using Kuntur.Framework.Model.General.i18n;

namespace Kuntur.Framework.Kernel.Data.UnitOfWork
{
    internal sealed class Configuration : DbMigrationsConfiguration<KunturContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(KunturContext context)
        {
            const string langCulture = "es-AR";
            var language = context.Language.FirstOrDefault(x => x.LanguageCulture == langCulture);
            if (language == null)
            {

                var cultureInfo = LanguageUtils.GetCulture(langCulture);
                language = new Language
                {
                    Name = cultureInfo.EnglishName,
                    LanguageCulture = cultureInfo.Name,
                };
                context.Language.Add(language);
                context.SaveChanges();
            }


        }
    }

    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private bool _isDisposed;
        private readonly KunturContext _context;

        public UnitOfWorkManager(IKunturContext context)
        {
            //http://www.entityframeworktutorial.net/code-first/automated-migration-in-code-first.aspx
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KunturContext, Configuration>(SiteConstants.Instance.MvcKunturContext));
            _context = context as KunturContext;
        }

        /// <summary>
        /// Provides an instance of a unit of work. This wrapping in the manager
        /// class helps keep concerns separated
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork NewUnitOfWork()
        {
            return new UnitOfWork(_context);
        }

        /// <summary>
        /// Make sure there are no open sessions.
        /// In the web app this will be called when the injected UnitOfWork manager
        /// is disposed at the end of a request.
        /// </summary>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _context.Dispose();
                _isDisposed = true;
            }
        }
    }
}
