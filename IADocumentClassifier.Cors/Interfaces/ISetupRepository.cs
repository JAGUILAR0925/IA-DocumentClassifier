
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISetupRepository
    {
        Task<IEnumerable<Setup>> GetAllTags();
        Task<Setup> GetByIdTag(int id);
        Task Add(Setup doctype);
        Task<bool> Update(Setup tag);
        Task<bool> Delete(int id);
    }
}
