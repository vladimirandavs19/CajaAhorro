using AutoMapper;
using CajaAhorro.Web.Data.Entities;
using CajaAhorro.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CajaAhorro.Web.Helpers
{
    public class BankCompanyProfile : Profile
    {
        public BankCompanyProfile()
        {
            CreateMap<BankCompany, BankCompanyViewModel>();
        }
    }
}
