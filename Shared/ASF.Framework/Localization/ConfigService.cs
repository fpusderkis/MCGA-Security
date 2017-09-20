using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Xml;
using Kuntur.Framework.Kernel.Interfaces.Services;
using Kuntur.Framework.Model.Enums;

namespace Kuntur.Framework.Services
{
    public partial class ConfigService : IConfigService
    {
        private readonly ICacheService _cacheService;
        public ConfigService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        

        #region Settings

        public Dictionary<string, string> GetKunturConfig()
        {
            const string key = "SiteConfig";
            var siteConfig = _cacheService.Get<Dictionary<string, string>>(key);
            if (siteConfig == null)
            {
                siteConfig = new Dictionary<string, string>();
                var root = SiteConfig.SiteConfig.Instance.GetSiteConfig();
                    var nodes = root?.SelectNodes("/kuntur/settings/setting");
                    if (nodes != null)
                    {
                        foreach (XmlNode node in nodes)
                        {
                            //<emoticon symbol="O:)" image="angel-emoticon.png" />  
                            if (node.Attributes != null)
                            {
                                var keyAttr = node.Attributes["key"];
                                var valueAttr = node.Attributes["value"];
                                if (keyAttr != null && valueAttr != null)
                                {
                                    siteConfig.Add(keyAttr.InnerText, valueAttr.InnerText);
                                }
                            }
                        }

                        _cacheService.Set(key, siteConfig, CacheTimes.OneDay);
                    }
             
            }
            return siteConfig;
        }

        #endregion

        #region Types

        public Dictionary<string, string> GetTypes()
        {
            const string key = "SiteTypes";
            var siteConfig = _cacheService.Get<Dictionary<string, string>>(key);
            if (siteConfig == null)
            {
                siteConfig = new Dictionary<string, string>();
                var root = SiteConfig.SiteConfig.Instance.GetSiteConfig();
                var nodes = root?.SelectNodes("/kuntur/types/type");
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        //<emoticon symbol="O:)" image="angel-emoticon.png" />  
                        if (node.Attributes != null)
                        {
                            var keyAttr = node.Attributes["name"];
                            var valueAttr = node.Attributes["value"];
                            if (keyAttr != null && valueAttr != null)
                            {
                                siteConfig.Add(keyAttr.InnerText, valueAttr.InnerText);
                            }
                        }
                    }

                    _cacheService.Set(key, siteConfig, CacheTimes.OneDay);
                }

            }
            return siteConfig;
        }

        #endregion

    }
}
