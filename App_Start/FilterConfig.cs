using System.Web;
using System.Web.Mvc;

namespace Online_Story_Maker_Sridhar
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
