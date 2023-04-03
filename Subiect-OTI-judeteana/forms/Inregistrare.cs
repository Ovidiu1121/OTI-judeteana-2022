using Subiect_OTI_judeteana.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiect_OTI_judeteana
{
    public partial class Inregistrare : Form
    {

        private Label lbltitlu;
        private Label lblnume;
        private Label lblparola;
        private Label lblconfirmare;
        private Label lblemail;
        private Button btnsalvare;
        private Button btnrenunta;
        private TextBox txtnume;
        private TextBox txtparola;
        private TextBox txtconfirmare;
        private TextBox txtemail;
        private ControlUtilizator control=new ControlUtilizator();


        public Inregistrare()
        {
            InitializeComponent();

            this.Size=new System.Drawing.Size(692, 496);

            this.lbltitlu=new Label();
            this.Controls.Add(this.lbltitlu);
            this.lbltitlu.Location=new Point(0, 0);
            this.lbltitlu.Size=new Size(280, 46);
            this.lbltitlu.Font=new Font("Arial", 20, FontStyle.Bold);
            this.lbltitlu.Text="Creeaza un cont";
            this.lbltitlu.BackColor=System.Drawing.Color.DeepSkyBlue;
            this.lbltitlu.ForeColor=this.BackColor;

            this.lblnume=new Label();
            this.Controls.Add(this.lblnume);
            this.lblnume.Location = new Point(134, 85);
            this.lblnume.Size = new Size(140, 20);
            this.lblnume.ForeColor=System.Drawing.SystemColors.Highlight;
            this.lblnume.Text="Nume";
            this.lblnume.Font=new Font("Arial", 10, FontStyle.Bold);

            this.lblparola=new Label();
            this.Controls.Add(this.lblparola);
            this.lblparola.Location = new Point(134, 159);
            this.lblparola.Size = new Size(60, 20);
            this.lblparola.ForeColor=System.Drawing.SystemColors.Highlight;
            this.lblparola.Text="Parola";
            this.lblparola.Font=new Font("Arial", 10, FontStyle.Bold);

            this.lblconfirmare=new Label();
            this.Controls.Add(this.lblconfirmare);
            this.lblconfirmare.Location = new Point(134, 228);
            this.lblconfirmare.Size = new Size(150, 20);
            this.lblconfirmare.ForeColor=System.Drawing.SystemColors.Highlight;
            this.lblconfirmare.Text="Confirmare parola";
            this.lblconfirmare.Font=new Font("Arial", 10, FontStyle.Bold);

            this.lblemail=new Label();
            this.Controls.Add(this.lblemail);
            this.lblemail.Location = new Point(134, 297);
            this.lblemail.Size = new Size(60, 20);
            this.lblemail.ForeColor=System.Drawing.SystemColors.Highlight;
            this.lblemail.Text="Email";
            this.lblemail.Font=new Font("Arial", 10, FontStyle.Bold);

            this.txtnume=new TextBox();
            this.Controls.Add(this.txtnume);
            this.txtnume.Location = new Point(134, 108);
            this.txtnume.Size = new Size(396, 27);
            this.txtnume.BorderStyle=BorderStyle.FixedSingle;
            this.txtnume.Validating+=new CancelEventHandler(txtNume_Validating);

            this.txtparola=new TextBox();
            this.Controls.Add(this.txtparola);
            this.txtparola.Location = new Point(134, 182);
            this.txtparola.Size = new Size(396, 27);
            this.txtparola.BorderStyle=BorderStyle.FixedSingle;
            this.txtparola.PasswordChar='*';
            this.txtparola.Validating+=new CancelEventHandler(txtparola_Validating);

            this.txtconfirmare=new TextBox();
            this.Controls.Add(this.txtconfirmare);
            this.txtconfirmare.Location = new Point(134, 251);
            this.txtconfirmare.Size = new Size(396, 27);
            this.txtconfirmare.BorderStyle=BorderStyle.FixedSingle;
            this.txtconfirmare.PasswordChar='*';
            this.txtconfirmare.Validating+=new CancelEventHandler(txtparolaconfirmare_Validating);

            this.txtemail=new TextBox();
            this.Controls.Add(this.txtemail);
            this.txtemail.Location = new Point(134, 320);
            this.txtemail.Size = new Size(396, 27);
            this.txtemail.BorderStyle=BorderStyle.FixedSingle;

            this.btnsalvare=new Button();
            this.Controls.Add(this.btnsalvare);
            this.btnsalvare.Location = new Point(134, 367);
            this.btnsalvare.Size = new Size(263, 44);
            this.btnsalvare.Text="Salvare";
            this.btnsalvare.Click+=new EventHandler(btnSalvare_Click);

            this.btnrenunta=new Button();
            this.Controls.Add(this.btnrenunta);
            this.btnrenunta.Location = new Point(425, 382);
            this.btnrenunta.Size = new Size(105, 29);
            this.btnrenunta.Text="Renunta";
            this.btnrenunta.Click+=new EventHandler(btnRenunta_Click);

        }

        public void btnRenunta_Click(object sender,EventArgs e)
        {

            this.Hide();
            Autentificare a = new Autentificare();
            a.Closed += (s, args) => this.Close();
            a.Show();

        }

        private void txtNume_Validating(object sender, CancelEventArgs e)
        {
            if (txtnume.Text.Length < 4)
            {
                MessageBox.Show("Numele trebuie să conțină cel puțin 4 caractere.");

                e.Cancel = true;
            }
        }

        private void txtparola_Validating(object sender, CancelEventArgs e)
        {
            if (txtparola.Text.Length < 6)
            {
                MessageBox.Show("Parola trebuie să conțină cel puțin 6 caractere.");

                e.Cancel = true;
            }
        }

        private void txtparolaconfirmare_Validating(object sender, CancelEventArgs e)
        {
            if (txtconfirmare.Text.Equals(this.txtparola.Text)==false)
            {
                MessageBox.Show("Parola trebuie să fie la fel.");

                e.Cancel = true;
            }
        }

        public void btnSalvare_Click(object sender,EventArgs e)
        {
            if (this.txtemail.Text.Equals(""))
            {
                MessageBox.Show("Exista camp necompletat");
            }
            else
            {
                DateTime date = DateTime.Now.ToLocalTime();
                Utilizator a=new Utilizator(this.control.lista.Count+1,this.txtnume.Text,this.txtparola.Text,this.txtemail.Text,date);

                this.control.adaugare(a);
                this.control.salvareFisier();

                this.Hide();
                Autentificare autentificare = new Autentificare();
                autentificare.Closed+=(s, args) => this.Close();
                autentificare.Show();
            }
            

        }


        private void Inregistrare_Load(object sender, EventArgs e)
        {

        }
    }
}
