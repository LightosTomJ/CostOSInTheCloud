using System.Collections.Generic;

namespace Desktop.common.nomitech.common.countries
{

    public class CountryMapUtil
    {
        private static readonly IList<string> europeanCountries = new List<string> { "AL", "AD", "AT", "BY", "BE", "BA", "BG", "HR", "CY", "CZ", "DK", "EE", "FO", "FI", "FR", "DE", "GI", "GR", "HU", "IS", "IE", "IT", "LV", "LI", "LT", "LU", "MK", "MT", "MD", "MC", "NL", "NO", "PL", "PT", "RO", "RU", "SM", "RS", "SK", "SI", "ES", "SE", "CH", "UA", "GB", "VA", "RS", "IM", "RS", "ME" };

        public static bool allCountriesEuropean(IList<string> paramList)
        {
            foreach (string str in paramList)
            {
                if (!europeanCountries.Contains(str))
                {
                    return false;
                }
            }
            return true;
        }
    }

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\countries\CountryMapUtil.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}