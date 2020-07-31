

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

    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesServices  _rolesServices;
        private readonly IMapper _mapper;
        /// <summary>
        /// metodo para la inyeccion de dependencias mediante el contructor
        /// </summary>
        /// <param name="rolesServices"></param>
        /// <param name="mapper"></param>
        public RolesController(IRolesServices rolesServices, IMapper mapper)
        {
            _rolesServices = rolesServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para consultar todos los tipos de documentos
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var role = await _rolesServices.GetAll();
            var roleDto = _mapper.Map<IEnumerable<RolesDTO>>(role);
            var response = new GenericResponse<IEnumerable<RolesDTO>>(roleDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para consultar por Roles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _rolesServices.GetById(id);
            var roleDto = _mapper.Map<RolesDTO>(role);
            var response = new GenericResponse<RolesDTO>(roleDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para crear Roles
        /// </summary>
        /// <param name="rolesDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolesDTO rolesDto)
        {
            var role = _mapper.Map<Roles>(rolesDto);
            await _rolesServices.Add(role);
            rolesDto = _mapper.Map<RolesDTO>(role);

            var response = new GenericResponse<RolesDTO>(rolesDto);
            return Ok(response);
        }
        /// <summary>
        /// Metodo para actulizar Roles
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rolesDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, RolesDTO rolesDto)
        {
            try
            {
                var roles = _mapper.Map<Roles>(rolesDto);
                roles.Rol_Id = id;

                await _rolesServices.Update(roles);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para Eliminar o borrar Roles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolesServices.Delete(id);
            var response = new GenericResponse<bool>(true);
            return Ok(response);
        }
    }
}
