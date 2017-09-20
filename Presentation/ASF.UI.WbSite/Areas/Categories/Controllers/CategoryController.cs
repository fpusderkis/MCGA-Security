﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using Kuntur.Framework.Kernel.Interfaces.Services;
using Kuntur.Framework.Kernel.Interfaces.Services.UnitOfWork;

namespace ASF.UI.WbSite.Areas.Categories.Controllers
{
    public class CategoryController : Controller
    {
        
        public CategoryController(IUnitOfWorkManager unitOfWorkManager,
            ILocalizationService localizationService,
            ISettingsService settingsService)
            
        {
            
        }
        // GET: Categories/Category
        public ActionResult Index()
        {
            var cpf = new CategoryProcess();
            var data = cpf.Find(2);

            var cp = new CategoryProcess();
            var lista = cp.SelectList();
            return View(lista);
        }
    }
}