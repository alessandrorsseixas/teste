using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMercado.View.Api.Settings.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpireTime { get; set; }
        public string Issuer { get; set; }
        public string ValidateTime { get; set; }

        public bool Mock { get; set; }
    }
}
