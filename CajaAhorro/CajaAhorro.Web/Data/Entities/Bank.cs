using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Data.Entities
{
    public class Bank : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BankAccount { get; set; }
        public int AccountType { get; set; }
        Company Company { get; set; }
    }
}
