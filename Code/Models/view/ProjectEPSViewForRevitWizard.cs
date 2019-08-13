namespace Models.view
{
    public class ProjectEPSViewForRevitWizard
    {
        public string treeId { get; set; }
        public string treeNodeTitle { get; set; }
        public string treeParentId { get; set; }
        public string treeType { get; set; }
        public string treeLevel { get; set; }
        public long? entityId { get; set; }
        public string title { get; set; }
        public string code { get; set; }
        public string client { get; set; }

        public ProjectEPSViewForRevitWizard()
        { }

        public ProjectEPSViewForRevitWizard(string treeId, string treeNodeTitle, string treeParentId, string treeType, string treeLevel, long? entityId, string title, string code, string client) : base()
        {
            this.treeId = treeId;
            this.treeNodeTitle = treeNodeTitle;
            this.treeParentId = treeParentId;
            this.treeType = treeType;
            this.treeLevel = treeLevel;
            this.entityId = entityId;
            this.title = title;
            this.code = code;
            this.client = client;
        }
    }
}