using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana
{
    public class PnlHarta:Panel
    {
        private ControlMasurare controlmasurare=new ControlMasurare();
        Graphics g;
        private string numeharta;
        private DateTime data;
     
        public PnlHarta(string numeharta,DateTime data)
        {
            this.numeharta = numeharta;
            this.data = data;
            this.Location = new Point(331, 0);
            this.Size = new Size(650, 510);
            this.Name="harta";
           

            this.BackgroundImage=Image.FromFile(Application.StartupPath+@"\data\harti\"+numeharta+".png");
            this.Paint+=new PaintEventHandler(panel_Paint);

        }

        public void panel_Paint(object sender, PaintEventArgs e)
        {
            List<Masurare> masurari = this.controlmasurare.returnlista(this.numeharta, this.data);
            g=this.CreateGraphics();
            foreach (Masurare m in masurari)
            {
                if (m.Valoare<20)
                {
                    Cerc a = new Cerc(m.Xpoz, m.Ypoz, Color.Green);
                    a.Name="sub 20";
                    a.Paint(g);
                    this.Controls.Add(a);
                }
                else if (m.Valoare>=20&&m.Valoare<=40)
                {
                    Cerc b = new Cerc(m.Xpoz, m.Ypoz, Color.Yellow);
                    b.Name="intre 20 si 40";
                    b.Paint(g);
                    this.Controls.Add(b);
                }
                else if (m.Valoare>40)
                {
                    Cerc c = new Cerc(m.Xpoz, m.Ypoz, Color.Red);
                    c.Name="peste 40";
                    c.Paint(g);
                    this.Controls.Add(c);
                }

            }


        }



    }
}
