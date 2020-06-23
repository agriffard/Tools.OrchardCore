using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using OrchardCore.Environment.Extensions;

namespace Tools.OrchardCore.Services
{
    public interface IToolsService
    {
        Task<RouteValueDictionary> GetHomeRoute();
        Task SetHomeRoute(RouteValueDictionary homeRoute);
    }
}
