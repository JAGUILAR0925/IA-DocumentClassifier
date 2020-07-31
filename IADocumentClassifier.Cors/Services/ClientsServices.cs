
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.QueryFilters;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ClientsServices : IClientsServices
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsServices(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<PagedList<Clients>> GetAll(ClientsQueryFilters filters)
        {
            var client = await _clientsRepository.GetAll();
            
            if(filters.clientId != null)
            {
                client = client.Where(x => x.Client_Id == filters.clientId);
            }

            if (filters.identification != null)
            {
                client = client.Where(x => x.Identification == filters.identification);
            }

            if (filters.status)
            {
                client = client.Where(x => x.Status == filters.status);
            }

            var pageClient = PagedList<Clients>.Create(client, filters.PageNumber, filters.PageSize);
            return pageClient;
        }

        public async Task<Clients> GetById(int id)
        {
            return await _clientsRepository.GetById(id);
        }
        public async Task Add(Clients client)
        {
            await _clientsRepository.Add(client);
        }

        public async Task<bool> Update(Clients client)
        {
            await _clientsRepository.Update(client);
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _clientsRepository.Delete(id);
            return true;
        }
    }
}
