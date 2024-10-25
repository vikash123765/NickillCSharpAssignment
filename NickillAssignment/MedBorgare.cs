using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NickillAssignment;

namespace NickillAssignment
{




    internal class MedBorgare : Person
    {
        public static int numOfTimesRobbed { get; set; } = 0;

      
        public MedBorgare(int x, int y) : base(x, y)
        {

            // Medborgaren har alltid samma tillhörigheter

           // List<String> itemsList = new List<String>();
           // itemsList.Add("Nycklar");
            //itemsList.Add("Mobiltelefon");
            //itemsList.Add("Pengar");
            //itemsList.Add("Klocka");
            Inventory.Add(new Sak("Nycklar"));
            Inventory.Add(new Sak("Mobiltelefon"));
            Inventory.Add(new Sak("Pengar"));
            Inventory.Add(new Sak("Nycklar"));

        }

        public override void Interact(Person other)
        {
            Console.WriteLine(other);
            Console.WriteLine("MedBorgare interaction triggered");

            if (other is NickillAssignment.Tjuv tjuv)
            {
                Console.WriteLine("Interaction with a Tjuv detected!");

                if (Inventory.Count > 0)
                {
                    var random = new Random();
                    var item = Inventory[random.Next(Inventory.Count)];
                    Inventory.Remove(item);
                    tjuv.Inventory.Add(item);
                    Console.WriteLine($"Tjuven rånar medborgaren på {item}");
                    numOfTimesRobbed++;
                }
            }
            else if (other is NickillAssignment.Polis)
            {
                Console.WriteLine("Interaction with a Polis detected! Medborgaren möter polisen, inget händer.");
            }
            else if (other is NickillAssignment.MedBorgare)
            {
                Console.WriteLine("Medborage  mötte medborgare inget händer!");


            }

            else
            {
                Console.WriteLine("Interaction with an unknown type detected.");
                Console.WriteLine($"other = {other.GetType()} is not equal to {typeof(Polis)}.");

                Console.WriteLine($"other = {other.GetType()} is not equal to {typeof(Tjuv)}.");

            }
        }





    }
}
