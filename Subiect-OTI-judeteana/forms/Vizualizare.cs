using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiect_OTI_judeteana.forms
{
    public partial class Vizualizare : Form
    {
        private Label lblharta;
        private Label lbldata;
        private Label lblfiltru;
        private ComboBox cmbharta;
        private DateTimePicker date;
        private ComboBox cmbfiltru;
        private Button btnfiltru;
        private Button btnresetare;
        private PictureBox picbox;
        private TabControl tabcontrol;

        public Vizualizare()
        {
            InitializeComponent();

            this.Size = new System.Drawing.Size(1000, 581);

            this.tabcontrol = new TabControl();
            this.Controls.Add(this.tabcontrol);
            this.tabcontrol.Location = new System.Drawing.Point(0, 0);
            this.tabcontrol.Size = new System.Drawing.Size(984, 539);
            
            TabPage tab = new TabPage("Harta");
            TabPage tab2 = new TabPage("Traseu");
            this.tabcontrol.Controls.Add(tab);
            this.tabcontrol.Controls.Add(tab2);

            tab.BackgroundImage=Image.FromFile(Application.StartupPath+@"data\Background\back4.jpg");

            this.lblharta = new Label();
            tab.Controls.Add(this.lblharta);
            this.lblharta.Location=new Point(29, 100);
            this.lblharta.Size=new Size(66, 28);
            this.lblharta.Text="Harta";
            this.lblharta.Font=new Font("Arial", 12, FontStyle.Bold);
            this.lblharta.BackColor=Color.Transparent;

            this.cmbharta=new ComboBox();
            tab.Controls.Add(this.cmbharta);
            this.cmbharta.Location=new Point(29, 131);
            this.cmbharta.Size = new Size(250, 28);
            this.cmbharta.Text="Selecteaza un text";
            this.cmbharta.Items.AddRange(new object[] { "Bucuresti","Cluj-Napoca","Constanta","Sibiu","Iasi" });
            this.cmbharta.SelectedIndexChanged+=new EventHandler(schimbareHarta_SelectedIndexChanged);

            this.lbldata=new Label();
            tab.Controls.Add(this.lbldata);
            this.lbldata.Location=new Point(29, 191);
            this.lbldata.Size=new Size(57, 28);
            this.lbldata.Text="Data";
            this.lbldata.Font=new Font("Arial", 12, FontStyle.Bold);
            this.lbldata.BackColor=Color.Transparent;

            this.date=new DateTimePicker();
            tab.Controls.Add(this.date);
            this.date.Location=new Point(29, 222);
            this.date.Size=new Size(250, 27);

            this.lblfiltru=new Label();
            tab.Controls.Add(this.lblfiltru);
            this.lblfiltru.Location=new Point(29, 290);
            this.lblfiltru.Size=new Size(62, 28);
            this.lblfiltru.Text="Filtru";
            this.lblfiltru.Font=new Font("Arial", 12, FontStyle.Bold);
            this.lblfiltru.BackColor=Color.Transparent;

            this.cmbfiltru=new ComboBox();
            tab.Controls.Add(this.cmbfiltru);
            this.cmbfiltru.Location=new Point(29, 321);
            this.cmbfiltru.Size = new Size(250, 28);
            this.cmbfiltru.Text="Niciun filtru";
            this.cmbfiltru.Items.AddRange(new object[] { "Niciun filtru", "Valoarea < 20", "20 <= Valoarea <= 40", "Valoarea > 40" });

            this.btnfiltru=new Button();
            tab.Controls.Add(this.btnfiltru);
            this.btnfiltru.Location = new Point(95, 372);
            this.btnfiltru.Size=new Size(110, 39);
            this.btnfiltru.Text="Filtrare";

            this.btnresetare=new Button();
            tab.Controls.Add(this.btnresetare);
            this.btnresetare.Location = new Point(53, 417);
            this.btnresetare.Size=new Size(199, 39);
            this.btnresetare.Text="Reseteaza filtru";

            this.picbox=new PictureBox();
            tab.Controls.Add(this.picbox);
            this.picbox.Location=new Point(331, 0);
            this.picbox.Size=new Size(645, 503);
            this.picbox.Image=Image.FromFile(Application.StartupPath+@"data\Harti\default_harta.png");
            this.picbox.SizeMode=PictureBoxSizeMode.StretchImage;


        }

        public void schimbareHarta_SelectedIndexChanged(object sender,EventArgs e)
        {

            switch (this.cmbharta.SelectedItem)
            {
                case "Sibiu":
                    this.picbox.Image=Image.FromFile(Application.StartupPath+@"data\Harti\harta_sibiu.png");
                    this.picbox.SizeMode=PictureBoxSizeMode.StretchImage;
                    break;
                case "Bucuresti":
                    this.picbox.Image=Image.FromFile(Application.StartupPath+@"data\Harti\harta_bucuresti.png");
                    this.picbox.SizeMode=PictureBoxSizeMode.StretchImage;
                    break;
                case "Iasi":
                    this.picbox.Image=Image.FromFile(Application.StartupPath+@"data\Harti\harta_iasi.png");
                    this.picbox.SizeMode=PictureBoxSizeMode.StretchImage;
                    break;
                case "Constanta":
                    this.picbox.Image=Image.FromFile(Application.StartupPath+@"data\Harti\harta_constanta.png");
                    this.picbox.SizeMode=PictureBoxSizeMode.StretchImage;
                    break;
                case "Cluj-Napoca":
                    this.picbox.Image=Image.FromFile(Application.StartupPath+@"data\Harti\harta_cluj.png");
                    this.picbox.SizeMode=PictureBoxSizeMode.StretchImage;
                    break;
            }

        }

        private void Vizualizare_Load(object sender, EventArgs e)
        {

        }
    }
}
