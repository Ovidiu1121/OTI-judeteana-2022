using Subiect_OTI_judeteana.controller;
using Subiect_OTI_judeteana.forms;
using Subiect_OTI_judeteana.repository;
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

        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new Vizualizare());

            MasurareRepository a=new MasurareRepository();

            List<Masurare> x = a.getAllMasurari();

            foreach(Masurare m in x)
            {
                Debug.WriteLine(m.descriere());
            }

        }
    }
}