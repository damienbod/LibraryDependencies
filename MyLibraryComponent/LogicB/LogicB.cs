using MyLibraryComponent.Log;
using MyLibraryComponent.LogicB.LogicC;

namespace MyLibraryComponent.LogicB
{
    public class LogicB : ILogicB
    {
        private readonly ILogProvider _logProvider;
        private readonly ILogicC _logicC;

        public LogicB(ILogProvider logProvider, ILogicC logicC)
        {
            _logProvider = logProvider;
            _logicC = logicC;
        }

        public void LogicBMethodA()
        {
            _logProvider.LogInfo("LogicB.LogicBMethodA");
            _logicC.LogicCMethodA();
        }

        public void LogicBMethodB()
        {
            _logProvider.LogInfo("LogicB.LogicBMethodB");
            _logicC.LogicCMethodB();
        }

        public void LogicBMethodC()
        {
            _logProvider.LogInfo("LogicB.LogicBMethodC");
            _logicC.LogicCMethodA();
            _logicC.LogicCMethodC();
        }
    }
}
