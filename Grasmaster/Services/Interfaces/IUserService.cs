using Grasmaster.Infrastructure.Models;

namespace Grasmaster.Services.Interfaces
{
    public interface IUserService
    {
        public IReadOnlyList<User> GetAllUser();
        public Task AddUser(User user);
        public void RemoveUser(User user);
        public Task FindUserById(Guid guid);
        public void UpdateUser(User user);
    }
}
