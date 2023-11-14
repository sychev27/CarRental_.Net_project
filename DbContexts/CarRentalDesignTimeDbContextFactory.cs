using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Design;

namespace CarRental.DbContexts
{
    public class CarRentalDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CarRentalDbContext>
    {
        public CarRentalDbContext CreateDbContext(string[] args)
        {
            DbContextOptions dbContextOptions = new DbContextOptionsBuilder().UseSqlite("Data Source=carrental.db").Options;
            return new CarRentalDbContext(dbContextOptions);
        }
    }
}