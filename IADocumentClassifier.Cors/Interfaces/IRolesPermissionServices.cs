
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public interface IRolesPermissionServices
    {
        Task<IEnumerable<RolesPermission>> GetAll();
        Task<RolesPermission> GetById(int id);
        Task Add(RolesPermission roles);
        Task<bool> Update(RolesPermission roles);
        Task<bool> Delete(int id);
    }
}
