
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISetupServices
    {
        Task<IEnumerable<Setup>> GetAll();
        Task<Setup> GetById(int id);
        Task Add(Setup client);
        Task<bool> Update(Setup client);
        Task<bool> Delete(int id);
    }
}
