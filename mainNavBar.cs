using catwiftools.bundler;
using catwiftools.wallet;
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

        public void mainNavBar_Load(object sender, EventArgs e)
        {

        }

        public void btnTasks_Click(object sender, EventArgs e)
        {
            selectButton(btnTasks);
            deselectButton(btnBundler);
            deselectButton(btnProxies);
            deselectButton(btnWallets);
            deselectButton(btnSettings);
        }

        private void btnBundler_Click(object sender, EventArgs e)
        {
            CatWifTools parentForm = this.FindForm() as CatWifTools;
            if (parentForm != null)
            {
                // Call the method to toggle bundlerNav visibility
                parentForm.ToggleBundlerNav();
            }
            selectButton(btnBundler);
            deselectButton(btnProxies);
            deselectButton(btnWallets);
            deselectButton(btnTasks);
            deselectButton(btnSettings);
        }
        private void btnWallets_Click(object sender, EventArgs e)
        {
            selectButton(btnWallets);
            deselectButton(btnProxies);
            deselectButton(btnSettings);
            deselectButton(btnTasks);
            deselectButton(btnBundler);
        }
        private void btnProxies_Click(object sender, EventArgs e)
        {
            selectButton(btnProxies);
            deselectButton(btnSettings);
            deselectButton(btnWallets);
            deselectButton(btnTasks);
            deselectButton(btnBundler);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            selectButton(btnSettings);
            deselectButton(btnProxies);
            deselectButton(btnWallets);
            deselectButton(btnTasks);
            deselectButton(btnBundler);
        }

        // Changes color of text and image to selected
        public void selectButton(Button button)
        {
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
        }

        public static void SelectButtonFromOtherControl(mainNavBar navBar, Button button)
        {
            navBar.selectButton(button);
        }

        // Changes color of text and image to default
        public void deselectButton(Button button)
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

        // Draw the left border of a button
        public void DrawLeftBorder(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(0, 134, 179), 2)) //(0,134,179) = color, 2 = thickness
                {
                    // Left border
                    e.Graphics.DrawLine(borderPen, 0, 0, 0, button.Height);
                }
            }
        }


        //Draw the separator of header and buttons
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.Gray, 2)) // Color.Gray and thickness 2
            {

                e.Graphics.DrawLine(pen, 10, 84, 190, 84); // (X1, Y1, X2, Y2)
            }
        }

        


    }
}
