using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasCirculares_Procesos
{
    class Proceso
    {
        public int ciclos { get; set; }
        public Proceso siguiente { get; set; }
        public Proceso anterior { get; set; }

        static Random aleatorio = new Random();

        public Proceso()
        {
            ciclos = aleatorio.Next(4, 15);

            siguiente = null;
            anterior = null;
        }
    }
}
