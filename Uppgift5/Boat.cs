using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5
{
     public class Boat : Vehicle
    {
        public int Width { get; set; }

        public Boat(string regNr, string color, int weight, int width) : base (regNr, color, 0, weight)
        {
            this.Width = width;

        }
        public override string ToString()
        {
            return base.ToString() + $", Båtens bredd: {Width}";
        }
    }
}