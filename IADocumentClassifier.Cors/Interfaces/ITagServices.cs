
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITagServices
    {
        Task<IEnumerable<Tags>> GetAll();
        Task<Tags> GetByIdTag(int id);
        Task Add(Tags doctype);
        Task<bool> Update(Tags tag);
        Task<bool> Delete(int id);
    }
}
