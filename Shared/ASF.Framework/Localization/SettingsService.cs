using System;
using System.Linq;
using System.Data.Entity;
using Kuntur.Framework.Kernel.Constants;
using Kuntur.Framework.Kernel.Data.Context;
using Kuntur.Framework.Kernel.Interfaces.Services;
using Kuntur.Framework.Model.Enums;
using Kuntur.Framework.Model.Security;

namespace Kuntur.Framework.Services
{
    public partial class SettingsService : ISettingsService
    {
        private readonly KunturContext _context;
        private readonly ICacheService _cacheService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"> </param>
        /// <param name="cacheService"></param>
        public SettingsService(IKunturContext context, ICacheService cacheService)
        {
            _cacheService = cacheService;
            _context = context as KunturContext;
        }

        /// <summary>
        /// Get the site settings from cache, if not in cache gets from database and adds into the cache
        /// </summary>
        /// <returns></returns>
        public Settings GetSettings(bool useCache = true)
        {
            //useCache = false;
            if (useCache)
            {
                var cachedSettings = _cacheService.Get<Settings>(CacheKeys.Settings.Main);
                if (cachedSettings == null)
                {
                    cachedSettings = GetSettingsLocal(false);
                    _cacheService.Set(CacheKeys.Settings.Main, cachedSettings, CacheTimes.OneDay);
                }
                return cachedSettings;
            }
            return GetSettingsLocal(true);
        }

        private Settings GetSettingsLocal(bool addTracking)
        {
            var settings = _context.Setting
                .Include(x => x.DefaultLanguage);
                              

            return addTracking ? settings.FirstOrDefault() : settings.AsNoTracking().FirstOrDefault();
        }

        public Settings Add(Settings settings)
        {
            return _context.Setting.Add(settings);
        }

        public Settings Get(Guid id)
        {
            return _context.Setting.FirstOrDefault(x => x.Id == id);
        }
    }
}
