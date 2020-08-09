
namespace IADocumentClassifier.Cors.Services
{
    using IADocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Cors.QueryFilters;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ClientTagServices: IClientTagServices
    {
        private readonly IClientTagRepository _clientTagRepository;
        public ClientTagServices(IClientTagRepository clientTagRepository)
        {
            _clientTagRepository = clientTagRepository;
        }

        public async Task<IEnumerable<ClientTag>> GetAll()
        {
            return await _clientTagRepository.GetAll();
        }

        public async Task<ClientTag> GetById(int id)
        {
            return await _clientTagRepository.GetById(id);
        }

        public async Task Add(ClientTag clienTag)
        {
            await _clientTagRepository.Add(clienTag);
        }
        public async Task<bool> Update(ClientTag clienTag)
        {
            await _clientTagRepository.Update(clienTag);
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _clientTagRepository.Delete(id);
            return true;
        }
    }
}
