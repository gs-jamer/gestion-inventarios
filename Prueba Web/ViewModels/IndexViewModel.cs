using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ViewModels
{
    public class IndexViewModel
    {
        public class ElementoEliminado
        {
            public bool Eliminado { get; set; }
            public string NombreElemento { get; set; }
        };

        public SortedDictionary<string, InventarioElem> Inventario { get; set; }

        public ElementoEliminado UltimoElementoEliminado { get; set; } = new ElementoEliminado() { Eliminado = false, NombreElemento = string.Empty };
    }
}