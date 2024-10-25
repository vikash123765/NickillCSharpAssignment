using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NickillAssignment;

namespace NickillAssignment
{

     public  class Tjuv : Person
    {

       
        public Tjuv(int x, int y) : base(x, y)
        {
            // empty inventory 
        }

        public override void Interact(Person other)

        {
            Console.WriteLine(other);
            Console.WriteLine("Tjuv interaction triggered");

            if (other is NickillAssignment.MedBorgare medborgare)
            {
                Console.WriteLine("Interaction with a MedBorgare detected!");

                if (medborgare.Inventory.Count > 0)
                {
                    var random = new Random();
                    var item = medborgare.Inventory[random.Next(medborgare.Inventory.Count)];
                    medborgare.Inventory.Remove(item);
                    Inventory.Add(item);
                    Console.WriteLine($"Tjuven rånar medborgaren på {item}");
                }
            }
            else if (other is NickillAssignment.Polis police)
            {
                Console.WriteLine("Interaction with a Polis detected!");

                foreach (var item in Inventory)
                {
                    police.Inventory.Add(item);
                }

                Polis.numOfTimesTheifGotCaught++;
                //Inventory.Clear();  // Empty the thief's inventory after getting caught
                Console.WriteLine("Polisen tar tjuven och beslagtar allt stöldgods.");
            }
            else if (other is NickillAssignment.Tjuv)
            {
                Console.WriteLine("Tjuv mötte tjuv inget händer!");

                
            }
            else
            {
                Console.WriteLine("Interaction with an unknown type detected.");
                Console.WriteLine($"other = {other.GetType()} is not equal to {typeof(MedBorgare)}.");
                Console.WriteLine($"other = {other.GetType()} is not equal to {typeof(Polis)}.");
            }
        }


    }
}
