using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PermissionModule;

namespace Sample.Models
{
    public class PermissionModel:IAcl
    {
        public string ResourceName { get; set; }
    }
}