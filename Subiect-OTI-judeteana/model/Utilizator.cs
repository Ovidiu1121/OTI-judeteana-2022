using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana
{
    public class Utilizator
    {

        private int id;
        private string name;
        private string password;
        private string email;
        private DateTime ultimautilizare;

        public Utilizator()
        {

        }

        public Utilizator(int id,string name,string password,string email,DateTime ultimautilizare)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.email = email;
            this.ultimautilizare = ultimautilizare;

        }

        public Utilizator(string prop)
        {
            string[] a = prop.Split(",");

            this.id=int.Parse(a[0]);
            this.name = a[1];
            this.password = a[2];
            this.email = a[3];
            this.ultimautilizare=DateTime.Parse(a[4]);

        }

        public string description()
        {
            string text = "";

            text+=this.id+", ";
            text+=this.name+", ";
            text+=this.password+", ";
            text+=this.email+", ";
            text+=this.ultimautilizare+"\n";

            return text;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }

        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email=value; }
        }

        public DateTime Ultimautilizare
        {
            get { return this.ultimautilizare; }
            set { this.ultimautilizare = value; }
        }

        public string save()
        {
            string text = "";

            text+=this.id+",";
            text+=this.name+",";
            text+=this.password+",";
            text+=this.Email+",";
            text+=this.ultimautilizare;

            return text;

        }



    }
}
