
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRolesClientRepository
    {
        Task<IEnumerable<RolesClient>> GetAll();
        Task<RolesClient> GetById(int id);
        Task Add(RolesClient roles);
        Task<bool> Update(RolesClient roles);
        Task<bool> Delete(int id);
    }
}
