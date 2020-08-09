
namespace IADocumentClassifier.Infrastructure.Repositories
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CientTagRepository : IClientTagRepository
    {
        private readonly DocumentClassifierDbContext _context;
        public CientTagRepository(DocumentClassifierDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClientTag>> GetAll()
        {
            return await _context.ClientTag.ToListAsync();
        }

        public async Task<ClientTag> GetById(int id)
        {
            return await _context.ClientTag.FirstOrDefaultAsync(x => x.ClientTag_Id == id);
        }

        public async Task Add(ClientTag clienTag)
        {
            _context.ClientTag.Add(clienTag);
            await _context.SaveChangesAsync();
        }
        
        public async Task<bool> Update(ClientTag clienTag)
        {
            var currentclient = await GetById(clienTag.ClientTag_Id);
            currentclient.Client_Id = clienTag.Client_Id;                
            currentclient.Tag_Id = clienTag.Tag_Id;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var currentClientTag = await GetById(id);
            _context.ClientTag.Remove(currentClientTag);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
