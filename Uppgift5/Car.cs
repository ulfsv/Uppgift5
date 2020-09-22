using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5
{
    public class Car : Vehicle
    {
        public string CarBrand { get; set; }

        public Car(string regNr, string color, int weight, string carBrand) : base(regNr, color, 4, weight)
        {
            this.CarBrand = carBrand;
        }

        public override string ToString()
        {
            return base.ToString() + $", Bilmärke: {CarBrand}";
        }
    }
}