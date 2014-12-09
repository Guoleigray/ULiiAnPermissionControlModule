using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermissionModule
{
    /// <summary>
    /// 资源命名特性，用于资源的自定义命名
    /// <author>
    /// ULiiAn·喵
    /// </author>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class ResourceCustomerNameAttribute : Attribute
    {
        private readonly string _resourceName;

        public ResourceCustomerNameAttribute(string resourceName)
        {
            _resourceName = resourceName;
        }

        public string ResourceName
        {
            get { return _resourceName; }
        }
    }
}
