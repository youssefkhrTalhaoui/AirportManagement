// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System.Numerics;

/*Plane p1= new Plane();
p1.Capacity = 200;
p1.PlaneType = PlaneType.Boing;
p1.ManufactureDate = new DateTime(2023, 01, 01);

Plane p2=new Plane (PlaneType.Airbus,200,new DateTime(2022,03,03));


Plane p3 = new Plane
{
    Capacity=250,
    ManufactureDate=new DateTime(2022,02,02),
    PlaneType=PlaneType.Airbus,
};
Passenger passenger1 = new Passenger
{
    FirstName = "test",
    LastName = "test1",
    EmailAddress = "test@esprit.tn"
};
Console.WriteLine(passenger1.CheckProfile("test", "test1", "test@esprit.tn"));
Traveller traveller1 = new Traveller
{

    FirstName = "test",
    LastName = "test1",
    Nationality = "Tunisian"
};
Console.WriteLine("traveller1: ");
traveller1.PassengerType();
Staff staff1 = new Staff
{
    FirstName = "aa",
    LastName = "bb",
    Salary = 6000.0
};
Console.WriteLine("Staff1: ");
staff1.PassengerType();
*/
AMContext ctx = new AMContext();
ctx.Flights.Add(TestData.flight1);
ctx.SaveChanges();
ServiceFlight sf = new ServiceFlight();
sf.Flights = TestData.listFlights;
foreach(var flight in sf.GetFlightDates("Paris"))
{
    Console.WriteLine(flight);
}
sf.GetFlights("Destination", "Paris");
sf.FlightDetailsDel(TestData.BoingPlane);
Console.WriteLine("total flights :"+sf.ProgrammedFlightNumber(new DateTime (2022,02,01)));
Console.WriteLine( "Duration Average : "+sf.DurationAverageDel("Paris"));
foreach (var item in sf.OrderedDurationFlights())
{
    Console.WriteLine(item);
}
foreach( var item in sf.SeniorTravellers(TestData.flight1)) { Console.WriteLine(item); }
sf.DestinationGroupedFlights();
Passenger passenger1 = new Passenger
{
    FirstName = "test",
    LastName = "test1",
    EmailAddress = "test@esprit.tn"
};
Console.WriteLine(passenger1.FirstName + passenger1.LastName);
passenger1.UpperFullName();
Console.WriteLine(passenger1.FirstName + passenger1.LastName);
