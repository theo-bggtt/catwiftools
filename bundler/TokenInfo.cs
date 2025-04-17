using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools.bundler
{
    public partial class TokenInfo : Form
    {
        public TokenInfo()
        {
            InitializeComponent();
        }

        private void TokenInfo_Load(object sender, EventArgs e)
        {
        }

        private void set_background(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // Define the bounds of the gradient (same size as form)
            Rectangle bounds = new Rectangle(0, 0, Width, Height);

            // Define a circle in the center of the form
            Point center = new Point(bounds.Width / 2, bounds.Height / 2);
            int radius = Math.Max(bounds.Width, bounds.Height);

            // Create a circular path
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(center.X - radius, center.Y - radius, radius * 2, radius * 2);

                // Create a PathGradientBrush with that path
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterPoint = center;
                    brush.CenterColor = Color.FromArgb(37, 37, 53);
                    brush.SurroundColors = new Color[] { Color.Black };

                    graphics.FillRectangle(brush, bounds);
                }
            }
        }


        private void TokenInfo_Paint(object sender, PaintEventArgs e)
        {
            set_background(sender, e);
        }
    }
}
