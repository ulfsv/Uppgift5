using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5
{
    class Mc : Vehicle
    {
        public int CylVol { get; set; }
        public Mc(string regNr, string color, int wheel, int weight, int cylVol) : 
            base(regNr, color, wheel, weight)
        {
            CylVol = cylVol;
        }

        public override string ToString()
        {
            return base.ToString() + $", Cylindervolym: {CylVol}";
        }
    }
}