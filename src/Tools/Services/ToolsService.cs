using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Settings;

namespace Tools.OrchardCore.Services
{
    public class ToolsService : IToolsService
    {
        private readonly ISiteService _siteService;

        public ToolsService(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<RouteValueDictionary> GetHomeRoute()
        {
            var site = await _siteService.GetSiteSettingsAsync();
            //var jsonHomeRoute = JToken.FromObject(site.HomeRoute);

            return site.HomeRoute; //jsonHomeRoute.ToString();
        }

        public async Task SetHomeRoute(RouteValueDictionary homeRoute)
        {
            var site = await _siteService.LoadSiteSettingsAsync();
            //var jsonHomeRoute = JToken.FromObject(homeRoute);
            site.HomeRoute = homeRoute; //jsonHomeRoute.ToObject<RouteValueDictionary>();

            // Find content and update SetHomepage ?

            await _siteService.UpdateSiteSettingsAsync(site);
        }
    }
}
