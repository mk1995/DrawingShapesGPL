using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingShapesGPL
{
    /// <summary>Custom defined exception for DrawiingShapes</summary>
    /// <seealso cref="System.Exception" />
    public class DrawingShapesException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="DrawingShapesException"/> class.</summary>
        /// <param name="msg">The error message.</param>
        public DrawingShapesException(string msg) : base(String.Format("DrawingShapesException: {0}", msg))
        { }
    }
}
