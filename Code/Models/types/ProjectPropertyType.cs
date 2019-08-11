using System;

namespace Models.types
{

	using ProjectGroupCodesProvider = nomitech.common.@base.ProjectGroupCodesProvider;

	using HibernateException = org.hibernate.HibernateException;
	using CustomType = org.hibernate.type.CustomType;

	public class ProjectPropertyType : CustomType
	{

		public ProjectPropertyType(ProjectGroupCodesProvider provider, string key, string propKey) : this(new ProjectPropertyTextType(provider,propKey), new string[] {key})
		{
		}

		private ProjectPropertyType(ProjectPropertyTextType notNullTextType, string[] keys) : base(notNullTextType, keys)
		{
		}

		[Serializable]
		private class ProjectPropertyTextType : NotNullTextType
		{
			internal ProjectGroupCodesProvider provider;
			internal string propKey;

			internal ProjectPropertyTextType(ProjectGroupCodesProvider provider, string propKey) : base()
			{
				this.provider = provider;
				this.propKey = propKey;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public Object nullSafeGet(java.sql.ResultSet arg0, String[] arg1, Object arg2) throws org.hibernate.HibernateException, java.sql.SQLException
			public override object nullSafeGet(ResultSet arg0, string[] arg1, object arg2)
			{
				return provider.getProjectProperty(propKey);
			}
		}
	}
}