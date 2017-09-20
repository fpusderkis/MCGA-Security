using System;
using System.Collections.Generic;
using Kuntur.Framework.Model.General;

namespace Kuntur.Framework.Kernel.Interfaces.Services
{
    public partial interface ILoggingService
    {
        void Error(string message);
        void Error(Exception ex);
        void Initialise(int maxLogSize);
        IList<LogEntry> ListLogFile();
        void Recycle();
        void ClearLogFiles();
    }
}
