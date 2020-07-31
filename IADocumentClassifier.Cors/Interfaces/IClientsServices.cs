

namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.QueryFilters;
    using System.Threading.Tasks;

    public interface IClientsServices
    {
        Task<PagedList<Clients>> GetAll(ClientsQueryFilters filters);
        Task<Clients> GetById(int id);
        Task Add(Clients client);
        Task<bool> Update(Clients client);
        Task<bool> Delete(int id);
    }
}
