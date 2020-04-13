using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CajaAhorro.Web.Data;
using CajaAhorro.Web.Data.Entities;
using AutoMapper;
using CajaAhorro.Web.Models;

namespace CajaAhorro.Web.Controllers
{
    public class BankCompaniesController : Controller
    {
        private readonly IBankCompanyRepository bankCompanyRepository;
        private readonly IMapper mapper;

        public BankCompaniesController(IBankCompanyRepository bankCompanyRepository, IMapper mapper)
        {
            this.bankCompanyRepository = bankCompanyRepository;
            this.mapper = mapper;
        }

        // GET: BankCompanies
        public IActionResult Index()
        {
            return View(this.bankCompanyRepository.GetAllWithEntities());
        }

        // GET: BankCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankCompany = await this.bankCompanyRepository.GetByIdASyncWithEntities(id.Value);
            var bankCompanyViewModel = GetViewModel(bankCompany);
            if (bankCompany == null)
            {
                return NotFound();
            }

            return View(bankCompanyViewModel);
        }

        // GET: BankCompanies/Create
        public IActionResult Create()
        {
            BankCompanyViewModel bankCompanyViewModel = new BankCompanyViewModel();
            bankCompanyViewModel.BankSelectList = new SelectList(this.bankCompanyRepository.GetBanks().AsNoTracking(), "Id", "Name", null);
            bankCompanyViewModel.CompanySelectList = new SelectList(this.bankCompanyRepository.GetCompanies().AsNoTracking(), "Id", "Name", null);
            bankCompanyViewModel.TypeAccountList = new SelectList(this.bankCompanyRepository.GetParameters(1).AsNoTracking(), "IntValue", "StringValue", null);
            return View(bankCompanyViewModel);
        }

        // POST: BankCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankCompanyViewModel bankCompanyViewModel)
        {
            if (ModelState.IsValid)
            {
                bankCompanyViewModel.DateCreate = DateTime.Now;
                bankCompanyViewModel.Deleted = false;
                var bankCompany = GetModel(bankCompanyViewModel);
                await this.bankCompanyRepository.CreateAsync(bankCompany);
                return RedirectToAction(nameof(Index));
            }
            bankCompanyViewModel.BankSelectList = new SelectList(this.bankCompanyRepository.GetBanks().AsNoTracking(), "Id", "Name", bankCompanyViewModel.BankId);
            bankCompanyViewModel.CompanySelectList = new SelectList(this.bankCompanyRepository.GetCompanies().AsNoTracking(), "Id", "Name", bankCompanyViewModel.CompanyId);
            bankCompanyViewModel.TypeAccountList = new SelectList(this.bankCompanyRepository.GetParameters(1).AsNoTracking(), "IntValue", "StringValue", bankCompanyViewModel.AccountType);
            return View(bankCompanyViewModel);
        }

        // GET: BankCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankCompany = await this.bankCompanyRepository.GetByIdASyncWithEntities(id.Value);
            var bankCompanyViewModel = GetViewModel(bankCompany);
            if (bankCompany == null)
            {
                return NotFound();
            }
            return View(bankCompanyViewModel);
        }

        // POST: BankCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BankCompanyViewModel bankCompanyViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bankCompany = GetModel(bankCompanyViewModel);
                    await this.bankCompanyRepository.UpdateAsync(bankCompany);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.bankCompanyRepository.ExistAsync(bankCompanyViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bankCompanyViewModel);
        }

        private BankCompany GetModel(BankCompanyViewModel entity)
        {
            var bank = this.bankCompanyRepository.GetBanks().FirstOrDefault(x => x.Id == entity.BankId);
            var company = this.bankCompanyRepository.GetCompanies().FirstOrDefault(x => x.Id == entity.CompanyId);
            entity.Bank = bank;
            entity.Company = company;
            entity.DateModify = DateTime.Now;
            return mapper.Map<BankCompany>(entity);
        }

        // GET: BankCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankCompany = await this.bankCompanyRepository.GetByIdASyncWithEntities(id.Value);
            var bankCompanyViewModel = GetViewModel(bankCompany);
            if (bankCompany == null)
            {
                return NotFound();
            }

            return View(bankCompanyViewModel);
        }

        private BankCompanyViewModel GetViewModel(BankCompany dto)
        {
            BankCompanyViewModel entity = new BankCompanyViewModel();
            entity = mapper.Map<BankCompanyViewModel>(dto);
            entity.BankSelectList = new SelectList(this.bankCompanyRepository.GetBanks().AsNoTracking(), "Id", "Name", dto.Bank.Id);
            entity.CompanySelectList = new SelectList(this.bankCompanyRepository.GetCompanies().AsNoTracking(), "Id", "Name", dto.Company.Id);
            entity.TypeAccountList = new SelectList(this.bankCompanyRepository.GetParameters(1).AsNoTracking(), "IntValue", "StringValue", dto.AccountType);
            entity.TypeAccountName = this.bankCompanyRepository.GetParameters(1).AsNoTracking().Where(x => x.IntValue == dto.AccountType).FirstOrDefault().StringValue;
            return entity;
        }

        // POST: BankCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankCompany = await this.bankCompanyRepository.GetByIdAsync(id);
            await this.bankCompanyRepository.DeleteAsync(bankCompany);
            return RedirectToAction(nameof(Index));
        }
    }
}
