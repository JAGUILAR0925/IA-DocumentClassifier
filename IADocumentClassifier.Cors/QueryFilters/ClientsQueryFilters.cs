
namespace IADocumentClassifier.Cors.QueryFilters
{
    using System;

    public class ClientsQueryFilters : PaginationFilters
    {
        public int? clientId { get; set; }
        public int? identification { get; set; }
        public Boolean status { get; set; }
      
    }
}
