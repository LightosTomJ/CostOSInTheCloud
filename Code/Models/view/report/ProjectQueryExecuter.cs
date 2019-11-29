using System;
using System.Collections.Generic;
using System.Numerics;

namespace Models.report
{
    public class ProjectQueryExecuter
    {
        protected internal const string CANONICAL_LANGUAGE = "CostosHQL";
        private static readonly IDictionary<Type, Type> hibernateTypeMap;

        //static ProjectQueryExecuter()
        //{
        //    hibernateTypeMap = new Dictionary<Type, Type>();
        //    hibernateTypeMap.Add(typeof(bool), BooleanType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(byte), ByteType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(double), DoubleType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(float), FloatType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(int), IntegerType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(long), LongType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(short), ShortType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(decimal), BigDecimalType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(BigInteger), BigIntegerType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(char), CharacterType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(string), StringType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(DateTime), DateType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(TimeStamp), TimestampType.INSTANCE);
        //    hibernateTypeMap.Add(typeof(Time), TimeType.INSTANCE);
        //}

        //public readonly int? reportMaxCount { get; set; }
        //public Session session { get; set; }
        //public Query query { get; set; }
        public bool queryRunning { get; set; }
        //public ScrollableResults scrollableResults { get; set; }
        public bool isClearCache { get; set; }

        private bool isSubquery = false;
        private bool mustCloseSession = false;

        public ProjectQueryExecuter()
        { }
    }
}