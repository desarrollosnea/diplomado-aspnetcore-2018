
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdeDBFirst.Datos.Interface;
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio.Interfaces;

namespace ProdeDBFirst.Controllers
{
    public class TorneoController : Controller
    {
        private readonly ITorneoNegocio _TorneoNegocio;

        public TorneoController(ITorneoNegocio TorneoNegocio)
        {
            _TorneoNegocio = TorneoNegocio;
        }

        // GET: Torneo
        public async Task<IActionResult> Index()
        {
            return View(await _TorneoNegocio.GetAllAsync());
        }

        // GET: Torneo/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Torneo = await _TorneoNegocio.GetById(id.GetValueOrDefault());
        //    if (Torneo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(Torneo);
        //}

        //// GET: Torneo/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Torneo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("TorneoId,Nombre,Codigo")] Torneo Torneo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _TorneoNegocio.Create(Torneo);
        //        //await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(Torneo);
        //}

        // GET: Torneo/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Torneo = await _TorneoNegocio.GetById(id.GetValueOrDefault());
        //    if (Torneo == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Torneo);
        //}

        // POST: Torneo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("TorneoId,Nombre,Codigo")] Torneo Torneo)
        //{
        //    if (id != Torneo.TorneoId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //           await _TorneoNegocio.Update(Torneo);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            var TorneoExiste = await TorneoExists(Torneo.TorneoId);
        //            if (!TorneoExiste)
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(Torneo);
        //}

        // GET: Torneo/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Torneo = await _TorneoNegocio.GetById(id.GetValueOrDefault());
        //    if (Torneo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(Torneo);
        //}

        // POST: Torneo/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var Torneo = await _TorneoNegocio.GetById(id);
        //    await _TorneoNegocio.Delete(Torneo.TorneoId);
        //    return RedirectToAction(nameof(Index));
        //}

        //private async Task<bool> TorneoExists(int id)
        //{
        //    var Torneo = await _TorneoNegocio.GetById(id);
        //    return Torneo != null;
        //}
    }
}
