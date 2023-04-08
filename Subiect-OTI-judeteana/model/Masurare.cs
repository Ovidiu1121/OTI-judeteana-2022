using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana
{
    public class Masurare
    {

        private int id;
        private string numeharta;
        private int xpoz;
        private int ypoz;
        private int valoare;
        private DateTime data;

        public Masurare()
        {

        }

        public Masurare(int id,string numeharta, int xpoz,int ypoz,int valoare,DateTime data)
        {
            this.id = id;
            this.numeharta = numeharta;
            this.xpoz = xpoz;
            this.ypoz = ypoz;
            this.valoare = valoare;
            this.data = data;
        }

        public Masurare(string prop)
        {
            string[] a = prop.Split("#");

            this.id=int.Parse(a[0]);
            this.numeharta=a[1];
            this.xpoz=int.Parse(a[2]);
            this.ypoz=int.Parse(a[3]);
            this.valoare=int.Parse(a[4]);
            this.data=DateTime.Parse(a[5]);
            
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Numeharta
        {
            get { return this.numeharta; }
            set { this.numeharta=value; }
        }

        public int Xpoz
        {
            get { return this.xpoz; }
            set { this.xpoz=value;}
        }

        public int Ypoz
        {
            get { return this.ypoz; }
            set { this.ypoz=value; }
        }

        public int Valoare
        {
            get { return this.valoare; }
            set { this.valoare=value;}
        }

        public DateTime Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public string descriere()
        {
            string text = "";

            text+=this.id+",";
            text+=this.numeharta+",";
            text+=this.xpoz+",";
            text+=this.ypoz+",";
            text+=this.valoare+",";
            text+=this.data+"\n";

            return text;
        }

        public string save()
        {
            string text = "";

            text+=this.id+"#";
            text+=this.numeharta+"#";
            text+=this.xpoz+"#";
            text+=this.ypoz+"#";
            text+=this.valoare+"#";
            text+=this.data;

            return text;
        }



    }
}
