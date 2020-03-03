using Models.local.BaseClass;
using System;

namespace Models.projects
{

    public class AssemblyHistory
    {
        public long? assemblyHistoryId { get; set; }
        public string baseTableId { get; set; }
        public string resource { get; set; }
        public DateTime predictionDate { get; set; }
        public Assembly assemblyTable { get; set; }
    }
}