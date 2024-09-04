﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos
{
    public class Nodo
    {
        public int Dato { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }

        public void Agregar(int valor)
        {
            if(valor < Dato)
            {
                if(Anterior == null)
                {
                    Anterior = new Nodo { Dato = valor };
                }
                else
                {
                    Anterior.Agregar(valor);
                }

            }
            else
            {
                if (Siguiente == null)
                {
                    Siguiente = new Nodo { Dato = valor };
                }
                else
                {
                    Siguiente.Agregar(valor);
                }
            }

          
        }

        public void Inorden()
        {
            if(Anterior != null)
            {
                Anterior.Inorden();
            }
            Console.WriteLine(Dato);

            if(Siguiente != null)
            {
                Siguiente.Inorden();
            }
        }
    }
}
