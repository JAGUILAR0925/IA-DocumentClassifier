
namespace IADocumentClassifier.Cors.DTOs
{
    using IADocumentClassifier.Cors.Entities;
    using System;

    public class DocumentsTypeDTO 
    {
        public int DocumentTypeId { get; set; }
        public string DocumentType { get; set; }
        public Boolean Status { get; set; }
    }
}
