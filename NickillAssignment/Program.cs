using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NickillAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

        var persons = new List<Person>
        {
            new MedBorgare(5, 5),
            new Tjuv(10, 10),
            new Polis(15, 15),
            new MedBorgare(20, 5),
            new Tjuv(30, 10),
            new Polis(50, 20)
        };

         var stad = new Staden(100, 25, persons);
         stad.RunSimulation();

          
            // Main thread waits for input to stop the simulation
            Console.WriteLine("Press any key to stop the simulation...");
            Console.ReadKey();
            stad.StopSimulation();

        }


    }
}