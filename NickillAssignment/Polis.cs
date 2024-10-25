using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickillAssignment
{



    internal class Polis : Person
    {
   
        public static int numOfTimesTheifGotCaught { get; set; } =0;
        public Polis(int x, int y) : base(x, y)
        {


        }

        public override void Interact(Person other)
        {
            Console.WriteLine(other);
            Console.WriteLine("Polis interaction triggered");

            if (other is NickillAssignment.Tjuv tjuv)
            {
                Console.WriteLine("Interaction with a Tjuv detected!");

                foreach (var item in tjuv.Inventory)
                {
                    Inventory.Add(item);
                }
                Polis.numOfTimesTheifGotCaught++;
                tjuv.Inventory.Clear();  // Clear thief's inventory
                Console.WriteLine("Polisen tar tjuven och beslagtar allt stöldgods.");
            }
            else if (other is NickillAssignment.MedBorgare)
            {
                Console.WriteLine("Interaction with a MedBorgare detected! Nothing happens.");
            }
            else if (other is NickillAssignment.Polis)
            {
                Console.WriteLine("Polis mötte Polis inget händer!");


            }
            else
            {
                Console.WriteLine("Interaction with an unknown type detected.");
                Console.WriteLine($"other = {other.GetType()} is not equal to {typeof(Tjuv)}.");
                Console.WriteLine($"other = {other.GetType()} is not equal to {typeof(MedBorgare)}.");
               
            }
        }


    }
}
