namespace Model.local
{
    public class ProjectPropertyTable
    {
        public long? prjPropId { get; set; }
        public string propKey { get; set; }
        public string propValue { get; set; }
        public ProjectUrlTable urlTable { get; set; }

        public ProjectPropertyTable()
        { }
    }
}