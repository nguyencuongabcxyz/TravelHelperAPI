using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Models;

namespace TravelHelperProject.Infrastructure
{
    public interface IDbFactory
    {
        TravelHelperContext Init();
    }
}
