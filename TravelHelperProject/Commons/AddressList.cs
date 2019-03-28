using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Models;

namespace TravelHelperProject.Commons
{
    public class AddressList: IAddressList
    {
        private TravelHelperContext _travelHelperContext;
        public AddressList(TravelHelperContext travelHelperContext)
        {
            _travelHelperContext = travelHelperContext;
        }
        public List<string> GetListAddresses()
        {
            List<string> listAddress = new List<string>();
            var countryList = _travelHelperContext.Countries
                .Include(s => s.Cities)
                .ToList();
            foreach (Country country in countryList)
            {
                foreach (City city in country.Cities)
                {
                    string item = city.Name + ", " + country.Name;
                    listAddress.Add(item);
                }
            }
            return listAddress;
        }

    }
}
