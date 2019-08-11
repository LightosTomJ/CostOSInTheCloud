using System;

namespace Desktop.common.nomitech.common.@base
{

    public interface GroupCode : DatabaseTable, IComparable<GroupCode>
    {
        GroupCode Data { set; }

        void setFieldData(string paramString, GroupCode paramGroupCode);

        string getGroupCode();

        string Notes { get; set; }

        string Unit { get; set; }

        decimal UnitFactor { get; set; }

        decimal Quantity { get; }

        string Title { set; }

        string Description { set; }

        void setGroupCode(string paramString);


    }

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\GroupCode.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}