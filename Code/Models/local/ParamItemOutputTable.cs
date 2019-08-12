using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ParamItemOutputTable
    {
        public static readonly string[] VIEWABLE_FIELDS = new string[] { "paramOutputId", "title", "sortOrder", "factorEquation", "quantityEquation", "productivityEquation", "generationCondition", "resourceIds" };
        public long? paramOutputId { get; set; }
        public string quantityEquation { get; set; }
        public string factorEquation { get; set; }
        public string labLocEquation { get; set; }
        public string matLocEquation { get; set; }
        public string equLocEquation { get; set; }
        public string subLocEquation { get; set; }
        public string conLocEquation { get; set; }
        public string generationCondition { get; set; }
        public string title { get; set; }
        public string productivityEquation { get; set; }
        public int? sortOrder { get; set; }
        public string loopVar { get; set; }
        public string resourceIds { get; set; }
        public ParamItemTable paramItemTable { get; set; }
        public ISet<ParamItemConceptualResourceTable> conceptualSet { get; set; }
        public ISet<ParamItemQueryResourceTable> queryResourceSet { get; set; }

        public ParamItemOutputTable()
        { }
    }
}