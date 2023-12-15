/* 
 Programa que Implementación de una aplicación de nómina simple para
 una empresa agrícola en Constanza utilizando Microsoft.Data.Sqlite.
 Nombre: Marlon Francisco Gónzalez - Matricula: 100598322
 Fecha: 10/12/2023 - Hora: 11:56 P.M.
 Proyecto Final.sln
 */

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Proyecto_Final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Iniciar();
        }
    }
}