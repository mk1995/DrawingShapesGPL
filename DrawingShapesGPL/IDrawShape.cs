using System.Drawing;

namespace DrawingShapesGPL
{
    /// <summary>Defining the interface</summary>
    interface IDrawShape
    {
        /// <summary>Draws the shape.</summary>
        /// <param name="g">The g.</param>
        void DrawShape(Graphics g);
        
        /// <summary>Sets the shape parameter.</summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="hypotenuse">The hypotenuse.</param>
        void SetShapeParam(int width, int height, int hypotenuse);
    }
}
