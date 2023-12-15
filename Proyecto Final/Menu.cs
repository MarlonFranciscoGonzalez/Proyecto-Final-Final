using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace Proyecto_Final
{
    internal class Menu
    {
        public static Random random = new Random();
        private readonly Persistencia _storage;
        public Menu()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            _storage = new Persistencia($"Data Source={appPath}empleados.db");
        }

        public void Menus(string v)
        {
            Console.WriteLine("\n  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine($"             Menú selecionador {v} \n");
            Console.WriteLine("            Hecho Por: Marlon Francisco González  -   100598322\n");
            Console.WriteLine("  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }

        public void Iniciar()
        {
            int seleccion;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Menus("general de la empresa agricola");
                Console.WriteLine("\t\t1.  Menú de Empleado");
                Console.WriteLine("\t\t2.  Menú de Registro Laboral");
                Console.WriteLine("\t\t3.  Menú de Detalle de Nomina");
                Console.WriteLine("\t\t4.  Salir del Menú\n\n");
                Console.Write("\tIngrese el número de el menú al que quiere acceder: ");

                if (int.TryParse(Console.ReadLine(), out seleccion))
                {
                    switch (seleccion)
                    {
                        case 1:
                            MenuEmpleado();
                            break;

                        case 2:
                            MenuRegistroEmpleado();
                            break;

                        case 3:
                            MenuDetalleNomina();
                            break;

                        case 4:
                            Console.WriteLine("\n      Gracias por utilizar el software de AgroConstanza V. 1.0");
                            Console.Write("\t\tPresione Enter para salir del programa... ");
                            Console.ReadKey(); Console.WriteLine("\n"); Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("\n\t\t       Opción no válida");
                            Console.Write("\t\tPresione Enter para continuar... ");
                            Console.ReadKey(); Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\t\tPor favor, ingrese un número válido.");
                    Console.Write("\t\t  Presione Enter para continuar... ");
                    Console.ReadKey(); Console.Clear();
                }
            } while (seleccion != 4);
        }

        public void MenuEmpleado()
        {
            char seleccion;

            do
            {
                Console.Clear();
                Menus("empleado de la empresa agricola");
                Console.WriteLine("\t\t1.  Listar Empleados");
                Console.WriteLine("\t\t2.  Agregar Empleados");
                Console.WriteLine("\t\t3.  Actualizar Empleados");
                Console.WriteLine("\t\t4.  Eliminar Empleados");
                Console.WriteLine("\t\t5.  Salir del Menú\n\n");
                Console.Write("      Ingrese el número de la opción a la que quiere acceder: ");

                seleccion = Console.ReadKey().KeyChar;

                if (seleccion == '1')
                {
                    ListarEmpleado(_storage.GetEmpleado());
                    Console.Write("\n\n\t\tPresione Enter para continuar... ");
                    Console.ReadKey();
                }

                if (seleccion == '2')
                {
                    AgregarEmpleado();
                }

                if (seleccion == '3')
                {
                    ActualizarEmpleado();
                }

                if (seleccion == '4')
                {
                    ElilinarEmpleado();
                }

                if (seleccion == '5')
                {
                    Console.WriteLine("\n\n   Ha terminado de usar este menú, ahora será devuelto al menú principal");
                    Console.Write("\t\tPresione Enter para salir del programa... ");
                    Console.ReadKey(); Console.Clear();
                }

                if (seleccion != '1' && seleccion != '2' && seleccion != '3' && seleccion != '4' && seleccion != '5')
                {
                    Console.WriteLine("\n\n\t\t       Opción no válida");
                    Console.Write("\t\tPresione Enter para continuar... ");
                    Console.ReadKey(); Console.Clear();
                }
            } while (seleccion != '5');

            Console.Clear();
        }

        private void ListarEmpleado(List<Empleado> empleados)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t---LISTA DE EMPLEADOS---\n\n");

            if (empleados.Count == 0)
            {
                Console.WriteLine("\n\tNo hay Empleados en existencia, debe de agregar.");
            }
            else
            {
                Console.WriteLine($"\t\t Total de Empleados: {empleados.Count}\n\n");
                for (int i = 0; i < empleados.Count; i++)
                {
                    Console.WriteLine
                    ("--------------------------------------------------------------------------------------");
                    Console.Write($" IdEmpleado: {empleados[i].Idempleado}   ");
                    Console.Write($"Puesto: {empleados[i].Puesto}   ");
                    Console.Write($"Cédula: {empleados[i].Cedula}   ");
                    Console.Write($"Nombre: {empleados[i].Nombre}   \n");
                    Console.Write($" Apellido: {empleados[i].Apellido}    ");
                    Console.Write($"Edad: {empleados[i].Edad}    ");
                    Console.Write($"Telefono: {empleados[i].Telefono}   ");
                    Console.Write($"Salario: {empleados[i].Salario}\n\t\t\t    ");
                    Console.Write($"Cuenta de banco: {empleados[i].Cuentabanco}\n");
                    Console.WriteLine
                    ("--------------------------------------------------------------------------------------");
                }
            }
        }

        private void AgregarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\tIntroduzca los datos del Empleado:\n\n");
            Console.Write("\tIntroduzca el Puesto del Empleado: ");
            string puesto = Console.ReadLine();
            Console.Write("\tIntroduzca la Cédula del Empleado: ");
            string cedula = Console.ReadLine();
            Console.Write("\tIntroduzca el Nombre del Empleado: ");
            string nombre = Console.ReadLine();
            Console.Write("\tIntroduzca el Apellido del Empleado: ");
            string apellido = Console.ReadLine();

            int edad;
            bool inputInvalido;
            do
            {
                Console.Write("\tIntroduzca la Edad del Empleado: ");
                if (!int.TryParse(Console.ReadLine(), out edad))
                {
                    Console.WriteLine("\n\t\t       Opción no válida");
                    Console.Write("\t\tPresione Enter para Ingresar la Edad del Empleado... ");
                    Console.ReadKey(); Console.WriteLine();
                    inputInvalido = true;
                }
                else
                {
                    inputInvalido = false;
                }
            } while (inputInvalido);

            Console.Write("\tIntroduzca el Telefono del Empleado: ");
            string telefono = Console.ReadLine();

            int horastrabajadas;
            inputInvalido = true;
            do
            {
                Console.Write("\tIntroduzca las Horas a Trabajar del Empleado: ");
                if (!int.TryParse(Console.ReadLine(), out horastrabajadas))
                {
                    Console.WriteLine("\n\t\t       Opción no válida");
                    Console.Write("\tPresione Enter para Ingresar las Horas Trabajadas... ");
                    Console.ReadKey(); Console.WriteLine();
                    inputInvalido = true;
                }
                else
                {
                    inputInvalido = false;
                }
            } while (inputInvalido);


            double tarifa;
            inputInvalido = true;
            do
            {
                Console.Write("\tIntroduzca la Tarifa que tendrá el Empleado: ");
                if (!double.TryParse(Console.ReadLine(), out tarifa))
                {
                    Console.WriteLine("\n\t\t      Opción no válida");
                    Console.Write("\tPresione Enter para Ingresar la Tarifa del Empleado... ");
                    Console.ReadKey(); Console.WriteLine();
                    inputInvalido = true;
                }
                else
                {
                    inputInvalido = false;
                }
            } while (inputInvalido);

            int cuentabanco = random.Next(10000000, 99999999);

            double salario = horastrabajadas * tarifa;

            DateTime fecha = DateTime.Now;

            Empleado empleado = new Empleado(puesto, cedula, nombre, apellido, edad, telefono, salario, cuentabanco);
            RegistroLaboral registroLaboral = new RegistroLaboral(horastrabajadas, tarifa);
            DetalleNomina nomina = new DetalleNomina(fecha, cedula, salario, horastrabajadas,cuentabanco);

            _storage.GuardarEmpleado(empleado);
            _storage.GuardarRegistroLaboral(registroLaboral);
            _storage.GuardarNomina(nomina);
        }

        private void ActualizarEmpleado()
        {
            List<Empleado> empleados = _storage.GetEmpleado();
            
            bool inputInvalido;
            int idempleado;
            
            do
            {
                ListarEmpleado(empleados);
                Console.Write("\n\n\tIntroduzca el ID del Empleado que desea actualizar: ");
                if (!int.TryParse(Console.ReadLine(), out idempleado))
                {
                    Console.WriteLine("\n\t\t         Opción no válida");
                    Console.Write("\tPresione Enter para Ingresar el ID del Empleado... ");
                    Console.ReadKey(); Console.WriteLine();
                    inputInvalido = true;
                }
                else
                {
                    inputInvalido = false;
                }
            } while (inputInvalido);

            Empleado empleado = empleados.Find(c => c.Idempleado == idempleado);
            if (empleado != null)
            {
                Console.WriteLine("\t\nIngrese los datos a actualizar:");

                Console.Clear();
                Console.WriteLine("\n\n\tIntroduzca los datos a actualizar del Empleado:\n\n");
                Console.Write("\tIntroduzca el Puesto del Empleado: ");
                string puesto = Console.ReadLine();
                Console.Write("\tIntroduzca la Cédula del Empleado: ");
                string cedula = Console.ReadLine();
                Console.Write("\tIntroduzca el Nombre del Empleado: ");
                string nombre = Console.ReadLine();
                Console.Write("\tIntroduzca el Apellido del Empleado: ");
                string apellido = Console.ReadLine();

                int edad;
                inputInvalido = true;
                do
                {
                    Console.Write("\tIntroduzca la Edad del Empleado: ");
                    if (!int.TryParse(Console.ReadLine(), out edad))
                    {
                        Console.WriteLine("\n\t\t       Opción no válida");
                        Console.Write("\t\tPresione Enter para Ingresar la Edad del Empleado... ");
                        Console.ReadKey(); Console.WriteLine();
                        inputInvalido = true;
                    }
                    else
                    {
                        inputInvalido = false;
                    }
                } while (inputInvalido);

                Console.Write("\tIntroduzca el Telefono del Empleado: ");
                string telefono = Console.ReadLine();

                int salario;
                inputInvalido = true;
                do
                {
                    Console.Write("\tIntroduzca el Salario del Empleado: ");
                    if (!int.TryParse(Console.ReadLine(), out salario))
                    {
                        Console.WriteLine("\n\t\t         Opción no válida");
                        Console.Write("\tPresione Enter para Ingresar el Salario del Trabajador... ");
                        Console.ReadKey(); Console.WriteLine();
                        inputInvalido = true;
                    }
                    else
                    {
                        inputInvalido = false;
                    }
                } while (inputInvalido);

                _storage.ActualizarEmpleado(idempleado, puesto, cedula, nombre, apellido, edad, telefono, salario);
                Console.WriteLine("\n        Empleado Actualizado Exitosamente.\t");
            }
            else { Console.WriteLine("\n\n\tEl ID del Empleado que desea actualizar no es válido."); }
            Console.Write("\t   Presione Enter para volver al menú anterior... ");
            Console.ReadKey();
        }

        private void ElilinarEmpleado()
        {
            List<Empleado> empleados = _storage.GetEmpleado();
            List<RegistroLaboral> registrolaborales = _storage.GetRegistroLaboral();
            List<DetalleNomina> nominas = _storage.GetNomina();
            ListarEmpleado(empleados);

            Console.Write("\n\n  Ingrese el ID del Empleado que desea Eliminar: ");
            int idx;
            int.TryParse(Console.ReadLine(), out idx);

            Empleado empleado = empleados.Find(c => c.Idempleado == idx);
            RegistroLaboral registrolaboral = registrolaborales.Find(c => c.Idempleado == idx);
            DetalleNomina nomina = nominas.Find(c => c.Idempleado == idx);
            if (empleado != null)
            {
                _storage.EliminarEmpleado(empleado.Idempleado);
                _storage.EliminarRegistroLaboral(registrolaboral.Idempleado);
                _storage.EliminarNomina(nomina.Idempleado);
                Console.WriteLine("\n         Empleado Eliminado Exitosamente.\t");
            }
            else { Console.WriteLine("\n\n\t\t   Id de Empleado Inválido"); }
            Console.Write("\tPresione Enter para volver al menú anterior... ");
            Console.ReadKey();
        }

        private void MenuRegistroEmpleado()
        {
            char opcion;

            do
            {
                Console.Clear();
                Menus("Registro empleado de la empresa");
                Console.WriteLine("\t\t1.  Listar Registro de Empleados");
                Console.WriteLine("\t\t2.  Actualizar Registro de  Empleados");
                Console.WriteLine("\t\t3.  Eliminar Registro de Empleados");
                Console.WriteLine("\t\t4.  Salir del Menú\n\n");
                Console.Write("      Ingrese el número de la opción a la que quiere acceder: ");

                opcion = Console.ReadKey().KeyChar;

                if (opcion == '1')
                {
                    ListarRegistroLaboral(_storage.GetRegistroLaboral());
                    Console.Write("\n\n\t\t   Presione Enter para continuar... ");
                    Console.ReadKey();
                }

                if (opcion == '2')
                {
                    ActualizarRegistroEmpleado();
                }

                if (opcion == '3')
                {
                    EliminarRegistroLaboral();
                }

                if (opcion == '4')
                {
                    Console.WriteLine("\n\n   Ha terminado de usar este menú, ahora será devuelto al menú principal");
                    Console.Write("\t\tPresione Enter para salir del programa... ");
                    Console.ReadKey(); Console.Clear();
                }

                if (opcion != '1' && opcion != '2' && opcion != '3' && opcion != '4')
                {
                    Console.WriteLine("\n\n\t\t       Opción no válida");
                    Console.Write("\t\tPresione Enter para continuar... ");
                    Console.ReadKey(); Console.Clear();
                }
            } while (opcion != '4');

            Console.Clear();
        }

        private void ListarRegistroLaboral(List<RegistroLaboral> registroslaborales)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t---LISTA DE REGISTROS LABORALES---\n\n");

            if (registroslaborales.Count == 0)
            {
                Console.WriteLine("\n\t   No hay Empleados en existencia, debe de agregar.");
            }
            else
            {
                Console.WriteLine($"\t\t       Total de Empleados {registroslaborales.Count}\n\n");
                for (int i = 0; i < registroslaborales.Count; i++)
                {
                    Console.WriteLine
                    ("---------------------------------------------------------------------------");
                    Console.Write($"\t   IdEmpleado: {registroslaborales[i].Idempleado}   ");
                    Console.Write($"Horas trabajadas: {registroslaborales[i].Horastrabajadas}   ");
                    Console.Write($"Tarifa: {registroslaborales[i].Tarifa}   \n");
                    Console.WriteLine
                    ("---------------------------------------------------------------------------");
                }
            }
        }

        private void ActualizarRegistroEmpleado()
        {
            List<RegistroLaboral> registrolaboral = _storage.GetRegistroLaboral();

            bool inputInvalido;
            int idempleado;

            do
            {
                ListarRegistroLaboral(registrolaboral);
                Console.Write("\n\n\tIntroduzca el ID del Empleado que desea actualizar: ");
                if (!int.TryParse(Console.ReadLine(), out idempleado))
                {
                    Console.WriteLine("\n\t\t         Opción no válida");
                    Console.Write("\tPresione Enter para Ingresar el ID del Empleado... ");
                    Console.ReadKey(); Console.WriteLine();
                    inputInvalido = true;
                }
                else
                {
                    inputInvalido = false;
                }
            } while (inputInvalido);

            Empleado empleado = registrolaboral.Find(c => c.Idempleado == idempleado);
            if (empleado != null)
            {
                int horastrabajadas;
                inputInvalido = true;
                do
                {
                    Console.Write("\tIntroduzca las Horas a Trabajar del Empleado: ");
                    if (!int.TryParse(Console.ReadLine(), out horastrabajadas))
                    {
                        Console.WriteLine("\n\t\t       Opción no válida");
                        Console.Write("\tPresione Enter para Ingresar las Horas Trabajadas... ");
                        Console.ReadKey(); Console.WriteLine();
                        inputInvalido = true;
                    }
                    else
                    {
                        inputInvalido = false;
                    }
                } while (inputInvalido);


                double tarifa;
                inputInvalido = true;
                do
                {
                    Console.Write("\tIntroduzca la Tarifa que tendrá el Empleado: ");
                    if (!double.TryParse(Console.ReadLine(), out tarifa))
                    {
                        Console.WriteLine("\n\t\t      Opción no válida");
                        Console.Write("\tPresione Enter para Ingresar la Tarifa del Empleado... ");
                        Console.ReadKey(); Console.WriteLine();
                        inputInvalido = true;
                    }
                    else
                    {
                        inputInvalido = false;
                    }
                } while (inputInvalido);

                _storage.ActualizarRegistroLaboral(idempleado, horastrabajadas, tarifa);
                Console.WriteLine("\n\t\t Empleado Actualizado Exitosamente.\t");
            }
            else { Console.WriteLine("\n\n\tEl ID del Empleado que desea actualizar no es válido."); }
            Console.Write("\t   Presione Enter para volver al menú anterior... ");
            Console.ReadKey();
        }

        private void EliminarRegistroLaboral()
        {
            List<Empleado> empleados = _storage.GetEmpleado();
            List<RegistroLaboral> registrolaborales = _storage.GetRegistroLaboral();
            List<DetalleNomina> nominas = _storage.GetNomina();
            ListarRegistroLaboral(registrolaborales);

            Console.Write("\n\n  Ingrese el ID del Empleado que desea Eliminar: ");
            int idx;
            int.TryParse(Console.ReadLine(), out idx);

            Empleado empleado = empleados.Find(c => c.Idempleado == idx);
            RegistroLaboral registrolaboral = registrolaborales.Find(c => c.Idempleado == idx);
            DetalleNomina nomina = nominas.Find(c => c.Idempleado == idx);
            if (empleado != null)
            {
                _storage.EliminarEmpleado(empleado.Idempleado);
                _storage.EliminarRegistroLaboral(registrolaboral.Idempleado);
                _storage.EliminarNomina(nomina.Idempleado);
                Console.WriteLine("\n         Empleado Eliminado Exitosamente.\t");
            }
            else { Console.WriteLine("\n\n\t\t   Id de Empleado Inválido"); }
            Console.Write("\tPresione Enter para volver al menú anterior... ");
            Console.ReadKey();
        }

        private void MenuDetalleNomina()
        {
            char opcion;

            do
            {
                Console.Clear();
                Menus("Detalle de Nomina de la empresa");
                Console.WriteLine("\t\t1.  Reporte Nominal en TXT");
                Console.WriteLine("\t\t2.  Reporte Nominal del banco en TXT");
                Console.WriteLine("\t\t3.  Salir del Menú\n\n");
                Console.Write("      Ingrese el número de la opción a la que quiere acceder: ");

                opcion = Console.ReadKey().KeyChar;

                if (opcion == '1')
                {
                    ReporteNominal(_storage.GetNomina());
                }

                if (opcion == '2')
                {
                    ReporteNominalBanco(_storage.GetNomina());
                }

                if (opcion == '3')
                {
                    Console.WriteLine("\n\n   Ha terminado de usar este menú, ahora será devuelto al menú principal");
                    Console.Write("\t\tPresione Enter para salir del programa... ");
                    Console.ReadKey(); Console.Clear();
                }

                if (opcion != '1' && opcion != '2' && opcion != '3')
                {
                    Console.WriteLine("\n\n\t\t       Opción no válida");
                    Console.Write("\t\tPresione Enter para continuar... ");
                    Console.ReadKey(); Console.Clear();
                }
            } while (opcion != '3');

            Console.Clear();
        }

        private void ReporteNominal(List<DetalleNomina> nominas)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t     --------REPORTE DE LA NOMINA--------\n\n");

            string acumulador = "\n\n\t\t\t\t\t     --------REPORTE DE NOMINA--------";

            if (nominas.Count == 0)
            {
                acumulador += "\n\t   No hay Empleados en existencia, debe de agregar.";
            }
            else
            {
                acumulador += $"\n\n\t\t\t\t\t           Total de Empleados {nominas.Count}";
                for (int i = 0; i < nominas.Count; i++)
                {
                    acumulador += $"\n\n\t\t\t\t\t     Fecha: {nominas[i].Fechaguardada}\n";
                    acumulador +=
                        "   -----------------------------------------------------------" +
                        "----------------------------------------------------------------";
                    acumulador += $"\n\t   IdEmpleado: {nominas[i].Idempleado}   ";
                    acumulador += $"Cédula: {nominas[i].Cedula}   ";
                    acumulador += $"Salario: {nominas[i].Salario}    ";
                    acumulador += $"Horas trabajadas: {nominas[i].Horastrabajadas}   ";
                    acumulador += $"Cuenta de banco: {nominas[i].Cuentabanco}\n";
                    acumulador +=
                        "   -----------------------------------------------------------" +
                        "----------------------------------------------------------------";
                }

                string rutaArchivo = "Reporte Nominal.txt";
                File.WriteAllText(rutaArchivo, acumulador);

                Process.Start("notepad.exe", rutaArchivo);
            }

            Console.Write("\tPresione Enter para volver al menú anterior... ");
            Console.ReadKey();
        }

        private void ReporteNominalBanco(List<DetalleNomina> nominas) 
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("\n\n       --------REPORTE DE LA NOMINA PARA EL BANCO--------\n\n");

            string acumulador = "\n\n\t\t\t\t     --------REPORTE DE NOMINA PARA EL BANCO--------";

            if (nominas.Count == 0)
            {
                acumulador += "\n\t   No hay Empleados en existencia, debe de agregar.";
            }
            else
            {
                acumulador += $"\n\n\t\t\t\t\t           Total de Empleados {nominas.Count}";
                for (int i = 0; i < nominas.Count; i++)
                {
                    acumulador += $"\n\n\t\t\t\t\t     Fecha: {nominas[i].Fechaguardada}\n";
                    acumulador +=
                        "   ---------------------------------------------------------" +
                        "-------------------------------------------------------------";
                    acumulador += $"\n\t   IdEmpleado: {nominas[i].Idempleado}, ";
                    acumulador += $"Cédula: {nominas[i].Cedula}, ";
                    acumulador += $"Salario: {nominas[i].Salario}, ";
                    acumulador += $"Horas trabajadas: {nominas[i].Horastrabajadas}, ";
                    acumulador += $"Cuenta de banco: {nominas[i].Cuentabanco}\n";
                    acumulador +=
                        "   ---------------------------------------------------------" +
                        "-------------------------------------------------------------";
                }

                string rutaArchivo = "Reporte Nominal Banco.txt";
                File.WriteAllText(rutaArchivo, acumulador);

                Process.Start("notepad.exe", rutaArchivo);
            }

            Console.Write("\tPresione Enter para volver al menú anterior... ");
            Console.ReadKey();
        }
    }
}