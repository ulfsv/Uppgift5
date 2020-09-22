using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Uppgift5
{
    public class Vehicle
    {
        public string Color { get; set; }
        public string RegNr { get; set; }
        public int Wheel { get; set; }
        public int Weight { get; set; }


        public Vehicle(string regNr, string color, int wheel, int weight)
        {
            this.RegNr = regNr;
            this.Color = color;
            this.Wheel = wheel;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return $"Registreringsnummer: {RegNr}, Färg: {Color}, Antal hjul: {Wheel}, Vikt: {Weight}";
        }

    }
}