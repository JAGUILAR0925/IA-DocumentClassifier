
namespace IADocumentClassifier.Cors.Services
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class PermissionsServices:IPermissionsServices
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionsServices(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public async Task<IEnumerable<Permissions>> GetAll()
        {
            return await _permissionRepository.GetAll();
        }

        public async Task<Permissions> GetById(int id)
        {
            return await _permissionRepository.GetById(id);
        }
        public async Task Add(Permissions permi)
        {
            await _permissionRepository.Add(permi);
        }

        public async Task<bool> Update(Permissions permi)
        {
            return await _permissionRepository.Update(permi);
        }
        public async Task<bool> Delete(int id)
        {
            return await _permissionRepository.Delete(id);
        }
    }
}
