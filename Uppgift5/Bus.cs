using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5
{
    public class Bus : Vehicle
    {
        public int Length { get; set; }


        public Bus(string regNr, string color, int wheel, int weight, int length) : base(regNr, color, wheel, weight)
        {
            this.Length = length;
        }

        public override string ToString()
        {
            return base.ToString() + $", Längd: {Length}";
        }
    }
}