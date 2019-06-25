using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Integration
{
    public class Inventario
    {

        private static SortedDictionary<string, InventarioElem> _inventario;

        public static SortedDictionary<string, InventarioElem> DicInventario {
            get
            {
                if (_inventario == null)
                    _inventario = new SortedDictionary<string, InventarioElem>();
                return _inventario;
            }

        }
    }
}