using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ParamItemConditionTable
    {
        public long? conditionId { get; set; }
        public string databaseName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string host { get; set; }
        public int? bidNo { get; set; }
        public int? cndNo { get; set; }
        public int? cndId { get; set; }
        public string cndType { get; set; }
        public int? pickType { get; set; }
        public string pickData { get; set; }

        public string description { get; set; }
        public string title { get; set; }

        public string building { get; set; }
        public string storey { get; set; }
        public string location { get; set; }

        public string bimType { get; set; }
        public string bimMaterial { get; set; }

        public string layer { get; set; }
        public string quantity1Name { get; set; }
        public string quantity2Name { get; set; }
        public string quantity3Name { get; set; }
        public string quantityFName { get; set; }

        public string formula1 { get; set; }
        public string formula2 { get; set; }
        public string formula3 { get; set; }
        public string formulaF { get; set; }

        public decimal quantity1 { get; set; }
        public decimal quantity2 { get; set; }
        public decimal quantity3 { get; set; }
        public decimal quantityF { get; set; }

        public int? selectedQuantity = new int?(0);

        public string unit1 { get; set; }
        public string unit2 { get; set; }
        public string unit3 { get; set; }
        public string unitF { get; set; }
        public string takeOffType { get; set; }
        public string globalId { get; set; }
        public string functionState { get; set; }

        public ParamItemTable paramItemTable { get; set; }
        public ParamItemInputTable paramItemInputTable { get; set; }
        public bool? @virtual { get; set; }

        public ParamItemConditionTable()
        { }
    }
}