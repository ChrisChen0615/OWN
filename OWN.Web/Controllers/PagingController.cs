using Microsoft.AspNetCore.Mvc;
using OWN.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OWN.Web.Controllers
{
    public class PagingController : Controller
    {
        private readonly IAddressService _address;

        public PagingController(IAddressService address)
        {
            _address = address;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Address(int? pageNumber)
        {
            var data = await _address.GetAll(pageNumber);
            return PartialView("TestAddress", data);
        }
    }
}
