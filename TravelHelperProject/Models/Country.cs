using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class Country
    {
        public int  CountryId { get; set; }
        public string Name { get; set; }
        public ICollection<City> States { get; set; }
    }
}
