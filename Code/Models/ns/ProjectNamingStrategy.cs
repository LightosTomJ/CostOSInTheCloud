namespace Models.ns
{
	using DefaultNamingStrategy = org.hibernate.cfg.DefaultNamingStrategy;

	public class ProjectNamingStrategy : DefaultNamingStrategy
	{

		private string prefix;
	//	private ProjectServerDBUtil projectServerDBUtil;

		public ProjectNamingStrategy(string prefix)
		{
			this.prefix = prefix;
		}

	//	public ProjectNamingStrategy(ProjectServerDBUtil projectServerDBUtil) {
	//		this.projectServerDBUtil = projectServerDBUtil;
	//	}

		public override string tableName(string tableName)
		{
			return prefix + "_" + base.tableName(tableName);
		}
	}

}