using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListasCirculares_Procesos
{
    public partial class Form1 : Form
    {
        static Random aleatorio = new Random();
        Procesador proceso = new Procesador();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            int contadorDeVacio = 0;
            int contadorDeCompletos = 0;
            int contadorCiclosquellegaron = 0;


            for (int i = 0; i < 300; i++)
            {
                if (aleatorio.Next(1, 101) <= 35)
                {
                    Proceso nuevoP = new Proceso();
                    proceso.Agregar(nuevoP);//Meter proceso
                    contadorCiclosquellegaron++;

                }
                Proceso vProceso = proceso.peek(); //Ver primero de la cola
                if (vProceso != null)
                {
                    vProceso.ciclos--;
                    if (vProceso.ciclos == 0)
                    {
                        proceso.Sacar();//saca proceso
                        contadorDeCompletos++;
                    }

                    proceso.Avanzar();
                }
                else
                {
                    contadorDeVacio++; //si el procesador está vacío, suma uno al contador
                }

            }
            txtProcesos.Text = "Ciclos que estuvo vacía: " + contadorDeVacio.ToString() + Environment.NewLine + proceso.procesosoPendientes() + Environment.NewLine + 
                               "Procesos completos: " + contadorDeCompletos.ToString() + Environment.NewLine +
                               "Ciclos que llegaron: " + contadorCiclosquellegaron.ToString() + Environment.NewLine;
        }
    }

 }

