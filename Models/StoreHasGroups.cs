using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieHunterProject.Models
{
    public class StoreHasGroups
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int GroupACategoryId { get; set; }
        public int GroupBCategoryId { get; set; }
        public int GroupCCategoryId { get; set; }
    }
}