namespace AeroPlusButBetter.DatabaseObjects;

public class User
{
    public int Id { get; set; }
    public required Titles Title { get; set; } 

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Web { get; set; }
    public int LicenseNumber { get; set; }
    public LicenseTypes LicenseType { get; set; } 
    public required string PasswordHash { get; set; }
    public required string Salt { get; set; }
    public required bool IsInstructor { get; set; }
    
    public enum Titles
    {
        Mr,
        Miss,
        Mrs,
        Ms,
        Mx
    }

    public enum LicenseTypes
    {
        Ppl
    }
}