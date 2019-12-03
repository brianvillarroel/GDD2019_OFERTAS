using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MiLibreria;
using OfertasGD2019.CrearOferta;
using OfertasGD2019.ComprarOferta;
using OfertasGD2019.AbmCliente;
using OfertasGD2019.CargarCredito;
using OfertasGD2019.AbmProveedor;

namespace OfertasGD2019
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RegistroProveedor());
        }
    }
}
