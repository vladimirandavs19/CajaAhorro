using CajaAhorro.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data
{
    public class BankRepository : GenericRepository<Bank>, IBankRepository
    {
        public BankRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
