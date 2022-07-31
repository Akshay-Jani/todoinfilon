using System.Collections.Generic;
using ToDoInfilonUI.Models.DB;

namespace ToDoInfilonUI.Repository.Interface
{
    public interface IToDoRepository
    {
        List<ToDo> GetToDos(int userId);
        ToDo GetItem(int itemId);
        void UpdateItem(ToDo toDo);
    }
}
