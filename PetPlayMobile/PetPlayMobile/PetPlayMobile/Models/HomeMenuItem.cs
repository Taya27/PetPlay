using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayMobile.Models
{
    public enum MenuItemType
    {
        Pets,
        Toys,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
