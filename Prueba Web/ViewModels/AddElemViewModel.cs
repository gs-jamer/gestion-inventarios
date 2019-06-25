using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModels
{
    public class AddElemViewModel
    {
        
        [Required(ErrorMessage ="Nombre obligatorio.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Fecha de caducidad obligatoria.")]
        [Display(Name = "Fecha de Caducidad")]
        public DateTime FechaCaducidad { get; set; }

        [Required(ErrorMessage = "Tipo obligatorio.")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
    }
}