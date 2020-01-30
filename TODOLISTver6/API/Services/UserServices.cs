using API.Services.Interface;
using Data.Model;
using Data.Repositories.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int Create(UserVM userVM)
        {
            return _userRepository.Create(userVM);
        }

        public int Delete(int Id)
        {
            return _userRepository.Delete(Id);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _userRepository.Get();
        }

        public async Task<IEnumerable<User>> Get(int Id)
        {
            return await _userRepository.Get(Id);
        }

        public User Login(UserVM userVM)
        {
            return _userRepository.Login(userVM);
        }

        public int Update(int Id, UserVM userVM)
        {
            return _userRepository.Update(Id, userVM);
        }
    }
}
