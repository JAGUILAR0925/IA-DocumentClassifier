
namespace IADocumentClassifier.Infrastructure.Repositories
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SetupRepository : ISetupRepository
    {
        private readonly DocumentClassifierDbContext _context;
        public SetupRepository(DocumentClassifierDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Setup>> GetAllTags()
        {
            var setup = await _context.Setup.ToListAsync();
            return setup;
        }

        public async Task<Setup> GetByIdTag(int id)
        {
            var setup = await _context.Setup.FirstOrDefaultAsync(x => x.Setup_Id == id);
            return setup;
        }
       
        public async Task Add(Setup setup)
        {
            _context.Setup.Add(setup);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Update(Setup setup)
        {
            var currentSetup = await GetByIdTag(setup.Setup_Id);
            currentSetup.Name = setup.Name;
            currentSetup.ValueParameter = setup.ValueParameter;
            currentSetup.Status = setup.Status;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var currentSetup = await GetByIdTag(id);
            _context.Setup.Remove(currentSetup);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
