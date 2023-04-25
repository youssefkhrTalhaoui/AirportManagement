using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {

        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void DeletePlanes()
        {
            Delete(p => p.ManufactureDate.AddYears(10).Year > DateTime.Now.Year);
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll().OrderByDescending(p => p.PlaneId).Take(n).SelectMany(p => p.Flights).OrderBy(f => f.FlightDate).ToList();

        }

        public IList<Plane> GetPassenger(Plane plane)
        {
            return (IList<Plane>)GetById(plane.PlaneId).Flights.SelectMany(f => f.Tickets.Select(t => t.Passenger)).ToList();
        }

        public bool isAvailable(Flight flight, int n)
        {
            int PlaneCapacity = flight.Plane.Capacity;

            int nbrTicket = flight.Tickets.Count;
            return PlaneCapacity > nbrTicket;
        }
    }
}

