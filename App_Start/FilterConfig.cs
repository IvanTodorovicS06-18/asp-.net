using System.Web;
using System.Web.Mvc;

namespace Rvas_ispit_projekat
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // ne dozvoljava pristup stranici ukuliko nema auth
            filters.Add(new AuthorizeAttribute());
        }
    }
}
