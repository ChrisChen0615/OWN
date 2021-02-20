using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OWN.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavViewComponent : ViewComponent
    {
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
        }
    }
}
