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
        private TabControl tabcontrol;
        private ControlMasurare controlmasurare=new ControlMasurare();
        private Panel pnlimage;
        Graphics g;
        private TabPage tab;

        public Vizualizare()    
        {
            InitializeComponent();

            this.Size = new System.Drawing.Size(1000, 581);
            g = this.CreateGraphics();

            this.tabcontrol = new TabControl();
            this.Controls.Add(this.tabcontrol);
            this.tabcontrol.Location = new System.Drawing.Point(100, 100) ;
            this.tabcontrol.Size = new System.Drawing.Size(984, 539);
            
            TabPage tab = new TabPage("Harta");

            this.tab = tab;
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
            this.date.ValueChanged+=new EventHandler(schimbareHarta_ValueChanged);

            this.pnlimage=new PnlHarta("Bucuresti", this.date.Value);
            tab.Controls.Add(pnlimage);

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
            this.btnfiltru.Click+=new EventHandler(filtrare_Click);

            this.btnresetare=new Button();
            tab.Controls.Add(this.btnresetare);
            this.btnresetare.Location = new Point(53, 417);
            this.btnresetare.Size=new Size(199, 39);
            this.btnresetare.Text="Reseteaza filtru";
           

        }

        public void schimbareHarta_ValueChanged(object sender, EventArgs e)
        {
            if(this.cmbharta.Text.Equals("Selecteaza un text")==false)
            {
                this.pnlimage.BackgroundImage=Image.FromFile(Application.StartupPath+@"\data\harti\"+this.cmbharta.Text+".png");

                this.pnlimage=new PnlHarta(this.cmbharta.Text, this.date.Value);

               
                tab.Controls.Add(pnlimage);

            }
            this.pnlimage.SendToBack();


            foreach(var x in  this.Controls)
            {
                (x as Control).SendToBack();
            }

        }

        public void filtrare_Click(object sender, EventArgs e)
        {
            Cerc a = new Cerc(200, 500, Color.Green);
            a.Paint(g);

        }


        
    }
}
