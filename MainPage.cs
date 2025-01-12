using catwiftools.bundler;
using catwiftools.proxies;
using catwiftools.settings;
using catwiftools.tasks;
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
    public partial class CatWifTools : Form
    {
        private List<UserControl> userControls;

        public CatWifTools()
        {
            InitializeComponent();
            InitializeUserControls();
        }

        private void InitializeUserControls()
        {
            userControls = new List<UserControl>
            {
                walletNav1,
                bundlerNav1,
                // Add other user controls here
            };
        }

        private void CatWifTools_Load(object sender, EventArgs e)
        {
            //HideAllUserControls(null);
            walletNav1.Visible = true;
        }

        public void HideAllUserControls(Button btn)
        {
            for (int i = 0; i < userControls.Count; i++)
            {
                if (userControls[i].Name == $"btn{btn.Name}")
                {
                    userControls[i].Visible = true;
                }
                else
                {
                    userControls[i].Visible = false;
                }
            }
        }

        public void btnTasks_Click(object sender, EventArgs e)
        {
            selectButton(btnTasks);
            deselectButton(btnBundler);
            deselectButton(btnProxies);
            deselectButton(btnWallets);
            deselectButton(btnSettings);
            HideAllUserControls(btnTasks);
        }

        private void btnBundler_Click(object sender, EventArgs e)
        {
            selectButton(btnBundler);
            deselectButton(btnProxies);
            deselectButton(btnWallets);
            deselectButton(btnTasks);
            deselectButton(btnSettings);
            HideAllUserControls(btnBundler);
        }

        private void btnWallets_Click(object sender, EventArgs e)
        {
            selectButton(btnWallets);
            deselectButton(btnProxies);
            deselectButton(btnSettings);
            deselectButton(btnTasks);
            deselectButton(btnBundler);
            HideAllUserControls(btnWallets);
        }

        private void btnProxies_Click(object sender, EventArgs e)
        {
            selectButton(btnProxies);
            deselectButton(btnSettings);
            deselectButton(btnWallets);
            deselectButton(btnTasks);
            deselectButton(btnBundler);
            HideAllUserControls(btnProxies);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            selectButton(btnSettings);
            deselectButton(btnProxies);
            deselectButton(btnWallets);
            deselectButton(btnTasks);
            deselectButton(btnBundler);
            HideAllUserControls(btnSettings);
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
                e.Graphics.DrawLine(pen, 215, 15, 215, 795);
                if (walletNav1.Visible == true)
                {
                    e.Graphics.DrawLine(pen, 435, 35, 435, 775);
                }
            }
        }
    }
}
