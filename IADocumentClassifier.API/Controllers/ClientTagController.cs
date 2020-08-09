
namespace IADocumentClassifier.API.Controllers
{
    using AutoMapper;
    using IADocumentClassifier.API.Responses;
    using IADocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.DTOs;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Exceptions;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Cors.QueryFilters;
    using IADocumentClassifier.Infrastructure.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using static IADocumentClassifier.Cors.Exceptions.MessageHandlercs;

    [Route("api/[controller]")]
    [ApiController]
    public class ClientTagController : ControllerBase
    {
        private readonly IClientTagServices _clientTag;
        private readonly IMapper _mapper;
        public ClientTagController(IClientTagServices clientTag, IMapper mapper)
        {
            _clientTag = clientTag;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para consultar todos los Clientes por Tag
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clieTag = await _clientTag.GetAll();
            var clieTagDto = _mapper.Map<IEnumerable<ClientTagDTO>>(clieTag);
            var response = new GenericResponse<IEnumerable<ClientTagDTO>>(clieTagDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para consultar por Clientes por Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var clieTag = await _clientTag.GetById(id);
            var clieTagDto = _mapper.Map<ClientTagDTO>(clieTag);
            var response = new GenericResponse<ClientTagDTO>(clieTagDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para Crear Clientes por Tag
        /// </summary>
        /// <param name="clieTagDto"></param>
        /// <returns>Ok</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientTagDTO clieTagDto)
        {
            var clietag = _mapper.Map<ClientTag>(clieTagDto);
            await _clientTag.Add(clietag);
            clieTagDto = _mapper.Map<ClientTagDTO>(clietag);

            var response = new GenericResponse<ClientTagDTO>(clieTagDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para actualizar Clientes por Tag
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clieTag"></param>
        /// <returns>Ok</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, ClientTagDTO clieTag)
        {
            try
            {
                var clienTag = _mapper.Map<ClientTag>(clieTag);
                clienTag.ClientTag_Id = id;

                await _clientTag.Update(clienTag);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }
        }

        /// <summary>
        /// Metodo para Eliminar Clientes por Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientTag.Delete(id);
            var response = new GenericResponse<bool>(true);
            return Ok(response);
        }

    }
}
