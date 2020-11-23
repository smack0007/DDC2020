using System;
using System.Linq;
using TodoApi.Models.Entities;

namespace TodoApi.Repositories
{
    public interface ITodoRepository
    {
        TodoEntity Add(TodoEntity toAdd);
        
        int Count();
        void Delete(TodoEntity toDelete);
        
        IQueryable<TodoEntity> GetAll(bool? done);
        
        TodoEntity GetById(Guid id);
        
        bool Save();

        TodoEntity Update(TodoEntity toUpdate);
    }
}