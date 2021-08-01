using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreConsoleSingleton
{
    public sealed class MySingletonResourceNonThreadSafe
    {
        //Two different threads could both have evaluated the test (if instance == null) and found it to be true,
        //then both create instances, which violates the singleton pattern.

        private static MySingletonResourceNonThreadSafe instance = null;

        private MySingletonResourceNonThreadSafe() {
            Console.WriteLine("Resource is being intializing...");
        }

        public static MySingletonResourceNonThreadSafe Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MySingletonResourceNonThreadSafe();
                }
                return instance;
            }
        }

        public void ExecuteResourceProcess(string procName)
        {
            Console.WriteLine($"NON THREAD SAFE: Executing resource process {procName}");
        }
    }
}
