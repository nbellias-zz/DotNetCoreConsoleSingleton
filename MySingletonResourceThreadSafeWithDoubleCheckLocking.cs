using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreConsoleSingleton
{
    public sealed class MySingletonResourceThreadSafeWithDoubleCheckLocking
    {
        //In the following code, the thread is locked on a shared object and
        //checks whether an instance has been created or not with double checking.
        
        private static MySingletonResourceThreadSafeWithDoubleCheckLocking instance = null;

        private static readonly object threadlock = new object();

        private MySingletonResourceThreadSafeWithDoubleCheckLocking()
        {
            Console.WriteLine("Resource is being intializing...");
        }

        public static MySingletonResourceThreadSafeWithDoubleCheckLocking Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (threadlock)
                        {
                            if (instance == null)
                            {
                                instance = new MySingletonResourceThreadSafeWithDoubleCheckLocking();
                            }
                        }
                }
                return instance;
            }
        }

        public void ExecuteResourceProcess(string procName)
        {
            Console.WriteLine($"THREAD SAFE WITH DOUBLE-CHECK LOCKING: Executing resource process {procName}");
        }
    }
}
