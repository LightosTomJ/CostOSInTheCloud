using System;

namespace Model.types
{



	using HibernateException = org.hibernate.HibernateException;
	using TextType = org.hibernate.type.TextType;
	using UserType = org.hibernate.usertype.UserType;
	using EqualsHelper = org.hibernate.util.EqualsHelper;

	public class EncryptedStringUserType : UserType
	{

		private const string KEY_ALGORITHM = "PBEWithMD5AndDES";

		private const string CIPHER_ALGORITHM = "PBEWithMD5AndDES/CBC/PKCS5Padding";

		private static readonly sbyte[] SALT = "a#$sd#J%".Bytes;

		private readonly PBEParameterSpec paramSpec = new PBEParameterSpec(SALT, 5);

		private static SecretKey masterKey;

		private static readonly int[] SQLTYPE = new int[] {TextType.INSTANCE.sqlType()};

		/*
		 * (non-Javadoc)
		 * 
		 * @see org.hibernate.usertype.UserType#sqlTypes()
		 */
		public int[] sqlTypes()
		{
			return new int[] {Types.LONGVARBINARY};
		}

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

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public final void nullSafeSet(java.sql.PreparedStatement st, Object value, int index) throws org.hibernate.HibernateException, java.sql.SQLException
		public void nullSafeSet(PreparedStatement st, object value, int index)
		{
			if (value == null)
			{
				st.setNull(index,Types.VARBINARY);
			}
			else
			{
				noNullSet(st, value, index);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void noNullSet(java.sql.PreparedStatement st, Object value, int index) throws java.sql.SQLException
		protected internal virtual void noNullSet(PreparedStatement st, object value, int index)
		{
			sbyte[] clearText = ((string)value).GetBytes();
			try
			{
				Cipher encryptCipher = Cipher.getInstance(CIPHER_ALGORITHM);
				encryptCipher.init(Cipher.ENCRYPT_MODE, masterKey, paramSpec);
				st.setBytes(index, encryptCipher.doFinal(clearText));

			}
			catch (GeneralSecurityException e)
			{
				Console.WriteLine("value came: " + value);
				throw new Exception("should never happen", e);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Object nullSafeGet(java.sql.ResultSet rs, String[] names, Object owner) throws org.hibernate.HibernateException, java.sql.SQLException
		public virtual object nullSafeGet(ResultSet rs, string[] names, object owner)
		{
			sbyte[] bytes = rs.getBytes(names[0]);
			try
			{
				Cipher decryptCipher = Cipher.getInstance(CIPHER_ALGORITHM);
				decryptCipher.init(Cipher.DECRYPT_MODE, masterKey, paramSpec);
				return new string(decryptCipher.doFinal(bytes));
			}
			catch (GeneralSecurityException)
			{
				throw new Exception("wrong pass");
			}
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

		public static char[] Key
		{
			set
			{
				try
				{
					SecretKeyFactory secretKeyFactory = SecretKeyFactory.getInstance(KEY_ALGORITHM);
					PBEKeySpec keySpec = new PBEKeySpec(value);
					masterKey = secretKeyFactory.generateSecret(keySpec);
				}
				catch (GeneralSecurityException e)
				{
					throw new Exception("should never happen", e);
				}
			}
		}
	}


}