using Dapper;
using Data.Model;
using Data.Repositories.Interface;
using Data.ViewModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ConnectionString _connectionString;
        public UserRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        public int Create(UserVM userVM)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@paramUserName", userVM.UserName);
                parameters.Add("@paramPassword", userVM.Password);
                var result = conn.Execute("SP_InsertDataUsers", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public int Delete(int Id)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@paramId", Id);
                var result = conn.Execute("SP_DeleteDataUsers", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<User>> Get()
        {
            const string query = "SP_GetIsDelUserIdToDoList";
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.QueryAsync<User>(query);
                return result;
            }
        }

        public async Task<IEnumerable<User>> Get(int id)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@paramId", id);
                var result = await conn.QueryAsync<User>("SP_GetbyIdUsers", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public User Login(UserVM userVM)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@paramUserName", userVM.UserName);
                parameters.Add("@paramPassword", userVM.Password);
                var result = conn.Query<User>("SP_Login", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;
            }
        }

        public int Update(int Id, UserVM userVM)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@paramId", Id);
                parameters.Add("@paramUserName", userVM.UserName);
                parameters.Add("@paramPassword", userVM.Password);
                var result = conn.Execute("SP_UpdateDataUsers", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
