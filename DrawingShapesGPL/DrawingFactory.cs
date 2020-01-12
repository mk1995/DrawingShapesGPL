namespace DrawingShapesGPL
{
    /// <summary>DrawingFactory Class</summary>
    class DrawingFactory
    {

        /// <summary> Get the shape implementing Interface.</summary>
        /// <param name="shapeType">Type of the shape.</param>
        /// <returns>Shape</returns>
        public IDrawShape getShape(string shapeType)
        {
            IDrawShape shape = null;
            switch (shapeType)
            {
                case "CIRCLE":
                    shape = new DrawCircle();
                    break;
                case "RECTANGLE":
                    shape = new DrawRectangle();
                    break;
                case "TRIANGLE":
                    shape = new DrawTriangle();
                    break;
            }
            return shape;
        }
    }
}
