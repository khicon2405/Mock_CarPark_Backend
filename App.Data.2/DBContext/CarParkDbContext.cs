using System;
using System.Collections.Generic;
using System.Text;
using CoreApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Data.DBContext
{
    public class CarParkDbContext : DbContext
    {
        /*public DBContextCarpark() : base()
        {
        }

        public DBContextCarpark(DbContextOptions<DBContextCarpark> options) : base(options)
        {
        }*/

        public DbSet<EmployeeModel> Employees { get; set; }
        /*public DbSet<AuthenticationModel> AuthenticationModel { get; set; }*/
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ParkingLotModel> ParkingLots { get; set; }
        public DbSet<BookingOfficeModel> BookingOfficeModels { get; set; }
        public DbSet<TripModel> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-F9LQS1U\SQLEXPRESS;Initial Catalog=Mock_CarPark;Integrated Security=True");
        }
        
    }

}
