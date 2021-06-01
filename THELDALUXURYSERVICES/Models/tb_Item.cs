using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Models
{
    public class tb_Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<decimal> ItemPrice { get; set; }
        public Nullable<int> ItemStatusId { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string Photo { get; set; }
    }
}
