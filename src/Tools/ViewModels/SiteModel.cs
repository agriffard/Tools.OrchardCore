using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;

namespace Tools.OrchardCore.ViewModels
{
    public class SiteModel
    {
        public RouteValueDictionary HomeRoute { get; set; }
    }
}
