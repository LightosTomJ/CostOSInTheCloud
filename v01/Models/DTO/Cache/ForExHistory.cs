using Models.DB.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO.Cache
{
    public class ForExHistory
    {
        public Country country { get; set; }
        public List<Currency> currencies { get; set; }
        public List<List<ExchangeRate>> rates { get; set; }

        public ForExHistory()
        { }
    }
}
