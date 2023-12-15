using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_Final
{
    internal class Empleado
    {
        protected int idempleado;
        private string puesto;
        protected string cedula;
        private string nombre;
        private string apellido;
        private int edad;
        private string telefono;
        protected double salario;
        protected int cuentabanco;

        public int Idempleado { get { return idempleado; } set { idempleado = value; } }
        public string Puesto { get { return puesto; } set { puesto = value; } }
        public string Cedula { get { return cedula; } set { cedula = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public int Edad { get { return edad; } set { edad = value; } }
        public string Telefono { get { return telefono; } set { telefono = value; } }
        public double Salario { get {  return salario; } set {  salario = value; } }
        public int Cuentabanco { get { return cuentabanco; } set {  cuentabanco = value; } }

        public Empleado()
        {
            puesto = "";
            cedula = "";
            nombre = "";
            apellido = "";
            edad = 0;
            telefono = "";
            salario = 0;
        }

        public Empleado(string puesto, string cedula, string nombre, string apellido, int edad, string telefono, double salario, int cuentabanco)
        {
            this.puesto = puesto;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.telefono = telefono;
            this.salario = salario;
            this.cuentabanco = cuentabanco;
        }

        public Empleado(int idempleado, string puesto, string cedula, string nombre, string apellido, int edad, string telefono, double salario, int cuentabanco):this(puesto, cedula, nombre, apellido, edad, telefono, salario, cuentabanco)
        {
            this.idempleado = idempleado;
        }
    }
}
