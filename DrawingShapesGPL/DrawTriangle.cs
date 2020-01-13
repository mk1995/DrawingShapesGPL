using System;
using System.Drawing;

namespace DrawingShapesGPL
{
    /// <summary>DrawTriangle</summary>
    /// <seealso cref="DrawingShapesGPL.Main" />
    /// <seealso cref="DrawingShapesGPL.IDrawShape" />
    public class DrawTriangle : CmdUtilities, IDrawShape
    {
        /// <summary>The width of triangle.</summary>
        private int tWidth;        
        /// <summary>The height of triangle.</summary>
        private int tHeight;        
        /// <summary>The hypotenuse of triangle.</summary>
        private int tHypotenuse;

        /// <summary>Checks whether triangle exists or not.</summary>
        /// <returns>True || False</returns>
        public Boolean checkTriangleValidity()
        {
            // check condition 
            if (tWidth + tHeight <= tHypotenuse || tWidth + tHypotenuse <= tHeight || tHeight + tHypotenuse <= tWidth)
                return false;
            else
                return true;
        }
        
        /// <summary>Draws the Triangle shape.</summary>
        /// <param name="g">The g.</param>
        /// <exception cref="DrawingShapesGPL.DrawingShapesException">Triangle doesnt exist.</exception>
        public void DrawShape(Graphics g)
        {
            if(checkTriangleValidity())
            {
                Pen myPen = new Pen(Color.Black, 4);
                Point[] pnt = new Point[3];

                pnt[0].X = mouseX;
                pnt[0].Y = mouseY;

                pnt[1].X = mouseX - tWidth;
                pnt[1].Y = mouseY;

                pnt[2].X = mouseX;
                pnt[2].Y = mouseY - tHeight;
                g.DrawPolygon(myPen, pnt);
            }
            else
            {
                //throw new DrawingShapesException("Triangle doesnt exist.");
                throw new DrawingShapesException();
            }
            
        }
        
        /// <summary>Sets the parameters of the triangle.</summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="hypotn">The hypotn.</param>
        public void SetShapeParam(int width, int height, int hypotn)
        {
            this.tWidth = width;
            this.tHeight = height;
            this.tHypotenuse = hypotn;
        }
    }
}
