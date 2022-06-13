using At.Mausa.Grasmaster.Domain.Models;
using At.Mausa.Grasmaster.Infrastructure.Context;
using At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace At.Mausa.Grasmaster.Infrastructure.Services {
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

		public User DeleteUser(Guid user)
		{
			if (!_applicationDbContext.User.Where(u => u.Guid == user).Any())
				throw new ArgumentException("User not found");

			User u = _applicationDbContext.User.Remove(_applicationDbContext.User.Where(u => u.Guid == user).First()).Entity;
			_applicationDbContext.SaveChanges();
			return u;
		}

        public User GetUser(Guid user) {
            if(!_applicationDbContext.User.Where(u => u.Guid == user).Any())
                throw new ArgumentException("User not found");

			return _applicationDbContext.User.Where(u => u.Guid == user).First();
        }

        public IReadOnlyList<User> GetUsers()
		{
			return _applicationDbContext.User.ToList();
		}

		public User UpdateUser(Guid guid, User user)
		{
			if (!_applicationDbContext.User.Where(u => u.Guid == guid).Any())
				throw new ArgumentException("User not found");

			User u = _applicationDbContext.User.Where(u => u.Guid == guid).First();

			u = user;

            _applicationDbContext.SaveChanges();
			return u;
		}
	}
}
