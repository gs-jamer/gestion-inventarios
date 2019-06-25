using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using ViewModels;
using Integration;

namespace Controllers
{
    [TestClass]
    public class Test
    {

        [TestMethod]
        public void PtoEntrada()
        {
            var controller = new InventarioController();
            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void InsertarElemento()
        {
            var controller = new InventarioController();
            string nombre = "Elemento Inventario 1";
            string tipo = "Tipo Correcto";
            DateTime fecha = DateTime.Today;
            AddElemViewModel model = new AddElemViewModel()
            {
                Nombre = nombre,
                Tipo = tipo,
                FechaCaducidad = fecha
            };
            var result = (RedirectToRouteResult) controller.AddElem(model);

            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(new InventarioElem(nombre, fecha, tipo), Inventario.DicInventario[nombre]);
        }

        [TestMethod]
        public void InsertarElementoCaducado()
        {
            var controller = new InventarioController();
            string nombre = "Elemento Inventario 2 Caducado";
            string tipo = "Tipo Caducado";
            DateTime fecha = DateTime.Today.AddMonths(-1);
            AddElemViewModel model = new AddElemViewModel()
            {
                Nombre = nombre,
                Tipo = tipo,
                FechaCaducidad = fecha
            };
            var result = (RedirectToRouteResult)controller.AddElem(model);

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void BorrarElemento()
        {
            var controller = new InventarioController();
            string nombre = "Elemento Inventario 2 Caducado";
            var result = (RedirectToRouteResult)controller.RemoveElem(nombre);

            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(false, Inventario.DicInventario.ContainsKey(nombre));
        }

        [TestMethod]
        public void BorrarElementoCaducado()
        {

        }

        [TestMethod]
        public void ListarElementos()
        {

        }
    }
}