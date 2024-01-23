namespace AeroPlusButBetter.DatabaseObjects;

public class Maintenance
{
    public int Id { get; set; }
    public required Plane Plane { get; set; }
    public required User User { get; set; }
    public required DateTime Date { get; set; }
    public required Statuses Status { get; set; }
    public string? Note { get; set; }
    
    public enum Statuses
    {
        New,
        Fixed
    }
}