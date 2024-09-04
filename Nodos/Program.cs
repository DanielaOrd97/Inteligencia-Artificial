using Nodos;

Nodo raiz = new Nodo() { Dato = 12};

raiz.Agregar(5);
raiz.Agregar(7);
raiz.Agregar(1);
raiz.Agregar(10);
raiz.Agregar(50);
raiz.Agregar(3);
raiz.Agregar(8);



raiz.Inorden();

Console.WriteLine("Exito");