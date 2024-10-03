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
            //encontrar el 0.
            int f = -1; //fila
            int c = -1; //columna
			bool encontrado = false;

			//for (f = 0;  f < 3; f++)
			//{
			//    for (c = 0; c < 3; c++)
			//    {
			//        if (actual.Tablero[f,c] == 0)
			//        {
			//            break;
			//        }
			//    }
			//}

			for (int i = 0; i < 3 && !encontrado; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (actual.Tablero[i, j] == 0)
					{
						f = i;
						c = j;
						encontrado = true;
						break;
					}
				}
			}

		    //Generacion de sucesores, despues de encontrar el 0.
		    List<Nodo> sucesores = new();

            //crear los nuevos nodos y agregarlos a la lista.
            if(f > 0) //verificar el intercambio con la posicion de arriba
            {
                Nodo nuevo = new();
                nuevo.Tablero = new byte[3,3];
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
                        nuevo.Tablero[i, j] = actual.Tablero[i, j];
					}
				}

				//Hacer el intercambio
				//f-1,c
				nuevo.Tablero[f, c] = actual.Tablero[f - 1, c];  // Mover el valor de arriba hacia la posición del 0
				nuevo.Tablero[f - 1, c] = 0; // Colocar el 0 en la posición de arriba.
				sucesores.Add(nuevo);
			}

			if(f < 2)
			{
				Nodo nuevo = new();
				nuevo.Tablero = new byte[3, 3];
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						nuevo.Tablero[i, j] = actual.Tablero[i, j];
					}
				}

				nuevo.Tablero[f, c] = actual.Tablero[f + 1, c]; // Mover el valor de abajo hacia la posición del 0
				nuevo.Tablero[f + 1, c] = 0; // Colocar el 0 en la posición de abajo
				sucesores.Add(nuevo);
			}

			if(c > 0)
			{
				Nodo nuevo = new();
				nuevo.Tablero = new byte[3, 3];
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						nuevo.Tablero[i, j] = actual.Tablero[i, j];
					}
				}
				nuevo.Tablero[f, c] = actual.Tablero[f, c - 1];
				nuevo.Tablero[f, c - 1] = 0;
				sucesores.Add(nuevo);
			}

			if(c < 2)
			{
				Nodo nuevo = new();
				nuevo.Tablero = new byte[3, 3];
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						nuevo.Tablero[i, j] = actual.Tablero[i, j];
					}
				}
				nuevo.Tablero[f, c] = actual.Tablero[f, c + 1];
				nuevo.Tablero[f, c + 1] = 0;
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

			//interpolar
			//$"{Estado[0,0]}{Estado[0,0]}"


		}


	}
}
