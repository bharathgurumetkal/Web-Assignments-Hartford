using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
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
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        public Vehicle()
        {

        }
        public Vehicle(string _registrationNo, string _name,
                       string _type, double _weight, Ticket _ticket)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = _ticket;
        }

        public override string ToString()
        {
            return "Registration No:" + _registrationNo + "\n" +
               "Name:" + _name + "\n" +
               "Type:" + _type + "\n" +
               "Weight:" + _weight.ToString("0.0") + "\n" +
               "Ticket No:" + _ticket.TicketNo;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Vehicle))
            {
                return false;
            }
            Vehicle other = (Vehicle)obj;
            return this._registrationNo.Equals(other._registrationNo,
            StringComparison.OrdinalIgnoreCase)
     && this._name.Equals(other._name,
            StringComparison.OrdinalIgnoreCase);
        }
    }
}
