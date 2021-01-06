using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OWN.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavViewComponent : ViewComponent
    {
        //private readonly ToDoContext db;

        //public SideBarNavViewComponent(ToDoContext context)
        //{
        //    db = context;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = GetItemsAsync();
            return View(items);
        }
        private List<SideBarNavVM> GetItemsAsync()
        {
            var items = new List<SideBarNavVM>();
            items.Add(new SideBarNavVM
            {
                Name = "Home",
                DisplayName = "Home",
                Url = "/"
            });
            items.Add(new SideBarNavVM
            {
                Name = "Paging",
                DisplayName = "Paging",
                Url = "/Paging"
            });
            var dropItems = new SideBarNavVM
            {
                Name = "Demo",
                DisplayName = "Demo",
                Url = "",
                IsFolder = true,
                SubItems = new List<SideBarNavVM>()
            };
            dropItems.SubItems.Add(new SideBarNavVM
            {
                Name = "Paging",
                DisplayName = "Paging",
                Url = "/Paging"
            });            

            items.Add(dropItems);
            return items;
            //return db.ToDo.Where(x => x.IsDone == isDone &&
            //                     x.Priority <= maxPriority).ToListAsync();
        }
    }
}
