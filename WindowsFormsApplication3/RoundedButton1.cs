using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

public class RoundedButton1 : Button
{
    public RoundedButton1()
    {
        this.SetStyle(ControlStyles.UserPaint, true); // Enables custom drawing
        this.FlatStyle = FlatStyle.Flat; // Optional: makes the button flat
        this.FlatAppearance.BorderSize = 0; // Removes the default border
    }

    // Override OnPaint to draw the button with rounded corners
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Set the radius for rounded corners
        int radius = 40;

        // Define the rectangle for the button area
        Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);

        // Create a graphics path for the rounded corners
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            // Fill the button with a color (or any other background)
            e.Graphics.FillPath(Brushes.Salmon, path);


        }

        // Draw the text in the center of the button
        TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}