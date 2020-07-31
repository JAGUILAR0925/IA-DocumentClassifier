
namespace IADocumentClassifier.Cors.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SetupDTO
    {
        public int Setup_Id { get; set; }
        public string Name { get; set; }
        public string ValueParameter { get; set; }
        public Boolean Status { get; set; }
    }
}
