using Grasmaster.Infrastructure.Context;
using Grasmaster.Infrastructure.Models;
using Grasmaster.Services.Interfaces;

namespace Grasmaster.Services
{
    public class UserService : IUserService
    {
        ApplicationContext Context { get; init; }

        public UserService(ApplicationContext context) => Context = context ?? throw new ArgumentNullException("ApplicationContext context is null!");

        public Task AddUser(User user)
        {
            return Context.User.AddAsync(user).AsTask();
        }

        public void RemoveUser(User user)
        {
            Context.User.Remove(user);
        }

        public Task FindUserById(Guid guid)
        {
            return Context.User.FindAsync(guid).AsTask();
        }

        public IReadOnlyList<User> GetAllUser()
        {
            return Context.User.ToList().AsReadOnly();
        }

        public void UpdateUser(User user)
        {
            Context.User.Update(user);
        }
    }
}
