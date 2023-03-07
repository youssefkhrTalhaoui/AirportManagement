using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Display(Name ="Date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Key, StringLength(7)]
        
        public string PassportNumber { get; set; }
        [EmailAddress]
         //[DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public FullName FullName { get; set; }    
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public int TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "BirthDate :"+this.BirthDate+"PassportNumber :"+this.PassportNumber+"EmailAdresss :"+this.EmailAddress+"FirstName :"+this.FullName.FirstName+"LastName :"+this.FullName.LastName + "TelNumber :"+this.TelNumber;
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
                return firstname == this.FullName.FirstName && lastname == this.FullName.LastName;
            }
            else {

                return firstname == this.FullName.FirstName && lastname == this.FullName.LastName && email == this.EmailAddress;
            }
            
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }


    }
}
