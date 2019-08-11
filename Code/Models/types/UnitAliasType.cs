using System;

namespace Models.types
{

	using GroupCodesProvider = nomitech.common.@base.GroupCodesProvider;

	using HibernateException = org.hibernate.HibernateException;
	using CustomType = org.hibernate.type.CustomType;

	public class UnitAliasType : CustomType
	{

		public UnitAliasType(GroupCodesProvider provider, string key) : this(new ProjectPropertyTextType(provider), new string[] {key})
		{
		}

		private UnitAliasType(ProjectPropertyTextType notNullTextType, string[] keys) : base(notNullTextType, keys)
		{
		}

		[Serializable]
		private class ProjectPropertyTextType : NotNullTextType
		{
			internal GroupCodesProvider provider;

			internal ProjectPropertyTextType(GroupCodesProvider provider) : base()
			{
				this.provider = provider;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public Object nullSafeGet(java.sql.ResultSet arg0, String[] arg1, Object arg2) throws org.hibernate.HibernateException, java.sql.SQLException
			public override object nullSafeGet(ResultSet arg0, string[] arg1, object arg2)
			{
				string unit = (string)base.nullSafeGet(arg0, arg1, arg2);
				return provider.getUnitAlias(unit);
			}
		}
	}
}