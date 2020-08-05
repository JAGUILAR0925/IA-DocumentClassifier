
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPermissionRepository
    {
        Task<IEnumerable<Permissions>> GetAll();
        Task<Permissions> GetById(int id);
        Task Add(Permissions permi);
        Task<bool> Update(Permissions permi);
        Task<bool> Delete(int id);
    }
}
