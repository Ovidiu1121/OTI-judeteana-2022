using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Subiect_OTI_judeteana
{
    public class Cerc:Panel
    {
        private int x;
        private int y;  
        private Color culoare;

        public Cerc(int x,int y,Color culoare)
        {
            this.x = x; 
            this.y = y;
            this.culoare = culoare;
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public void Paint(Graphics g)
        {

            SolidBrush yBrush=new SolidBrush(this.culoare);

            g.FillEllipse(yBrush, this.x, this.y, 50, 50);


        }



















    }
}
