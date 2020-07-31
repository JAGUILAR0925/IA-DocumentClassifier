using IADocumentClassifier.Cors.Entities;
using IADocumentClassifier.Cors.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IADocumentClassifier.Cors.Services
{
    public class TagServices : ITagServices
    {
       private readonly ITagsRepository  _tagsRepository;
       public TagServices(ITagsRepository tagsRepository)
       {
            _tagsRepository = tagsRepository;
       }

        public async Task Add(Tags tag)
        {
            await _tagsRepository.Add(tag);
        }

        public async Task<bool> Delete(int id)
        {
            return await _tagsRepository.Delete(id);
        }

        public async Task<IEnumerable<Tags>> GetAll()
        {
            return await _tagsRepository.GetAllTags();
        }

        public async Task<Tags> GetByIdTag(int id)
        {
            return await _tagsRepository.GetByIdTag(id);
        }

        public async Task<bool> Update(Tags tag)
        {
            return await _tagsRepository.Update(tag);
        }
    }
}
