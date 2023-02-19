using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        //public List<DateTime> GetFlightDates(string destination)
        //{
        //    List<DateTime> result = new List<DateTime>();
        //    {
        //        for (int i = 0; i < Flights.Count; i++)
        //        {
        //            if (Flights[i].Destination == destination)
        //            {
        //                result.Add(Flights[i].FlightDate);
        //            }
        //        }
        //        return result;


        //    }
        //}
        //public List<DateTime> GetFlightDates(string destination)
        //{
        //    List<DateTime> result = new List<DateTime>();
        //    foreach (Flight flight in Flights)
        //    {

        //                   if (flight.Destination == destination)
        //                   {
        //                       result.Add(flight.FlightDate);
        //                   }

        //    }
        //    return result;
        //}
        /*public List<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> query= from f in Flights
                                         where f.Destination == destination
                                         select f.FlightDate;
            //si in change le type de la ligne 46 en IEnumerable la fonction retourne directement query.....                          
            return query.ToList();
        }
        */
        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> queryLambda = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate);
            return queryLambda;
        }

        //public void ShowFlightDetails(Plane plane)
        //{
        //    var query = from f in Flights   
        //                where f.Plane == plane
        //                select f;
        //    foreach (var f in query)
        //    {
        //        Console.WriteLine("destination :"+f.Destination+"flightDate :"+f.FlightDate);
        //    }
        //}
        public void ShowFlightDetails(Plane plane)
        {
           var queryLambda = Flights
                .Where(f=>f.Plane == plane)
                .Select(f=>f);
            foreach (var f in queryLambda)
            {
                Console.WriteLine("destination :" + f.Destination + "flightDate :" + f.FlightDate);
            }

        }
        //public int ProgrammedFlightNumber(DateTime startDate)
        //{
        //    var query = from f in Flights
        //                where (DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7)
        //                select f;
        //    return query.Count();



        //}
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var queryLambda = Flights
                .Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7)
                .Select(f => f);
                 return queryLambda.Count();
        }
        //public double DurationAverage(string destination)
        //{
        //    var query = from f in Flights
        //                where f.Destination == destination
        //                select f.EstimatedDuration;
        //    return query.Average();
        //}
        public double DurationAverage(string destination)
        {
            var queryLambda = Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration);
            return queryLambda.Average();
        }
        //public IEnumerable<Flight> OrderedDurationFlights()
        //{
        //    var query = from f in Flights
        //                orderby f.EstimatedDuration descending
        //                select f;
        //    return query;
        //}
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var queryLambda = Flights
                .OrderByDescending(f=> f.EstimatedDuration)
                .Select(f => f);
            return queryLambda;

        }
        //public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        //{
        //    var query = from p in flight.Passengers.OfType<Traveller>() //ofType en cas d'héritage dans notre cas traveller et staff héritent de passenger...
        //                orderby p.BirthDate ascending
        //                select p;
        //    return query.Take(3);
        //}
        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var queryLambda = flight.Passengers.OfType<Traveller>()
                .OrderBy(p => p.BirthDate)
                .Select(p => p);
                return queryLambda.Take(3);

        }


        public void  GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                        foreach(Flight flight in Flights)
                    {
                            if (flight.Destination.Equals(filterValue))
                        
                            Console.WriteLine(flight);
                        

                      
                    }
                         break;
                case "FlightDate":
                        foreach (Flight  flight in Flights)
                    {
                            if(flight.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(flight);

                    }
                         break;
                case "EstimatedDuration":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EstimatedDuration == int.Parse(filterValue))
                            Console.WriteLine(flight);

                    }
                    break;
            }
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query = from f in Flights
                        group f by f.Destination;
            foreach (var g in query)
            {
                Console.WriteLine("Destination :" + g.Key);
                foreach (var v in g)
                {
                    Console.WriteLine("Décolgae : " + v.FlightDate);
                }
            }
            return query;
        }
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;
        public ServiceFlight()
        {
            FlightDetailsDel = plane => {
                var query = from f in Flights
                            where f.Plane == plane
                            select f;
                foreach (var f in query)
                {
                    Console.WriteLine("destination :" + f.Destination + "flightDate :" + f.FlightDate);
                }
            };
            DurationAverageDel = destination => {
                var query = from f in Flights
                            where f.Destination == destination
                            select f.EstimatedDuration;
                return query.Average();
            };
        }




    }
}

