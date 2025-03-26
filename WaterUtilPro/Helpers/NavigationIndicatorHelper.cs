using Microsoft.AspNetCore.Mvc;

namespace WaterUtilPro.Helpers
{
    public static class NavigationIndicatorHelper
    {
        public static string MakeActiveClass(this IUrlHelper urlHelper, string page, string route)
        {
            try
            {
                string result = "active";
                var pageName = urlHelper.ActionContext.RouteData.Values["page"]!.ToString();
                //var routeName = urlHelper.ActionContext.RouteData.Values["route"]!.ToString();
                if (string.IsNullOrEmpty(pageName)) return null!;

                if (pageName.Contains(page, StringComparison.OrdinalIgnoreCase))
                {
                    return result;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
