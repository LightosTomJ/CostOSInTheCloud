using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class GekCodeTableList
    {
        public List<GekCodeTable> GekCodes { get; set; }
        public const long serialVersionUID = 1L;

        public GekCodeTableList()
        {
            GekCodes = new List<GekCodeTable>();
        }
    }
}