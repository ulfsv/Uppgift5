using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift5
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;

        public int Capacity
        {
            get { return vehicles.Length; }

        }


        public int CountVehicle { get; private set; } = 0;

        public bool IsFull => CountVehicle >= Capacity;

        public Garage(int capacity)
        {
            if (capacity <= 0) throw new InvalidOperationException("Capacity must be more than zero");

            vehicles = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                if (item != null)
                    yield return item;
            }
        }

        public T GetVehicleAtIndex(int index)
        {
            return vehicles[index];
        }

        public string ListAllVehicle()
        {
            string allVehicles = "";

            int current = 1;
            foreach (var vehicle in this)
            {
                allVehicles += $"{current}: {vehicle.GetType().Name}    {vehicle}\n";
                current++;
            }
            return allVehicles;
        }

        internal bool buildNewCapacity(int newCapacity)
        {
            T[] temp = vehicles;
            vehicles = new T[newCapacity];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i + 1 > CountVehicle)
                    break;
                vehicles[i] = temp[i];
            }
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool AddVehicle(T vehicle)
        {
            if (IsFull) return false;

            vehicles[CountVehicle] = vehicle;
            CountVehicle++;
            return true;
        }



        public bool RemoveVehicle(T vehicle)
        {
            bool isRemoved = false;
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (!isRemoved)
                {
                    if (vehicles[i] == vehicle)
                    {
                        vehicles[i] = null;
                        CountVehicle--;
                        isRemoved = true;
                    }
                }
                else
                {
                    vehicles[i - 1] = vehicles[i];
                }
            }

            return isRemoved;
        }


    }
}