using System;
using Kuntur.Framework.Model.Security;

namespace Kuntur.Framework.Kernel.Interfaces.Services
{
    public partial interface ISettingsService
    {
        Settings GetSettings(bool useCache = true);
        Settings Add(Settings settings);
        Settings Get(Guid id);
    }
}
