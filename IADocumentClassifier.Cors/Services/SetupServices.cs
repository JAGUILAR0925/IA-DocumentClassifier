
namespace IADocumentClassifier.Cors.Services
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class SetupServices : ISetupServices
    {
        private readonly ISetupRepository _setupRepository;
       public SetupServices(ISetupRepository setupRepository)
        {
            _setupRepository = setupRepository;
        }

        public async Task<IEnumerable<Setup>> GetAll()
        {
            return await _setupRepository.GetAllTags();
        }

        public async Task<Setup> GetById(int id)
        {
            return await _setupRepository.GetByIdTag(id);
        }

        public async Task Add(Setup setup)
        {
            await _setupRepository.Add(setup);
        }

        public async Task<bool> Update(Setup setup)
        {
            return await _setupRepository.Update(setup);
        }
        public async Task<bool> Delete(int id)
        {
            return await _setupRepository.Delete(id);
        }

    }
}
