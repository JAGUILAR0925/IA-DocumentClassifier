
namespace IADocumentClassifier.Cors.Services
{
    using IADocumentClassifier.Cors.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDocumentTypeServices
    {
        Task<IEnumerable<DocumentsType>> GetAll();
        Task<DocumentsType> GetById(int id);
        Task Add(DocumentsType doctype);
        Task<bool> Update(DocumentsType documentype);
        Task<bool> Delete(int id);
    }
}