using System.Web;

namespace Kuntur.Framework.Kernel.Constants
{
    public enum UrlType
    {
        Category,
        Member,
        Tag
    }
    public static class UrlTypes
    {
        


        public static string GenerateFileUrl(string filePath)
        {
            return VirtualPathUtility.ToAbsolute(filePath);
        }
    }
}