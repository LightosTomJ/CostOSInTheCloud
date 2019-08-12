using System;

namespace Model.types
{

	using GroupCode = nomitech.common.@base.GroupCode;
	using GroupCodesProvider = nomitech.common.@base.GroupCodesProvider;
	using ItemCode = nomitech.common.@base.ItemCode;
	using GroupCodeExtractor = nomitech.common.util.GroupCodeExtractor;
	using StringUtils = nomitech.common.util.StringUtils;

	using HibernateException = org.hibernate.HibernateException;
	using CustomType = org.hibernate.type.CustomType;

	public class GroupCodeType : CustomType
	{

		public const short GROUP_CODE_TITLE = 0;
		public const short GROUP_CODE_DESCRIPTION = 1;
		public const short GROUP_CODE_CODE = 2;
		public const short GROUP_CODE_NOTES = 3;
		public const short GROUP_CODE_UNIT = 4;
		public const short GROUP_CODE_ITEM_CODE = 5;
		public const short GROUP_CODE_QUANTITY = 6;

		public GroupCodeType(GroupCodesProvider provider, short codeType, int level, string key, short groupCodeField) : this(new GroupCodeTextType(provider,codeType,level,groupCodeField), new string[] {key})
		{
		}

		private GroupCodeType(GroupCodeTextType notNullTextType, string[] keys) : base(notNullTextType, keys)
		{
		}

		[Serializable]
		private class GroupCodeTextType : NotNullTextType
		{
			internal int level;
			internal GroupCodesProvider provider;
			internal short codeType;
			internal short groupCodeField;

			internal GroupCodeTextType(GroupCodesProvider provider, short codeType, int level, short groupCodeField) : base()
			{
				this.provider = provider;
				this.level = level;
				this.codeType = codeType;
				this.groupCodeField = groupCodeField;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public Object nullSafeGet(java.sql.ResultSet arg0, String[] arg1, Object arg2) throws org.hibernate.HibernateException, java.sql.SQLException
			public override object nullSafeGet(ResultSet arg0, string[] arg1, object arg2)
			{
				object rowCode = base.nullSafeGet(arg0, arg1, arg2);
				if (rowCode == null || provider == null)
				{
					return "";
				}
				string groupCodeStr = rowCode.ToString();
				int index = groupCodeStr.IndexOf(" - ", StringComparison.Ordinal);
				if (index == -1)
				{
					return "";
				}
				groupCodeStr = groupCodeStr.Substring(0,index);
				groupCodeStr = GroupCodeExtractor.extractCodeLevels(groupCodeStr, provider.getGroupCodeStyle(codeType))[level - 1];
				if (string.ReferenceEquals(groupCodeStr, null))
				{
					return "";
				}

				if (groupCodeField == GROUP_CODE_CODE)
				{
					string separator = provider.getGroupCodeSeparator(codeType);
					return StringUtils.replaceAll(groupCodeStr, ".", separator);
				}

				GroupCode groupCode = provider.getGroupCodeCache(codeType).getGroupCode(groupCodeStr);
				if (groupCode == null)
				{
					return "";
				}

				if (groupCodeField == GROUP_CODE_TITLE)
				{
					return groupCode.Title;
				}
				else if (groupCodeField == GROUP_CODE_ITEM_CODE)
				{
					return ((ItemCode)groupCode).ItemCode;
				}
				else if (groupCodeField == GROUP_CODE_UNIT)
				{
					return provider.getUnitAlias(groupCode.Unit);
				}
				else if (groupCodeField == GROUP_CODE_DESCRIPTION)
				{
					return groupCode.Description;
				}
				else if (groupCodeField == GROUP_CODE_QUANTITY)
				{
					return groupCode.Quantity;
				}


				return groupCode.Notes;
			}
		}
	}
}