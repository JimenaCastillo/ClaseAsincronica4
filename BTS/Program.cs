using System;
using BST_CA;

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree tree = new BinarySearchTree();

        Console.WriteLine("=== INSERCIÓN DE NODOS ===");
        int[] valores = { 50, 30, 70, 20, 40, 60, 80 };
        foreach (int val in valores)
        {
            Console.WriteLine($"Insertando: {val}");
            tree.Insert(val);
        }

        Console.WriteLine("\n=== RECORRIDOS ===");
        Console.Write("InOrder:   ");
        tree.InOrder();    // Debe imprimir en orden ascendente

        Console.Write("PreOrder:  ");
        tree.PreOrder();   // Raíz antes que hijos

        Console.Write("PostOrder: ");
        tree.PostOrder();  // Raíz después que hijos

        Console.WriteLine("\n=== BÚSQUEDA ===");
        Console.WriteLine("¿Existe 40? " + tree.Search(40)); // true
        Console.WriteLine("¿Existe 90? " + tree.Search(90)); // false

        Console.WriteLine("\n=== ELIMINACIÓN ===");
        Console.WriteLine("Eliminando 20 (hoja): " + tree.Delete(20));   // true
        Console.WriteLine("Eliminando 30 (un hijo): " + tree.Delete(30)); // true
        Console.WriteLine("Eliminando 50 (dos hijos): " + tree.Delete(50)); // true
        Console.WriteLine("Eliminando 100 (no existe): " + tree.Delete(100)); // false

        Console.WriteLine("\n=== RECORRIDOS TRAS ELIMINACIÓN ===");
        Console.Write("InOrder:   ");
        tree.InOrder();    // Ver cómo quedó el árbol

        Console.Write("PreOrder:  ");
        tree.PreOrder();

        Console.Write("PostOrder: ");
        tree.PostOrder();

        Console.WriteLine("\nFIN DE LA DEMOSTRACIÓN.");
    }
}
