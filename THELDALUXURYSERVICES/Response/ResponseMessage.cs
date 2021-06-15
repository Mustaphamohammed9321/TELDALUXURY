using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Response
{
    public class ResponseMessage
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Data2 { get; set; }

        public string LoginToken { get; set; }
    }
}
