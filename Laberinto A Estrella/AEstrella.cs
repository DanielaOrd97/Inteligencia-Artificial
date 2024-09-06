using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto_A_Estrella
{
    public class AEstrella
    {
        readonly int _ancho; //dimensiones tablero
        readonly int _alto; //dimensiones tablero

        readonly Nodo[,] _nodos;

        public AEstrella(int ancho, int alto, bool[,] mapa)
        {
            _ancho = ancho;
            _alto = alto;
            _nodos = new Nodo[ancho, alto];


            //Matriz de booleanos para los nodos (bloqueada o no). 
            for (int i = 0; i < _ancho; i++)
            {
                for (int j = 0; j < _alto; j++)
                {
                    _nodos[i, j] = new Nodo(i, j, mapa[i, j]);
                }
            }
        }

        //Calcular distancia Manhattan de un punto a otro con valores absolutos.
        public int Heuristica(Nodo a, Nodo b) => 
            Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

        public List<Nodo> GenerarSucesores(Nodo nodo)
        {
            List<Nodo> sucesores = new List<Nodo>();
            int nuevaX;
            int nuevaY;

            //Hacia arriba
            nuevaX = nodo.X;
            nuevaY = nodo.Y-1;    

            if(nuevaX >= 0)
            {
                sucesores.Add(_nodos[nuevaX,nuevaY]);
            }

			//Hacia abajo
			nuevaX = nodo.X;
			nuevaY = nodo.Y + 1;

            if(nuevaY < _alto)
            {
                sucesores.Add(_nodos[nuevaX, nuevaY]);
            }

            //Hacia la izq
            nuevaX = nodo.X - 1;
            nuevaY = nodo.Y;

            if(nuevaX >= 0)
            {
                sucesores.Add(_nodos[nuevaX, nuevaY]);
            }

            //Hacia la derecha
            nuevaX = nodo.X + 1;
            nuevaY = nodo.Y;

            if(nuevaX < _ancho)
            {
                sucesores.Add(_nodos[nuevaX, nuevaY]);
            }

            return sucesores;
        }

        public List<Nodo> BuscarRuta(Nodo origen, Nodo meta)
        {
            List<Nodo> abiertos = new List<Nodo>();
            abiertos.Add(origen); //Iniciar algoritmo.
            HashSet<Nodo> cerrados = new HashSet<Nodo>();
            //origen.G: Costo de la distancia.
            origen.G = 0; //distancia a la que esta el origen del origen.
            origen.H = Heuristica(origen, meta);

        }
    }
}
