
namespace IADocumentClassifier.Cors.DTOs
{
    using System;
    public class ClientsDTO 
    {
        public int Client_Id { get; set; }
        public string Name { get; set; }
        public int Identification { get; set; }
        public Boolean Status { get; set; }
        public string Token { get; set; }
    }
}
