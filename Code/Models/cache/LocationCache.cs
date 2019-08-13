using System;

namespace Models.cache
{
    [Serializable]
    public class LocationCache
    {
        public long? id { get; set; }
        public static long? idCounter = 0L;
        public const string TABLE_NAME = "Location";

        public LocationCache()
        { }
    }
}