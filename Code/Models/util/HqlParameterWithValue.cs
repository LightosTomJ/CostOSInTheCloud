using System;

namespace Models.util
{
    [Serializable]
    public class HqlParameterWithValue
    {
        public string paramName { get; set; }
        public int? index { get; set; }
        public double? decimalValue { get; set; }
        public long? longValue { get; set; }
        public string stringValue { get; set; }

        public HqlParameterWithValue()
        { }
    }
}