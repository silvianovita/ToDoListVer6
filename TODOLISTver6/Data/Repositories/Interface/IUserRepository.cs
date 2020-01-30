using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<IEnumerable<User>> Get(int id);

        User Login(UserVM userVM);
        int Create(UserVM userVM);
        int Update(int Id, UserVM userVM);
        int Delete(int Id);
    }
}
