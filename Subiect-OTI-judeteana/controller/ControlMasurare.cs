using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana
{
    public class ControlMasurare
    {
        private List<Masurare>lista=new List<Masurare>();
        public string path = Application.StartupPath+@"\data\masurari.txt";

        public ControlMasurare()
        {
            load();
        }

        public void load()
        {

            StreamReader read=new StreamReader(path);

            string line = "";

            while ((line=read.ReadLine())!=null){
                Masurare a=new Masurare(line);
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

            for(i=0; i<lista.Count-1; i++)
            {
                text+=lista[i].save();
            }
            text+=lista[i].save();

            return text;
        }

        public void salvareFisier()
        {

            StreamWriter write=new StreamWriter(path);

            write.WriteLine(toSave());

            write.Close();

        }

        public List<Masurare> returnlista(string numeharta,DateTime data)
        {
            List<Masurare>lst=new List<Masurare>();

            for(int i=0; i<lista.Count; i++)
            {
                if (lista[i].Numeharta.Equals(numeharta)&&lista[i].Data.Day.Equals(data.Day))
                {
                    lst.Add(lista[i]);
                }
            }
            return lst;
        }






    }
}
