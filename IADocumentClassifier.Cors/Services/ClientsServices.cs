
namespace IADocumentClassifier.Cors.Interfaces
{
    using AIDocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.QueryFilters;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ClientsServices : IClientsServices
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly PaginationOptions _paginationOptions;

        public ClientsServices(IClientsRepository clientsRepository, IOptions<PaginationOptions> options)
        {
            _clientsRepository = clientsRepository;
            _paginationOptions = options.Value;
        }

        public async Task<PagedList<Clients>> GetAll(ClientsQueryFilters filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

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
