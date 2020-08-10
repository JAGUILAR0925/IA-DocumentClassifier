
namespace IADocumentClassifier.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using IADocumentClassifier.API.Responses;
    using IADocumentClassifier.Cors.CustomEntities;
    using IADocumentClassifier.Cors.DTOs;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Exceptions;
    using IADocumentClassifier.Cors.Interfaces;
    using IADocumentClassifier.Cors.QueryFilters;
    using IADocumentClassifier.Infrastructure.Interface;
    using AutoMapper;
    using System.Net;
    using static IADocumentClassifier.Cors.Exceptions.MessageHandlercs;

    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionsServices   _permissionsServices;
        private readonly IMapper _mapper;
        /// <summary>
        /// metodo para la inyeccion de dependencias mediante el contructor
        /// </summary>
        /// <param name="permissionsServices"></param>
        /// <param name="mapper"></param>
        public PermissionsController(IPermissionsServices permissionsServices, IMapper mapper)
        {
            _permissionsServices = permissionsServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para consultar todos los permisos
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var perm = await _permissionsServices.GetAll();
            var permDto = _mapper.Map<IEnumerable<PermissionsDTO>>(perm);
            var response = new GenericResponse<IEnumerable<PermissionsDTO>>(permDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para consultar por permisos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var perm = await _permissionsServices.GetById(id);
            var permDto = _mapper.Map<PermissionsDTO>(perm);
            var response = new GenericResponse<PermissionsDTO>(permDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para Crear Permisos
        /// </summary>
        /// <param name="permDto"></param>
        /// <returns>Ok</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermissionsDTO permDto)
        {
            var permiso = _mapper.Map<Permissions>(permDto);
            await _permissionsServices.Add(permiso);
            permDto = _mapper.Map<PermissionsDTO>(permiso);

            var response = new GenericResponse<PermissionsDTO>(permDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para actualizar permisos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permisosDto"></param>
        /// <returns>Ok</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, PermissionsDTO permisosDto)
        {
            try
            {
                var permiso = _mapper.Map<Permissions>(permisosDto);
                permiso.Permissions_Id = id;

                await _permissionsServices.Update(permiso);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }
        }

        /// <summary>
        /// Metodo para remover permisos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _permissionsServices.Delete(id);
            var response = new GenericResponse<bool>(true);
            return Ok(response);
        }
    }
}
