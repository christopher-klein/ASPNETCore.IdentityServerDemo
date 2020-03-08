using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.IdentityServerDemo.API.Models
{
    public class SimpleClaim
    {
        public string Type { get; set; } = "";
        public string Value { get; set; } = "";
    }
}
