using ASF.Framework.Localization.Kernel.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ASF.Framework.Data
{
    public partial interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Commit(List<string> cacheStartsWithToClear, ICacheService cacheService);
        void Rollback();
        void SaveChanges();
    }
}
