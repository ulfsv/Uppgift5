using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5
{
    public class ConsoleUI : IUI
    {
        public void ShowMainMenu(GarageHandler garageHandler)
        {
            Console.WriteLine("Ange en siffa mellan 1-5");
            Console.WriteLine($"I garaget finns nu {garageHandler.Garage.CountVehicle} fordon");
            Console.WriteLine($"Garaget har kapacitet för {garageHandler.Garage.Capacity} fordon");
            Console.WriteLine("1. Ändra garagets storlek");
            Console.WriteLine("2. Lägg till fordon");
            Console.WriteLine("3. Lista parkerade fordon i garaget");
            Console.WriteLine("4. Lista fordonstyper och hur många av varje fordon som finns parkerade i garaget just nu");
            Console.WriteLine("5. Sök efter fordon via registreringsnummer");
            Console.WriteLine("6. Sök efter fordon utifrån en eller flera egenskaper");
            Console.WriteLine("7. Ta bort ett fordon från garaget");
            Console.WriteLine("0. Avsluta programmet");
        }

        public int NewCapacity(GarageHandler garageHandler)
        {
            Console.WriteLine($"Ange den nya kapaciteten: (Behöver vara större än {garageHandler.Garage.CountVehicle} som finns i garaget just nu");
            int capacity = 0;
            int.TryParse(Console.ReadLine(), out capacity);

            return capacity;
        }

        public Commando getCommand()
        {
            string commando = Console.ReadLine();

            switch (commando)
            {
                case "1":
                    return Commando.ChangeCapacity;
                case "2":
                    return Commando.AddVehicle;
                case "3":
                    return Commando.ListAllVehicles;
                case "4":
                    return Commando.ListVehicleTypeCount;
                case "5":
                    return Commando.SearchVehicleByRegNr;
                case "6":
                    return Commando.SearchVehicleByProperty;
                case "7":
                    return Commando.RemoveVehicle;
                case "0":
                    return Commando.Quit;
            }
            return 0;
        }

        public void ListAllVehicle(string vehiclesString)
        {
            Console.WriteLine("Pakrerade fordon: ");
            Console.WriteLine(vehiclesString);
            Console.ReadLine();
        }

        public void PrintMessage(string print)
        {
            Console.WriteLine(print);
            Console.ReadLine();
        }

        public VehicleTypes GetVehicleType()
        {
            Console.WriteLine("Ange typ av fordon att registrera i garaget");
            Console.WriteLine($"1. Bil");
            Console.WriteLine($"2. Båt");
            Console.WriteLine($"3. Flygplan");
            Console.WriteLine($"4. MC");
            Console.WriteLine($"5. Buss");
            do
            {
                int vehicleType = 0;
                int.TryParse(Console.ReadLine(), out vehicleType);

                switch (vehicleType)
                {
                    case 1:
                        return VehicleTypes.Bil;
                    case 2:
                        return VehicleTypes.Båt;
                    case 3:
                        return VehicleTypes.Flygplan;
                    case 4:
                        return VehicleTypes.Motorcykel;
                    case 5:
                        return VehicleTypes.Buss;
                }

                Console.WriteLine("Ange en siffra mellan 1-5 för att ange typ av fordon");
            } while (true);
        }

        public Vehicle AddVehicleMenu(VehicleTypes vehicleType)
        {
            string regNr = "";
            while (regNr == "")
            {
                Console.Write("Ange Registreringsnummer: ");
                regNr = Console.ReadLine();
            }

            Console.Write("Ange Färg: ");
            string color = Console.ReadLine();

            int weight = 0;
            Console.Write("Ange vikt: ");
            int.TryParse(Console.ReadLine(), out weight);

            switch (vehicleType)
            {
                case VehicleTypes.Bil:
                    Console.WriteLine("Bilmärke: ");
                    string carBrand = Console.ReadLine();
                    Car car = new Car(regNr, color, weight, carBrand);
                    return car;
                case VehicleTypes.Flygplan:
                    Console.Write("Antal hjul: ");
                    int wheel = 0;
                    int.TryParse(Console.ReadLine(), out wheel);
                    Console.Write("Max antal passagerare: ");
                    int numberOfSeats = 0;
                    int.TryParse(Console.ReadLine(), out numberOfSeats);
                    Airplane airplane = new Airplane(regNr, color, wheel, weight, numberOfSeats);
                    return airplane;
                case VehicleTypes.Buss:
                    Console.Write("Antal hjul: ");
                    wheel = 0;
                    int.TryParse(Console.ReadLine(), out wheel);
                    Console.Write("Bussens längd i meter: ");
                    int length = 0;
                    int.TryParse(Console.ReadLine(), out length);
                    Bus bus = new Bus(regNr, color, wheel, weight, length);
                    return bus;
                case VehicleTypes.Motorcykel:
                    Console.Write("Antal hjul: ");
                    wheel = 0;
                    int.TryParse(Console.ReadLine(), out wheel);
                    Console.Write("Max hastighet på motorcykeln: ");
                    int MaxSpeed = 0;
                    int.TryParse(Console.ReadLine(), out MaxSpeed);
                    Mc motorcycle = new Mc(regNr, color, wheel, weight, MaxSpeed);
                    return motorcycle;
                case VehicleTypes.Båt:
                    Console.Write("Ange båtens bredd: ");
                    int width = 0;
                    int.TryParse(Console.ReadLine(), out width);
                    Boat boat = new Boat(regNr, color, weight, width);
                    return boat;
            }
            return null;
        }

        public string GetRegNr()
        {
            Console.WriteLine("Ange registreringsnummer: ");
            return Console.ReadLine();
        }

        public void PrintSuccessMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public void PrintWrongMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public void PrintVehicle(Vehicle vehicle)
        {
            Console.WriteLine(vehicle);
            Console.ReadLine();
        }

        public void ListVehicleTypeCount(string vehicleTypeCount)
        {
            Console.WriteLine(vehicleTypeCount);
            Console.ReadLine();
        }

        public int getCapacity()
        {
            Console.WriteLine("1. Ändra garagets kapacitet (Ange 0 för huvudmenyn utan att ändra kapaciteten)");
            Console.Write("Ange ny kapaciteten: ");
            string capacity = Console.ReadLine();
            return Int32.Parse(capacity);
        }

        public void clear()
        {
            Console.Clear();
        }

        public void Quit()
        {
            Console.WriteLine("Programmet har avslutats");
        }

        public Dictionary<string, string> GetSearchPropertiesAndValues(List<string> properties)
        {
            Dictionary<string, string> propertiesValue = new Dictionary<string, string>();

            Console.WriteLine("Ange egenskaper du vill söka efter. Tryck på enter för att hoppa över och söka på nästa egenskap.");
            foreach (var property in properties)
            {
                Console.Write(property + ": ");
                string value = Console.ReadLine();
                if (value != "")
                    propertiesValue.Add(property, value);
            }
            return propertiesValue;
        }

        public void PrintVehicles(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
            Console.ReadLine();
        }
    }
}