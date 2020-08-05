
namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IClientDocumentTypeServices
    {
        Task<IEnumerable<ClientDocumentType>> GetAll();
        Task<ClientDocumentType> GetById(int id);
        Task Add(ClientDocumentType clientDoc);
        Task<bool> Update(ClientDocumentType clientDoc);
        Task<bool> Delete(int id);
    }
}
