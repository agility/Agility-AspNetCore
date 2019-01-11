using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website;
using Website.AgilityModels;
using Agility.Web.Extensions;

namespace Website.ViewComponents.Modules
{
    public class Callout: ViewComponent
    {

        public Task<IViewComponentResult> InvokeAsync(Module_Callout module) 
        {
            return Task.Run<IViewComponentResult>(() =>
            {
                return View("~/Views/Modules/Callout.cshtml", module);
            });
        }

    }

}