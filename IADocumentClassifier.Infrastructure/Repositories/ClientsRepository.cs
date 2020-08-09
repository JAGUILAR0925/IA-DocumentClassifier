
namespace IADocumentClassifier.Infrastructure.Repositories
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ClientsRepository : IClientsRepository
    {
        private readonly DocumentClassifierDbContext _context;
        public ClientsRepository(DocumentClassifierDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clients>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Clients> GetById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.Client_Id == id);
        }

        public async Task Add(Clients client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Clients client)
        {
            var currentclient = await GetById(client.Client_Id);
            currentclient.Name = client.Name;
            currentclient.Identification = client.Identification;
            currentclient.Status = client.Status;
            currentclient.Token = client.Token;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var currentClient = await GetById(id);
            _context.Clients.Remove(currentClient);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
