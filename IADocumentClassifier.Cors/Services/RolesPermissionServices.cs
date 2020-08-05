
namespace IADocumentClassifier.Cors.Services
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public class RolesPermissionServices : IRolesPermissionServices
    {
        private readonly IRolesPermissionRepository  _rolesPermissionRepository;

        public RolesPermissionServices(IRolesPermissionRepository rolesPermissionRepository)
        {
            _rolesPermissionRepository = rolesPermissionRepository;
        }

        public async Task<IEnumerable<RolesPermission>> GetAll()
        {
            return await _rolesPermissionRepository.GetAll();
        }

        public async Task<RolesPermission> GetById(int id)
        {
            return await _rolesPermissionRepository.GetById(id);
        }

        public async Task Add(RolesPermission rolesPerm)
        {
            await _rolesPermissionRepository.Add(rolesPerm);
        }
        public async Task<bool> Update(RolesPermission rolesPerm)
        {
            return await _rolesPermissionRepository.Update(rolesPerm);
        }

        public async Task<bool> Delete(int id)
        {
            return await _rolesPermissionRepository.Delete(id);
        }
    }
}
