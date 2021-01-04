
using System.Collections.Generic;

namespace OWN.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavVM
    {
        //Unique name of the menu in the application.
        public string Name { get; set; }
        //Display name of the menu.
        public string DisplayName { get; set; }

        public string Url { get; set; }

        public bool IsFolder { get; set; }

        public List<SideBarNavVM> SubItems { get; set; }
        ////A custom object related to this menu item.
        //public object CustomData { get; set; }
        ////Menu items (first level).
        //public IList<UserMenuItem> Items { get; set; }
    }
}
