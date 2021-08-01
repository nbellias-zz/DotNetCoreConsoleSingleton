using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreConsoleSingleton
{
    public sealed class MySingletonResourceWithoutLockNorLazyInstantiation
    {
        //This type of implementation has a static constructor, so it executes only once per Application Domain.
        //It is not as lazy as the other implementation.

        private static readonly MySingletonResourceWithoutLockNorLazyInstantiation instance = new MySingletonResourceWithoutLockNorLazyInstantiation();
        static MySingletonResourceWithoutLockNorLazyInstantiation()
        {
        }
        private MySingletonResourceWithoutLockNorLazyInstantiation()
        {
            Console.WriteLine("Resource is being intializing...");
        }
        public static MySingletonResourceWithoutLockNorLazyInstantiation Instance
        {
            get
            {
                return instance;
            }
        }

        public void ExecuteResourceProcess(string procName)
        {
            Console.WriteLine($"THREAD SAFE WITHOUT LOCKING NOR LAZY INSTANTIATION: Executing resource process {procName}");
        }
    }
}
