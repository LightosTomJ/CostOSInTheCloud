namespace Models.view
{
    public class ProjectEPSAppendProjectsView
    {
        public string treeId {get; set;}
        public string treeParentId {get; set;}
        public string treeType {get; set;}
        public long? entityId {get; set;}
        public string title {get; set;}
        public string code {get; set;}
        public string projectType {get; set;}
        public string revision {get; set;}
        public bool? defRev {get; set;}
        public string userId {get; set;}
        public decimal totalCost {get; set;}
        public string url {get; set;}
        public string currency {get; set;}

        public ProjectEPSAppendProjectsView()
        { }

        public ProjectEPSAppendProjectsView(string treeId, string treeParentId, string treeType, long? entityId, string title, string code, string projectType, string revision, bool? defRev, string userId, decimal totalCost, string url, string currency)
        {
            this.treeId = treeId;
            this.treeParentId = treeParentId;
            this.treeType = treeType;
            this.entityId = entityId;
            this.title = title;
            this.code = code;
            this.projectType = projectType;
            this.revision = revision;
            this.defRev = defRev;
            this.userId = userId;
            this.totalCost = totalCost;
            this.url = url;
            this.currency = currency;
        }
    }
}