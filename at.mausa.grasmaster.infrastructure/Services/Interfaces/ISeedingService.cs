using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace At.Mausa.Grasmaster.Infrastructure.Services.Interfaces; 
public interface ISeedingService {
    public void CreateProducts(uint cout, bool saveAfter);
    public void CreateUser(uint cout, bool saveAfter);
}
