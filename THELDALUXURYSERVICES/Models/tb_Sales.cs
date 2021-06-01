using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Models
{
    public class tb_Sales
    {
        public int SalesId { get; set; }
        public string Item { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}
