using System;

namespace Model.local
{
    [Serializable]
    public class ParamItemReturnTable
    {
        public long? paramReturnId { get; set; }
        public string returnEquation { get; set; }

        public ParamItemReturnTable()
        { }
    }
}