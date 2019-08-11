using System;

namespace Models.types
{

	using CryptUtil = nomitech.common.util.CryptUtil;

	using HibernateException = org.hibernate.HibernateException;
	using StringType = org.hibernate.type.StringType;
	using UserType = org.hibernate.usertype.UserType;
	using EqualsHelper = org.hibernate.util.EqualsHelper;

	public class NotNullPasswordType : UserType
	{

		public NotNullPasswordType() : base()
		{
		}

		//	@Override
		//	public Object fromStringValue(String xml) {
		//		if ( xml == null )
		//			return "";
		//		// TODO Auto-generated method stub
		//		return super.fromStringValue(xml);
		//	}
		//
		//	@Override
		//	public Object get(ResultSet rs, String name) throws SQLException {
		//		
		//		Object res = super.get(rs, name);
		//		System.out.println("NotNullStringType.get() = "+res);
		//		if ( res == null )
		//			return "k";
		//		return res;
		//	}
		//
		//	@Override
		//	public void set(PreparedStatement st, Object value, int index) throws SQLException {
		//		if ( value == null )
		//			value = "";
		//		super.set(st, value, index);
		//	}

		public const string PENTAHOEMPTY = "{#}"; //$NON-NLS-1$

		private static readonly int[] SQLTYPE = new int[] {StringType.INSTANCE.sqlType()};

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#sqlTypes()
		 */
		public virtual int[] sqlTypes()
		{
			return SQLTYPE;
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
			//System.out.println("NotNullStringType.nullSafeGet()");
			string colValue = (string) StringType.INSTANCE.nullSafeGet(arg0, arg1[0]);
			// _PENTAHOEMPTY_ shouldn't appear in the wild. So, check the string in
			// the DB for this flag,
			// and if it's there, then this must be an empty string.
			return ((!string.ReferenceEquals(colValue, null)) ? (colValue.Equals(PENTAHOEMPTY) ? "" : CryptUtil.Instance.decryptHexString(colValue)) : null); //$NON-NLS-1$
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
			//System.out.println("NotNullStringType.nullSafeSet()");
			st.setString(index, (value != null) ? ((((string) value).Length > 0) ? CryptUtil.Instance.encryptHexString(value.ToString()) : PENTAHOEMPTY) : (string)value);
			//StringType.INSTANCE.nullSafeSet(arg0, (arg1 != null) ? ((((String) arg1).length() > 0) ? CryptUtil.getInstance().encryptHexString(arg1.toString()) : PENTAHOEMPTY) : arg1, arg2);
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
	}


}