using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana
{
    public class PnlTest:Panel
    {

        Graphics g;

        public PnlTest()
        {
            this.Location = new Point(366, 21);
            this.Size = new Size(422, 417);
            this.BackColor = Color.LightGray;

            this.Paint+=new PaintEventHandler(panel1_Paint);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g=this.CreateGraphics();

            Cerc a = new Cerc(100, 100, Color.Green);
            a.Paint(g);

            Cerc b = new Cerc(200, 200, Color.Red);
            b.Paint(g);
        }










    }
}
