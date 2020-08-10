

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
    public class SetupController : ControllerBase
    {
        private readonly ISetupServices _setupServices;
       private readonly IMapper _mapper;

        public SetupController(ISetupServices setupServices, IMapper mapper)
        {
            _setupServices = setupServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para consultar las configuraciones
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var setup = await _setupServices.GetAll();
            var setupDto = _mapper.Map<IEnumerable<SetupDTO>>(setup);
            var response = new GenericResponse<IEnumerable<SetupDTO>>(setupDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para consultar por configuración
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var setup = await _setupServices.GetById(id);
            var setupDto = _mapper.Map<SetupDTO>(setup);
            var response = new GenericResponse<SetupDTO>(setupDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para crear configuraciones
        /// </summary>
        /// <param name="setupDto"></param>
        /// <returns>Ok</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SetupDTO setupDto)
        {
            var setup = _mapper.Map<Setup>(setupDto);
            await _setupServices.Add(setup);
            setupDto = _mapper.Map<SetupDTO>(setup);

            var response = new GenericResponse<SetupDTO>(setupDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para Actualizar configuraciones
        /// </summary>
        /// <param name="id"></param>
        /// <param name="setupDto"></param>
        /// <returns>Ok</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, SetupDTO setupDto)
        {
            try
            {
                var setup = _mapper.Map<Setup>(setupDto);
                setup.Setup_Id = id;

                await _setupServices.Update(setup);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }
        }

        /// <summary>
        /// Metodo para remover configuraciones
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _setupServices.Delete(id);
            var response = new GenericResponse<bool>(true);
            return Ok(response);
        }
    }
}
