
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio.Interfaces;

namespace ProdeDBFirst.Controllers
{
    public class EquipoController : Controller
    {
        private readonly IEquipoNegocio _equipoNegocio;

        public EquipoController(IEquipoNegocio equipoNegocio)
        {
            _equipoNegocio = equipoNegocio;
        }

        // GET: Equipo
        public async Task<IActionResult> Index()
        {
            return View(await _equipoNegocio.GetAllAsync());
        }

        // GET: Equipo/Details/5
        [ResponseCache(Duration = 120)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _equipoNegocio.GetById(id.GetValueOrDefault());
            if (equipo == null)
            {
                return NotFound();
            }
            
            return View(equipo);
        }

        // GET: Equipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipoId,Nombre,Codigo")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                await _equipoNegocio.Create(equipo);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: Equipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _equipoNegocio.GetById(id.GetValueOrDefault());
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: Equipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipoId,Nombre,Codigo")] Equipo equipo)
        {
            if (id != equipo.EquipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _equipoNegocio.Update(equipo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var equipoExiste = await EquipoExists(equipo.EquipoId);
                    if (!equipoExiste)
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
            return View(equipo);
        }

        // GET: Equipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _equipoNegocio.GetById(id.GetValueOrDefault());
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _equipoNegocio.GetById(id);
            await _equipoNegocio.Delete(equipo.EquipoId);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EquipoExists(int id)
        {
            var equipo = await _equipoNegocio.GetById(id);
            return equipo != null;
        }
    }
}
