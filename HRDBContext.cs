using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHR
{

    public class HRDBContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("data source = localhost\\SQLEXPRESS;" +
                "database = System HR;Integrated Security = True; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<User> Logins { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Contract> Contracts { get; set; }

    }

}
