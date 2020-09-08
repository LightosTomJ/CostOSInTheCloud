using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Shared
{
    public static class DataSource
    {
        public static short Current { get; set; } = 1;
        public static List<DataSourceType> Sources = new List<DataSourceType>
        { 
            new DataSourceType 
            { 
                Id = 1, 
                Name = "Local" 
            },
            new DataSourceType
            {
                Id = 2,
                Name = "Cloud"
            }
         };
    }

    public class DataSourceType
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}