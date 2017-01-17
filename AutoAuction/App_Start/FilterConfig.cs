using System.Web;
using System.Web.Mvc;

namespace AutoAuction
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());         
        }
    }
}
