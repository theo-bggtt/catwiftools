using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools
{
    internal class Functions
    {
        private Button? selectedButton = null;

        // Changes color of text and image to selected
        public void SelectButton(Button button)
        {
            if (selectedButton != null)
            {
                DeselectButton(selectedButton);
            }

            button.ForeColor = Color.FromArgb(00, 134, 179);
            string filename = $"{button.Text.ToLower()}Selected";
            string imagePath = $@"D:\crypto\catwiftools\img\icon\{filename}.png";

            if (File.Exists(imagePath))
            {
                button.Image = Image.FromFile(imagePath);
            }

            button.Invalidate();
            button.Paint += DrawLeftBorder;
            button.Refresh();

            selectedButton = button;
        }

        // Changes color of text and image to default
        public void DeselectButton(Button button)
        {
            button.ForeColor = Color.FromArgb(153, 153, 153);
            string filename = $"{button.Text.ToLower()}";
            string imagePath = $@"D:\crypto\catwiftools\img\icon\{filename}.png";

            if (File.Exists(imagePath))
            {
                button.Image = Image.FromFile(imagePath);
            }

            button.Invalidate();
            button.Paint -= DrawLeftBorder;
            button.Refresh();
        }

        public void DrawLeftBorder(object? sender, PaintEventArgs e)
        {
            if (sender is Button button)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(0, 134, 179), 2)) //(0,134,179) = color, 2 = thickness
                {
                    // Left border
                    e.Graphics.DrawLine(borderPen, 0, 0, 0, button.Height);
                }
            }
        }
    }
}
