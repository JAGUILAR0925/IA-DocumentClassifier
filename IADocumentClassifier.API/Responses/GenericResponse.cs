

namespace IADocumentClassifier.API.Responses
{
    using IADocumentClassifier.Cors.CustomEntities;

    public class GenericResponse<T>
    {
        public GenericResponse(T data)
        {
            Data = data;
        }
        
        public T Data { get; set; }

        public Metadata meta { get; set; }
    }
}
