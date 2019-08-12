namespace Model.local
{
    public class BenchmarkToBoqColumnMappingTable
    {
        public long? id { get; set; }
        public long? templateId { get; set; }
        public string fromBench { get; set; }
        public string toBoq { get; set; }
        public string aggregate { get; set; }
        public string viewName { get; set; }

        public BenchmarkToBoqColumnMappingTable()
        { }
    }
}