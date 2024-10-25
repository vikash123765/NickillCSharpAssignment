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
            while (isRunning)
            {
                foreach (var person in persons)
                {
                    person.Move(width, height);
                    Console.WriteLine($"{person.GetType().Name} moved to ({person.X}, {person.Y})");
                }

                for (int i = 0; i < persons.Count; i++)
                {
                    for (int j = i + 1; j < persons.Count; j++)
                    {
                        // Check if two people meet (i.e., same coordinates)
                        if (persons[i].X == persons[j].X && persons[i].Y == persons[j].Y)
                        {
                            // Trigger interaction between them
                            Console.WriteLine($"{persons[i].GetType().Name} met {persons[j].GetType().Name} at ({persons[i].X}, {persons[i].Y})");
              
                            persons[i].Interact(persons[j]);  // i interacts with j
                        
                        }
                    }
                }
                // Draw the city grid and display stats periodically
                DrawCity();
                Console.WriteLine($"Antal rånade medborgare: {MedBorgare.numOfTimesRobbed}");
                Console.WriteLine($"Antal gripna tjuvar: {Polis.numOfTimesTheifGotCaught}");

                Thread.Sleep(500);
            }
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
                Console.WriteLine($"{person.GetType().Name} is at ({person.X}, {person.Y})");
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
                        Console.Write(".");
                    else
                        Console.Write(grid[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}