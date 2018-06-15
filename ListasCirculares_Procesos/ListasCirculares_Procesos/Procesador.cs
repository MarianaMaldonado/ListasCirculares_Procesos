using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasCirculares_Procesos
{
    class Procesador
    {
        Proceso inicio, ultimo, temporal;


        public Procesador()
        {
            inicio = null;
            ultimo = null;
        }

        public void Agregar(Proceso nuevoP) //Meter proceso
        {
            if (inicio == null)
            {
                inicio = nuevoP;
                ultimo = nuevoP;
                inicio.siguiente = nuevoP;
                inicio.anterior = nuevoP;
            }
            else
            {
                ultimo.siguiente = nuevoP;
                nuevoP.anterior = ultimo;
                nuevoP.siguiente = inicio;
                inicio = nuevoP;
                inicio.anterior = ultimo;
            }
        }

        public Proceso Sacar() //sacar proceso
        {
            if (inicio == null)
            {
                return null;
            }
            else if (inicio.siguiente == inicio)
            {
                temporal = inicio;
                inicio = ultimo = null;
                return temporal;
            }

            temporal = inicio;
            inicio = inicio.siguiente;
            inicio.anterior = ultimo;
            ultimo.siguiente = inicio;


            return temporal;
        }

        public void Avanzar()
        {
            if (inicio != null)
                inicio = inicio.siguiente;
        }

        public Proceso peek() //Ver proceso actual
        {
            return inicio;
        }

        public string procesosoPendientes()
        {
            int procPendientes = 0;
            int sumaCiclosPendientes = 0;
            temporal = inicio;

            if (inicio != null)
                do
                {
                    sumaCiclosPendientes += temporal.ciclos;
                    procPendientes++;
                    temporal = temporal.siguiente;
                } while (temporal != ultimo);
            string pendientes = "Procesos pendientes: " + procPendientes.ToString() + Environment.NewLine +
                                "Suma de los ciclos pendientes: " + sumaCiclosPendientes.ToString();

            return pendientes;
        }
    }
}
