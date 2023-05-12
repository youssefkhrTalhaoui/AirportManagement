// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System.Numerics;
using Plane = AM.ApplicationCore.Domain.Plane;

Console.WriteLine("Hello, World!");
Console.WriteLine("************************************ Testing Signature Polymorphisme ****************************** ");
Passenger p1 = new Passenger { FullName = new FullName { FirstName = "steave", LastName = "jobs" }, EmailAddress = "steeve.jobs@gmail.com", BirthDate = new DateTime(1955, 01, 01) };
Console.WriteLine("La méthode CheckProfile:");
Console.WriteLine(p1.CheckProfile("steave", "jobs"));
Console.WriteLine(p1.CheckProfile("steave", "jobs", "steeve.jobs@gmail.com"));

Console.WriteLine("************************************ Testing Inheritance Polymorphisme ****************************** ");
Staff s1 = new Staff { FullName = new FullName { FirstName = "Bill", LastName = "Gates" }, EmailAddress = "Bill.gates@gmail.com", BirthDate = new DateTime(1945, 01, 01), EmployementDate = new DateTime(1990, 01, 01), Salary = 99999 };
Traveller t1 = new Traveller { FullName = new FullName { FirstName = "Mark", LastName = "Zuckerburg" }, EmailAddress = "Mark.Zuckerburg@gmail.com", BirthDate = new DateTime(1980, 01, 01), HealthInformation = "Some troubles", Nationality = "American" };
Console.WriteLine("La méthode PassengerType p1:");
p1.PassengerType();
Console.WriteLine("La méthode PassengerType s1:");
s1.PassengerType();
Console.WriteLine("La méthode PassengerType t1:");
t1.PassengerType();

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
//AMContext ctx = new AMContext();

//ctx.Flights.Add(TestData.flight1);
//ctx.SaveChanges();

//ServiceFlight sf = new ServiceFlight();
//sf.Flights = TestData.listFlights;
//foreach(var flight in sf.GetFlightDates("Paris"))
//{
//    Console.WriteLine(flight);
//}
//sf.GetFlights("Destination", "Paris");
//sf.FlightDetailsDel(TestData.BoingPlane);
//Console.WriteLine("total flights :"+sf.ProgrammedFlightNumber(new DateTime (2022,02,01)));
//Console.WriteLine( "Duration Average : "+sf.DurationAverageDel("Paris"));
//foreach (var item in sf.OrderedDurationFlights())
//{
//    Console.WriteLine(item);
//}
////foreach( var item in sf.SeniorTravellers(TestData.flight1)) { Console.WriteLine(item); }
//sf.DestinationGroupedFlights();
//Passenger passenger1 = new Passenger { FullName = new FullName { FirstName = "test", LastName = "test1" }, EmailAddress = "test@esprit.tn"
//};
//Console.WriteLine(passenger1.FullName.FirstName + passenger1.FullName.LastName);
//passenger1.UpperFullName();
//Console.WriteLine(passenger1.FullName.FirstName + passenger1.FullName.LastName);
AMContext ctx = new AMContext();
//instanciation des objets

Plane plane1 = new Plane
{
    PlaneType = PlaneType.Airbus,
    Capacity = 450,
    ManufactureDate = new DateTime(2015, 02, 03)
};

Flight f1 = new Flight()
{
    Departure = "Tunis",
    AirlineLogo = "Tunisair",
    FlightDate = new DateTime(2022, 02, 01, 21, 10, 10),
    Destination = "Paris",
    EffectiveArrival = new DateTime(2022, 02, 01, 23, 10, 10),
    EstimatedDuration = 103,
    Plane = plane1
};
ctx.Planes.Add(plane1);
ctx.Flights.Add(f1);
ctx.SaveChanges();
Console.WriteLine(f1.Plane.PlaneId + " " + f1.Plane.Capacity);
Console.WriteLine(plane1.PlaneId + " " + plane1.Capacity);

ServicePlane service = new ServicePlane(new UnitOfWork(ctx, typeof(GenericRepository<>)));
service.Add(plane1);
ctx.SaveChanges();

//AMContext ctx = new AMContext();

//ctx.Flights.Add(TestData.flight2);
//ctx.SaveChanges();
//Console.WriteLine(ctx.Flights.First().Plane.Capacity);