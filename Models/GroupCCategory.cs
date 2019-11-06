using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieHunterProject.Models
{
    public class GroupCCategory
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int StandardCategoryId { get; set; }
        public int Points { get; set; }
        public int PercentOff { get; set; }
    }
}