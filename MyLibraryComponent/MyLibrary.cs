using MyLibraryComponent.Log;
using MyLibraryComponent.LogicA;
using MyLibraryComponent.LogicB;

namespace MyLibraryComponent
{
    public class MyLibrary : IMyLibrary
    {
        private readonly ILogProvider _logProvider;
        private readonly ILogicB _logicB;
        private readonly ILogicA _logicA;

        public MyLibrary(ILogProvider logProvider, ILogicB logicB, ILogicA logicA)
        {
            _logProvider = logProvider;
            _logicB = logicB;
            _logicA = logicA;
        }

        public void LibraryMethodA()
        {
            _logProvider.LogInfo("MyLibrary.LibraryMethodA");
            _logicA.LogicAMethodA();
            _logicA.LogicAMethodB();
        }

        public void LibraryMethodB()
        {
            _logProvider.LogInfo("MyLibrary.LibraryMethodB");
            _logicB.LogicBMethodA();
            _logicB.LogicBMethodB();
        }

        public void LibraryMethodC()
        {
            _logProvider.LogInfo("MyLibrary.LibraryMethodC");
            _logicA.LogicAMethodC();
            _logicB.LogicBMethodC();
        }
    }
}
