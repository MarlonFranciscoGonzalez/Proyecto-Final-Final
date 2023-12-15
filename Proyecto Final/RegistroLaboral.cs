using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    internal class RegistroLaboral : Empleado
    {
        private double tarifa;
        protected int horastrabajadas;

        public int Horastrabajadas { get { return horastrabajadas; } set { horastrabajadas = value; } }
        public double Tarifa { get { return tarifa; } set { tarifa = value; } }

        public RegistroLaboral()
        {
            horastrabajadas = 0;
            tarifa = 0;
        }
        public RegistroLaboral(int horastrabajadas, double tarifa)
        {
            this.horastrabajadas = horastrabajadas;
            this.tarifa = tarifa;
        }
        public RegistroLaboral(int idempleado, int horastrabajadas, double tarifa) : this(horastrabajadas, tarifa) 
        { 
            this.Idempleado = idempleado;
        }
    }
}
