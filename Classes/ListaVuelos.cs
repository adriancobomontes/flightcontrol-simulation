using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Classes
{
    public class ListaVuelos
    {
        public int numvuelos;
        public Vuelo[] vuelos = new Vuelo[100];

        public int CargarVuelos(string nombre) //Esta funcion la usamos para cargar los datos que hay en el fichero
        {
            int i = 0, y = 0;
            StreamReader F = new StreamReader(nombre);
            string linea = F.ReadLine();
            string[] palabra = new string[100];
            while (linea != null) //Este bucle sirve para leer el documento y organizar el vector que lo contiene
            {
                Vuelo e = new Vuelo();
                palabra = linea.Split('-');
                e.SetID(palabra[y]);
                y++;
                e.SetPX(Convert.ToDouble(palabra[y]));
                y++;
                e.SetPY(Convert.ToDouble(palabra[y]));
                y++;
                e.SetDX(Convert.ToDouble(palabra[y]));
                y++;
                e.SetDY(Convert.ToDouble(palabra[y]));
                y++;
                e.SetV(Convert.ToDouble(palabra[y]));
                vuelos[i] = e;
                i++;
                y = 0;
                linea = F.ReadLine();
            }
            numvuelos = i;
            F.Close();
            return (0);
        }

        public void Guardar(ListaVuelos l) //Esta funcion la usamos para cargar los datos que hay en el fichero
        {
            int i = 0, y = 0;
            StreamWriter w = new StreamWriter("vuelos2.txt");            
            while (i < l.numvuelos) //Este bucle sirve para leer el documento y organizar el vector que lo contiene
            {
                w.Write(l.vuelos[i].GetID());
                w.Write("-");
                w.Write(l.vuelos[i].GetPX());
                w.Write("-");
                w.Write(l.vuelos[i].GetPY());
                w.Write("-");
                w.Write(l.vuelos[i].GetV());
                w.Write("-");
                w.Write(l.vuelos[i].GetDX());
                w.Write("-");
                w.Write(l.vuelos[i].GetDY());
                w.WriteLine();
                i++;
            }
            w.Close();
            Console.WriteLine("Los datos se han guardado correctamente");
        }
        
        public void MostrarVuelos()
        {
            for (int i = 0; i < numvuelos; i++)
            {
                string id = Convert.ToString(vuelos[i].GetID());
                double x = Convert.ToDouble(vuelos[i].GetPX());
                double y = Convert.ToDouble(vuelos[i].GetPY());

                Console.WriteLine("Id : " + id +", X : "+ x + ", Y : "+ y);                                
            }
        }

        public void MostrarOcupacion(Sectores s, ListaVuelos l)
        {
            int i = 0, y = 0;
            while (i < numvuelos)
            {
                if ((l.vuelos[i].GetPX() <= s.sector[0].GetPosX()) && (l.vuelos[i].GetPY() <= s.sector[0].GetPosY()))
                {
                    Console.WriteLine("El vuelo " + l.vuelos[i].GetID() + " está dentro del sector");
                    y++;
                }
                else
                {
                    Console.WriteLine("El vuelo " + l.vuelos[i].GetID() + " no está dentro del sector");
                }
                i++;
            }
            Console.WriteLine("Hay " + y + " vuelos en el sector. la ocupación és del " +(y*100/numvuelos)+ "%");
        }

        public void Simulacion(Sectores s, ListaVuelos l)
        {
            int i = 0;
            Console.Write("Escribe el tiempo del ciclo en minutos : ");
            int t = Convert.ToInt32(Console.ReadLine());
            while (i < numvuelos)
            {
                double DRT = (l.vuelos[i].GetV() / 60) * t; //DISTANCIA RECORRIDA EN TOTAL
                double DRX = DRT * ((l.vuelos[i].GetDX() - l.vuelos[i].GetPX()) / Math.Sqrt(((l.vuelos[i].GetDX() - l.vuelos[i].GetPX()) * (l.vuelos[i].GetDX() - l.vuelos[i].GetPX())) + ((l.vuelos[i].GetDY() - l.vuelos[i].GetPY()) * (l.vuelos[i].GetDY() - l.vuelos[i].GetPY()))));
                double DRY = DRT * ((l.vuelos[i].GetDY() - l.vuelos[i].GetPY()) / Math.Sqrt(((l.vuelos[i].GetDX() - l.vuelos[i].GetPX()) * (l.vuelos[i].GetDX() - l.vuelos[i].GetPX())) + ((l.vuelos[i].GetDY() - l.vuelos[i].GetPY()) * (l.vuelos[i].GetDY() - l.vuelos[i].GetPY()))));

                Console.WriteLine(l.vuelos[i].GetID() + " X=" + (DRT + DRX) + " Y=" +(DRT + DRY));
                i++;
            }
        }
    }
}
