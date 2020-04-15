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
    public class OcupationsController : Controller
    {
        private readonly IOcupationRepository ocupationRepository;

        public OcupationsController(IOcupationRepository ocupationRepository)
        {
            this.ocupationRepository = ocupationRepository;
        }

        // GET: Ocupations
        public IActionResult Index()
        {
            return View(ocupationRepository.GetAll());
        }

        // GET: Ocupations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocupation = await ocupationRepository.GetByIdAsync(id.Value);
            if (ocupation == null)
            {
                return NotFound();
            }

            return View(ocupation);
        }

        // GET: Ocupations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ocupations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ocupation ocupation)
        {
            if (ModelState.IsValid)
            {
                ocupation.DateCreate = DateTime.Now;
                ocupation.DateModified = DateTime.Now;
                await ocupationRepository.CreateAsync(ocupation);
                return RedirectToAction(nameof(Index));
            }
            return View(ocupation);
        }

        // GET: Ocupations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocupation = await ocupationRepository.GetByIdAsync(id.Value);
            if (ocupation == null)
            {
                return NotFound();
            }
            return View(ocupation);
        }

        // POST: Ocupations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ocupation ocupation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ocupation.DateModified = DateTime.Now;
                    await this.ocupationRepository.UpdateAsync(ocupation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ocupationRepository.ExistAsync(ocupation.Id))
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
            return View(ocupation);
        }

        // GET: Ocupations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocupation = await ocupationRepository.GetByIdAsync(id.Value);
            if (ocupation == null)
            {
                return NotFound();
            }

            return View(ocupation);
        }

        // POST: Ocupations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ocupation = await ocupationRepository.GetByIdAsync(id);
            await ocupationRepository.DeleteAsync(ocupation);
            return RedirectToAction(nameof(Index));
        }
    }
}
