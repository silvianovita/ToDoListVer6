using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<ToDoList>> Get();
        Task<IEnumerable<ToDoListVM>> GetTodoLists(int userId, int status);
        Task<IEnumerable<ToDoList>> Get(int Id);
        int Create(ToDoListVM toDoListVM);
        int Update(int Id, ToDoListVM toDoListVM);
        int Delete(int Id);
        int UpdateCheckedTodoList(int Id);
        int updateUncheckedTodolist(int Id);
    }
}
