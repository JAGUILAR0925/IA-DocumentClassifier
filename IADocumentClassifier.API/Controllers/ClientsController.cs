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
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using static IADocumentClassifier.Cors.Exceptions.MessageHandlercs;

    /// <summary>
    /// ClientsController
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]    
    public class ClientsController : ControllerBase
    {
        private readonly IClientsServices _clientsServices;
        private readonly IMapper _mapper;
        private readonly IUrlServices _urlServices;

        /// <summary>
        /// ClientsController Constructor
        /// </summary>
        /// <param name="clientsServices"></param>
        /// <param name="mapper"></param>
        /// <param name="urlServices"></param>
        public ClientsController(IClientsServices clientsServices,IMapper mapper, IUrlServices urlServices)
        {
            _clientsServices = clientsServices;
            _mapper = mapper;
            _urlServices = urlServices;
        }

        /// <summary>
        ///  Metodo para consultar todos los clientes
        /// </summary>
        /// <returns>ok</returns>
        [HttpGet(Name = nameof(GetAll))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResponse<IEnumerable<Clients>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery]ClientsQueryFilters filters)
        {
           
                var client = await _clientsServices.GetAll(filters);
                var clientDto = _mapper.Map<IEnumerable<ClientsDTO>>(client);
                Metadata metadata = MetadaFill(client);

                var response = new GenericResponse<IEnumerable<ClientsDTO>>(clientDto)
                {
                    meta = metadata
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                return Ok(response);          
        }

        private static Metadata MetadaFill(PagedList<Clients> client)
        {
            var metadata = new Metadata
            {
                TotalCount = client.TotalCount,
                PageSize = client.PageSize,
                CurrentPage = client.CurrentPage,
                TotalPages = client.TotalPages,
                HasNextPage = client.HasNextPage,
                HasPreviousPage = client.HasPreviousPage,
                //NextPageUrl = _urlServices.GetPaginationUri(filters, Url.RouteUrl(Url.ToString())).ToString(),
                //PreviousPageUrl = _urlServices.GetPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString()
            };
            return metadata;
        }

        /// <summary>
        /// Metodo para consultar por clientes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientsServices.GetById(id);
            var clientDto = _mapper.Map<ClientsDTO>(client);
            var response = new GenericResponse<ClientsDTO>(clientDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para crear nuevos clientes
        /// </summary>
        /// <param name="clientDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientsDTO clientDto)
        {             
            try
            {
                var client = _mapper.Map<Clients>(clientDto);
                await _clientsServices.Add(client);
                clientDto = _mapper.Map<ClientsDTO>(client);

                var response = new GenericResponse<ClientsDTO>(clientDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }
           
        }

        /// <summary>
        /// Metodo para actualizar datos de clientes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clientDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, ClientsDTO clientDto)
        {
            try
            {
                var client = _mapper.Map<Clients>(clientDto);
                client.Client_Id = id;
                await _clientsServices.Update(client);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }

        }

        /// <summary>
        /// Metodo para remover clientes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientsServices.Delete(id);
            var response = new GenericResponse<bool>(true);
            return Ok(response);
        }
    }
}
