using System;

namespace DotNetCoreConsoleSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A singleton implementation example.");
            /*
             * Problem #1: It is vital for some classes to have one and only one instance. 
             * For example, there should be only one file system and one window manager.
             * But why would we want to control how many instances a class may have? 
             * The answer is to be able to control access to some shared resource (e.g. a database or a file).
             * 
             * The idea of how a single instance is working, is to imagine that we created an instance of an object. 
             * If we then decided to create another one, instead of receiving a brand new one, we will just get the one we initially created. 
             * The above behavior is impossible to implement with a regular constructor since a constructor call must always return a new object.
             * 
             * Problem #2: The second problem the Singleton pattern is trying to solve is the need to provide a global access point to that instance from the outside world.
             * When we use global variables to store some essential objects may seem quite handy at first, but on the same time they are unsafe, since any code can potentially overwrite the contents of those variables and cause problems to our application.
             * 
             * The exact same way as with a global variable, implementing and using the Singleton pattern lets you access some object from anywhere in the program - the single instance we create and use throughout the lifetime of our application.
             * On the same time, it protects that instance from being overwritten by other code.
             * 
             * Use the Singleton pattern when:
             * 1) There must be exactly one instance of a class and it must be accessible to clients from a well-known access point.
             * 2) When the sole instance should be extensible by subclassing and clients should be able to use an extended instance without modifying their code.
             * 
             */
            Console.WriteLine("Case #1: singleton non thread safe.");

            var myResource1 = MySingletonResourceNonThreadSafe.Instance;
            myResource1.ExecuteResourceProcess("Sensor 1 data");

            var myResource2 = MySingletonResourceNonThreadSafe.Instance;
            myResource2.ExecuteResourceProcess("Sensor 2 data");

            Console.WriteLine("Case #2: singleton thread safe.");

            var myResource3 = MySingletonResourceThreadSafe.Instance;
            myResource3.ExecuteResourceProcess("Sensor 3 data");

            var myResource4 = MySingletonResourceThreadSafe.Instance;
            myResource4.ExecuteResourceProcess("Sensor 4 data");

            Console.WriteLine("Case #3: singleton thread safe with double-check locking.");

            var myResource5 = MySingletonResourceThreadSafeWithDoubleCheckLocking.Instance;
            myResource5.ExecuteResourceProcess("Sensor 5 data");

            var myResource6 = MySingletonResourceThreadSafeWithDoubleCheckLocking.Instance;
            myResource6.ExecuteResourceProcess("Sensor 6 data");

            Console.WriteLine("Case #4: singleton without locking nor lazy instantiation.");

            var myResource7 = MySingletonResourceWithoutLockNorLazyInstantiation.Instance;
            myResource7.ExecuteResourceProcess("Sensor 7 data");

            var myResource8 = MySingletonResourceWithoutLockNorLazyInstantiation.Instance;
            myResource8.ExecuteResourceProcess("Sensor 8 data");

            Console.WriteLine("Case #5: singleton without lazy type.");

            var myResource9 = MySingletonResourceUsingLazyType.Instance;
            myResource9.ExecuteResourceProcess("Sensor 9 data");

            var myResource10 = MySingletonResourceUsingLazyType.Instance;
            myResource10.ExecuteResourceProcess("Sensor 10 data");

        }
    }
}
