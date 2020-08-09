﻿

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
    public class ClientDocumentTypeController : ControllerBase
    {
        private readonly IClientDocumentTypeServices _clientDocumentTypeServices;
        private readonly IMapper _mapper;
        /// <summary>
        /// metodo para la inyeccion de dependencias mediante el contructor
        /// </summary>
        /// <param name="permissionsServices"></param>
        /// <param name="mapper"></param>
        public ClientDocumentTypeController(IClientDocumentTypeServices permissionsServices, IMapper mapper)
        {
            _clientDocumentTypeServices = permissionsServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieve all ClientDocumentType
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet(Name = nameof(GetAllClientDocumentType))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type =typeof(GenericResponse<IEnumerable<ClientDocumentType>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllClientDocumentType()
        {
            var clieDoc = await _clientDocumentTypeServices.GetAll();
            var clieDocDto = _mapper.Map<IEnumerable<ClientDocumentTypeDTO>>(clieDoc);
            var response = new GenericResponse<IEnumerable<ClientDocumentTypeDTO>>(clieDocDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para consultar por Clientes por tipo de documentos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var clieDoc = await _clientDocumentTypeServices.GetById(id);
            var clieDocDto = _mapper.Map<ClientDocumentTypeDTO>(clieDoc);
            var response = new GenericResponse<ClientDocumentTypeDTO>(clieDocDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para Crear Clientes por tipo de documentos
        /// </summary>
        /// <param name="clieDocDto"></param>
        /// <returns>Ok</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientDocumentTypeDTO clieDocDto)
        {
            var clieDoc = _mapper.Map<ClientDocumentType>(clieDocDto);
            await _clientDocumentTypeServices.Add(clieDoc);
            clieDocDto = _mapper.Map<ClientDocumentTypeDTO>(clieDoc);

            var response = new GenericResponse<ClientDocumentTypeDTO>(clieDocDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para actualizar Clientes por tipo de documentos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clieDocDto"></param>
        /// <returns>Ok</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, ClientDocumentTypeDTO clieDocDto)
        {
            try
            {
                var clieDoc = _mapper.Map<ClientDocumentType>(clieDocDto);
                clieDoc.ClientDocumentType_Id = id;

                await _clientDocumentTypeServices.Update(clieDoc);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }
        }

        /// <summary>
        /// Metodo para Eliminar Clientes por tipo de documentos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientDocumentTypeServices.Delete(id);
            var response = new GenericResponse<bool>(true);
            return Ok(response);
        }
    }
}
