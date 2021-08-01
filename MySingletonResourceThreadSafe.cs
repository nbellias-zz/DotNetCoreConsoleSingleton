using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreConsoleSingleton
{
    public sealed class MySingletonResourceThreadSafe
    {
        //In the code, the thread is locked on a shared object and checks whether an instance has been created or not.
        //It takes care of the memory barrier issue and ensures that only one thread will create an instance.
        //For example: Since only one thread can be in that part of the code at a time, by the time the second thread enters it,
        //the first thread will have created the instance, so the expression will evaluate as false.
        //
        //The BIGGEST PROBLEM with this is performance; performance suffers since a lock is required every time an instance is requested.

        private static MySingletonResourceThreadSafe instance = null;

        private static readonly object threadlock = new object();

        private MySingletonResourceThreadSafe()
        {
            Console.WriteLine("Resource is being intializing...");
        }

        public static MySingletonResourceThreadSafe Instance
        {
            get
            {
                lock (threadlock)
                {
                    if(instance == null)
                    {
                        instance = new MySingletonResourceThreadSafe();
                    }
                    return instance;
                }
            }
        }

        public void ExecuteResourceProcess(string procName)
        {
            Console.WriteLine($"THREAD SAFE: Executing resource process {procName}");
        }
    }
}
