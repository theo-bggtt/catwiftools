using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools
{
    internal class functions
    {

        public static Image RecolorImage(Image originalImage, Color newColor)
        {
            Bitmap bitmap = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Enable anti-aliasing for smooth edges
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Clear the bitmap with a transparent background
                graphics.Clear(Color.Transparent);

                // Create an image attributes object to recolor
                using (ImageAttributes imageAttributes = new ImageAttributes())
                {
                    // Set the color matrix to transform all colors into the new color
                    ColorMatrix colorMatrix = new ColorMatrix(
                        new float[][]
                        {
                    new float[] {0, 0, 0, 0, 0},       // Red
                    new float[] {0, 0, 0, 0, 0},       // Green
                    new float[] {0, 0, 0, 0, 0},       // Blue
                    new float[] {0, 0, 0, 1, 0},       // Alpha
                    new float[] {newColor.R / 255f, newColor.G / 255f, newColor.B / 255f, 0, 1} // Tint
                        });

                    imageAttributes.SetColorMatrix(colorMatrix);

                    // Draw the original image with the color transformation applied
                    graphics.DrawImage(
                        originalImage,
                        new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        0, 0, originalImage.Width, originalImage.Height,
                        GraphicsUnit.Pixel,
                        imageAttributes);
                }
            }

            return bitmap;
        }

        
    }
}
