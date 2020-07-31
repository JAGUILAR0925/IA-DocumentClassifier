
namespace IADocumentClassifier.Infrastructure.Repositories
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TagsRepository : ITagsRepository
    {
        private readonly DocumentClassifierDbContext _context;

        public TagsRepository(DocumentClassifierDbContext context)
        {
            _context = context;
        }

        public async Task Add(Tags tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var currentTag = await GetByIdTag(id);
            _context.Tags.Remove(currentTag);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Tags>> GetAllTags()
        {
            var tags = await _context.Tags.ToListAsync();
            return tags;
        }

        public async Task<Tags> GetByIdTag(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Tag_Id == id);
            return tag;
        }

        public async Task<bool> Update(Tags tag)
        {
            var currentTag = await GetByIdTag(tag.Tag_Id);
            currentTag.TagName = tag.TagName;
            currentTag.Status = tag.Status;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
