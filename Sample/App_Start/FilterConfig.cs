using System.Web;
using System.Web.Mvc;
using PermissionModule;

namespace Sample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PermissionCheckAttribute("Home", "NoPermission"));
        }
    }
}