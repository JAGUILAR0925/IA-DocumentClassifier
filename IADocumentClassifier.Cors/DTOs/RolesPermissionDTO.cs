
namespace IADocumentClassifier.Cors.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    public class RolesPermissionDTO
    {
        public int RolPermission_Id { get; set; }
        public int Rol_Id { get; set; }
        public int Permission_Id { get; set; }
        public Boolean Status { get; set; }
    }
}
