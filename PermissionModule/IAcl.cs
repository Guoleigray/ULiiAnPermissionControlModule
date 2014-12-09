using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermissionModule
{
    public interface IAcl
    {
        string ResourceName { get; set; }
    }
}
