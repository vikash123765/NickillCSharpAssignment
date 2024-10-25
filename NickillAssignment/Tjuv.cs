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
            
            if (other is NickillAssignment.MedBorgare medborgare)
            {
                

                if (medborgare.Inventory.Count > 0)
                {
                    var random = new Random();
                    var item = medborgare.Inventory[random.Next(medborgare.Inventory.Count)];
                    medborgare.Inventory.Remove(item);
                    Inventory.Add(item);
                    Console.WriteLine($"Tjuven rånar medborgaren på {item}");
                    Console.ReadKey();
                }
            }
            else if (other is NickillAssignment.Polis police)
            {
             

                foreach (var item in Inventory)
                {
                    police.Inventory.Add(item);
                }

                Polis.numOfTimesTheifGotCaught++;
                //Inventory.Clear();  // Empty the thief's inventory after getting caught
                Console.WriteLine("Polisen tar tjuven och beslagtar allt stöldgods.");
                Console.ReadKey();
            }
            else if (other is NickillAssignment.Tjuv)
            {
                Console.WriteLine("Tjuv mötte tjuv inget händer!");
                Console.ReadKey();


            }
            else
            {
                Console.WriteLine("Interaction with an unknown type detected.");
                Console.ReadKey();

            }
        }


    }
}
