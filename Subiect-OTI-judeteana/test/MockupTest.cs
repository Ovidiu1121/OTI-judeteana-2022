using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiect_OTI_judeteana
{
    public partial class MockupTest : Form
    {
        Graphics g;
        public MockupTest()
        {
            InitializeComponent();
            g=this.CreateGraphics();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            PnlTest panel=new PnlTest();
            this.Controls.Add(panel);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MockupTest_Load(object sender, EventArgs e)
        {

        }
    }
}
