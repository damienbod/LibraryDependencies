using MyLibraryComponent.Log;
using MyLibraryComponent.LogicB.LogicC.LogicD;

namespace MyLibraryComponent.LogicB.LogicC
{
    public class LogicC : ILogicC
    {
        private readonly ILogProvider _logProvider;
        private readonly ILogicD _logicD;

        public LogicC(ILogProvider logProvider, ILogicD logicD)
        {
            _logProvider = logProvider;
            _logicD = logicD;
        }

        public void LogicCMethodA()
        {
            _logProvider.LogInfo("LogicC.LogicCMethodA");
            _logicD.LogicDMethodA();
        }

        public void LogicCMethodB()
        {
            _logProvider.LogInfo("LogicC.LogicCMethodB");
            _logicD.LogicDMethodA();
            _logicD.LogicDMethodB();
        }

        public void LogicCMethodC()
        {
            _logProvider.LogInfo("LogicC.LogicCMethodC");
            _logicD.LogicDMethodC();
        }
    }
}
