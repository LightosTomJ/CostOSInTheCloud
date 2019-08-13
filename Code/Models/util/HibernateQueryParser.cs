using System;
using System.Collections.Generic;
using System.Text;

namespace Models.util
{
    public class HibernateQueryParser
    {
        //public  DatabaseTableDefinition tableDefinition {get; set;}
        //public Query query { get; set; }
        public Type tableClass { get; set; }
        //public Session session { get; set; }
        public int dbmsType { get; set; }
        //public  Map<BooleanClause,List<Restrictions>> clauseMap = new HashMap<BooleanClause,List<Restrictions>>();

        public HibernateQueryParser()
        { }
    }
}