using System;
using System.Collections.Generic;
using System.Linq;
using CajaAhorro.Web.Data.Entities;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data
{
    public class ParameterRepository : GenericRepository<Parameter>, IParameterRepository
    {
        public ParameterRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
