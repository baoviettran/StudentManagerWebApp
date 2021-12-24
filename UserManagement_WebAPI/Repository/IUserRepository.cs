using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement_WebAPI.Models;

namespace UserManagement_WebAPI.Repository
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int userID);
        User GetUserByAccount(string email, string password);
        void InsertUser(User user);
        void DeleteUser(int userID);
        void UpdateUser(User user);
        bool ExistUser(int userID);
        void Save();
    }
}
