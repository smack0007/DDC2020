using AutoMapper;
using TodoApi.Models;
using TodoApi.Models.Dtos;
using TodoApi.Models.Entities;

namespace TodoApi.Mappings
{
    public class TodoMappings : Profile
    {
        public TodoMappings()
        {
            CreateMap<TodoEntity, TodoCreateDto>().ReverseMap();
            CreateMap<TodoEntity, TodoDto>().ReverseMap();
            CreateMap<TodoEntity, TodoUpdateDto>().ReverseMap();
        }
    }
}
