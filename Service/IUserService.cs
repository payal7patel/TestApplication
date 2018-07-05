using Data;
using System.Linq;

namespace TestApplication.Service
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        User GetUser(int id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
