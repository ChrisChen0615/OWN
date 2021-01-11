using Microsoft.AspNetCore.Mvc;
using OWN.Repository.Paging;
using OWN.Repository.Tables;
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

        //public async Task<IActionResult> Address(int? pageNumber)
        //{
        //    var data = await _address.GetAll(pageNumber);
        //    return PartialView("TestAddress", data);
        //}
        public async Task<IActionResult> Address(int? pageNumber)
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

            // Skip number of Rows count  
            var start = Request.Form["start"].FirstOrDefault();

            // Paging Length 10,20  
            var length = Request.Form["length"].FirstOrDefault();

            // Sort Column Name  
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            // Sort Column Direction (asc, desc)  
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            // Search Value from (Search box)  
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10, 20, 50,100)  
            int pageSize = length != null ? Convert.ToInt32(length) : 0;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            int recordsTotal = 0;

            var query = await _address.GetAll(pageNumber);

            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //{
            //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
            //}
            ////Search  
            //if (!string.IsNullOrEmpty(searchValue))
            //{
            //    customerData = customerData.Where(m => m.Name == searchValue);
            //}

            //total number of rows counts   
            recordsTotal = query.Count();
            //Paging   
            var data = query.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data  
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            //var data = await _address.GetAll(pageNumber);
            //return data;
        }
    }
}
