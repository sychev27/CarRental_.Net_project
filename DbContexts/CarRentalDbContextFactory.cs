using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DbContexts
{
    public class CarRentalDbContextFactory
    {
        private readonly string _connectionString;

        public CarRentalDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CarRentalDbContext CreateDbContext()
        {
            DbContextOptions dbContextOptions = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new CarRentalDbContext(dbContextOptions);
        }
    }
}
