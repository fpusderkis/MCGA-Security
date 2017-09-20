using System.Web;
using Kuntur.Framework.Kernel.Constants;
using NPoco;

namespace Kuntur.Framework.Kernel.Data.NPoco
{
    internal static class ContextPerRequest
    {
        internal static IDatabase Current
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(SiteConstants.Instance.MvcKunturContext))
                {
                    HttpContext.Current.Items.Add(SiteConstants.Instance.MvcKunturContext, new Database(SiteConstants.Instance.MvcKunturContext));
                }
                return HttpContext.Current.Items[SiteConstants.Instance.MvcKunturContext] as IDatabase;
            }
        }
    }
}
