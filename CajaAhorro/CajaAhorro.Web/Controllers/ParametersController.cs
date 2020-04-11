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
    public class ParametersController : Controller
    {
        private readonly IParameterRepository parameterRepository;

        public ParametersController(IParameterRepository parameterRepository)
        {
            this.parameterRepository = parameterRepository;
        }

        // GET: Parameters
        public IActionResult Index()
        {
            return View(this.parameterRepository.GetAll());
        }

        // GET: Parameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await this.parameterRepository.GetByIdAsync(id.Value);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // GET: Parameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                await this.parameterRepository.CreateAsync(parameter);
                return RedirectToAction(nameof(Index));
            }
            return View(parameter);
        }

        // GET: Parameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await this.parameterRepository.GetByIdAsync(id.Value);
            if (parameter == null)
            {
                return NotFound();
            }
            return View(parameter);
        }

        // POST: Parameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.parameterRepository.UpdateAsync(parameter);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.parameterRepository.ExistAsync(parameter.Id))
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
            return View(parameter);
        }

        // GET: Parameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await this.parameterRepository.GetByIdAsync(id.Value);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // POST: Parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parameter = await this.parameterRepository.GetByIdAsync(id);
            await this.parameterRepository.DeleteAsync(parameter);
            return RedirectToAction(nameof(Index));
        }
    }
}
