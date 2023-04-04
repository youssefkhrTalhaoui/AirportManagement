using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boing,Airbus}
    public class Plane
    {
        [Range(0,int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "Capacity :"+this.Capacity+"manufactureDate : "+ this.ManufactureDate+"PlaneId :"+this.PlaneId;
        }
        public Plane() { }
        public Plane(PlaneType type, int Capacity, DateTime date)
        {
            this.PlaneType= type;

           this.Capacity = Capacity;
            this.ManufactureDate= date;
        }

    }
}
