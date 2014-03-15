using System;
using MyLibraryComponent.Log;

namespace ConsoleApp
{
    public class DummyLogProvider : ILogProvider
    {
        public void LogInfo(string message)
        {
            Console.WriteLine("DUMMY LOGGER: {0}", message);
        }
    }
}
