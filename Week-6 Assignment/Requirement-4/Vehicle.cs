using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    public class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

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

        public Ticket Ticket
        {
            get
            {
                return _ticket;
            }
            set
            {
                _ticket = value;
            }
        }
        public Vehicle() { }

        public Vehicle(string _registrationNo, string _name, string _type, double _weight, Ticket _ticket)
        {
            _registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = _ticket;
        }

        public static Vehicle CreateVehicle(string detail)
        {
            string[] data = detail.Split(',');

            string registrationNo = data[0].Trim();
            string name = data[1].Trim();
            string type = data[2].Trim();
            double weight = double.Parse(data[3].Trim());

            string ticketNo = data[4].Trim();
            DateTime parkedTime =
                DateTime.ParseExact(data[5].Trim(),
                "dd-MM-yyyy HH:mm:ss", null);
            double cost = double.Parse(data[6].Trim());

            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);

            return new Vehicle(registrationNo, name, type, weight, ticket);
        }

    }
}