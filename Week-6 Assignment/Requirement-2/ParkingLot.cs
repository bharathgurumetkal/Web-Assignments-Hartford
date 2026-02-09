using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
{
    public class ParkingLot
    {
        private List<Vehicle> _vehicleList;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Vehicle> Vehicles
        {
            get { return _vehicleList; }
            set { _vehicleList = value; }
        }

        // Default constructor initializes the vehicle list
        public ParkingLot()
        {
            _vehicleList = new List<Vehicle>();
        }

        // Parameterized constructor assigns name and vehicle list
        public ParkingLot(string name, List<Vehicle> vehicleList)
        {
            _name = name;
            _vehicleList = vehicleList ?? new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            foreach (Vehicle v in _vehicleList)
            {
                if (v.Equals(vehicle))
                {
                    throw new ApplicationException("Vehicle already exists");
                }
            }
            _vehicleList.Add(vehicle);
        }

        public bool RemoveVehicle(string registrationNo)
        {
            foreach (Vehicle v in _vehicleList)
            {
                if (v.RegistrationNo.Equals(registrationNo))
                {
                    _vehicleList.Remove(v);
                    return true;
                }
            }
            return false;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleList;
        }
    }
}
