﻿using ProyectoPrueba.Principal;
using System;
using System.Windows.Forms;

namespace ProyectoPrueba
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmUsuario());
        }
    }
}
