using CajaAhorro.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data
{
    public class BankCompanyRepository : GenericRepository<BankCompany>, IBankCompanyRepository
    {
        private readonly DataContext dataContext;

        public BankCompanyRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public IQueryable<BankCompany> GetAllWithEntities()
        {
            return this.dataContext.BankCompanies.Include(x => x.Bank).Include(y => y.Company);
        }

        public async Task<BankCompany> GetByIdASyncWithEntities(int Id)
        {
            return await this.dataContext.BankCompanies.Include(x => x.Bank).Include(y => y.Company).FirstOrDefaultAsync(z => z.Id == Id);
        }

        public IQueryable<Bank> GetBanks()
        {
            return this.dataContext.Banks;
        }

        public IQueryable<Company> GetCompanies()
        {
            return this.dataContext.Companies;
        }

        public IQueryable<Parameter> GetParameters(int ParameterType)
        {
            return this.dataContext.Parameters.Where(x => x.ParameterType == ParameterType);
        }
    }
}
