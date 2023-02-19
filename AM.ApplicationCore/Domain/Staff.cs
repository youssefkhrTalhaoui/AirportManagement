using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger
    {
        public DateOnly EmployementDate { get; set; }
        public string Function { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return "Function :" + this.Function + "Salary :" + this.Salary ;
        }
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a staff member");
        }
    }
}
