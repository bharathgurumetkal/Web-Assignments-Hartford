using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    public class VehicleBO
    {
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            List<Vehicle> res = new List<Vehicle>();
            foreach (Vehicle v in vehicleList)
            {
                if (v.Type != null && v.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    res.Add(v);
                }

            }
            return res;
        }

        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            List<Vehicle> res = new List<Vehicle>();
            foreach (Vehicle v in vehicleList)
            {
                if (v.Ticket.ParkedTime.Equals(parkedTime))
                {
                    res.Add(v);
                }
            }
            return res;

        }
    }

}