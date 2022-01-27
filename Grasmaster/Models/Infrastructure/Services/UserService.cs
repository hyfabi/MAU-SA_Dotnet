using Grasmaster.Infrastructure.Context;
using Grasmaster.Infrastructure.Models;
using Grasmaster.Infrastructure.Services.Interfaces;

using System.Linq;

namespace Grasmaster.Infrastructure.Services
{
	public class UserService : IUserService
	{
		private ApplicationDbContext _applicationDbContext;

		public UserService(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public User CreateUser(User user)
		{
			if (_applicationDbContext.User.Contains(user))
				throw new ArgumentException("User already found");

			User u = _applicationDbContext.User.Add(user).Entity;
			_applicationDbContext.SaveChanges();
			return u;
		}

		public User DeleteUser(User user)
		{
			if (!_applicationDbContext.User.Contains(user))
				throw new ArgumentException("User not found");

			User u = _applicationDbContext.User.Remove(user).Entity;
			_applicationDbContext.SaveChanges();
			return u;
		}

		public IReadOnlyList<User> GetUsers()
		{
			return _applicationDbContext.User.ToList();
		}

		public User UpdateUser(User user)
		{
			if (!_applicationDbContext.User.Contains(user))
				throw new ArgumentException("User not found");

			User u = _applicationDbContext.User.Update(user).Entity;
			_applicationDbContext.SaveChanges();
			return u;
		}
	}
}
