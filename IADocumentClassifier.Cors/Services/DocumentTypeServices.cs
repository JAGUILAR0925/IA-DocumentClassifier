
namespace IADocumentClassifier.Cors.Services
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DocumentTypeServices : IDocumentTypeServices
    {
        private readonly IDocumentsTypesRepository _documentsTypesRepository;
       
        public DocumentTypeServices(IDocumentsTypesRepository documentsTypesRepository)
        {
            _documentsTypesRepository = documentsTypesRepository;
        }

        public async Task<DocumentsType> GetById(int id)
        {
            return await _documentsTypesRepository.GetSpecificDocumentType(id);
        }

        public async Task<IEnumerable<DocumentsType>> GetAll()
        {
            return await _documentsTypesRepository.GetDocumentsType();
        }

        public async Task Add(DocumentsType doctype)
        {
            await _documentsTypesRepository.InsertDocumentType(doctype);
        }

        public async Task<bool> Update(DocumentsType documentype)
        {
            await _documentsTypesRepository.UpdateDocumentType(documentype);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _documentsTypesRepository.DeleteDocumentType(id);
            return true;
        }
    }
}
