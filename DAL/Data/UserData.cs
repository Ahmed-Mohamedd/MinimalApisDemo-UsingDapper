using DAL.DbAccess;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db=db;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _db.LoadData<User, dynamic>("dbo.spUser_GetAll", new { });
        }

        public async Task<User?> GetUser(int id)
        {
            var result = await _db.LoadData<User, dynamic>("dbo.spUser_Get", new { id = id });
            return result.FirstOrDefault();
        }

        public async Task InsertUser(User user)
        {
            await _db.SaveData("dbo.spUser_insert", new { user.first_name, user.last_name });
        }

        public async Task UpdateUser(User user)
        {
            await _db.SaveData("dbo.spUser_Update", user);
        }

        public async Task DeleteUser(int id)
        {
            await _db.SaveData("dbo.spUser_Delete", new { id = id });
        }

    }
}
