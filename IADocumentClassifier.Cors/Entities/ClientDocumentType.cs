
namespace IADocumentClassifier.Cors.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ClientDocumentType
    {
        public int ClientDocumentType_Id { get; set; }
        public int Client_Id { get; set; }
        public int DocumentType_Id { get; set; }
        public string Path { get; set; }
    }
}
