using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana
{
    public class PnlHarta:Panel
    {
        private ControlMasurare controlmasurare=new ControlMasurare();
        Graphics g;

        public PnlHarta(string numeharta,DateTime data)
        {
            this.Location = new Point(331, 0);
            this.Size = new Size(650, 510);
            this.BackgroundImage=Image.FromFile(Application.StartupPath+@"data\Harti\default_harta.png");
            g = this.CreateGraphics();

            List<Masurare> masurari = this.controlmasurare.returnlista(numeharta, data);

            foreach (Masurare m in masurari)
            {
                if (m.Valoare<20)
                {
                    Cerc a = new Cerc(m.Xpoz, m.Ypoz, Color.Green);
                    a.Paint(g);
                    this.Controls.Add(a);
                }
                else if (m.Valoare>=20&&m.Valoare<=40)
                {
                    Cerc a = new Cerc(m.Xpoz, m.Ypoz, Color.Yellow);
                    a.Paint(g);
                    this.Controls.Add(a);
                }
                else if (m.Valoare>40)
                {
                    Cerc a = new Cerc(m.Xpoz, m.Ypoz, Color.Red);
                    a.Paint(g);
                    this.Controls.Add(a);
                }

            }
            

        }
     


    }
}
