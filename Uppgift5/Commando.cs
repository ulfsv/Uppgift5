using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5
{ 
    public enum Commando
    {
        ListAllVehicles,
        AddVehicle,
        RemoveVehicle,
        SearchVehicleByRegNr,
        ListVehicleTypeCount,
        ChangeCapacity,
        SearchVehicleByProperty,
        Quit
    }
}