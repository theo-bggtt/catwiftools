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
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public CatWifTools()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.Gray, 2)) // Color.Gray and thickness 2
            {

                // Draw a separator line (horizontal) at a specific Y position
                e.Graphics.DrawLine(pen, 215, 15, 215, 795); // (X1, Y1) -> (X2, Y2)
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            //walletCreator1.Visible = false;
            //walletManager1.Visible = false;
            //tokenLauncher1.Visible = false;
        }

        private void btnWalletCreator_Click(object sender, EventArgs e)
        {
            //walletCreator1.Visible = true;
            //walletManager1.Visible = false;
            //tokenLauncher1.Visible = false;
        }

        private void btnWalletManager_Click(object sender, EventArgs e)
        {
            //walletManager1.Visible = true;
            //walletCreator1.Visible = false;
            //tokenLauncher1.Visible = false;
        }

        private void btnTokenLauncher_Click(object sender, EventArgs e)
        {
            //walletManager1.Visible = false;
            //walletCreator1.Visible = false;
            //tokenLauncher1.Visible = true;
        }

        private void walletCreator1_Load(object sender, EventArgs e)
        {

        }

        private void CatWifTools_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void CatWifTools_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void CatWifTools_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
