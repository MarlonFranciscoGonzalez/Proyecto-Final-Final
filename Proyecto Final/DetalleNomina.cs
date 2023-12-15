using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Final
{
    internal class DetalleNomina : RegistroLaboral
    {
        private DateTime fecha;
        private string fechaguardada;

        public DateTime Fecha { get { return fecha; } set { fecha = value; } }
        public string Fechaguardada { get { return fechaguardada; } set { fechaguardada = value; } }

        public DetalleNomina()
        {
            fecha = DateTime.Now;
            cedula = "";
            salario = 0;
            horastrabajadas = 0;
            cuentabanco = 0;
        }

        public DetalleNomina(DateTime fecha, string cedula, double salario, int horastrabajadas, int cuentabanco)
        {
            this.fecha = fecha;
            this.cedula = cedula;
            this.salario = salario;
            this.horastrabajadas = horastrabajadas;
            this.cuentabanco = cuentabanco;
        }

        public DetalleNomina(int idempleado, DateTime fecha, string cedula, double salario, int horastrabajadas, int cuentabanco) : this (fecha, cedula, salario, horastrabajadas, cuentabanco)
        {
            this.idempleado = idempleado;
        }
    }
}
