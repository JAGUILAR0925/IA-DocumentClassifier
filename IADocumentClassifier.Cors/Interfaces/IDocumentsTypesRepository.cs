
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDocumentsTypesRepository
    {
        Task<IEnumerable<DocumentsType>> GetDocumentsType();
        Task<DocumentsType> GetSpecificDocumentType(int id);
        Task InsertDocumentType(DocumentsType documentype);
        Task<bool> UpdateDocumentType(DocumentsType documentype);
        Task<bool> DeleteDocumentType(int id);
    }
}
