using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools.bundler
{
    public partial class CreateToken : Form
    {
        private string tokenName, tokenSymbol, tokenDescription, tokenImagePath, websiteUrl, twitterUrl, telegramUrl;

        public CreateToken()
        {
            InitializeComponent();
        }

        private void CreateToken_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image into the PictureBox
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Visible = true; // Make the PictureBox visible
            }
            else
            {
                MessageBox.Show("No image selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tokenName = tbxName.Text.Trim();
        }

        private void tbxSymbol_TextChanged(object sender, EventArgs e)
        {
            tokenSymbol = tbxSymbol.Text.Trim();
        }

        private void tbxDescription_TextChanged(object sender, EventArgs e)
        {
            tokenDescription = tbxDescription.Text.Trim();
        }

        private void tbxWebsite_TextChanged(object sender, EventArgs e)
        {
            websiteUrl = tbxWebsite.Text.Trim();
        }

        private void tbxTwitter_TextChanged(object sender, EventArgs e)
        {
            twitterUrl = tbxTwitter.Text.Trim();
        }
        private void tbxTelegram_TextChanged(object sender, EventArgs e)
        {
            telegramUrl = tbxTelegram.Text.Trim();
        }
    }
}
