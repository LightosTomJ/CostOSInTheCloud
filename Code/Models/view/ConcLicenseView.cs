namespace Models.view
{

	public class ConcLicenseView
	{

		private long? id;
		private string computerId;
		private string userId;
		private string lastLoginDate;
		private string plugins;
		private string email;
		private string fullName;

		public virtual long? Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}
		public virtual string ComputerId
		{
			get
			{
				return computerId;
			}
			set
			{
				this.computerId = value;
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
		public virtual string LastLoginDate
		{
			get
			{
				return lastLoginDate;
			}
			set
			{
				this.lastLoginDate = value;
			}
		}
		public virtual string Plugins
		{
			get
			{
				return plugins;
			}
			set
			{
				this.plugins = value;
			}
		}
		public virtual string Email
		{
			get
			{
				return email;
			}
			set
			{
				this.email = value;
			}
		}
		public virtual string FullName
		{
			get
			{
				return fullName;
			}
			set
			{
				this.fullName = value;
			}
		}
	}

}