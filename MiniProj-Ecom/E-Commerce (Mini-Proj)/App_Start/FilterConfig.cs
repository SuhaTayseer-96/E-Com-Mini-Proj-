using System.Web;
using System.Web.Mvc;

namespace E_Commerce__Mini_Proj_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
