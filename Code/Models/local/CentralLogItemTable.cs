namespace Model.local
{
    public class CentralLogItemTable
    {
        public long? id { get; set; }
        public long? logId { get; set; }        // CentralLogTable Id
        public string logFilter { get; set; }
        public sbyte? operation { get; set; }
        public long? itemId { get; set; }
        public string item { get; set; }
        public long? projectId { get; set; }    // is in project

        public CentralLogItemTable()
        { }
    }
}