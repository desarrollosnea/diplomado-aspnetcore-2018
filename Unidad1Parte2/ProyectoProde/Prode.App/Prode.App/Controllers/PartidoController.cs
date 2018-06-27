using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prode.App.Entidades;

namespace Prode.App.Controllers
{
    public class PartidoController : Controller
    {
        // GET: Partido
        public ActionResult Index()
        {
            return View();
        }

        // GET: Partido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Partido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Partido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Partido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Partido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Partido/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

		public ActionResult ResultadoPartido()
		{
			Equipo Equipo1 = new Equipo()
			{
				EquidoId = 1,
				Nombre = "Argentina"
			};

			Equipo Equipo2 = new Equipo()
			{
				EquidoId = 2,
				Nombre = "Nigeria"
			};

			Partido Partido = new Partido()
			{
				EquipoLocal = Equipo1,
				EquipoVisitante = Equipo2,
				Fecha = DateTime.Today,
				GolesLocal = 1,
				GolesVisitante = 2,
				Lugar = "Rusia"

			};

			ViewData["EquipoLocal"] = Partido.EquipoLocal.Nombre;
			ViewData["idLocal"] = Partido.EquipoLocal.EquidoId;
			ViewData["EquipoLocalDescripcion"] = Partido.EquipoLocal.Nombre;
			ViewData["EquipoVisitante"] = Partido.EquipoVisitante.Nombre;
			ViewData["Resultado"] = Partido.InformarResultado;
			ViewBag.MostrarResultado = true;

			return View("ResultadoPartido",Partido);

		}

    }
}