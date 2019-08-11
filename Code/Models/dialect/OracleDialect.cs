namespace Models.dialect
{
	using Oracle10gDialect = org.hibernate.dialect.Oracle10gDialect;

	public class OracleDialect : Oracle10gDialect
	{

		public OracleDialect() : base()
		{
		}

		protected internal override void registerLargeObjectTypeMappings()
		{
			base.registerLargeObjectTypeMappings();

			//registerColumnType(2005, "clob");
			registerColumnType(-1, "clob");
		}
	}

}