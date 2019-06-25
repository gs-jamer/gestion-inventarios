using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModels;
using Integration;

namespace Controllers
{
    public class InventarioController : Controller
    {
        private SortedDictionary<string, InventarioElem> inventario = Inventario.DicInventario;

        public InventarioController()
        {

            ComprobarElementosCaducados();
        }

        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Inventario = inventario;
            return View("Index", model);
        }

        private void ComprobarElementosCaducados()
        {
            ViewBag.NumElementosCaducados = 0;
            ViewBag.ElementosCaducados = new List<InventarioElem>();
            foreach(var elem in inventario)
            {
                if(elem.Value.FechaCaducidad.Date <= DateTime.Today.Date)
                {
                    ViewBag.NumElementosCaducados++;
                    ViewBag.ElementosCaducados.Add(elem.Value);
                }
            }
        }

        [ActionName("AddElem")]
        public ActionResult AddElemView()
        {
            AddElemViewModel model = new AddElemViewModel();
            return View("AddElem", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddElem(AddElemViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!inventario.ContainsKey(model.Nombre))
                {
                    inventario.Add(model.Nombre, new InventarioElem(model.Nombre, model.FechaCaducidad, model.Tipo));
                }
                return RedirectToAction("Index");
            }
            else return View("AddElem", model);
        }

        [ActionName("RemoveElemByName")]
        public ActionResult RemoveElemByNameView()
        {
            RemoveElemByNameViewModel model = new RemoveElemByNameViewModel();
            model.SelectListItems = new SelectList(inventario.Keys);
            model.Inventario = inventario.Keys.ToList();
            return View("RemoveElemByName", model);
        }

        [HttpGet]
        [ActionName("GetElemToRemove")]
        public ActionResult GetElemToRemove(RemoveElemByNameViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SelectListItems = new SelectList(inventario.Keys);
                model.Inventario = inventario.Keys.ToList();
                model.Tipo = inventario[model.Nombre].Tipo;
                model.FechaCaducidad = inventario[model.Nombre].FechaCaducidad;
                return View("RemoveElemByName", model);
            }
            else return RedirectToAction("Index");
        }

        [ActionName("RemoveElem")]
        public ActionResult RemoveElem(string nombre)
        {
            if (inventario.ContainsKey(nombre))
            {
                inventario.Remove(nombre);
                IndexViewModel model = new IndexViewModel();
                model.Inventario = inventario;
                model.UltimoElementoEliminado = new IndexViewModel.ElementoEliminado() { Eliminado = true, NombreElemento = nombre };
                return View("Index", model);
            }
            return RedirectToAction("Index");

        }
    }
}