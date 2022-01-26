using Bogus;

using Grasmaster.Infrastructure.Context;
using Grasmaster.Infrastructure.Models;

namespace Grasmaster.Infrastructure.Services
{
    /// <summary>
    /// Seeding Service
    /// </summary>
    public class SeedingService
    {
        private ApplicationContext _applicationContext;

        private Faker _faker;

        public SeedingService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _faker = new Faker("en");
        }

        public void CreateProducts(uint cout)
        {
            for (int i = 0; i < cout; i++)
            {
                Product p = new Product(null);
                //TODO: Configure anything
                _applicationContext.Products.Add(p);
            }
        }

        public void MockUp()
        {

        }
    }
}
