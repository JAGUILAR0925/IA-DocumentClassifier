
namespace IADocumentClassifier.API.Controllers
{
    using AutoMapper;
    using IADocumentClassifier.API.Responses;
    using IADocumentClassifier.Cors.DTOs;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Exceptions;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Cors.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using static IADocumentClassifier.Cors.Exceptions.MessageHandlercs;

    [Route("api/[controller]")]
    [ApiController]
    ///[Authorize]
    public class DocumentsTypesController : ControllerBase
    {
        private readonly IDocumentTypeServices _DocumentsTypesServices;
        private readonly IMapper _mapper;
        /// <summary>
        /// metodo para la inyeccion de dependencias mediante el contructor
        /// </summary>
        /// <param name="DocumentsTypesServices"></param>
        /// <param name="mapper"></param>
        public DocumentsTypesController(IDocumentTypeServices DocumentsTypesServices, IMapper mapper)
        {
            _DocumentsTypesServices = DocumentsTypesServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para consultar todos los tipos de documentos
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _DocumentsTypesServices.GetAll();
            var documentsDto = _mapper.Map<IEnumerable<DocumentsTypeDTO>>(documents);
            var response = new GenericResponse<IEnumerable<DocumentsTypeDTO>>(documentsDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para consultar por tipos de documentos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var docType = await _DocumentsTypesServices.GetById(id);
            var docTypeDto = _mapper.Map<DocumentsTypeDTO>(docType);
            var response = new GenericResponse<DocumentsTypeDTO>(docTypeDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para crear nuevos tipos de documentos
        /// </summary>
        /// <param name="documentypeDto"></param>
        /// <returns>Ok</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DocumentsTypeDTO documentypeDto)
        {
            var docType = _mapper.Map<DocumentsType>(documentypeDto);
            await _DocumentsTypesServices.Add(docType);
            documentypeDto = _mapper.Map<DocumentsTypeDTO>(docType);
           
            var response = new GenericResponse<DocumentsTypeDTO>(documentypeDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para actualizar los tipos de documentos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="documentypeDto"></param>
        /// <returns>Ok</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, DocumentsTypeDTO documentypeDto)
        {
            try
            {
                var docType = _mapper.Map<DocumentsType>(documentypeDto);
                docType.DocumentTypeId = id;

                await _DocumentsTypesServices.Update(docType);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }
        }

        /// <summary>
        /// Metodo para remover tipos de documentos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _DocumentsTypesServices.Delete(id);
           var response = new GenericResponse<bool>(true);
           return Ok(response);
        }
    }
}
