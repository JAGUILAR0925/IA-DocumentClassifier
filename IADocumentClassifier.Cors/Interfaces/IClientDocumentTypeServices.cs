
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.QueryFilters;
    using IADocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IClientDocumentTypeServices
    {
        Task<PagedList<ClientDocumentType>> GetAll(ClientDocumentTypeQueryFilters filters);
        Task<ClientDocumentType> GetById(int id);
        Task Add(ClientDocumentType clientDoc);
        Task<bool> Update(ClientDocumentType clientDoc);
        Task<bool> Delete(int id);
    }
}
