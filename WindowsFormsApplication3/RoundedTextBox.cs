using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;



public class RoundedTextBox : TextBox
{
    public RoundedTextBox()
    {
        this.SetStyle(ControlStyles.UserPaint, true); // Enables custom drawing
        this.BorderStyle = BorderStyle.FixedSingle; // Default border style
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Set the radius for rounded corners
        int radius = 40;

        // Define the rectangle for the text box's inner area
        Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);

        // Create the graphics path for rounded corners
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            // Fill the background and draw the border
            e.Graphics.FillPath(Brushes.WhiteSmoke, path); // White background

        }
    }
}