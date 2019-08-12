using Model.local;
using System;

namespace Models.project
{

    public class AssemblyHistoryTable
    {
        public long? assemblyHistoryId { get; set; }
        public string baseTableId { get; set; }
        public string resource { get; set; }
        public DateTime predictionDate { get; set; }
        public AssemblyTable assemblyTable { get; set; }
    }
}