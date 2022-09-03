using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib
{
    public class UsersData : IUsersData
    {
        private readonly IDatabaseAccess _db;

        public UsersData(IDatabaseAccess db)
        {
            _db = db;
        }

        public async Task<Users> SelectUser(Users user)
        {
            string sql = @"SELECT * FROM dbo.Users WHERE Email = @Email AND Password = @Password;";

            var list = await _db.LoadData<Users, dynamic>(sql, new Users { Email = user.Email, Password = user.Password });

            return list.FirstOrDefault();
        }

        public async Task<bool> InsertUsers(Users user)
        {
            string sql = @"insert into dbo.Users (Email, Password) values (@Email, @Password);";

            return await _db.SaveData(sql, new Users { Email = user.Email, Password = user.Password });
        }
    }
}
