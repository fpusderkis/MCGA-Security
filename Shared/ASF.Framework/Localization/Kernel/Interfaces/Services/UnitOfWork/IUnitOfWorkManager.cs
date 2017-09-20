using System;

namespace Kuntur.Framework.Kernel.Interfaces.Services.UnitOfWork
{
    public partial interface IUnitOfWorkManager : IDisposable
    {
        //IUnitOfWork NewUnitOfWork(bool isReadyOnly);     
        IUnitOfWork NewUnitOfWork();
    }
}
