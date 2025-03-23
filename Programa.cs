using System;

class Nodo
{
    public int temperatura;
    public Nodo izquierda, derecha;

    public Nodo(int temperatura)
    {
        this.temperatura = temperatura;
        izquierda = derecha = null;
    }
}

class ArbolBinario
{
    private Nodo raiz;

    public void Insertar(int temperatura)
    {
        raiz = InsertarRecursivo(raiz, temperatura);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int temperatura)
    {
        if (nodo == null)
        {
            return new Nodo(temperatura);
        }

        if (temperatura < nodo.temperatura)
            nodo.izquierda = InsertarRecursivo(nodo.izquierda, temperatura);
        else
            nodo.derecha = InsertarRecursivo(nodo.derecha, temperatura);

        return nodo;
    }

    public bool Buscar(int temperatura)
    {
        return BuscarRecursivo(raiz, temperatura) != null;
    }

    private Nodo BuscarRecursivo(Nodo nodo, int temperatura)
    {
        if (nodo == null || nodo.temperatura == temperatura)
            return nodo;

        if (temperatura < nodo.temperatura)
            return BuscarRecursivo(nodo.izquierda, temperatura);

        return BuscarRecursivo(nodo.derecha, temperatura);
    }

    public void InOrden()
    {
        InOrdenRecursivo(raiz);
        Console.WriteLine();
    }

    private void InOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrdenRecursivo(nodo.izquierda);
            Console.Write(nodo.temperatura + " ");
            InOrdenRecursivo(nodo.derecha);
        }
    }

    public void PosOrden()
    {
        PosOrdenRecursivo(raiz);
        Console.WriteLine();
    }

    private void PosOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            PosOrdenRecursivo(nodo.izquierda);
            PosOrdenRecursivo(nodo.derecha);
            Console.Write(nodo.temperatura + " ");
        }
    }
}

class Programa
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, temperatura;

        do
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Insertar temperatura");
            Console.WriteLine("2. Buscar temperatura");
            Console.WriteLine("3. Recorrido InOrden");
            Console.WriteLine("4. Recorrido PosOrden");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la temperatura a insertar: ");
                    temperatura = Convert.ToInt32(Console.ReadLine());
                    arbol.Insertar(temperatura);
                    break;
                case 2:
                    Console.Write("Ingrese la temperatura a buscar: ");
                    temperatura = Convert.ToInt32(Console.ReadLine());
                    bool encontrado = arbol.Buscar(temperatura);
                    Console.WriteLine(encontrado ? "Temperatura encontrada." : "Temperatura no encontrada.");
                    break;
                case 3:
                    Console.WriteLine("Recorrido InOrden:");
                    arbol.InOrden();
                    break;
                case 4:
                    Console.WriteLine("Recorrido PosOrden:");
                    arbol.PosOrden();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 5);
    }
}
