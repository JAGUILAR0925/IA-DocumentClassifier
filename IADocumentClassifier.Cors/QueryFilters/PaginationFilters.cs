using System;
using System.Collections.Generic;
using System.Text;

namespace IADocumentClassifier.Cors.QueryFilters
{
    public abstract class PaginationFilters
    {
        public int PageNumber { get; set; }
        public  int PageSize { get; set; }       
    }
}
