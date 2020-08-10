
namespace IADocumentClassifier.API.Controllers
{
    using AutoMapper;
    using IADocumentClassifier.API.Responses;
    using IADocumentClassifier.Cors.DTOs;
    using IADocumentClassifier.Cors.Entities;
    using IADocumentClassifier.Cors.Exceptions;
    using IADocumentClassifier.Cors.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static IADocumentClassifier.Cors.Exceptions.MessageHandlercs;

    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagServices _tagsServices;
        private readonly IMapper _mapper;

        /// <summary>
        /// constructor de la clase
        /// </summary>
        /// <param name="tagServices"></param>
        /// <param name="mapper"></param>
        public TagsController(ITagServices tagServices, IMapper mapper)
        {
            _tagsServices = tagServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para consultar todos los Tags
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tagsServices.GetAll();
            var tagsDto = _mapper.Map<IEnumerable<TagDTO>>(tags);
            var response = new GenericResponse<IEnumerable<TagDTO>>(tagsDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para consultar especificamente un Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTag(int id)
        {
            var tag = await _tagsServices.GetByIdTag(id);
            var tagDto = _mapper.Map<TagDTO>(tag);
            var response = new GenericResponse<TagDTO>(tagDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para crear Tag
        /// </summary>
        /// <param name="tagDto"></param>
        /// <returns>Ok</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TagDTO tagDto)
        {
            var tag = _mapper.Map<Tags>(tagDto);
            await _tagsServices.Add(tag);
            tagDto = _mapper.Map<TagDTO>(tag);

            var response = new GenericResponse<TagDTO>(tagDto);
            return Ok(response);
        }

        /// <summary>
        /// Metodo para actualizar Tag
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tagDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, TagDTO tagDto)
        {
            try
            {
                var tag = _mapper.Map<Tags>(tagDto);
                tag.Tag_Id = id;

                await _tagsServices.Update(tag);
                var response = new GenericResponse<bool>(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new BusinessException(MessageCodes.PROPERTY_NO_VALID, GetErrorDescription(MessageCodes.PROPERTY_NO_VALID), ex.Message);
            }

        }

        /// <summary>
        /// Metodo para remover Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagsServices.Delete(id);
            var response = new GenericResponse<bool>(true);
            return Ok(response);
        }
    }
}
