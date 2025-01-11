using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools
{
    public partial class mainNavBar : UserControl
    {
        public mainNavBar()
        {
            InitializeComponent();
        }

        private void mainNavBar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.Gray, 2)) // Color.Gray and thickness 2
            {

                // Draw a separator line (horizontal) at a specific Y position
                e.Graphics.DrawLine(pen, 10, 84, 190, 84); // (X1, Y1) -> (X2, Y2)
            }
        }
    }
}
