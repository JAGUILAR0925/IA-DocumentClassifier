
namespace IADocumentClassifier.Infrastructure.Services
{
    using IADocumentClassifier.Cors.QueryFilters;
    using IADocumentClassifier.Infrastructure.Interface;
    using System.Security.Policy;

    public class UrlServices : IUrlServices
    {
        private readonly string _baseUri;
        public UrlServices(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Url GetPaginationUri(ClientsQueryFilters filters, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Url(baseUrl);
        }
    }
}
