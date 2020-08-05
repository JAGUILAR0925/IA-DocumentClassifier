
namespace IADocumentClassifier.Cors.Services
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class RolesClientServices : IRolesClientServices
    {
        private readonly IRolesClientRepository _rolesClientRepository;

        public RolesClientServices(IRolesClientRepository rolesClientRepository)
        {
            _rolesClientRepository = rolesClientRepository;
        }

        public async Task Add(RolesClient rolescli)
        {
            await _rolesClientRepository.Add(rolescli);
        }

        public async Task<bool> Delete(int id)
        {
            return await _rolesClientRepository.Delete(id);
        }

        public async Task<IEnumerable<RolesClient>> GetAll()
        {
            return await _rolesClientRepository.GetAll();
        }

        public async Task<RolesClient> GetById(int id)
        {
            return await _rolesClientRepository.GetById(id);
        }

        public async Task<bool> Update(RolesClient rolescli)
        {
            return await _rolesClientRepository.Update(rolescli);
        }
    }
}
