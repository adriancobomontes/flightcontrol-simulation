using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Classes
{
    public class Sectores
    {
        public Sectores[] sector = new Sectores[100];
        int NumSectores;
        String IdSector;
        int Capacidad;
        double PosX;
        double PosY;

        public void SetPosX(double PosX)
        {
            this.PosX = PosX;
        }
        public void SetPosY(double PosY)
        {
            this.PosY = PosY;
        }

        public double GetPosX()
        {
            return this.PosX;
        }
        public double GetPosY()
        {
            return this.PosY;
        }

        public int CargarSectores(string nombre)
        {
            int i = 0, y = 0;
            StreamReader G = new StreamReader(nombre);
            string linea = G.ReadLine();
            string[] palabra = new string[2];
            while (linea != null)
            {
                Sectores t = new Sectores();
                palabra = linea.Split('-');
                t.SetPosX(Convert.ToDouble(palabra[y]));
                y++;
                t.SetPosY(Convert.ToDouble(palabra[y]));                
                sector[i] = t;
                y = 0;
                linea = G.ReadLine();
            }
            NumSectores = i;
            G.Close();
            return 0;
        }
    }
}
