namespace AeroPlusButBetter.DatabaseObjects;

public class Plane
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int MinutesTillMaint { get; set; }
    public required int Landings { get; set; }
    public float? CurrentTacho { get; set; }
    public float? CurrentHobbs { get; set; }
    public required PlaneTypes PlaneType { get; set; }
    
    public enum PlaneTypes
    {
        SingleEnginePiston
    }
}