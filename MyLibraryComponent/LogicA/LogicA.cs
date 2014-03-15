using MyLibraryComponent.Log;

namespace MyLibraryComponent.LogicA
{
    public class LogicA : ILogicA
    {
        private readonly ILogProvider _logProvider;

        public LogicA(ILogProvider logProvider)
        {
            _logProvider = logProvider;

        }

        public void LogicAMethodA()
        {
            _logProvider.LogInfo("LogicA.LogicAMethodA");
        }

        public void LogicAMethodB()
        {
            _logProvider.LogInfo("LogicA.LogicAMethodB");
        }

        public void LogicAMethodC()
        {
            _logProvider.LogInfo("LogicA.LogicAMethodC");
        }
    }
}
