﻿using System;
using System.Web.Mvc;
using Kuntur.Framework.Kernel.Interfaces.Services;

namespace Kuntur.Framework.Kernel.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DescriptionAttribute : Attribute
    {
        private readonly ILocalizationService _localizationService;
        public string Description { get; set; }

        public DescriptionAttribute(string desc)
        {
            if (_localizationService == null)
            {
                _localizationService = DependencyResolver.Current.GetService<ILocalizationService>();
            }

            Description = _localizationService.GetResourceString(desc.Trim());
        }
    }
}
