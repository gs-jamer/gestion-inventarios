using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewModels
{
    public class RemoveElemByNameViewModel
    {

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public DateTime FechaCaducidad { get; set; }

        public IEnumerable<SelectListItem> SelectListItems { get; set; }
        public List<string> Inventario { get; set; }
    }
}