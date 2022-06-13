
using At.Mausa.Grasmaster.Domain.Models;

namespace At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;
public interface IUserService
{
    public IReadOnlyList<User> GetUsers();
    public User GetUser(Guid user);
    public User CreateUser(User user);
    public User UpdateUser(Guid guid, User user);
    public User DeleteUser(Guid user);
}
