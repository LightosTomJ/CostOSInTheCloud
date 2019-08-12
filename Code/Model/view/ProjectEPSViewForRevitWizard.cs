namespace Model.view
{
	public class ProjectEPSViewForRevitWizard
	{

		private string treeId;
		private string treeNodeTitle;
		private string treeParentId;
		private string treeType;
		private string treeLevel;
		private long? entityId;
		private string title;
		private string code;
		private string client;

		public ProjectEPSViewForRevitWizard()
		{
		}

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

		public virtual string TreeId
		{
			get
			{
				return treeId;
			}
			set
			{
				this.treeId = value;
			}
		}

		public virtual string TreeNodeTitle
		{
			get
			{
				return treeNodeTitle;
			}
			set
			{
				this.treeNodeTitle = value;
			}
		}

		public virtual string TreeParentId
		{
			get
			{
				return treeParentId;
			}
			set
			{
				this.treeParentId = value;
			}
		}

		public virtual string TreeType
		{
			get
			{
				return treeType;
			}
			set
			{
				this.treeType = value;
			}
		}

		public virtual string TreeLevel
		{
			get
			{
				return treeLevel;
			}
			set
			{
				this.treeLevel = value;
			}
		}

		public virtual long? EntityId
		{
			get
			{
				return entityId;
			}
			set
			{
				this.entityId = value;
			}
		}

		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
			}
		}

		public virtual string Code
		{
			get
			{
				return code;
			}
			set
			{
				this.code = value;
			}
		}

		public virtual string Client
		{
			get
			{
				return client;
			}
			set
			{
				this.client = value;
			}
		}










	}

}