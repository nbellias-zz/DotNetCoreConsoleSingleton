using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreConsoleSingleton
{
    class MySingletonResourceUsingLazyType
    {
        //If you are using .NET 4 or higher then you can use the System.Lazy<T> type to make the laziness really simple.
        //You can pass a delegate to the constructor that calls the Singleton constructor, which is done most easily with a lambda expression.
        //Allows you to check whether or not the instance has been created with the IsValueCreated property.

        private static readonly Lazy<MySingletonResourceUsingLazyType> lazy = new Lazy<MySingletonResourceUsingLazyType>(() => new MySingletonResourceUsingLazyType());
        
        private MySingletonResourceUsingLazyType()
        {
            Console.WriteLine("Resource is being intializing...");
        }
        
        public static MySingletonResourceUsingLazyType Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public void ExecuteResourceProcess(string procName)
        {
            Console.WriteLine($"LAZY TYPE: Executing resource process {procName}");
        }
    }
}
