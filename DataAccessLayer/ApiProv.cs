using DataAccessLayer.DbProv;
using DataBase.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ApiProv
    {
        private readonly UserContext _userContext;

        public ApiProv(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task CreateUser(UserModel user)
        {
            if (user == null)
            {
                throw new Exception("user was null");
            }

            UserDbModel newUser = new UserDbModel(user.Name, user.Email, user.Password, user.Role);
            await _userContext.Create(newUser);
        }

        public async Task<UserModel> ReadUser(int key)
        {
            UserDbModel userFromDb = await _userContext.Read(key);
            UserModel user = new()
            {
                Id = userFromDb.Id,
                Name = userFromDb.Name,
                Email = userFromDb.Email,
                Password = userFromDb.Password,
                Role = userFromDb.Role
            };
            return user;

        }

        public async Task<List<UserModel>> ReadAllUsers()
        {
            List<UserDbModel> usersFromDb = await _userContext.ReadAll();
            List<UserModel> users = new List<UserModel>();

            users = usersFromDb.Select(x => new UserModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                Role = x.Role
            }).ToList();
            return users;
        }

        public async Task UpdateUser(UserModel user)
        {
            UserDbModel userToBeUpdated = new UserDbModel(user.Name, user.Email, user.Password, user.Role);
            await _userContext.Update(userToBeUpdated);
        }
        public async Task DeleteUser(int key)
        {
            await _userContext.Delete(key);
        }
    }
}
