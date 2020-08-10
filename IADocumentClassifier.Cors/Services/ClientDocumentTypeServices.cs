
namespace IADocumentClassifier.Cors.Services
{
    using AIDocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.QueryFilters;
    using IADocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Exceptions;
    using IADocumentClassifier.Cors.Interfaces;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using static IADocumentClassifier.Cors.Exceptions.MessageHandlercs;
    using System.Linq;

    public class ClientDocumentTypeServices:IClientDocumentTypeServices
    {
        private readonly IClientDocumentTypeRepository  _clientDocumentTypeRepository;
        private readonly PaginationOptions _paginationOptions;
        public ClientDocumentTypeServices(IClientDocumentTypeRepository clientDocumentTypeRepository, IOptions<PaginationOptions> options)
        {
            _clientDocumentTypeRepository = clientDocumentTypeRepository;
            _paginationOptions = options.Value;
        }

        public async Task<PagedList<ClientDocumentType>> GetAll(ClientDocumentTypeQueryFilters filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            var clientDocumentType = await _clientDocumentTypeRepository.GetAll();

            if (filters.clientDocumentType_Id > 0)
            {
                clientDocumentType = clientDocumentType.Where(x => x.ClientDocumentType_Id == filters.clientDocumentType_Id);
            }

            if (filters.client_Id > 0)
            {
                clientDocumentType = clientDocumentType.Where(x => x.Client_Id == filters.client_Id);
            }

            if (filters.documentType_Id > 0)
            {
                clientDocumentType = clientDocumentType.Where(x => x.DocumentType_Id == filters.documentType_Id);
            }

            var pageClient = PagedList<ClientDocumentType>.Create(clientDocumentType, filters.PageNumber, filters.PageSize);
            return pageClient;
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
