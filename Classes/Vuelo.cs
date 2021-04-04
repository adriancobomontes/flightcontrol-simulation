using System;

namespace Classes
{
    public class Vuelo
    {
        string Id;        
        double PX;//Posicion y origen del vuelo en X
        double PY;//Posicion y origen del vuelo en Y
        double DX;//Destino del vuelo en X
        double DY;//Destino del vuelo en X
        double Velocidad;

        public void SetID(string Id)
        {
            this.Id = Id;
        }
        public void SetPX(double PX)
        {
            this.PX = PX;
        }
        public void SetPY(double PY)
        {
            this.PY = PY;
        }
        public void SetDX(double DX)
        {
            this.DX = DX;
        }
        public void SetDY(double DY)
        {
            this.DY = DY;
        }
        public void SetV(double Velocidad)
        {
            this.Velocidad = Velocidad;
        }

        public string GetID()
        {
            return this.Id;
        }

        public double GetPX()
        {
            return this.PX;
        }

        public double GetPY()
        {
            return this.PY;
        }
        public double GetV()
        {
            return this.Velocidad;
        }
        public double GetDX()
        {
            return this.DX;
        }
        public double GetDY()
        {
            return this.DY;
        }
    }
}
