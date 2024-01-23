namespace AeroPlusButBetter.DatabaseObjects;

public class Reservation
{
    public int Id { get; set; }
    public required Plane Plane { get; set; }
    public User? Instructor { get; set; }
    public required User Customer { get; set; }
    public TypesOfFlight? TypeOfFlight { get; set; }
    public string? Notes { get; set; }
    public required Statuses Status { get; set; }
    public required DateTime StartDateTime { get; set; }
    public required DateTime EndDateTime { get; set; }
    public int EstimatedFlightTime { get; set; }
    public string? DepartureAirport { get; set; }
    public string? ArrivalAirport { get; set; }
    public string? AlternateAirport { get; set; }
    
    public enum TypesOfFlight
    {
        Vfr,
        Ifr
    }

    public enum Statuses
    {
        Approved
    }
}