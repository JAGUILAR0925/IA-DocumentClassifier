
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClientsRepository
    {
        Task<IEnumerable<Clients>> GetAll();
        Task<Clients> GetById(int id);
        Task Add(Clients client);
        Task<bool> Update(Clients client);
        Task<bool> Delete(int id);
    }
}
