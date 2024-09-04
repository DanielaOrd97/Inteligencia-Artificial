using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto_A_Estrella
{
    public class Nodo
    {
        //LABERINTO

        public int X { get; set; }  //para posicion
        public int Y { get; set; } //para posicion
        public bool Bloqueada { get; set; } //casillas por las que no se puede pasar.
        public Nodo Padre { get; set; }
        public int G { get; set; }
        public int H { get; set; }

        public int F
        {
            get { return G + H; }
        }

        public Nodo(int x, int y, bool bloqueada)
        {
            X = x;
            Y = y;
            Bloqueada = bloqueada;
        }
    }
}
