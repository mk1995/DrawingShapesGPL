using System.Drawing;

namespace DrawingShapesGPL
{
    /// <summary>DrawRectangle</summary>
    /// <seealso cref="DrawingShapesGPL.Main" />
    /// <seealso cref="DrawingShapesGPL.IDrawShape" />
    class DrawRectangle : CmdUtilities, IDrawShape
    {
        /// <summary>The width</summary>
        private new int width;
        /// <summary>The height</summary>
        private new int height;

        /// <summary>Draws the shape.</summary>
        /// <param name="g">The g.</param>
        public void DrawShape(Graphics g)
        {
            Pen p = new Pen(Color.Black, 4);
            g.DrawRectangle(p, mouseX - width / 2, mouseY - height / 2, width, height);
            p.Dispose();
        }
        /// <summary>Sets the shape parameter.</summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="hypotenuse">The hypotenuse.</param>
        public void SetShapeParam(int width, int height, int hypotenuse)
        {
            this.width = width;
            this.height = height;
        }
    }
}
