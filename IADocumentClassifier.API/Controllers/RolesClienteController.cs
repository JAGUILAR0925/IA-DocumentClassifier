
namespace IADocumentClassifier.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using IADocumentClassifier.API.Responses;
    using IADocumentClassifier.Cors.DTOs;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Exceptions;
    using IADocumentClassifier.Cors.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using static IADocumentClassifier.Cors.Exceptions.MessageHandlercs;

    [Route("api/[controller]")]
    [ApiController]
    public class RolesClienteController : ControllerBase
    {
        private readonly IRolesClientServices  _rolesClientServices;
        private readonly IMapper _mapper;

        public RolesClienteController(IRolesClientServices rolesClientServices, IMapper mapper)
        {
            _rolesClientServices = rolesClientServices;
             _mapper = mapper;
        }

        /// <summary>
        /// Metodo para consultar todos los roles clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rolesclie = await _rolesClientServices.GetAll();
            var rolespermDto = _mapper.Map<IEnumerable<RolesClientDTO>>(rolesclie);
            var response = new GenericResponse<IEnumerable<RolesClientDTO>>(rolespermDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para consultar por roles clientes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rolespermi = await _rolesClientServices.GetById(id);
            var rolespermDto = _mapper.Map<RolesClientDTO>(rolespermi);
            var response = new GenericResponse<RolesClientDTO>(rolespermDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para crear roles clientes
        /// </summary>
        /// <param name="rolesclieDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolesClientDTO rolesclieDto)
        {
            var rolecli = _mapper.Map<RolesClient>(rolesclieDto);
            await _rolesClientServices.Add(rolecli);
            rolesclieDto = _mapper.Map<RolesClientDTO>(rolecli);

            var response = new GenericResponse<RolesClientDTO>(rolesclieDto);
            return Ok(response);
        }


        /// <summary>
        /// Metodo para actualizar roles clientes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rolecliDto"></param>
        /// <returns>Ok</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, RolesClientDTO rolecliDto)
        {
            try
            {
                var rolecli = _mapper.Map<RolesClient>(rolecliDto);
                rolecli.RolesClient_Id = id;

                await _rolesClientServices.Update(rolecli);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }
        }

        /// <summary>
        /// Metodo para remover los roles clientes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolesClientServices.Delete(id);
            var response = new GenericResponse<bool>(true);
            return Ok(response);
        }
    }
}
