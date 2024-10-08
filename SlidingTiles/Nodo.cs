using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SlidingTiles
{
	public class Nodo
	{
        public int G { get; set; }
        public int H { get; set; }
        public int F //suma de G y H.
		{
            get { return G + H; }
        }
        public Nodo? Padre { get; set; }

        public byte[,] Tablero;

		public List<Nodo> GenerarSucesores(Nodo actual)
		{
			int fila = 0;
			int columna = 0;

			//recorrer mariz para encontrar la posicion del 0
			for (int f = 0; f < 3; f++)
			{
				for (int c = 0; c < 3; c++)
				{
					if (actual.Tablero[f, c] == 0) // si se encuentra el 0
					{
						fila = f;   //se guarda la fila donde se encuentra
						columna = c;  // se guarda la columna donde se encuentra
						break; 
					}
				}
			}

			List<Nodo> sucesores = new List<Nodo>();

			if (fila > 0)
			{
				Nodo nuevo = new();
				nuevo.Tablero = new byte[3, 3];

				for (int f = 0; f < 3; f++)
				{
					for (int c = 0; c < 3; c++)
					{
						nuevo.Tablero[f, c] = actual.Tablero[f, c];
					}
				}

				nuevo.Tablero[fila, columna] = actual.Tablero[fila - 1, columna]; // se asigna el numero de arriba a la posicion actual.
				nuevo.Tablero[fila - 1, columna] = 0; // la posicion de arriba queda vacia asi que se le asigna el 0.
				sucesores.Add(nuevo);
			}

			if (fila < 2)
			{
				Nodo nuevo = new();
				nuevo.Tablero = new byte[3, 3];

				for (int f = 0; f < 3; f++)
				{
					for (int c = 0; c < 3; c++)
					{
						nuevo.Tablero[f, c] = actual.Tablero[f, c];
					}
				}

				nuevo.Tablero[fila, columna] = actual.Tablero[fila + 1, columna]; // se asigna el numero de abajo a la posicion actual.
				nuevo.Tablero[fila + 1, columna] = 0;  // la posicion de abajo queda vacia asi que se le asigna el 0.
				sucesores.Add(nuevo);
			}

			if (columna > 0)
			{
				Nodo nuevo = new();
				nuevo.Tablero = new byte[3, 3];

				for (int f = 0; f < 3; f++)
				{
					for (int c = 0; c < 3; c++)
					{
						nuevo.Tablero[f, c] = actual.Tablero[f, c];
					}
				}

				nuevo.Tablero[fila, columna] = actual.Tablero[fila, columna - 1]; // se asigna el numero de la izq a la posicion actual.
				nuevo.Tablero[fila, columna - 1] = 0; // la posicion de la izq queda vacia asi que se le asigna el 0.
				sucesores.Add(nuevo);
			}

			if (columna < 2)
			{
				Nodo nuevo = new();
				nuevo.Tablero = new byte[3, 3];

				for (int f = 0; f < 3; f++)
				{
					for (int c = 0; c < 3; c++)
					{
						nuevo.Tablero[f, c] = actual.Tablero[f, c];
					}
				}

				nuevo.Tablero[fila, columna] = actual.Tablero[fila, columna + 1]; // se asigna el numero de la derecha a la posicion actual.
				nuevo.Tablero[fila, columna + 1] = 0; // la posicion de la derecha queda vacia asi que se le asigna el 0.
				sucesores.Add(nuevo);
			}

			return sucesores;
		}



		public void Euristica(Nodo a)
        {
            byte[,] estado = new byte[,] { { 5, 4, 7 }, { 2, 3, 1 }, { 8, 2, 0 } };

            Dictionary<byte, byte[]> meta = new Dictionary<byte, byte[]>();
            meta[1] = new byte[] { 0, 0 };
			meta[2] = new byte[] { 0, 1 };
			meta[3] = new byte[] { 0, 2 };
			meta[4] = new byte[] { 1, 0 };
			meta[5] = new byte[] { 1, 1 };
			meta[6] = new byte[] { 1, 2 };
			meta[7] = new byte[] { 2, 0 };
			meta[8] = new byte[] { 2, 1 };
			meta[0] = new byte[] { 2, 2 };

            int resultado=0;
            //suma de distancias
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var posicion = meta[estado[i, j]];
                    resultado += Math.Abs(i - posicion[0]) + Math.Abs(j - posicion[1]);
                }
            }
		}


	}
}











//interpolar
//$"{Estado[0,0]}{Estado[0,0]}"