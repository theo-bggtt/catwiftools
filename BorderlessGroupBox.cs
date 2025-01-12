using System.Drawing;
using System.Windows.Forms;

namespace catwiftools // Replace with your actual namespace
{
    public class BorderlessGroupBox : GroupBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the base method to ensure the text is drawn
            base.OnPaint(e);

            // Customize the appearance - hide the border by clearing it
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // Optionally, draw the text manually
            TextRenderer.DrawText(
                e.Graphics,
                this.Text,
                this.Font,
                new Point(6, 0), // Adjust position if needed
                this.ForeColor
            );
        }
    }
}
