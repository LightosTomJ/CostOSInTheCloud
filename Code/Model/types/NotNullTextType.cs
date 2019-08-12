using System;

namespace Model.types
{

	using HibernateException = org.hibernate.HibernateException;
	using LobCreator = org.hibernate.engine.jdbc.LobCreator;
	using NonContextualLobCreator = org.hibernate.engine.jdbc.NonContextualLobCreator;
	using TextType = org.hibernate.type.TextType;
	using WrapperOptions = org.hibernate.type.descriptor.WrapperOptions;
	using UserType = org.hibernate.usertype.UserType;
	using EqualsHelper = org.hibernate.util.EqualsHelper;

	[Serializable]
	public class NotNullTextType : UserType
	{

		public const string PENTAHOEMPTY = "{=}"; //$NON-NLS-1$

		private static readonly int[] TEXTTYPE = new int[] {TextType.INSTANCE.sqlType()};

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#sqlTypes()
		 */
		public virtual int[] sqlTypes()
		{
			return TEXTTYPE;
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#returnedClass()
		 */
		public virtual Type returnedClass()
		{
			return typeof(string);
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#equals(java.lang.Object,
		 *      java.lang.Object)
		 */
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean equals(Object arg0, Object arg1) throws org.hibernate.HibernateException
		public virtual bool Equals(object arg0, object arg1)
		{
			return EqualsHelper.Equals(arg0, arg1);
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#hashCode(java.lang.Object)
		 */
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int hashCode(Object arg0) throws org.hibernate.HibernateException
		public virtual int GetHashCode(object arg0)
		{
			return arg0.GetHashCode();
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#nullSafeGet(java.sql.ResultSet,
		 *      java.lang.String[], java.lang.Object)
		 */
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Object nullSafeGet(java.sql.ResultSet arg0, String[] arg1, Object arg2) throws org.hibernate.HibernateException, java.sql.SQLException
		public virtual object nullSafeGet(ResultSet arg0, string[] arg1, object arg2)
		{
			string colValue = (string) TextType.INSTANCE.nullSafeGet(arg0, arg1[0]);
			// _PENTAHOEMPTY_ shouldn't appear in the wild. So, check the string in
			// the DB for this flag,
			// and if it's there, then this must be an empty string.
			return ((!string.ReferenceEquals(colValue, null)) ? (colValue.Equals(PENTAHOEMPTY) ? "" : colValue) : null); //$NON-NLS-1$
		}

		private static WrapperOptions NO_OPTIONS = new WrapperOptionsAnonymousInnerClass();

		private class WrapperOptionsAnonymousInnerClass : WrapperOptions
		{
			public bool useStreamForLobBinding()
			{
			  return false;
			}

			public LobCreator LobCreator
			{
				get
				{
				  return NonContextualLobCreator.INSTANCE;
				}
			}
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#nullSafeSet(java.sql.PreparedStatement,
		 *      java.lang.Object, int)
		 */
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void nullSafeSet(java.sql.PreparedStatement st, Object value, int index) throws org.hibernate.HibernateException, java.sql.SQLException
		public virtual void nullSafeSet(PreparedStatement st, object value, int index)
		{
			// If this is an empty string, write _PENTAHOEMPTY_ into the database.
			st.setString(index, (value != null) ? ((((string) value).Length > 0) ? value.ToString() : PENTAHOEMPTY) : (string)value);
			//TextType.INSTANCE.nullSafeSet(st, (value != null) ? ((((String) value).length() > 0) ? value : PENTAHOEMPTY) : value, index);
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#deepCopy(java.lang.Object)
		 */
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Object deepCopy(Object arg0) throws org.hibernate.HibernateException
		public virtual object deepCopy(object arg0)
		{
			return arg0;
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#isMutable()
		 */
		public virtual bool Mutable
		{
			get
			{
				return false;
			}
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#disassemble(java.lang.Object)
		 */
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.io.Serializable disassemble(Object arg0) throws org.hibernate.HibernateException
		public virtual Serializable disassemble(object arg0)
		{
			return (Serializable) arg0;
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#assemble(java.io.Serializable,
		 *      java.lang.Object)
		 */
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Object assemble(java.io.Serializable arg0, Object arg1) throws org.hibernate.HibernateException
		public virtual object assemble(Serializable arg0, object arg1)
		{
			return arg0;
		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#replace(java.lang.Object,
		 *      java.lang.Object, java.lang.Object)
		 */
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Object replace(Object arg0, Object arg1, Object arg2) throws org.hibernate.HibernateException
		public virtual object replace(object arg0, object arg1, object arg2)
		{
			return arg0;
		}

		/*
		public NotNullTextType() {
			super();
		}
		@Override
		public Object get(ResultSet rs, String name) throws SQLException {
			Object res = super.get(rs, name);
			if ( res == null )
				return "";
			return res;
		}
		
		public int[] sqlTypes() {		
			return new int[] { TextType.INSTANCE.sqlType() };
		}
	
		public Class returnedClass() {
			return String.class;
		}
		
		public Object nullSafeGet(ResultSet resultSet, String[] names, Object owner) throws HibernateException, SQLException {         
			String value = (String) TextType.INSTANCE.nullSafeGet(resultSet, names[0]);         
			return ((value != null) ? value : "");     
		}       
		
	//	public void nullSafeSet(PreparedStatement preparedStatement, Object value, int index) throws HibernateException, SQLException {         
	//		TextType.INSTANCE.nullSafeSet(preparedStatement, (value != null) ? value.toString() : null, index);     
	//	
	//	} 
	//	public Object nullSafeGet(ResultSet resultSet,  String[] names, Object owner) throws HibernateException, SQLException {
	//		String result = resultSet.getString(names[0]);
	//		return result == null || result.trim().length() == 0 
	//		? null : result;
	//	}
	//
	//	public void nullSafeSet(PreparedStatement statement, 
	//			Object value, int index) 
	//	throws HibernateException, SQLException {
	//		statement.setString(index, value == null ? " " :(String) value);
	//	}
	
	//	@Override    
	//	public boolean isMutable() {        
	//		return false;     
	//	}       
		
		@Override
		public boolean equals(Object x, Object y) throws HibernateException {
			if (x == y) {
				return true;
			} else if (x == null) {
				return false;
			} else {
				return x.equals(y);
			}
		}       
	
		@Override  
		public int hashCode(Object x) throws HibernateException {      
			assert (x != null);      
			return x.hashCode();   
		}     
	
		@Override   
		public Object deepCopy(Object value) throws HibernateException {     
			return value;  
		}     
	
		@Override   
		public Object replace(Object original, Object target, Object owner) throws HibernateException {    
			return original;   
		}    
	
		@Override    
		public Serializable disassemble(Object value) throws HibernateException {   
			return (Serializable) value;     
		}       
	
		@Override   
		public Object assemble(Serializable cached, Object owner) throws HibernateException {  
			return cached; 
		} */
	}


}