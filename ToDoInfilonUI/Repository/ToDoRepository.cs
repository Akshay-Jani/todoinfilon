using System.Collections.Generic;
using System.Linq;
using ToDoInfilonUI.Models.DB;
using ToDoInfilonUI.Repository.Interface;

namespace ToDoInfilonUI.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoInfilonContext _context;

        public ToDoRepository(ToDoInfilonContext context)
        {
            _context = context;
        }

        public ToDo GetItem(int itemId)
        {
            return _context.ToDo.Find(itemId);
        }

        public List<ToDo> GetToDos(int userId)
        {
            var list = _context.ToDo.Where(x => x.UserId == userId).ToList();
            return list;
        }

        public void UpdateItem(ToDo toDo)
        {
            var entry = _context.ToDo.Update(toDo);
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                _context.SaveChanges();
            }
        }
    }
}
