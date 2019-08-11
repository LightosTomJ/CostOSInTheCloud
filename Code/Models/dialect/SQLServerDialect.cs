namespace Models.dialect
{

	using SQLServer2008Dialect = org.hibernate.dialect.SQLServer2008Dialect;
	using StandardBasicTypes = org.hibernate.type.StandardBasicTypes;

	public class SQLServerDialect : SQLServer2008Dialect
	{
		public SQLServerDialect() : base() // register additional hibernate types for default use in scalar
		{
								// sqlquery type auto detection
			// registerHibernateType(Types.LONGVARCHAR, Hibernate.TEXT.getName());
			registerColumnType(Types.CHAR, "nchar(1)");
			registerColumnType(Types.LONGVARCHAR, "nvarchar(max)");
			registerColumnType(Types.VARCHAR, 4000, "nvarchar($l)");
			registerColumnType(Types.VARCHAR, "nvarchar(max)");
			registerColumnType(Types.CLOB, "nvarchar(max)");
			registerColumnType(Types.NCHAR, "nchar(1)");
			registerColumnType(Types.LONGNVARCHAR, "nvarchar(max)");
			registerColumnType(Types.NVARCHAR, 255000, "nvarchar($l)");
			registerColumnType(Types.NVARCHAR, "nvarchar(255)");
			registerColumnType(Types.NCLOB, "nvarchar(max)");
			registerHibernateType(Types.NCHAR, StandardBasicTypes.CHARACTER.Name);
			registerHibernateType(Types.LONGNVARCHAR, StandardBasicTypes.TEXT.Name);
			registerHibernateType(Types.NVARCHAR, StandardBasicTypes.STRING.Name);
			registerHibernateType(Types.LONGNVARCHAR, "costos_text");
			registerHibernateType(Types.NVARCHAR, "costos_string");
			registerHibernateType(Types.NCLOB, StandardBasicTypes.CLOB.Name);
		}
	}

}