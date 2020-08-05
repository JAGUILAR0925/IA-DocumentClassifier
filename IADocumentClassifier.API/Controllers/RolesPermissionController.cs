
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
    public class RolesPermissionController : ControllerBase
    {
        private readonly IRolesPermissionServices _rolesPermissionServices;
        private readonly IMapper _mapper;
        public RolesPermissionController(IRolesPermissionServices rolesPermissionServices, IMapper mapper)
        {
            _rolesPermissionServices = rolesPermissionServices;
            _mapper = mapper;
        }
        /// <summary>
        /// Metodo para consultar todos los roles por permisos
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rolespermi = await _rolesPermissionServices.GetAll();
            var rolespermDto = _mapper.Map<IEnumerable<RolesPermissionDTO>>(rolespermi);
            var response = new GenericResponse<IEnumerable<RolesPermissionDTO>>(rolespermDto);
            return Ok(response);
        }
        /// <summary>
        /// Metodo para consultar por roles por permisos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rolespermi = await _rolesPermissionServices.GetById(id);
            var rolespermDto = _mapper.Map<RolesPermissionDTO>(rolespermi);
            var response = new GenericResponse<RolesPermissionDTO>(rolespermDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para crear roles por permisos
        /// </summary>
        /// <param name="rolesperDto"></param>
        /// <returns>Ok/returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolesPermissionDTO rolesperDto)
        {
            var roleper = _mapper.Map<RolesPermission>(rolesperDto);
            await _rolesPermissionServices.Add(roleper);
            rolesperDto = _mapper.Map<RolesPermissionDTO>(roleper);

            var response = new GenericResponse<RolesPermissionDTO>(rolesperDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para actualizar roles permisos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleperDto"></param>
        /// <returns>Ok</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, RolesPermissionDTO roleperDto)
        {
            try
            {
                var roleper = _mapper.Map<RolesPermission>(roleperDto);
                roleper.RolPermission_Id = id;

                await _rolesPermissionServices.Update(roleper);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }
        }

        /// <summary>
        /// Metodo para borrar roles permisos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolesPermissionServices.Delete(id);
            var response = new GenericResponse<bool>(true);
            return Ok(response);
        }
    }
}
