using System;
using Kuntur.Framework.Model.General;
using Kuntur.Framework.Model.General.i18n;
using ASF.Framework.Utilities;

namespace Kuntur.Framework.Model.Security
{
    public partial class Settings : Entity
    {
        public Settings()
        {
            Id = GuidComb.GenerateComb();
        }
        public Guid Id { get; set; }
        public string WebSiteName { get; set; }
        public string WebSiteUrl { get; set; }
        public string PageTitle { get; set; }
        public string NotificationReplyEmail { get; set; }
        public string SMTP { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPPort { get; set; }
        public bool? SMTPEnableSSL { get; set; }
        public string Theme { get; set; }
        public string CurrentDatabaseVersion { get; set; }
        public bool? SuspendRegistration { get; set; }
        public string CustomHeaderCode { get; set; }
        public string CustomFooterCode { get; set; }
        public virtual Language DefaultLanguage { get; set; }
    }
}
