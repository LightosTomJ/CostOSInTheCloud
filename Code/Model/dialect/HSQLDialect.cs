namespace Model.dialect
{

	using TextType = org.hibernate.type.TextType;

	public class HSQLDialect : org.hibernate.dialect.HSQLDialect
	{
		public HSQLDialect() : base()
		{

			registerHibernateType(Types.LONGVARCHAR, 65535, TextType.INSTANCE.Name);
			registerHibernateType(Types.LONGNVARCHAR, "costos_text_utf8");
			registerHibernateType(Types.LONGNVARCHAR, "nvarchar(max)");
			registerColumnType(Types.CLOB, "longvarchar");
		}
	}

}