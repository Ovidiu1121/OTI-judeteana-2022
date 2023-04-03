using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana.controller
{
    public class ControlUtilizator
    {
        public List<Utilizator> lista=new List<Utilizator>();
        public string path = Application.StartupPath+@"data/utilizatori.txt";

        public ControlUtilizator()
        {

            load();

        }

        public void load()
        {
            StreamReader read=new StreamReader(path);

            string line = "";

            while ((line = read.ReadLine()) != null)
            {
                Utilizator a = new Utilizator(line);

                lista.Add(a);
            }
            read.Close();

        }

        public string afisare()
        {
            string text = "";
            
            for(int i = 0; i<lista.Count; i++)
            {
                text+=lista[i].description()+"\n";
            }

            return text;
        }

        public bool isUtilizator(string name,string password)
        {

            for(int i = 0; i<lista.Count; i++)
            {
                if (lista[i].Name.Equals(name))
                {
                    if (lista[i].Password.Equals(password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void updateUltimaUtilizare(string name,string password, DateTime ultimautilizare)
        {
            for(int i=0; i<lista.Count; i++)
            {
                if (lista[i].Name.Equals(name)&&lista[i].Password.Equals(password))
                {
                    lista[i].Ultimautilizare = ultimautilizare;
                }
            }


        }

        public string toSave()
        {

            string text = "";
            int i = 0;

            for (i = 0; i<lista.Count-1; i++)
            {
                text+=lista[i].save()+"\n";
            }
            text+=lista[i].save();

            return text;
        }

        public void salvareFisier()
        {

            StreamWriter writer = new StreamWriter(path);

            writer.WriteLine(this.toSave());

            writer.Close();
        }

        public void adaugare(Utilizator utilizator)
        {
            this.lista.Add(utilizator);
        }



    }
}
