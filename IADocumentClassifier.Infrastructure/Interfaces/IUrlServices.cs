

namespace IADocumentClassifier.Infrastructure.Interface
{
    using IADocumentClassifier.Cors.QueryFilters;
    using System.Security.Policy;

    public interface IUrlServices
    {
        Url GetPaginationUri(ClientsQueryFilters filters, string actionUrl);
    }
}