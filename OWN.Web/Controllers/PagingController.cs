using Microsoft.AspNetCore.Mvc;
using OWN.Service;
using OWN.Service.Paging.Dto;
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

        [HttpPost]
        public JsonResult Address(PagingQueryDto input)
        {
            var data = _address.GetAll(input);
            return Json(data);
        }
    }
}
