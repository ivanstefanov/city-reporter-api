using DataBase;
using DataBase.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DbProv
{
    public class UserContext : IDb<UserDbModel, int>
    {
        private readonly AppDbContext _appDbContext;

        public UserContext()
        {
            _appDbContext = new AppDbContext();
        }

        public async Task Create(UserDbModel entity)
        {
            if (entity is null)
            {
                throw new Exception("Entity was null");
            }
            await _appDbContext.UserDbModels.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<UserDbModel> Read(int key, bool useNavigationalProperties = false, bool isReadOnlyTrue = true)
        {
            UserDbModel userFromDb = await _appDbContext.UserDbModels.FirstOrDefaultAsync(x => x.Id == key);

            if (userFromDb == null)
            {
                throw new Exception("Theres no such Users with that Id!");
            }
            return userFromDb;
        }

        public async Task<List<UserDbModel>> ReadAll(bool useNavigationalProperties = false, bool isReadOnlyTrue = true)
        {
            List<UserDbModel> usersFromDb = await _appDbContext.UserDbModels.ToListAsync();
            return usersFromDb;
        }

        public async Task Update(UserDbModel entity, bool useNavigationalProperties = false)
        {
            UserDbModel userFromDb = await Read(entity.Id);

            userFromDb.Name = entity.Name;
            userFromDb.Email = entity.Email;
            userFromDb.Password = entity.Password;
            userFromDb.Role = entity.Role;

            _appDbContext.UserDbModels.Update(userFromDb);
            _appDbContext.SaveChangesAsync();
        }

        public Task Delete(int key)
        {
            throw new NotImplementedException();
        }
    }
}
