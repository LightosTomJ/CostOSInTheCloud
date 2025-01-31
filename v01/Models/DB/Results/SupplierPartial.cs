﻿using System;
using System.Collections.Generic;

namespace Models.DB.Results
{
    public partial class SupplierPartial
    {
        public int Id { get; set; }
        public int? ResultSize { get; set; }
        public int? PartialSize { get; set; }
        public int? PartialStart { get; set; }
        public int? PageSize { get; set; }
        public string SortByField { get; set; }
        public bool Ascending { get; set; }
        public string Query { get; set; }
        public string QueryType { get; set; }
        public decimal Seconds { get; set; }
    }
}
