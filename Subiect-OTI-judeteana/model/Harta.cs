using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana
{
    public class Harta
    {
        private int id;
        private string nume;
        private string path;

        public Harta()
        {

        }

        public Harta(int id,string nume,string path)
        {
            this.id = id;
            this.nume = nume;
            this.path = path;
        }

        public Harta(string prop)
        {
            string[] a = prop.Split(",");

            this.id=int.Parse(a[0]);
            this.nume = a[1];
            this.path = a[2];

        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Nume
        {
            get { return this.nume; }
            set { this.nume = value; }
        }

        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public string descriere()
        {
            string text = "";

            text+=this.id+",";
            text+=this.nume+",";
            text+=this.path+"\n";

            return text;

        }

        public string save()
        {
            string text = "";

            text+=this.id+",";
            text+=this.nume+",";
            text+=this.path;

            return text;

        }

    }
}
