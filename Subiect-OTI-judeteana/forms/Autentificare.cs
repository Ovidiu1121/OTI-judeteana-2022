using Subiect_OTI_judeteana.controller;
using Subiect_OTI_judeteana.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiect_OTI_judeteana
{
    public partial class Autentificare : Form
    {
        private Label lblnume;
        private Label lblparola;
        private Label lbltitlu;
        private TextBox txtparola;
        private TextBox txtnume;
        private Button btnlogare;
        private Button btncontnou;
        private ControlUtilizator control = new ControlUtilizator();

        public Autentificare()
        {
            InitializeComponent();

            this.BackgroundImage=Image.FromFile(Application.StartupPath+@"data\Background\back3.jpg");

            this.BackgroundImageLayout=ImageLayout.Stretch;


            this.lblnume = new Label();
            this.Controls.Add(this.lblnume);
            this.lblnume.Location = new Point(224, 98);
            this.lblnume.Size = new Size(49, 20);
            this.lblnume.ForeColor = Color.DarkBlue;
            this.lblnume.Text="Nume";
            this.lblnume.BackColor=Color.Transparent;

            this.lblparola = new Label();
            this.Controls.Add(this.lblparola);
            this.lblparola.Location = new Point(224, 187);
            this.lblparola.Size=new Size(67, 20);
            this.lblparola.ForeColor=Color.DarkBlue;
            this.lblparola.Text="Parola";
            this.lblparola.BackColor = Color.Transparent;

            this.txtnume=new TextBox();
            this.Controls.Add(this.txtnume);
            this.txtnume.Location = new Point(224, 121);
            this.txtnume.Size=new Size(375, 27);

            this.txtparola=new TextBox();
            this.Controls.Add(this.txtparola);
            this.txtparola.Location = new Point(224, 210);
            this.txtparola.Size=new Size(375, 27);
            this.txtparola.PasswordChar='*';

            this.btnlogare=new Button();
            this.Controls.Add(this.btnlogare);
            this.btnlogare.Location = new Point(224, 310);
            this.btnlogare.Size=new Size(177, 45);
            this.btnlogare.Text="Logare";
            this.btnlogare.Click+=new EventHandler(btnLogare_Click);

            this.btncontnou=new Button();
            this.Controls.Add(this.btncontnou);
            this.btncontnou.Location = new Point(422, 310);
            this.btncontnou.Size=new Size(177, 45);
            this.btncontnou.Text="Cont nou";
            this.btncontnou.Click+=new EventHandler(btnContNou_Click);

        }

        public void btnLogare_Click(object sender,EventArgs e)
        {
            if (this.txtnume.Text.Equals("")||this.txtparola.Text.Equals(""))
            {
                MessageBox.Show("Exista camp necompletat");
            }else if (this.control.isUtilizator(this.txtnume.Text, this.txtparola.Text).Equals(false))
            {
                MessageBox.Show("Numele sau parola nu coincid");
            }
            else
            {
                DateTime dateTime = DateTime.Now.ToLocalTime();

                this.control.updateUltimaUtilizare(this.txtnume.Text, this.txtparola.Text, dateTime);
                this.control.salvareFisier();

                this.Hide();
                Vizualizare a=new Vizualizare();
                a.Closed+=(s, args) => this.Close();
                a.Show();
            }


        }

        public void btnContNou_Click(object sender, EventArgs e)
        {

            this.Hide();
            Inregistrare a=new Inregistrare();
            a.Closed+=(s, args) => this.Close();
            a.Show();

        }

        private void Autentificare_Load(object sender, EventArgs e)
        {

        }
    }
}
