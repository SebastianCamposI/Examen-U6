using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExamenU6
{
    class Program
    {
        class ProductosAmazon
        {
            BinaryWriter bw = null;
            BinaryReader br = null;

            //Campos 
            string Nombre, Descripcion;
            float Precio;
            int Stock;

            public void CrearArchivo()
            {
                StreamWriter sw = new StreamWriter("Productos.txt", true);

                try
                {
                    // Captura de datos
                    Console.Clear();
                    Console.WriteLine("--Llenado de inventario--");
                    Console.Write("\nEscriba el nombre del producto: ");
                    Nombre = Console.ReadLine();
                    Console.Write("Escriba la descripción del producto: ");
                    Descripcion = Console.ReadLine();
                    Console.Write("Escriba el precio del producto: ");
                    Precio = float.Parse(Console.ReadLine());
                    Console.Write("Escriba el stock disponible: ");
                    Stock = int.Parse(Console.ReadLine());

                    sw.WriteLine("Nombre: " + Nombre);
                    sw.WriteLine("Descripción: " + Descripcion);
                    sw.WriteLine("Precio: " + Precio);
                    sw.WriteLine("Cantidad: " + Stock);

                    Console.Write("\nDeseas almacenar otro registro (s/n)?");
                }
                catch (IOException e)
                {
                    Console.WriteLine("\nError : " + e.Message);
                    Console.WriteLine("\nRuta : " + e.StackTrace);
                }
                finally
                {
                    Console.Write("\nPresione ENETER para regresar al Menu.");
                    sw.Close();
                    Console.ReadKey();
                }
            }
            public void Mostrar()
            {
                StreamWriter sw = new StreamWriter("Productos.txt", true);
                try
                {
                    // Despliegue de datos 
                    Console.Clear();
                    // Muestra los datos 
                    Console.WriteLine("--Inventario de Amazon");
                    Console.WriteLine("Nombre del producto: " + Nombre);
                    Console.WriteLine("Descripción del producto: " + Descripcion);
                    Console.WriteLine("Precio del producto: " + Precio);
                    Console.WriteLine("Stock del producto: " + Stock);
                    Console.WriteLine("\n");
                }
                catch (EndOfStreamException)
                {
                    Console.WriteLine("\n\nFin del Inventario");
                    Console.Write("\nPresione ENTER para continuar");
                }
                finally
                {
                    Console.Write("\nPresione ENTER para terminar la lectura de datos y regresar al menú");
                    sw.Close();
                    Console.ReadKey();
                }
            }
        }
        static void Main(string[] args)
        {
            int Opcion;
            ProductosAmazon Pro = new ProductosAmazon();
            do
            {
                Console.Clear();
                Console.WriteLine("Inventario Amazon");
                Console.WriteLine("1.Llenar inventario.");
                Console.WriteLine("2. Ver inventario.");
                Console.WriteLine("3. Salir del programa.");
                Console.Write("\nQue opción deseas: ");
                Opcion = Int16.Parse(Console.ReadLine());

                switch (Opcion)
                {
                    case 1: 
                        try
                        {
                            Pro.CrearArchivo();
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                            Console.WriteLine("\nRuta: " + e.StackTrace);
                        }
                        break;

                    case 2:
                        try
                        {
                            Pro.Mostrar();
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                            Console.WriteLine("\nRuta: " + e.StackTrace);
                        }
                        break;
                    case 3:
                        Console.Write("\nPresione ENTER para salir del programa.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nOpción no valida, presione ENTER para continuar");
                        Console.ReadKey();
                        break;
                }
            } while (Opcion != 3);
        }
    }
}
