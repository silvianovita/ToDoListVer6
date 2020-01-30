using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interface
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> Get();
        Task<IEnumerable<User>> Get(int Id);

        User Login(UserVM userVM);
        int Create(UserVM userVM);
        int Update(int Id, UserVM userVM);
        int Delete(int Id);
    }
}
