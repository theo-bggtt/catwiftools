using catwiftools.tasks;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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

        public void SelectButton(Button button)
        {
            if (selectedButton != null)
            {
                selectedButton.Paint -= DrawLeftBorder;
                selectedButton.Invalidate();
            }
            selectedButton = button;
            button.ForeColor = Color.FromArgb(0, 134, 179);
            string filename = $"{button.Tag}Selected";
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "icon");
            string imagePath = Path.Combine(basePath, $"{filename}.png");
            button.Image = Image.FromFile(imagePath);

            button.Paint += DrawLeftBorder;
            button.Invalidate();
        }

        public void DeselectButton(Button button)
        {
            button.ForeColor = Color.FromArgb(153, 153, 153);
            string filename = $"{button.Tag}";
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "icon");
            string imagePath = Path.Combine(basePath, $"{filename}.png");
            button.Image = Image.FromFile(imagePath);

            button.Paint -= DrawLeftBorder;
            button.Refresh();
        }

        public void DrawLeftBorder(object? sender, PaintEventArgs e)
        {
            if (sender is Button button)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(0, 134, 179), 2)) //(0,134,179) = color, 2 = thickness
                {
                    e.Graphics.DrawLine(borderPen, 0, 0, 0, button.Height);
                }
            }
        }

        public static (string ConnectionString, string HeliusUrl, string ApiKey) LoadEnvVariables()
        {
            Env.Load();
            string heliusApiKey = Env.GetString("API_KEY");
            string connectionString = "Data Source=catwiftools.db;";
            string heliusUrl = $"https://devnet.helius-rpc.com/?api-key={heliusApiKey}";
            return (connectionString, heliusUrl, heliusApiKey);
        }
    }
}