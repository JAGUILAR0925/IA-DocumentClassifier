
namespace IADocumentClassifier.Cors.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Permissions
    {
        public int Permissions_Id { get; set; }
        public string PermissionsName { get; set; }
        public string Action { get; set; }
        public Boolean Status { get; set; }
    }
}
