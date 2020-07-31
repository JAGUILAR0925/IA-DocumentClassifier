
namespace IADocumentClassifier.Cors.Services
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class RolesServices : IRolesServices
    {
        private readonly IRolesRepository  _rolesRepository;
        public RolesServices(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<IEnumerable<Roles>> GetAll()
        {
            return await _rolesRepository.GetAll();
        }

        public async Task<Roles> GetById(int id)
        {
            return await _rolesRepository.GetById(id);
        }
        public async Task Add(Roles roles)
        {
            await _rolesRepository.Add(roles);
        }

        public async Task<bool> Update(Roles roles)
        {
            return await _rolesRepository.Update(roles);
        }
        public async Task<bool> Delete(int id)
        {
            return await _rolesRepository.Delete(id);
        }
    }
}
