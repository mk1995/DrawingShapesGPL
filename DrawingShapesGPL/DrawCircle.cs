using System.Drawing;

namespace DrawingShapesGPL
{
    /// <summary>DrawCircle</summary>
    /// <seealso cref="DrawingShapesGPL.Main" />
    /// <seealso cref="DrawingShapesGPL.IDrawShape" />
    class DrawCircle : CmdUtilities, IDrawShape
    {        
        public Graphics g;
        
        /// <summary>Draws the shape.</summary>
        /// <param name="g">The g.</param>
        public void DrawShape(Graphics g)
        {
            Pen p = new Pen(Color.Black, 4);
            g.DrawEllipse(p, mouseX - radius, mouseY - radius, radius * 2, radius * 2);
            p.Dispose();
        }

        /// <summary>Sets the shape parameter.</summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="hypoten">The hypoten.</param>
        public void SetShapeParam(int width, int height, int hypoten)
        {
            radius = width;
        }
    }
}
