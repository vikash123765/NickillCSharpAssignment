using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickillAssignment
{
   
    public abstract class  Person
    {
        
        public int X { get; set; }
        public int Y { get; set; }
        // Initialize Inventory in the Person class
        public List<Sak> Inventory { get; set; }
    
        public int XDirection { get; set; }
        public int YDirection { get; set; }


        public Person()
        {
           
            Inventory = new List<Sak>();
        }

        public Person(int x, int y) : this() // Call the default constructor
        {
            // Other initialization
            X = x;
            Y = y;
            XDirection = new Random().Next(-1, 2); // Slumpmässig riktning
            YDirection = new Random().Next(-1, 2);
        }
        public void Move(int cityWidth, int cityHeight)
        {
            // Instead of random movement, move towards a target or in a predictable pattern
            // This is for testing purposes; revert it back to random later

            // Example: move towards the center of the grid
            int centerX = cityWidth / 2;
            int centerY = cityHeight / 2;

            if (X < centerX) X++;
            else if (X > centerX) X--;

            if (Y < centerY) Y++;
            else if (Y > centerY) Y++;

            // Wrap around the city boundaries
            X = (X + cityWidth) % cityWidth;
            Y = (Y + cityHeight) % cityHeight;
        }


        // Interaktion med andra personer (hanteras i subklasserna)
        public abstract void Interact(Person other);
    }
}
