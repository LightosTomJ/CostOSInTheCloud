namespace Model.local
{
    public class ExternalQueryAliasTable
    {
        public long? id { get; set; }
        public short? lineNumber { get; set; }
        public string fromAliasClassName { get; set; }
        public string fromAlias { get; set; }
        public string toField { get; set; }
        public string dataMapping { get; set; }
        public bool? isQueryColumnID { get; set; }
        public ExternalQueryTable externalQueryTable { get; set; }

        public ExternalQueryAliasTable()
        { }
    }
}