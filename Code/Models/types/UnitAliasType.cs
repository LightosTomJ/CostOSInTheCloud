using System;

namespace Models.types
{
    [Serializable]
	public class UnitAliasType
	{
		//public UnitAliasType(GroupCodesProvider provider, string key) : this(new ProjectPropertyTextType(provider), new string[] {key})
		//{ }

		//private UnitAliasType(ProjectPropertyTextType notNullTextType, string[] keys)
		//{ }

		//private class ProjectPropertyTextType : NotNullTextType
		//{
		//	internal GroupCodesProvider provider;

		//	internal ProjectPropertyTextType(GroupCodesProvider provider) : base()
		//	{
		//		this.provider = provider;
		//	}

		//	public override object nullSafeGet(ResultSet arg0, string[] arg1, object arg2)
		//	{
		//		string unit = (string)base.nullSafeGet(arg0, arg1, arg2);
		//		return provider.getUnitAlias(unit);
		//	}
		//}
	}
}