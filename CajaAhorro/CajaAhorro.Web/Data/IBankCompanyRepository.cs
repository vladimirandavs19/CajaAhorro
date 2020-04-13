using CajaAhorro.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data
{
    public interface IBankCompanyRepository : IGenericRepository<BankCompany>
    {
        IQueryable<Bank> GetBanks();

        IQueryable<Company> GetCompanies();

        IQueryable<Parameter> GetParameters(int ParameterType);

        Task<BankCompany> GetByIdASyncWithEntities(int Id);

        IQueryable<BankCompany> GetAllWithEntities();
    }
}
