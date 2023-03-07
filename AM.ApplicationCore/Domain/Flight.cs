﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string? AirlineLogo { get; set; }
        public string Destination { get; set; }
        public string? Departure { get; set; }
        public DateTime FlightDate { get; set; }
       
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        [ForeignKey("Plane")]
        public int PlaneId { get; set; }    
        public Plane Plane { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
        public override string ToString()
        {
            return " Destination : "+this.Destination+" Departure :"+this.Departure+" FlightDate :"+this.FlightDate+"EffectiveArrival :"+this.EffectiveArrival+"estimated duration :"+this.EstimatedDuration;
        }
    }
}
