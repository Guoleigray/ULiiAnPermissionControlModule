using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PermissionModule
{
    /// <summary>
    /// 权限检查
    /// </summary>
    public class PermissionCheckAttribute : FilterAttribute, IAuthorizationFilter
    {
        private readonly string _controller;
        private readonly string _action;

        public PermissionCheckAttribute(string controller, string action)
        {
            _controller = controller;
            _action = action;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var acl = filterContext.HttpContext.Session[SessionName.PermissionSessionName] as IEnumerable<IAcl>;
                
            var attNames = filterContext.ActionDescriptor.GetCustomAttributes(typeof(ResourceCustomerNameAttribute), true) as IEnumerable<ResourceCustomerNameAttribute>;

            var anonymous =filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true) as IEnumerable<AllowAnonymousAttribute>;

            if (anonymous != null && anonymous.Any())
            {
                return;
            }
            if (acl == null || !acl.Any())
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = _controller, action = _action }));
            }
            else
            {
                var joinResult = (from aclEntity in acl
                                  join attName in attNames on aclEntity.ResourceName equals attName.ResourceName
                                  select attName
                ).Any();

                if (joinResult)
                {
                    return;
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = _controller, action = _action }));
                }
            }
        }
    }
}
