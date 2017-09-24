using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Categories
{
    public class CategoriesAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Categories";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(null, "categorias/delete/{id}", new { action = "Delete", controller = "Category" });
            context.MapRoute(null, "categorias/edit/{id}", new { action = "Edit", controller = "Category", id = UrlParameter.Optional });
            context.MapRoute(null, "categorias/add", new { action = "Edit", controller = "Category" });
            context.MapRoute(null, "categorias/{id}", new { action = "Detail", controller = "Category" });
            context.MapRoute(null, "categorias", new { action = "Index", controller = "Category" });
        }
    }
}