using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.bueno.crm.infraestructure.Data
{

    public class TokenSettingOptions
    {
        public string Key { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public double DurationHours { get; init; }
    }
}
