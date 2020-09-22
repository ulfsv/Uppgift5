using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Uppgift5
{
    public class GarageHandler
    {
        public Garage<Vehicle> Garage { get; private set; } = new Garage<Vehicle>(1);

        public string ListAllVehicle()
        {
            return Garage.ListAllVehicle();
        }

        public List<string> getAllVehicleProperties()
        {
            List<string> properties = new List<string>();

            IEnumerable<Type> a = typeof(Vehicle).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Vehicle)));
            foreach (var type in a)
            {
                foreach (var property in type.GetProperties())
                {
                    properties.Add(property.Name);
                }
            }
            properties = properties.Distinct().ToList();
            return properties;
        }


        public bool AddVehicle(Vehicle vehicle)
        {
            return Garage.AddVehicle(vehicle);
        }

        public bool Remove(string regNr)
        {
            foreach (var vehicle in Garage)
            {
                if (vehicle.RegNr == regNr)
                {
                    Garage.RemoveVehicle(vehicle);
                    return true;
                }
            }
            return false;
        }

        public Vehicle GetVehicleByRegNr(string regNr)
        {
            Vehicle vehicle = null;

            foreach (var item in Garage)
            {
                if (item.RegNr.ToUpper() == regNr.ToUpper())
                {
                    vehicle = item;
                    break;
                }
            }
            return vehicle;
        }

        public string ListVehicleTypeCount()
        {
            var results = Garage.GroupBy(i => i.GetType().Name).Select(i => new
            {
                Type = i.Key,
                Count = i.Count()
            });

            string vehiclesTypeCount = "";
            foreach (var result in results)
            {
                vehiclesTypeCount += $"Det finns {result.Count} {result.Type} i garaget\n";
            }

            return vehiclesTypeCount;
        }

        public bool BuildGarage(int capacity)
        {
            if (capacity < Garage.CountVehicle)
                return false;

            return Garage.buildNewCapacity(capacity);
        }

        internal List<Vehicle> SearchVehicleByProperty(Dictionary<string, string> propertiesValues)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            foreach (var vehicle in Garage)
            {
                bool PropertiesValid = true;
                foreach (var property in propertiesValues)
                {
                    PropertyInfo propertyInfo = vehicle.GetType().GetProperty(property.Key);
                    if (propertyInfo != null)
                    {
                        if (property.Value != propertyInfo.GetValue(vehicle).ToString())
                        {
                            PropertiesValid = false;
                        }
                    }
                    else
                        PropertiesValid = false;
                }
                if (PropertiesValid)
                    vehicles.Add(vehicle);
            }

            return vehicles;
        }
    }
}