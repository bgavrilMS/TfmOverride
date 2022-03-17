using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // indirect reference (via LibraryForApp)
            ClassLibrary1.Lib lib = new ClassLibrary1.Lib();
            string fwk = lib.GetFramework();

            // direct reference
            //FakeMsal.FakeMsal f = new FakeMsal.FakeMsal();
            //string fwk = f.GetTfm();





            Console.WriteLine($"Hello World from {fwk}");
        }
    }
}
