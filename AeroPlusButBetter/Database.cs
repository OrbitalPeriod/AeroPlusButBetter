using System.Linq.Expressions;
using AeroPlusButBetter.DatabaseObjects;
using AeroPlusButBetter.Utils;
using Microsoft.EntityFrameworkCore;

namespace AeroPlusButBetter;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Plane> Planes { get; set; } = null!;
    public DbSet<Maintenance> Maintenances { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;

    private static readonly string Username = Config.GetSqlUsername();
    private static readonly string Password = Config.GetSqlPassword();
    private static readonly string Url = Config.GetSqlUrl();
    private static readonly int Port = Config.GetSqlPort();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql($"server={Url};port={Port};user={Username};password={Password};database=AeroPlusButBetter", new MySqlServerVersion(new Version(8, 0, 21)));
    }
}

public class Database
{
    private static readonly DatabaseContext Context = new DatabaseContext();

    public static async Task SaveChanges()
    {
        await Context.SaveChangesAsync();
    }

    public static async Task<User?> GetUser(int id)
    {
        return await Context.Users.FirstAsync(usr => usr.Id == id);
    }
    public static async Task AddUser(User usr)
    {
        await Context.Users.AddAsync(usr);
        await Context.SaveChangesAsync();
    }
    public static async Task<List<User>> GetUsers(Expression<Func<User, bool>> test)
    {
        return await Context.Users.Where(test).ToListAsync();
    }
    public static async Task DeleteUser(Expression<Func<User, bool>> test)
    {
        User? user = await Context.Users.FirstOrDefaultAsync(test);
        if (user == null) return;
        else
        {
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
        }
    }
    
    public static async Task<Plane?> GetPlane(int id)
    {
        return await Context.Planes.FirstAsync(plane => plane.Id == id);
    }
    public static async Task AddPlane(Plane plane)
    {
        await Context.Planes.AddAsync(plane);
        await Context.SaveChangesAsync();
    }
    public static async Task<List<Plane>> GetPlanes(Expression<Func<Plane, bool>> test)
    {
        return await Context.Planes.Where(test).ToListAsync();
    }
    public static async Task DeletePlane(Expression<Func<Plane, bool>> test)
    {
        Plane? plane = await Context.Planes.FirstOrDefaultAsync(test);
        if (plane == null) return;
        else
        {
            Context.Planes.Remove(plane);
            await Context.SaveChangesAsync();
        }
    }
    
    public static async Task<Reservation> GetReservation(int id)
    {
        return await Context.Reservations.FirstAsync(reservation => reservation.Id == id);
    }
    public static async Task AddReservation(Reservation reservation)
    {
        await Context.Reservations.AddAsync(reservation);
        await Context.SaveChangesAsync();
    }
    public static async Task<List<Reservation>> GetReservation(Expression<Func<Reservation, bool>> test)
    {
        return await Context.Reservations.Where(test).ToListAsync();
    }
    public static async Task DeleteReservation(Expression<Func<Reservation, bool>> test)
    {
        Reservation? reservation = await Context.Reservations.FirstOrDefaultAsync(test);
        if (reservation == null) return;
        else
        {
            Context.Reservations.Remove(reservation);
            await Context.SaveChangesAsync();
        }
    }
    
    public static async Task<Maintenance> GetMaintenance(int id)
    {
        return await Context.Maintenances.FirstAsync(maintenance => maintenance.Id == id);
    }
    public static async Task AddMaintenance(Maintenance maintenance)
    {
        await Context.Maintenances.AddAsync(maintenance);
        await Context.SaveChangesAsync();
    }
    public static async Task<List<Maintenance>> GetMaintenance(Expression<Func<Maintenance, bool>> test)
    {
        return await Context.Maintenances.Where(test).ToListAsync();
    }
    public static async Task DeleteMaintenance(Expression<Func<Maintenance, bool>> test)
    {
        Maintenance? maintenance = await Context.Maintenances.FirstOrDefaultAsync(test);
        if (maintenance == null) return;
        else
        {
            Context.Maintenances.Remove(maintenance);
            await Context.SaveChangesAsync();
        }
    }
}