using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using Tools.OrchardCore.Services;

namespace Tools.OrchardCore
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IToolsService, ToolsService>();
        }
    }
}