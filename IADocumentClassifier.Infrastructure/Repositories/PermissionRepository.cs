
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

    public class PermissionRepository: IPermissionRepository
    {
        private readonly DocumentClassifierDbContext _context;

        public PermissionRepository(DocumentClassifierDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permissions>> GetAll()
        {
            var permi = await _context.Permissions.ToListAsync();
            return permi;
        }

        public async Task<Permissions> GetById(int id)
        {
            var perm = await _context.Permissions.FirstOrDefaultAsync(x => x.Permissions_Id == id);
            return perm;
        }

        public async Task Add(Permissions permi)
        {
            _context.Permissions.Add(permi);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Permissions permi)
        {
            var currentPerm = await GetById(permi.Permissions_Id);
            currentPerm.PermissionsName = permi.PermissionsName;
            currentPerm.Status = permi.Status;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var currentPerm = await GetById(id);
            _context.Permissions.Remove(currentPerm);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
