using System;

namespace Model.types
{

	using HibernateException = org.hibernate.HibernateException;
	using StringType = org.hibernate.type.StringType;
	using UserType = org.hibernate.usertype.UserType;
	using EqualsHelper = org.hibernate.util.EqualsHelper;

	public class CostOSString256Type : UserType
	{

		public CostOSString256Type() : base()
		{
		}

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
			return (string) StringType.INSTANCE.nullSafeGet(arg0, arg1[0]);
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
			if (value != null && ((string)value).Length > 254)
			{
				value = ((string)value).Substring(0, 254);
			}

			st.setString(index, (string)value);
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