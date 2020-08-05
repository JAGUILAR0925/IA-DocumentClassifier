
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPermissionsServices
    {
        Task<IEnumerable<Permissions>> GetAll();
        Task<Permissions> GetById(int id);
        Task Add(Permissions permiss);
        Task<bool> Update(Permissions permiss);
        Task<bool> Delete(int id);
    }
}
