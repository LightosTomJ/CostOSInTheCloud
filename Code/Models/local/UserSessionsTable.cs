using System;

namespace Model.local
{
    [Serializable]
    public class UserSessionsTable
    {
        public static readonly string[] FIELDS = new string[] { "id", "userName", "loggeInDate" };
        public long? id;
        public string userName;
        public string serialKey;
        public DateTime loggeInDate;
        public DateTime lastUpdate;

        public UserSessionsTable()
        { }
    }
}