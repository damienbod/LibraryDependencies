using MyLibraryComponent.Log;
using MyLibraryComponent.LogicA;
using MyLibraryComponent.LogicB;
using MyLibraryComponent.LogicB.LogicC;
using MyLibraryComponent.LogicB.LogicC.LogicD;

namespace MyLibraryComponent
{
    public class DefaultDependencyRosolver
    {
        public ILogProvider LogProvider { get; set; }
        public ILogicA LogicA { get; set; }
        public ILogicB LogicB { get; set; }
        public ILogicC LogicC { get; set; }
        public ILogicD LogicD { get; set; }
        public IMyLibrary MyLibrary { get; set; }

        public void ResolveDependencies()
        {
            if (LogProvider == null) LogProvider = new DefaultLogProvider();
            if (LogicD == null) LogicD = new LogicD(LogProvider);
            if (LogicC == null) LogicC = new LogicC(LogProvider, LogicD);
            if (LogicB == null) LogicB = new LogicB.LogicB(LogProvider, LogicC);
            if (LogicA == null) LogicA = new LogicA.LogicA(LogProvider);
            if (MyLibrary == null) MyLibrary = new MyLibrary(LogProvider, LogicB, LogicA);
        }
    }

}
