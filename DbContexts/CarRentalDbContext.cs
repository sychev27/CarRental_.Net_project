using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DTOs;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace CarRental.DbContexts
{
    public class CarRentalDbContext : DbContext
    {
        public DbSet<CarDTO> Cars { get; set; }
        public CarRentalDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
