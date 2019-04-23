using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelHelperProject.Commons;
using TravelHelperProject.Models;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressList _addressList;
        public AddressController(IAddressList addressList)
        {
            _addressList = addressList;
        }
        //GET api/Address/address
        [HttpGet]
        [Route("{address}")]
        public IActionResult GetAddress(string address)
        {
            List<string> listAddress = new List<string>();
            foreach(string i in _addressList.GetListAddresses())
            {
                if (i.Contains(address,StringComparison.OrdinalIgnoreCase))
                {
                    listAddress.Add(i);
                }
            }
            return Ok(listAddress);
        }
        [HttpGet]
        public IActionResult GetAddress()
        {
            return Ok(_addressList.GetListAddresses());
        }

    }
}