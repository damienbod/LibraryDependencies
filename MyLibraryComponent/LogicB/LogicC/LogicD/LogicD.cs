using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibraryComponent.Log;

namespace MyLibraryComponent.LogicB.LogicC.LogicD
{
    public class LogicD :ILogicD
    {
        private readonly ILogProvider _logProvider;

        public LogicD(ILogProvider logProvider)
        {
            _logProvider = logProvider;
        }

        public void LogicDMethodA()
        {
            _logProvider.LogInfo("LogicD.LogicDMethodA");
        }

        public void LogicDMethodB()
        {
            _logProvider.LogInfo("LogicD.LogicDMethodB");
        }

        public void LogicDMethodC()
        {
            _logProvider.LogInfo("LogicD.LogicDMethodC");
        }
    }
}
