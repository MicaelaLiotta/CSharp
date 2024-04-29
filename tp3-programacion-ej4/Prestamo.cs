using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3_programacion_ej4
{
    
        public class Prestamo
        {
            public DateTime FechaPrestamo { get; set; }
            public DateTime FechaDevolucion { get; set; }
            public Libro LibroPrestado { get; set; }
            public string Lector { get; set; }
        }

    
}
