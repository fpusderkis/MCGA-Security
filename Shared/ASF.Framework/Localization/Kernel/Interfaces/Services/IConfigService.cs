using System.Collections.Generic;
using System.Collections.Specialized;

namespace Kuntur.Framework.Kernel.Interfaces.Services
{

    public partial interface IConfigService
    {
        Dictionary<string, string> GetKunturConfig();
        Dictionary<string, string> GetTypes();
    }
}
