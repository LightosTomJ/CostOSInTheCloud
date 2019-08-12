using System;

namespace Model.local
{
    [Serializable]
    public class ADTable
    {
        public static readonly string[] FIELDS = new string[] { "id", "profile", "type", "hostname", "baseDn", "rolesDn", "port", "isSSL", "bindDn", "password", "enable", "syncTime" };

        public long? id { get; set; }
        public string type { get; set; }
        public string statusMsg { get; set; }
        public string profile { get; set; }
        public string hostname { get; set; }
        public int? port { get; set; }
        public bool? isSSL { get; set; }
        public string bindDn { get; set; }
        public string searchFilter { get; set; }
        public string password { get; set; }
        public string baseDN { get; set; }
        public bool? enable { get; set; }
        public decimal syncTime { get; set; }

        public ADTable()
        { }
    }
}