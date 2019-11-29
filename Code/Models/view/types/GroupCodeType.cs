using System;

namespace Models.types
{
    public class GroupCodeType
    {
        public const short GROUP_CODE_TITLE = 0;
        public const short GROUP_CODE_DESCRIPTION = 1;
        public const short GROUP_CODE_CODE = 2;
        public const short GROUP_CODE_NOTES = 3;
        public const short GROUP_CODE_UNIT = 4;
        public const short GROUP_CODE_ITEM_CODE = 5;
        public const short GROUP_CODE_QUANTITY = 6;

        //public GroupCodeType(GroupCodesProvider provider, short codeType, int level, string key, short groupCodeField) : this(new GroupCodeTextType(provider, codeType, level, groupCodeField), new string[] { key })
        //{ }

        //private GroupCodeType(GroupCodeTextType notNullTextType, string[] keys) : base(notNullTextType, keys)
        //{ }

        //[Serializable]
        //private class GroupCodeTextType : NotNullTextType
        //{
        //    internal int level;
        //    internal GroupCodesProvider provider;
        //    internal short codeType;
        //    internal short groupCodeField;

        //    internal GroupCodeTextType(GroupCodesProvider provider, short codeType, int level, short groupCodeField) : base()
        //    {
        //        this.provider = provider;
        //        this.level = level;
        //        this.codeType = codeType;
        //        this.groupCodeField = groupCodeField;
        //    }
        //}
    }
}