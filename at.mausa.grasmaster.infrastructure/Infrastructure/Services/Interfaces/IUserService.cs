using Grasmaster.Infrastructure.Models;

namespace Grasmaster.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        public IReadOnlyList<User> GetUsers();
        public User CreateUser(User user);
        public User UpdateUser(User user);
        public User DeleteUser(User user);
    }
}
