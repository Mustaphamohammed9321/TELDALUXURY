using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Models
{
    public class ErrorLogModel
    {
        public int logId { get; set; }
        public string Error { get; set; }
        public string ErrorMessage { get; set; }
        public Nullable<System.DateTime> DateandTime { get; set; }
    }
}
