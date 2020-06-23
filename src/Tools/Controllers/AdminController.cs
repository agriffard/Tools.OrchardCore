using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Routing;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Routing;
using OrchardCore.Settings;
using Tools.OrchardCore.Services;
using Tools.OrchardCore.ViewModels;

namespace Tools.OrchardCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISiteService _siteService;
        private readonly INotifier _notifier;
        private readonly IHtmlLocalizer H;
        private readonly IToolsService _toolsService;

        public AdminController(ISiteService siteService, INotifier notifier, IHtmlLocalizer<AdminController> h, IToolsService toolsService)
        {
            _siteService = siteService;
            _notifier = notifier;
            _toolsService = toolsService;

            H = h;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var site = await _siteService.GetSiteSettingsAsync();
            var homeRoute = await _toolsService.GetHomeRoute();
            var model = new SiteModel() { HomeRoute = homeRoute };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SiteModel model)
        {
            //await _siteService.UpdateSiteSettingsAsync(model);
            await _toolsService.SetHomeRoute(model.HomeRoute);

            _notifier.Success(H["Site settings updated successfully."]);

            return View(model);
        }
    }
}
