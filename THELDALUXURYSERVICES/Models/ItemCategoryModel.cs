using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Models
{
    public class ItemCategoryModel
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public Nullable<int> ItemId { get; set; }
    }
}
