namespace Model.view
{

	using BigDecimalMath = nomitech.common.util.BigDecimalMath;

	public class ProjectEPSAppendProjectsView
	{

		private string treeId;
		private string treeParentId;
		private string treeType;
		private long? entityId;
		private string title;
		private string code;
		private string projectType;
		private string revision;
		private bool? defRev;
		private string userId;
		private decimal totalCost;
		private string url;
		private string currency;

		public ProjectEPSAppendProjectsView() : base()
		{
		}

		public ProjectEPSAppendProjectsView(string treeId, string treeParentId, string treeType, long? entityId, string title, string code, string projectType, string revision, bool? defRev, string userId, decimal totalCost, string url, string currency) : base()
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


		public virtual string ProjectType
		{
			get
			{
				return projectType;
			}
			set
			{
				this.projectType = value;
			}
		}


		public virtual string Revision
		{
			get
			{
				return revision;
			}
			set
			{
				this.revision = value;
			}
		}


		public virtual bool? DefRev
		{
			get
			{
				return defRev;
			}
			set
			{
				this.defRev = value;
			}
		}


		public virtual string UserId
		{
			get
			{
				return userId;
			}
			set
			{
				this.userId = value;
			}
		}


		public virtual decimal TotalCost
		{
			get
			{
				return totalCost;
			}
			set
			{
				this.totalCost = value;
			}
		}


		public virtual string Url
		{
			get
			{
				return url;
			}
			set
			{
				this.url = value;
			}
		}


		public virtual string Currency
		{
			get
			{
				return currency;
			}
			set
			{
				this.currency = value;
			}
		}


		public override int GetHashCode()
		{
			const int prime = 31;
			int result = 1;
			result = prime * result + ((string.ReferenceEquals(code, null)) ? 0 : code.GetHashCode());
			result = prime * result + ((defRev == null) ? 0 : defRev.GetHashCode());
			result = prime * result + ((entityId == null) ? 0 : entityId.GetHashCode());
			result = prime * result + ((string.ReferenceEquals(projectType, null)) ? 0 : projectType.GetHashCode());
			result = prime * result + ((string.ReferenceEquals(revision, null)) ? 0 : revision.GetHashCode());
			result = prime * result + ((string.ReferenceEquals(title, null)) ? 0 : title.GetHashCode());
			result = prime * result + ((totalCost == null) ? 0 : totalCost.GetHashCode());
			result = prime * result + ((string.ReferenceEquals(treeId, null)) ? 0 : treeId.GetHashCode());
			result = prime * result + ((string.ReferenceEquals(treeParentId, null)) ? 0 : treeParentId.GetHashCode());
			result = prime * result + ((string.ReferenceEquals(treeType, null)) ? 0 : treeType.GetHashCode());
			result = prime * result + ((string.ReferenceEquals(url, null)) ? 0 : url.GetHashCode());
			result = prime * result + ((string.ReferenceEquals(userId, null)) ? 0 : userId.GetHashCode());
			result = prime * result + ((string.ReferenceEquals(currency, null)) ? 0 : currency.GetHashCode());
			return result;
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}

			if (obj == null)
			{
				return false;
			}

			if (this.GetType() != obj.GetType())
			{
				return false;
			}

			ProjectEPSAppendProjectsView other = (ProjectEPSAppendProjectsView) obj;

			if (string.ReferenceEquals(code, null))
			{
				if (!string.ReferenceEquals(other.code, null))
				{
					return false;
				}
			}
			else if (!code.Equals(other.code))
			{
				return false;
			}

			if (defRev == null)
			{
				if (other.defRev != null)
				{
					return false;
				}
			}
			else if (!defRev.Equals(other.defRev))
			{
				return false;
			}

			if (entityId == null)
			{
				if (other.entityId != null)
				{
					return false;
				}
			}
			else if (!entityId.Equals(other.entityId))
			{
				return false;
			}

			if (string.ReferenceEquals(projectType, null))
			{
				if (!string.ReferenceEquals(other.projectType, null))
				{
					return false;
				}
			}
			else if (!projectType.Equals(other.projectType))
			{
				return false;
			}

			if (string.ReferenceEquals(revision, null))
			{
				if (!string.ReferenceEquals(other.revision, null))
				{
					return false;
				}
			}
			else if (!revision.Equals(other.revision))
			{
				return false;
			}

			if (string.ReferenceEquals(title, null))
			{
				if (!string.ReferenceEquals(other.title, null))
				{
					return false;
				}
			}
			else if (!title.Equals(other.title))
			{
				return false;
			}

			if (string.ReferenceEquals(treeId, null))
			{
				if (!string.ReferenceEquals(other.treeId, null))
				{
					return false;
				}
			}
			else if (!treeId.Equals(other.treeId))
			{
				return false;
			}

			if (string.ReferenceEquals(treeParentId, null))
			{
				if (!string.ReferenceEquals(other.treeParentId, null))
				{
					return false;
				}
			}
			else if (!treeParentId.Equals(other.treeParentId))
			{
				return false;
			}

			if (string.ReferenceEquals(treeType, null))
			{
				if (!string.ReferenceEquals(other.treeType, null))
				{
					return false;
				}
			}
			else if (!treeType.Equals(other.treeType))
			{
				return false;
			}

			if (string.ReferenceEquals(url, null))
			{
				if (!string.ReferenceEquals(other.url, null))
				{
					return false;
				}
			}
			else if (!url.Equals(other.url))
			{
				return false;
			}

			if (string.ReferenceEquals(userId, null))
			{
				if (!string.ReferenceEquals(other.userId, null))
				{
					return false;
				}
			}
			else if (!userId.Equals(other.userId))
			{
				return false;
			}

			if (string.ReferenceEquals(currency, null))
			{
				if (!string.ReferenceEquals(other.currency, null))
				{
					return false;
				}
			}
			else if (!currency.Equals(other.currency))
			{
				return false;
			}

			if (BigDecimalMath.cmpCheckNulls(totalCost, other.totalCost) != 0)
			{
				return false;
			}

			return true;
		}

	}

}