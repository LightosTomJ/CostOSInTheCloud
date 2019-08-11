namespace Desktop.common.nomitech.common.@base
{
    public interface BaseCache
    {

        GroupCode getGroupCode(string paramString);

        int getLevelOfGroupCode(GroupCode paramGroupCode);

        public static class BaseCache_Fields
        {
            public const string DOT = ".";
            public const string NUMERIC4_GC_STYLE = "numeric";
            public const string MASTERFORMAT_GC_STYLE = "masterformat";
            public const string NUMERIC5_GC_STYLE = "numeric5";
            public const string NUMERIC6_GC_STYLE = "numeric6";
            public const string DOTTED_GC_STYLE = "dotted";
            public const string RICHARDSON_GC_STYLE = "richardson";
        }
    }

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\BaseCache.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}