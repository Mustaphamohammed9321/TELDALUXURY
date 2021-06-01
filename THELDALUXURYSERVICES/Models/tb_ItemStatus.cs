using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Models
{
    public class tb_ItemStatus
    {
        public int ItemId { get; set; }
        public string Item { get; set; }
        public Nullable<int> ItemStatus { get; set; }
    }
}
