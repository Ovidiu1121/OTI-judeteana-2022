using Subiect_OTI_judeteana.controller;
using Subiect_OTI_judeteana.forms;
using System.Diagnostics;

namespace Subiect_OTI_judeteana
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Vizualizare());
        }
    }
}