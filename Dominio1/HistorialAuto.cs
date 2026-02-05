using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio1
{
    public class HistorialAuto
    {
        public int Id { get; set; }
        public int IdAuto { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
        public string ModeloAuto { get; set; }
    }
}
