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
            var dropItems = new SideBarNavVM
            {
                Name = "下拉選單",
                DisplayName = "下拉選單",
                Url = "",
                IsFolder = true,
                SubItems = new List<SideBarNavVM>()
            };
            dropItems.SubItems.Add(new SideBarNavVM
            {
                Name = "Address List",
                DisplayName = "Address List",
                Url = "/Home/Address"
            });            
            var dropItems2 = new SideBarNavVM
            {
                Name = "下拉選單-Lv2",
                DisplayName = "下拉選單-Lv2",
                Url = "",
                IsFolder = true,
                SubItems = new List<SideBarNavVM>()
            };
            dropItems2.SubItems.Add(new SideBarNavVM
            {
                Name = "Address List-Lv2",
                DisplayName = "Address List-Lv2",
                Url = "/Home/Address"
            });
            
            var dropItems3 = new SideBarNavVM
            {
                Name = "下拉選單-Lv3",
                DisplayName = "下拉選單-Lv3",
                Url = "",
                IsFolder = true,
                SubItems = new List<SideBarNavVM>()
            };
            dropItems3.SubItems.Add(new SideBarNavVM
            {
                Name = "Address List-Lv3",
                DisplayName = "Address List-Lv3",
                Url = "/Home/Address"
            });
            dropItems2.SubItems.Add(dropItems3);

            dropItems.SubItems.Add(dropItems2);

            items.Add(dropItems);
            return items;
            //return db.ToDo.Where(x => x.IsDone == isDone &&
            //                     x.Priority <= maxPriority).ToListAsync();
        }
    }
}
