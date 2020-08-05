
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
    public class RolesClientRepositorycs:IRolesClientRepository
    {
        private readonly DocumentClassifierDbContext _context;

        public RolesClientRepositorycs(DocumentClassifierDbContext context)
        {
            _context = context;
        }
        public async Task Add(RolesClient rolesclie)
        {
            _context.RolesClient.Add(rolesclie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var currentrolesper = await GetById(id);
            _context.RolesClient.Remove(currentrolesper);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<RolesClient>> GetAll()
        {
            var roleper = await _context.RolesClient.ToListAsync();
            return roleper;
        }

        public async Task<RolesClient> GetById(int id)
        {
            var roleper = await _context.RolesClient.FirstOrDefaultAsync(x => x.RolesClient_Id == id);
            return roleper;
        }

        public async Task<bool> Update(RolesClient rolesclie)
        {
            var currentroleclie = await GetById(rolesclie.RolesClient_Id);
            currentroleclie.Client_Id = rolesclie.Client_Id;
            currentroleclie.Rol_Id = rolesclie.Rol_Id;
            currentroleclie.Status = rolesclie.Status;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
