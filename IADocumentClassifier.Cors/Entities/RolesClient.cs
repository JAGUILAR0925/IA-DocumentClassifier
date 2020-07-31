
namespace IADocumentClassifier.Cors.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RolesClient
    {
        public int RolesClient_Id { get; set; }
        public int Client_Id { get; set; }
        public int Rol_Id { get; set; }
        public Boolean Status { get; set; }
    }
}
