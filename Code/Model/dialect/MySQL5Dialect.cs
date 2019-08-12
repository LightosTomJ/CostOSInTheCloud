namespace Model.dialect
{

	using MySQL5InnoDBDialect = org.hibernate.dialect.MySQL5InnoDBDialect;
	using TextType = org.hibernate.type.TextType;

	public class MySQL5Dialect : MySQL5InnoDBDialect
	{
		public MySQL5Dialect() : base() // register additional hibernate types for default use in scalar sqlquery type auto detection
		{
			// registerHibernateType(Types.LONGVARCHAR, Hibernate.TEXT.getName());
			registerHibernateType(Types.LONGVARCHAR, 65535, TextType.INSTANCE.Name);
			registerHibernateType(Types.NVARCHAR, 65535, "costos_text_utf8");
		}
	}

}