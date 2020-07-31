
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRolesServices
    {
        Task<IEnumerable<Roles>> GetAll();
        Task<Roles> GetById(int id);
        Task Add(Roles roles);
        Task<bool> Update(Roles roles);
        Task<bool> Delete(int id);
    }
}
