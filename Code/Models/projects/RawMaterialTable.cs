using System;

namespace Models.projects
{
    [Serializable]
    public class RawMaterial
    {
        public long? id;
        public string code;
        public decimal rate;
        public DateTime rateDate;

        public RawMaterial()
        { }

        public RawMaterial(string name, decimal rate, DateTime date) : base()
        {
            this.code = name;
            this.rate = rate;
            this.rateDate = date;
        }
    }
}