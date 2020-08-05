
namespace IADocumentClassifier.Infrastructure.Repositories
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class ClientDocumentTypeRepository : IClientDocumentTypeRepository
    {
        private readonly DocumentClassifierDbContext _context;

        public ClientDocumentTypeRepository(DocumentClassifierDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientDocumentType>> GetAll()
        {
            var client = await _context.ClientDocumentType.ToListAsync();
            return client;
        }

        public async Task<ClientDocumentType> GetById(int id)
        {
            var client = await _context.ClientDocumentType.FirstOrDefaultAsync(x => x.Client_Id == id);
            return client;
        }

        public async Task Add(ClientDocumentType clientDoc)
        {
            _context.ClientDocumentType.Add(clientDoc);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(ClientDocumentType clientDoc)
        {           
            var currentclientdoc = await GetById(clientDoc.ClientDocumentType_Id);
            currentclientdoc.Client_Id = clientDoc.Client_Id;
            currentclientdoc.DocumentType_Id = clientDoc.DocumentType_Id;
            currentclientdoc.Path = clientDoc.Path;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var currentClient = await GetById(id);
            _context.ClientDocumentType.Remove(currentClient);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
