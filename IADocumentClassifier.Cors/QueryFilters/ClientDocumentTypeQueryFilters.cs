
namespace IADocumentClassifier.Cors.QueryFilters
{
    using IADocumentClassifier.Cors.QueryFilters;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ClientDocumentTypeQueryFilters : PaginationFilters
    {
        public int clientDocumentType_Id { get; set; }
        public int client_Id { get; set; }
        public int documentType_Id { get; set; }
    }
}
