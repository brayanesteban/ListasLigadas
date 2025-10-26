using System;

namespace DoublyLinkedListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedListLib.DoublyLinkedList<string>(); // usar la librería directamente
            int option = -1;

            while (option != 0)
            {
                Console.Clear();
                Console.WriteLine("===== MENU LISTA DOBLEMENTE LIGADA =====");
                Console.WriteLine("1. Agregar (Ascendente)");
                Console.WriteLine("2. Mostrar Adelante");
                Console.WriteLine("3. Mostrar Atrás");
                Console.WriteLine("4. Ordenar Descendentemente");
                Console.WriteLine("5. Mostrar Moda(s)");
                Console.WriteLine("6. Mostrar Gráfico de Frecuencias");
                Console.WriteLine("7. Existe?");
                Console.WriteLine("8. Eliminar UNA ocurrencia");
                Console.WriteLine("9. Eliminar TODAS las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.Write("\nOpción: ");

                if (!int.TryParse(Console.ReadLine(), out option))
                    option = -1;

                Console.Clear();

                switch (option)
                {
                    case 1:
                        Console.Write("Ingrese el dato: ");
                        var data = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrEmpty(data))
                        {
                            list.InsertSorted(data);
                            Console.WriteLine("\nAgregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Dato vacío. No se agregó.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Lista (adelante):");
                        list.DisplayForward();
                        break;

                    case 3:
                        Console.WriteLine("Lista (atrás):");
                        list.DisplayBackward();
                        break;

                    case 4:
                        list.SortDescending();
                        Console.WriteLine("Lista ordenada descendentemente.");
                        break;

                    case 5:
                        list.ShowModes();
                        break;

                    case 6:
                        list.ShowFrequencyGraph();
                        break;

                    case 7:
                        Console.Write("Ingrese dato a buscar: ");
                        var search = Console.ReadLine()?.Trim();
                        Console.WriteLine(list.Exists(search) ? "Sí existe ✅" : "No existe ❌");
                        break;

                    case 8:
                        Console.Write("Dato a eliminar UNA vez: ");
                        var rem1 = Console.ReadLine()?.Trim();
                        Console.WriteLine(list.RemoveOne(rem1) ? "Eliminado ✅" : "No se encontró ❌");
                        break;

                    case 9:
                        Console.Write("Dato a eliminar TODAS las veces: ");
                        var remAll = Console.ReadLine()?.Trim();
                        int c = list.RemoveAll(remAll);
                        Console.WriteLine($"Se eliminaron {c} ocurrencias.");
                        break;

                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione ENTER para continuar...");
                Console.ReadLine();
            }
        }
    }
}
