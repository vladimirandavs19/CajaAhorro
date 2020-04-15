using CajaAhorro.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Parameter> Parameters { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<BankCompany> BankCompanies { get; set; }

        public DbSet<Ocupation> Ocupations { get; set; }
        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext)
        {

        }
    }
}
