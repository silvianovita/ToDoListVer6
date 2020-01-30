using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interface
{
    public interface IToDoListServices
    {
        Task<IEnumerable<ToDoList>> Get();
        Task<IEnumerable<ToDoListVM>> GetTodoLists(int userId,int status);
        Task<IEnumerable<ToDoList>> Get(int Id);
        int Create(ToDoListVM toDoListVM);
        int Update(int id, ToDoListVM toDoListVM);
        int Delete(int id);
        int UpdateCheckedTodoList(int Id);
        int updateUncheckedTodolist(int Id);
    }
}
