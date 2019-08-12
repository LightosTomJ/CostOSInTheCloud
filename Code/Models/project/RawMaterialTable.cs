using System;

namespace Models.project
{
    [Serializable]
    public class RawMaterialTable
    {
        public long? id;
        public string code;
        public decimal rate;
        public DateTime rateDate;

        public RawMaterialTable()
        { }

        public RawMaterialTable(string name, decimal rate, DateTime date) : base()
        {
            this.code = name;
            this.rate = rate;
            this.rateDate = date;
        }
    }
}