
namespace IADocumentClassifier.Cors.DTOs
{
    using IADocumentClassifier.Cors.Entities;
    using System;

    public class TagDTO 
    {
        public int Tag_Id { get; set; }
        public string TagName { get; set; }
        public Boolean Status { get; set; }
    }
}
