using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public int PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "BirthDate :"+this.BirthDate+"PassportNumber :"+this.PassportNumber+"EmailAdresss :"+this.EmailAddress+"FirstName :"+this.FirstName+"LastName :"+this.LastName+"TelNumber :"+this.TelNumber;
        }
        //la propriété et un attribut encapsulé avec les getters et setters....

        /* public bool CheckProfile(string firstname,string lastname)
         {
             return firstname == this.FirstName && lastname ==this.LastName;
         }

         public bool CheckProfile(string firstname, string lastname,string email)
         {
             return firstname == this.FirstName && lastname == this.LastName && email==this.EmailAddress;
         }
         */
        public bool CheckProfile(string firstname, string lastname,string email=null)
        {
            if(email== null)
            {
                return firstname == this.FirstName && lastname == this.LastName;
            }
            else {

                return firstname == this.FirstName && lastname == this.LastName && email == this.EmailAddress;
            }
            
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }


    }
}
