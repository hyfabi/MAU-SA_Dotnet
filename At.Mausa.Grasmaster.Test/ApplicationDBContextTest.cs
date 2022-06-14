using At.Mausa.Grasmaster.Infrastructure.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace At.Mausa.Grasmaster.Test; 
public class ApplicationDBContextTest {
    
    [Fact]
    public async Task Create(){
        ApplicationDbContext applicationDbContext = ProductTest.GetDbContext();
        applicationDbContext.Database.EnsureDeleted();
        await applicationDbContext.Database.EnsureCreatedAsync();
    }
}
