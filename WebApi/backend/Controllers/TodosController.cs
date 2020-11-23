using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TodoApi.Models.Dtos;
using TodoApi.Models.Entities;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRespository;
        private readonly IMapper _mapper;

        public TodosController(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRespository = todoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll(bool? done)
        {
            var entities = _todoRespository.GetAll(done);
            var dtos = entities.Select(x => _mapper.Map<TodoDto>(x));

            return Ok(dtos);
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetById))]
        public ActionResult<TodoDto> GetById(Guid id)
        {
            var entity = _todoRespository.GetById(id);

            if (entity == null)
                return NotFound();

            return Ok(_mapper.Map<TodoDto>(entity));
        }

        [HttpPost]
        public ActionResult Add([FromBody] TodoCreateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var entity = _mapper.Map<TodoEntity>(dto);
            entity.Created = DateTime.Now;

            var newEntity = _todoRespository.Add(entity);

            bool success = _todoRespository.Save();

            if (!success)
                throw new Exception("Adding an item failed on save.");

            return CreatedAtRoute(
                nameof(GetById),
                new { id = newEntity.Id },
                _mapper.Map<TodoDto>(entity));
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<TodoDto> Update(Guid id, [FromBody] TodoUpdateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var entity = _todoRespository.GetById(id);

            if (entity == null)
                return NotFound();

            _mapper.Map(dto, entity);

            var updatedEntity = _todoRespository.Update(entity);

            if (!_todoRespository.Save())
                throw new Exception("Update item failed on save.");

            var updatedDto = _mapper.Map<TodoDto>(updatedEntity);

            return Ok(updatedDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<TodoDto> Delete(Guid id)
        {
            var entity = _todoRespository.GetById(id);

            if (entity == null)
                return NotFound();

            _todoRespository.Delete(entity);

            if (!_todoRespository.Save())
                throw new Exception("Delete item failed on save.");

            return NoContent();
        }
    }
}
