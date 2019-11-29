using System;

namespace Models.util
{
    [Serializable]
    public class HqlResultValue
    {
        public long? longValue { get; set; }
        public string stringValue { get; set; }
        public DateTime dateValue { get; set; }
        public decimal decimalValue { get; set; }
        public bool? booleanValue { get; set; }

        public HqlResultValue()
        { }
    }
}