using CajaAhorro.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data
{
    public class OcupationRepository : GenericRepository<Ocupation>, IOcupationRepository
    {
        public OcupationRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
