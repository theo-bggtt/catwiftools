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
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private mainNavBar navBar; // The user control with the 5 buttons
        private tasksNav tasksControl;
        private bundlerNav bundlerControl;
        private walletNav walletControl;
        private proxiesNav proxiesControl;
        private settingsNav settingsControl;

        private Dictionary<Button, UserControl> buttonControlMap;

        public CatWifTools()
        {
            InitializeComponent();

            // Initialize the navigation bar and the 5 user controls
            navBar = new mainNavBar();
            tasksControl = new tasksNav();
            bundlerControl = new bundlerNav();
            walletControl = new walletNav();
            proxiesControl = new proxiesNav();
            settingsControl = new settingsNav();

            // Add the navigation bar and user controls to the form
            this.Controls.Add(navBar);
            this.Controls.Add(tasksControl);
            this.Controls.Add(bundlerControl);
            this.Controls.Add(walletControl);
            this.Controls.Add(proxiesControl);
            this.Controls.Add(settingsControl);

            // Position the navigation bar and user controls
            navBar.Dock = DockStyle.Top; // Adjust as necessary
            var userControls = new List<UserControl> { tasksControl, bundlerControl, walletControl, proxiesControl, settingsControl };
            foreach (var control in userControls)
            {
                control.Dock = DockStyle.Fill; // Adjust as necessary
                control.Visible = false; // Hide all controls initially
            }

            // Map buttons in the nav bar to their respective user controls
            buttonControlMap = new Dictionary<Button, UserControl>
            {
                { navBar.btnTasks, tasksControl },
                { navBar.btnBundler, bundlerControl },
                { navBar.btnWallets, walletControl },
                { navBar.btnProxies, proxiesControl },
                { navBar.btnSettings, settingsControl }
            };


            // Attach a single event handler for all buttons
            foreach (var button in buttonControlMap.Keys)
            {
                button.Click += Button_Click;
            }
        }

        private void CatWifTools_Load(object sender, EventArgs e)
        {
            walletNav1.Visible = true;
            bundlerNav1.Visible = false;
        }

        // Paints the separator between the main navbar and the second navbar
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.Gray, 2)) // Color.Gray, thickness 2
            {
                e.Graphics.DrawLine(pen, 215, 15, 215, 795);
            }
        }


        // Start of drag
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
        // End of drag


        public void ToggleBundlerNav()
        {
            bundlerNav1.Visible = !bundlerNav1.Visible;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null && buttonControlMap.ContainsKey(clickedButton))
            {
                // Hide all user controls
                foreach (var control in buttonControlMap.Values)
                {
                    control.Visible = false;
                }

                // Show the user control associated with the clicked button
                buttonControlMap[clickedButton].Visible = true;
            }
        }
    }
}
