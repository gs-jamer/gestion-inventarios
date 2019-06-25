using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class InventarioElem
    {
        private string _nombre;
        private DateTime _fechaCaducidad;
        private string _tipo;

        public InventarioElem()
        {
            _nombre = string.Empty;
            _fechaCaducidad = DateTime.MinValue;
            _tipo = string.Empty;
        }

        public InventarioElem(string nombre, DateTime fechaCaducidad, string tipo)
        {
            _nombre = nombre;
            _fechaCaducidad = fechaCaducidad;
            _tipo = tipo;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public DateTime FechaCaducidad
        {
            get { return _fechaCaducidad; }
            set { _fechaCaducidad = value; }
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            InventarioElem e = (InventarioElem)obj;
            return (this.Nombre == e.Nombre) && (this.Tipo == e.Tipo) && (this.FechaCaducidad == e.FechaCaducidad);
        }
    }
}