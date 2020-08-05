using IADocumentClassifier.Cors.Entities;
using IADocumentClassifier.Cors.Interfaces;
using IADocumentClassifier.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IADocumentClassifier.Infrastructure.Repositories
{
    public class RolesPermissionRepository : IRolesPermissionRepository
    {
        private readonly DocumentClassifierDbContext _context;

        public RolesPermissionRepository(DocumentClassifierDbContext context)
        {
            _context = context;
        }

        public async Task Add(RolesPermission rolesper)
        {
            _context.RolesPermission.Add(rolesper);
            await _context.SaveChangesAsync();
        }

        public async  Task<bool> Delete(int id)
        {
            var currentrolesper = await GetById(id);
            _context.RolesPermission.Remove(currentrolesper);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<RolesPermission>> GetAll()
        {
            var roleper = await _context.RolesPermission.ToListAsync();
            return roleper;
        }

        public async Task<RolesPermission> GetById(int id)
        {
            var roleper = await _context.RolesPermission.FirstOrDefaultAsync(x => x.RolPermission_Id == id);
            return roleper;
        }

        public async Task<bool> Update(RolesPermission rolesper)
        {
            var currentrolesper = await GetById(rolesper.RolPermission_Id);
            currentrolesper.Permission_Id = rolesper.Permission_Id;
            currentrolesper.Rol_Id = rolesper.Rol_Id;
            currentrolesper.Status = rolesper.Status;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
