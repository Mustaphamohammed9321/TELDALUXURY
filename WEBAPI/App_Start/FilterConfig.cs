using System.Web;
using System.Web.Mvc;

namespace DAPPER_WEBAPI_TELDA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
