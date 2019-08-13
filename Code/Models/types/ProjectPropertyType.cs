using System;

namespace Models.types
{
	public class ProjectPropertyType
	{
		//public ProjectPropertyType(ProjectGroupCodesProvider provider, string key, string propKey) : this(new ProjectPropertyTextType(provider,propKey), new string[] {key})
		//{ }

		//private ProjectPropertyType(ProjectPropertyTextType notNullTextType, string[] keys) : base(notNullTextType, keys)
		//{ }

		//[Serializable]
		//private class ProjectPropertyTextType : NotNullTextType
		//{
		//	internal ProjectGroupCodesProvider provider;
		//	internal string propKey;

		//	internal ProjectPropertyTextType(ProjectGroupCodesProvider provider, string propKey) : base()
		//	{
		//		this.provider = provider;
		//		this.propKey = propKey;
		//	}

		//	public override object nullSafeGet(ResultSet arg0, string[] arg1, object arg2)
		//	{
		//		return provider.getProjectProperty(propKey);
		//	}
		//}
	}
}