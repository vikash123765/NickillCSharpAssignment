using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NickillAssignment
{
    public class Staden
    {
        private int height;
        private int width;
        private List<Person> persons;
        private bool isRunning = true;

        public Staden(int width, int height, List<Person> persons)
        {
            this.width = width;
            this.height = height;
            this.persons = persons;
        }
       
        
        public void RunSimulation()
{
       int iterationCount = 0;
         var interactionPairs = new HashSet<(int, int)>(); // Track active interactions as unique pairs


         while (isRunning)
          { 
                Console.Clear(); 

       
                foreach (var person in persons)
        {
            person.Move(width, height);
        }

        for (int i = 0; i < persons.Count; i++)
        {
            for (int j = i + 1; j < persons.Count; j++)
            {
                // Check if two people meet (i.e., same coordinates)
                if (persons[i].X == persons[j].X && persons[i].Y == persons[j].Y)
                {
                    var pair = (Math.Min(i, j), Math.Max(i, j)); // Ensure pairs are consistent (e.g., (2,3) and (3,2) are treated the same)

                    // If the interaction is new, trigger it and add to the interactionPairs set
                    if (!interactionPairs.Contains(pair))
                    {
                        persons[i].Interact(persons[j]);
                        interactionPairs.Add(pair);

               
                    }
                }
                else
                {
                    // If no longer meeting, remove the pair from active interactions
                    var pair = (Math.Min(i, j), Math.Max(i, j));
                    interactionPairs.Remove(pair);
                }
            }
        }

        // Draw the city grid and display stats periodically
        DrawCity();

      
            Console.WriteLine($"Antal rånade medborgare: {MedBorgare.numOfTimesRobbed}");
            Console.WriteLine($"Antal gripna tjuvar: {Polis.numOfTimesTheifGotCaught}");
        
    
        iterationCount++;
        Thread.Sleep(500);
    }
       Console.ReadKey();
}


        public void StopSimulation()
        {
            isRunning = false;
        }

        private void DrawCity()
        {
            char[,] grid = new char[height, width];

            foreach (var person in persons)
            {
                
                if (person is Polis)
                    grid[person.Y, person.X] = 'P';
                else if (person is Tjuv)
                    grid[person.Y, person.X] = 'T';
                else if (person is MedBorgare)
                    grid[person.Y, person.X] = 'M';
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[y, x] == '\0')
                        Console.Write(" ");
                    else
                        Console.Write(grid[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}