
namespace IADocumentClassifier.Cors.Services
{
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Exceptions;
    using IADocumentClassifier.Cors.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using static IADocumentClassifier.Cors.Exceptions.MessageHandlercs;

    public class ClientDocumentTypeServices:IClientDocumentTypeServices
    {
        private readonly IClientDocumentTypeRepository  _clientDocumentTypeRepository;
        public ClientDocumentTypeServices(IClientDocumentTypeRepository clientDocumentTypeRepository)
        {
            _clientDocumentTypeRepository = clientDocumentTypeRepository;
        }

        public async Task<IEnumerable<ClientDocumentType>> GetAll()
        {
            return await _clientDocumentTypeRepository.GetAll();
        }

        public async Task<ClientDocumentType> GetById(int id)
        {
            return await _clientDocumentTypeRepository.GetById(id);
        }
        public async Task Add(ClientDocumentType clientDoc)
        {
            try
            {
                var existeClient = await GetById(clientDoc.Client_Id);
                var existedoc = await GetById(clientDoc.DocumentType_Id);

                if (existeClient != null & existedoc != null)
                {
                    if(existeClient.Client_Id == clientDoc.Client_Id && existedoc.DocumentType_Id == clientDoc.DocumentType_Id)
                    {
                        await _clientDocumentTypeRepository.Add(clientDoc);
                    }                    
                }
                else
                {
                    var message = "No existe datos relacionados con el client_Id o documentType_id";
                    throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID),"");
                }
            }
            catch(Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }
        }

        public async Task<bool> Update(ClientDocumentType clieDoc)
        {
            return await _clientDocumentTypeRepository.Update(clieDoc);
        }
        public async Task<bool> Delete(int id)
        {
            return await _clientDocumentTypeRepository.Delete(id);
        }
    }
}
