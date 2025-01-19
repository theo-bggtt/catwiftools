using System;
using System.Drawing;
using System.Windows.Forms;

namespace catwiftools
{
    public static class DraggingHelper
    {
        private static bool isDragging = false; // Tracks if the form is being dragged
        private static Point dragStartPoint = new Point(0, 0); // Stores the starting point of the drag

        // Method to attach drag events to a form and its GroupBox controls
        public static void EnableDragging(Form form)
        {
            AttachDragEvents(form);
        }

        private static void AttachDragEvents(Control control)
        {
            // Attach Mouse events only to the form and GroupBox controls
            if (control is Form || control is System.Windows.Forms.GroupBox || control is System.Windows.Forms.UserControl)
            {
                control.MouseDown += Control_MouseDown;
                control.MouseMove += Control_MouseMove;
                control.MouseUp += Control_MouseUp;
            }

            // Recursively check child controls for GroupBoxes
            foreach (Control child in control.Controls)
            {
                AttachDragEvents(child);
            }
        }

        private static void Control_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = new Point(e.X, e.Y);
            }
        }

        private static void Control_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Get the parent form
                Form? form = (sender as Control)?.FindForm();
                if (form != null)
                {
                    // Calculate the new position of the form
                    Point newLocation = new Point(
                        form.Left + e.X - dragStartPoint.X,
                        form.Top + e.Y - dragStartPoint.Y);

                    form.Location = newLocation;
                }
            }
        }

        private static void Control_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false; // Stop dragging
            }
        }
    }
}
