using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CajaAhorro.Web.Data;
using CajaAhorro.Web.Data.Entities;

namespace CajaAhorro.Web.Controllers
{
    public class BanksController : Controller
    {
        private readonly IBankRepository bankRepository;

        public BanksController(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }

        // GET: Banks
        public IActionResult Index()
        {
            return View(this.bankRepository.GetAll());
        }

        // GET: Banks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await this.bankRepository.GetByIdAsync(id.Value);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        // GET: Banks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bank bank)
        {
            if (ModelState.IsValid)
            {
                bank.ModifyDate = DateTime.Now;
                bank.CreateDate = DateTime.Now;
                await this.bankRepository.CreateAsync(bank);
                return RedirectToAction(nameof(Index));
            }
            return View(bank);
        }

        // GET: Banks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await this.bankRepository.GetByIdAsync(id.Value);
            if (bank == null)
            {
                return NotFound();
            }
            return View(bank);
        }

        // POST: Banks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Bank bank)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    bank.ModifyDate = DateTime.Now;
                    await this.bankRepository.UpdateAsync(bank);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.bankRepository.ExistAsync(bank.Id))
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
            return View(bank);
        }

        // GET: Banks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank = await this.bankRepository.GetByIdAsync(id.Value);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bank = await this.bankRepository.GetByIdAsync(id);
            await this.bankRepository.DeleteAsync(bank);
            return RedirectToAction(nameof(Index));
        }
    }
}
