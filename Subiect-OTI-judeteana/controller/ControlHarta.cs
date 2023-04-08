using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana
{
    public class ControlHarta
    {
        private List<Harta> lista=new List<Harta>();
        public string path = Application.StartupPath+@"\data\harti.txt";

        public ControlHarta()
        {
            load();
        }

        public void load()
        {
            StreamReader read=new StreamReader(path);

            string line = "";

            while ((line=read.ReadLine())!=null)
            {
                Harta a=new Harta(line);
                lista.Add(a);
            }
            read.Close();

        }

        public string afisare()
        {

            string text = "";

            for(int i = 0; i<lista.Count; i++)
            {
                text+=lista[i].descriere();
            }

            return text;
        }

        public string toSave()
        {
            string text = "";
            int i = 0;

            for (i = 0; i<lista.Count-1; i++)
            {
                text+=lista[i].save();
            }
            text+=lista[i].save();

            return text;


        }

        public void salvareFisier()
        {

            StreamWriter streamWriter = new StreamWriter(path);

            streamWriter.WriteLine(toSave());

            streamWriter.Close();

        }




    }
}
