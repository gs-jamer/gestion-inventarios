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
        private InventarioController _controller;
        private InventarioController TestController
        {
            get
            {
                if(_controller == null)
                {
                    _controller = new InventarioController();
                }
                return _controller;
            }
        }

        public void PtoEntrada()
        {
            InsertarElemento();
            InsertarElementoCaducado();
            BorrarElemento();
            BorrarElementoCaducado();
        }

        [TestMethod]
        public void InsertarElemento()
        {
            string nombre = "Elemento Inventario 1";
            string tipo = "Tipo Correcto";
            DateTime fecha = DateTime.Today;
            AddElemViewModel model = new AddElemViewModel()
            {
                Nombre = nombre,
                Tipo = tipo,
                FechaCaducidad = fecha
            };
            var result = (RedirectToRouteResult)TestController.AddElem(model);

            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsTrue(Inventario.DicInventario.ContainsKey(nombre));
            Assert.AreEqual(new InventarioElem(nombre, fecha, tipo), Inventario.DicInventario[nombre]);
        }

        [TestMethod]
        public void InsertarElementoCaducado()
        {
            string nombre = "Elemento Inventario 2 Caducado";
            string tipo = "Tipo Caducado";
            DateTime fecha = DateTime.Today.AddMonths(-1);
            AddElemViewModel model = new AddElemViewModel()
            {
                Nombre = nombre,
                Tipo = tipo,
                FechaCaducidad = fecha
            };
            var result = (RedirectToRouteResult)TestController.AddElem(model);

            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsTrue(Inventario.DicInventario.ContainsKey(nombre));
            Assert.AreEqual(new InventarioElem(nombre, fecha, tipo), Inventario.DicInventario[nombre]);
        }

        [TestMethod]
        public void BorrarElemento()
        {
            string nombre = "Elemento Inventario 1";
            var result = (RedirectToRouteResult)TestController.RemoveElem(nombre);

            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsFalse(Inventario.DicInventario.ContainsKey(nombre));
        }

        [TestMethod]
        public void BorrarElementoCaducado()
        {
            string nombre = "Elemento Inventario 2 Caducado";
            var result = (RedirectToRouteResult)TestController.RemoveElem(nombre);

            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsFalse(Inventario.DicInventario.ContainsKey(nombre));
        }
        
    }
}