namespace Model.types
{

	using HibernateException = org.hibernate.HibernateException;
	using SessionImplementor = org.hibernate.engine.SessionImplementor;
	using StringType = org.hibernate.type.StringType;

	public class CostOSStringType : StringType
	{
		public CostOSStringType() : base()
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public String nullSafeGet(java.sql.ResultSet rs, String name) throws org.hibernate.HibernateException, java.sql.SQLException
		public override string nullSafeGet(ResultSet rs, string name)
		{
			return StringType.INSTANCE.nullSafeGet(rs, name);
		}



//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public void nullSafeSet(java.sql.PreparedStatement st, String value, int index) throws org.hibernate.HibernateException, java.sql.SQLException
		public override void nullSafeSet(PreparedStatement st, string value, int index)
		{
			if (string.ReferenceEquals(value, null))
			{
				st.setString(index, null);
			}
			else
			{
				st.setString(index, ((string)value).Length > 254? ((string)value).Substring(0, 254): (string)value);
			}
		}


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public void set(java.sql.PreparedStatement st, String value, int index) throws org.hibernate.HibernateException, java.sql.SQLException
		public override void set(PreparedStatement st, string value, int index)
		{
			if (!string.ReferenceEquals(value, null) && value.Length > 253)
			{
				value = value.Substring(0, 253);
				//System.out.println("\n\n\n\n\nYOU ARE SETTING1: "+value);
			}
			// TODO Auto-generated method stub
			//System.out.println("CostOSStringType.set2()");
			base.set(st, value, index);
		}


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public void set(java.sql.PreparedStatement st, String value, int index, org.hibernate.engine.SessionImplementor session) throws org.hibernate.HibernateException, java.sql.SQLException
		public override void set(PreparedStatement st, string value, int index, SessionImplementor session)
		{
			if (!string.ReferenceEquals(value, null) && value.Length > 253)
			{
				value = value.Substring(0, 253);
			}
			base.set(st, value, index, session);
		}

		public virtual string Name
		{
			get
			{
				return "costos_string";
			}
		}

		public override string[] RegistrationKeys
		{
			get
			{
				// lets use delegation and register ourselves under all of StringType's keys
				return new string[]{"costos_string"}; // StringUtils.concat(super.getRegistrationKeys(),new String[]{"costos_text"});
				//return Arrays.asList(super.getRegistrationKeys(),new String[]{"costos_text"}).toArray(new String[]{});
			}
		}
	}

	/*
	public class CostOSStringType extends NotNullStringType implements Serializable{
		public CostOSStringType() {
			super();
		}
		
		public String getName() {
			return "costos_string";
		}
	
		public Object nullSafeGet(ResultSet arg0, String[] arg1, Object arg2) throws HibernateException, SQLException {
			return StringType.INSTANCE.nullSafeGet(arg0, arg1[0]);
		}
	
		public void nullSafeSet(PreparedStatement st, Object value, int index) throws HibernateException, SQLException {
			// If this is an empty string, write _PENTAHOEMPTY_ into the database.
			//System.out.println("NotNullStringType.nullSafeSet()");
			if ( value == null )
				st.setString(index, null);
			else
				st.setString(index, ((String)value).length()>254? ((String)value).substring(0, 254): (String)value);
			//StringType.INSTANCE.nullSafeSet(arg0, (arg1 != null) ? ((((String) arg1).length() > 0) ? ((String)arg1).length()>254? ((String)arg1).substring(0, 254): arg1 : PENTAHOEMPTY) : arg1, arg2);
		}
	
	//	@Override
	//	public void set(PreparedStatement st, String value, int index)
	//			throws HibernateException, SQLException {
	//		if ( value != null && value.length() > 253 ) {
	//			value = value.substring(0, 253);
	//			System.out.println("\n\n\n\n\nYOU ARE SETTING1: "+value);
	//		}
	//		// TODO Auto-generated method stub
	//		System.out.println("CostOSStringType.set2()");
	//		super.set(st, value, index);
	//	}
	
	//	@Override
	//    public String[] getRegistrationKeys() {
	//        // lets use delegation and register ourselves under all of StringType's keys
	//        return new String[]{"costos_string"};//StringUtils.concat(super.getRegistrationKeys(),new String[]{"costos_string"});
	//    }
	}*/


}