using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Log
{
    public interface IVuelingLogger
    {
        void Debug(object message);
        void Fatal(object message);
        void Warn(object message);
        void Error(object message);
        void Info(object message);
    }
}
