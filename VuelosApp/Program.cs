using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Classes;

namespace VuelosApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            try //El try nos sirve para detectar los errores que puede tener el programa
            {
                ListaVuelos mi_lista = new ListaVuelos();
                Sectores otra_lista = new Sectores();
                int opcion = 0;
                mi_lista.CargarVuelos("vuelos.txt");
                otra_lista.CargarSectores("sectores.txt");
                while (opcion != 4) //Este bucle nos da un listado de opciones que podemos hacer con el programa
                {
                    Console.WriteLine();
                    Console.WriteLine("MENU PRINCIPAL");                    
                    Console.WriteLine("1 - Mostrar posición vuelos");
                    Console.WriteLine("2 - Mostrar ocupación sector");
                    Console.WriteLine("3 - Simulación");
                    Console.WriteLine("4 - Guardar y salir");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    

                    switch (opcion)//El switch nos permite escoger la accion que queremos relizar por eso se tienen que corresponder los case con los writeline
                    {                        
                        case 4: mi_lista.Guardar(mi_lista); break;
                        case 3: mi_lista.Simulacion(otra_lista, mi_lista); break;
                        case 2: mi_lista.MostrarOcupacion(otra_lista, mi_lista); break;
                        case 1: mi_lista.MostrarVuelos(); break;
                        default: break;
                    }
                }
            }
            catch (FormatException) //Este catch nos indica que hay algun tipo de error en los datos
            {
                Console.WriteLine("Error en los datos");
                Console.ReadLine();
            }
            catch (FileNotFoundException) //Este catch nos indica que no se ha podido encontrar el fichero, se puede dar porque se le ha cambiado el nombre al fichero o porque no hay ningun fichero
            {
                Console.WriteLine("Error al encontrar el fichero");
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
