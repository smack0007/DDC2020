using System;
using System.Linq;
using TodoApi.Models.Entities;

namespace TodoApi.Repositories
{
    public class TodoSqlRepository : ITodoRepository
    {
        private TodoDbContext _dbContext;

        public TodoSqlRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;

            //if (_dbContext.TodoItems.Count() == 0)
            //{
            //    _dbContext.TodoItems.Add(new TodoEntity()
            //    {
            //        Id = Guid.NewGuid(),
            //        Created = DateTime.Now,
            //        Value = "Todo Item 1",
            //    });

            //    _dbContext.SaveChanges();
            //}
        }

        public IQueryable<TodoEntity> GetAll(bool? done)
        {
            if (done.HasValue)
            {
                return _dbContext.TodoItems.Where(x => x.Done == done.Value);
            }

            return _dbContext.TodoItems;
        }

        public TodoEntity GetById(Guid id)
        {
            return _dbContext.TodoItems.FirstOrDefault(x => x.Id == id);
        }

        public TodoEntity Add(TodoEntity toAdd)
        {
            _dbContext.TodoItems.Add(toAdd);
            return toAdd;
        }

        public TodoEntity Update(TodoEntity toUpdate)
        {
            _dbContext.TodoItems.Update(toUpdate);
            return toUpdate;
        }

        public void Delete(TodoEntity toDelete)
        {
            _dbContext.TodoItems.Remove(toDelete);
        }

        public int Count()
        {
            return _dbContext.TodoItems.Count();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0;
        }
    }
}
