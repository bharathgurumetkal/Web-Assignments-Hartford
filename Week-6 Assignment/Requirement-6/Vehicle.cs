using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_6
{
    public class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;


        public string RegistrationNo
        {
            get
            {
                return _registrationNo;
            }
            set
            {
                _registrationNo = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }

        }
        public Vehicle()
        {

        }
        public Vehicle(string _registrationNo, string _name, string _type, double _weight)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
        }
        public static Vehicle CreateVehicle(string detail)
        {
            string[] data = detail.Split(',');

            string registrationNo = data[0].Trim();
            string name = data[1].Trim();
            string type = data[2].Trim();
            double weight = double.Parse(data[3].Trim());

            return new Vehicle(registrationNo, name, type, weight);
        }

        //Sorted Dictionary for type-wise count
        public static SortedDictionary<string, int> TypeWiseCount(List<Vehicle> vehicleList)
        {
            SortedDictionary<string, int> res = new SortedDictionary<string, int>();
            foreach (Vehicle vehicle in vehicleList)
            {
                if (res.ContainsKey(vehicle.Type))
                {
                    res[vehicle.Type]++;
                }
                else
                {
                    res[vehicle.Type] = 1;
                }
            }
            return res;
        }
    }

}