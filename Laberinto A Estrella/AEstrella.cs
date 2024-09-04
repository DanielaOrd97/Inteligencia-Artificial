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
    }
}
