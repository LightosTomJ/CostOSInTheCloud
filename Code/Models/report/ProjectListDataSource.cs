using System.Collections.Generic;

namespace Models.report
{
    public class ProjectListDataSource
    {
        public readonly int pageSize;
        public int pageCount {get; set;}
        public bool nextPage {get; set;}
        public IList<object> returnValues {get; set;}
        public IEnumerator<object> iterator {get; set;}

        public ProjectListDataSource()
        {
            returnValues = new List<object>();
        }
    }
}