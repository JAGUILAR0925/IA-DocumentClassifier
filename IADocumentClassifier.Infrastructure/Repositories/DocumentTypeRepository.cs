
namespace IADocumentClassifier.Infrastructure.Repositories
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DocumentTypeRepository : IDocumentsTypesRepository
    {
        private readonly DocumentClassifierDbContext _context;
        public DocumentTypeRepository(DocumentClassifierDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentsType>> GetDocumentsType()
        {
            var documentype = await _context.DocumentType.ToListAsync();
            return documentype;
        }
        public async Task<DocumentsType>GetSpecificDocumentType(int id)
        {
            var docType = await _context.DocumentType.FirstOrDefaultAsync(x => x.DocumentTypeId == id);
            return docType;
        }
        public async Task InsertDocumentType(DocumentsType documentype)
        {
            _context.DocumentType.Add(documentype);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateDocumentType(DocumentsType documentype)
        {
            var currentDocumentType = await GetSpecificDocumentType(documentype.DocumentTypeId);
            currentDocumentType.DocumentType = documentype.DocumentType;
            currentDocumentType.Status = documentype.Status;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteDocumentType(int id)
        {
            var currentDocumentType = await GetSpecificDocumentType(id);
            _context.DocumentType.Remove(currentDocumentType);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
