using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class MyDependency : IMyDependency
    {
        public MyDependency()
        {
            Debug.WriteLine("MyDependency created");
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage Message: {message}");
        }
    }
}
