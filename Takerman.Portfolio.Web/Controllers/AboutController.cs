﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Takerman.Portfolio.Web.Models;
using Takerman.Portfolio.Web.Resources;
using Takerman.Portfolio.Web.Models.Services;

namespace Takerman.Portfolio.Web.Controllers
{
    public class AboutController : BaseController
    {
        public AboutController(ILogger<AboutController> logger, 
            NavLinksService navLinksService,
            IStringLocalizer<AboutController> localizer,
            IHtmlLocalizer<SharedResource> sharedLocalizer,
            IStringLocalizerFactory factory) : base(logger, navLinksService, localizer, sharedLocalizer, factory)
        {
        }

        public IActionResult Index()
        {
            Layout.Head.Title = "About | " + Layout.Head.Title + " | Software Company";
            Layout.Banner.Title = "About";
            Layout.Banner.NavLinks = new List<NavLink>()
            {
                new NavLink(){ Action = "Index", Controller = "Home", Label = "Home" },
                new NavLink(){ Action = "Index", Controller = "About", Label = "About" },
            };
            return View();
        }
    }
}