using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Utils
{
    public class CurrencySymbolAttribute : ValidationAttribute
    {

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=netcore-2.2
        /// https://docs.microsoft.com/en-us/dotnet/api/system.globalization.regioninfo.isocurrencysymbol?view=netcore-2.2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                if(ri.ISOCurrencySymbol.Equals(value))
                {
                    return true;
                }
            }

            return false;

        }
    }
}
