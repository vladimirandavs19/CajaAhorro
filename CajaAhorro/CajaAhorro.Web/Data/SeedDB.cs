using CajaAhorro.Web.Data.Entities;
using CajaAhorro.Web.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data
{
    public class SeedDB
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;
        private readonly Random random;


        public SeedDB(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
            random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.dataContext.Database.EnsureCreatedAsync();
            var user = await this.userHelper.GetUserByEmailAsync("vladivirus666@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    Email = "vladivirus666@gmail.com",
                    FirstName = "Vladimir",
                    LastName = "Miranda",
                    UserName = "vladivirus666@gmail.com",
                    PhoneNumber = "593988340574",
                };

                var result = await this.userHelper.AddUserAsync(user, "admin123");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                if (!this.dataContext.Parameters.Any())
                {
                    AddParameter(1, "Accounts", "Saving Accounts", 1);
                    AddParameter(1, "Accounts", "Current Accounts", 2);
                    await this.dataContext.SaveChangesAsync();
                }

                if (!this.dataContext.Banks.Any())
                {
                    AddBank("Banco Pichincha");
                    AddBank("Banco Guayaquil");
                    AddBank("Banco Produbanco");
                    AddBank("Banco del Pacífico");
                    await this.dataContext.SaveChangesAsync();
                }

                if (!this.dataContext.Companies.Any())
                {
                    AddCompanies("Principal", "1717780280001", "Tréboles del Sur", "5932673272", "593988340574", new DateTime(2018, 01, 01));
                    await this.dataContext.SaveChangesAsync();
                }
            }
        }

        private void AddCompanies(string Name, string DNI, string Address, string PhoneNumber, string CellPhone, DateTime InitialDate)
        {
            this.dataContext.Companies.Add(new Company
            {
                Name = Name,
                DNI = DNI,
                Address = Address,
                PhoneNumber = PhoneNumber,
                CellPhone = CellPhone,
                InitialDate = InitialDate,
                ModifyDate = DateTime.Now,
            });
        }

        private void AddBank(string Name)
        {
            this.dataContext.Banks.Add(new Bank
            {
                Name = Name,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
            });
        }

        private void AddParameter(int ParameterType, string TypeValue, string Name, Nullable<int> IntValue = null)
        {
            this.dataContext.Parameters.Add(new Parameter
            {
                ParameterType = ParameterType,
                TypeName = TypeValue,
                StringValue = Name,
                IntValue = IntValue,
            });
        }
    }
}
