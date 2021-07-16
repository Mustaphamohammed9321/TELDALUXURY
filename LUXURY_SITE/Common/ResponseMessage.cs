using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUXURY_SITE
{
    public class ResponseMessage
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        //public T Data { get; set; }
        public ResponseMessage()
        {
            Time = DateTime.Now;
        }
    }
}
