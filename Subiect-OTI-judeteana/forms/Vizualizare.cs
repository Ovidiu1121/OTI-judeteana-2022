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
        private Panel pnltraseu;
        Graphics g;
        private TabPage tab;
        private TabPage tab2;
        public Vizualizare()    
        {
            InitializeComponent();

            this.Size = new System.Drawing.Size(1000, 581);

            this.tabcontrol = new TabControl();
            this.Controls.Add(this.tabcontrol);
            this.tabcontrol.Location = new System.Drawing.Point(0, 0);
            this.tabcontrol.Size = new System.Drawing.Size(984, 539);

            TabPage tab = new TabPage("Harta");

            this.tab = tab;
            TabPage tab2 = new TabPage("Traseu");
            this.tab2 = tab2;
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
            this.btnresetare.Click+=new EventHandler(resetare_Click);

            //if (this.cmbharta.Text.Equals("Selecteaza un text"))
            //{
            //    string path = Application.StartupPath+@"\data\Harti\default_harta.png";

            //    this.pnltraseu=new PnlHarta(path, this.date.Value);
            //    tab2.Controls.Add(this.pnltraseu);
            //}
            //else
            //{
            //    this.pnltraseu=new PnlHarta(this.cmbharta.Text, this.date.Value);
            //    tab2.Controls.Add(this.pnltraseu);
            //}

        }

        public void schimbareHarta_ValueChanged(object sender, EventArgs e)
        {
            if(this.cmbharta.Text.Equals("Selecteaza un text")==false)
            {
                if (this.pnlimage!=null)
                {
                    foreach(Control ct in this.tab.Controls)
                    {

                        if (ct.Name.Equals("harta")){
                            this.tab.Controls.Remove(ct);
                        }
                    }
                }
                this.pnlimage=new PnlHarta(this.cmbharta.Text, this.date.Value);
                this.tab.Controls.Add(pnlimage);

            }

            if (this.pnltraseu!=null)
            {
                foreach (Control ct in this.tab2.Controls)
                {
                    if (ct.Name.Equals("harta"))
                    {
                        this.tab2.Controls.Remove(ct);
                    }
                }
            }

            this.pnltraseu=new PnlHarta(this.cmbharta.Text, this.date.Value);
            this.pnltraseu.Location=new Point(166, 2);
            this.tab2.Controls.Add(this.pnltraseu);
        }

        public void filtrare_Click(object sender, EventArgs e)
        {
            g=this.pnlimage.CreateGraphics();

            if(this.cmbfiltru.Text.Equals("Niciun filtru"))
            {
                MessageBox.Show("Selectati un filtru");
            }
            else if(this.cmbfiltru.Text.Equals("Valoarea < 20"))
            {
                foreach(Control ct in this.pnlimage.Controls)
                {
                    if(ct.Name.Equals("sub 20"))
                    {
                        this.pnlimage.Controls.Remove(ct);
                        g.Clear(Color.Red);
                    }
                }
                this.pnlimage.Invalidate();
                this.pnlimage.Update();
            }
            else if(this.cmbfiltru.Text.Equals("20 <= Valoarea <= 40"))
            {
                foreach (Control ct in this.pnlimage.Controls)
                {
                    if (ct.Name.Equals("intre 20 si 40"))
                    {
                        this.pnlimage.Controls.Remove(ct);
                    }
                }
            }
            else if(this.cmbfiltru.Text.Equals("Valoarea > 40"))
            {
                foreach (Control ct in this.pnlimage.Controls)
                {
                    if (ct.Name.Equals("peste 40"))
                    {
                        this.pnlimage.Controls.Remove(ct);
                    }
                }
            }

        }

        public void resetare_Click(object sender, EventArgs e)
        {
            this.cmbfiltru.Text="Niciun filtru";

        }



        
    }
}
