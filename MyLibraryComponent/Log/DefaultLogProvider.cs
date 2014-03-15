using System;

namespace MyLibraryComponent.Log
{
    public class DefaultLogProvider : ILogProvider
    {
        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}
