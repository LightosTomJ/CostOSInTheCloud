using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.local
{
    public interface ICountry
    {
        long? id { get; set; }
        string countryCode { get; set; }
        string countryName { get; set; }
    }
}
