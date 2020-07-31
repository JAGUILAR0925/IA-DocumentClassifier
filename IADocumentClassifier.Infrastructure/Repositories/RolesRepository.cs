

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

    public class RolesRepository : IRolesRepository
    {
        private readonly DocumentClassifierDbContext _context;

        public RolesRepository(DocumentClassifierDbContext context)
        {
            _context = context;
        }

        public async  Task<IEnumerable<Roles>> GetAll()
        {
            var rol = await _context.Roles.ToListAsync();
            return rol;
        }

        public async Task<Roles> GetById(int id)
        {
            var rol = await _context.Roles.FirstOrDefaultAsync(x => x.Rol_Id == id);
            return rol;
        }

        public async Task Add(Roles roles)
        {
            _context.Roles.Add(roles);
            await _context.SaveChangesAsync();
        }
       
        public async Task<bool> Update(Roles roles)
        {
            var currentRol = await GetById(roles.Rol_Id);
            currentRol.RolName = roles.RolName;
            currentRol.Status = roles.Status;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var currentRol = await GetById(id);
            _context.Roles.Remove(currentRol);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
