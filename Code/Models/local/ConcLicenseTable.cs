using System;

namespace Model.local
{
    [Serializable]
    public class ConcLicenseTable
    {
        public long? id { get; set; }
        public string hashKey { get; set; }

        public ConcLicenseTable()
        { }
    }
}