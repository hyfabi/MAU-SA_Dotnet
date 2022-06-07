using Bogus;
using Grasmaster.Infrastructure.Context;
using Grasmaster.Infrastructure.Models;

namespace Grasmaster.Infrastructure.Services
{
	/// <summary>Seeding Service</summary>
	public class SeedingService
	{
		private ApplicationDbContext _applicationContext;
		private Faker _faker;

		public SeedingService(ApplicationDbContext applicationContext)
		{
			_applicationContext = applicationContext;
			_faker = new Faker("en");
		}

		public void CreateProducts(uint cout, bool saveAfter)
		{
			for (int i = 0; i < cout; i++)
			{
				_applicationContext.Products.Add(
					new(null)
					{
						Name = _faker.Commerce.ProductName(),
						Description = _faker.Commerce.ProductDescription()
					}
				);
			}
			if (saveAfter)
				_applicationContext.SaveChanges();
		}

		public void CreateUser(uint cout, bool saveAfter)
		{
			for (int i = 0; i < cout; i++)
			{
				_applicationContext.User.Add(
					new(null, _faker.Name.FirstName())
					{
						Address = new()
						{
							City = _faker.Address.City(),
							Country = _faker.Address.Country(),
							Street = _faker.Address.StreetAddress()
						}
					}
				);
			}
			if(saveAfter)
				_applicationContext.SaveChanges();
		}

		public void MockUp()
		{
			CreateProducts(20, false);
			CreateUser(5, false);
		}
	}
}
