using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieHunterProject.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public int StandardCategoryId { get; set; }
    }
}