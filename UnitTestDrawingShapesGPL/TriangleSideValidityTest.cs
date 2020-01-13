using System;
using DrawingShapesGPL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDrawingShapesGPL
{
    [TestClass]
    public class TriangleSideValidityTest
    {
        [TestMethod]
        public void checkTriangleValidity()
        {
            DrawTriangle dt = new DrawTriangle();
            dt.SetShapeParam(1,2,3);
            bool expectedResult = false;
            bool actualResult = dt.checkTriangleValidity();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
