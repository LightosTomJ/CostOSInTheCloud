using System;
using System.Collections.Generic;

namespace Models.report
{
    public abstract class ProjectDataSource
    {
        public readonly bool useFieldDescription;
        //public readonly IDictionary<string, FieldReader> fieldReaders;
        protected internal readonly ProjectQueryExecuter queryExecuter;
        public object currentReturnValue { get; set; }
        public const string CURRENT_BEAN_MAPPING = "_THIS";

        public ProjectDataSource()
        { }
    }
}