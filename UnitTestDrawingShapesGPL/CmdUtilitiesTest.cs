using DrawingShapesGPL;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDrawingShapesGPL
{
    [TestClass]
    public class CmdUtilitiesTest
    {
        [TestMethod]
        public void GetStartLineNumber()
        {
            this.textBoxCmd.Text = "if counter=5 then \r\n circle 25 " +
                "\r\n rectangle 100,250 \r\n endif";
            int expectedOutcome = 1;
            int realOutcome;
            CmdUtilities cmU = new CmdUtilities();
            realOutcome = cmU.GetStartLineNumber("if");
            Assert.AreEqual(expectedOutcome, realOutcome);
        }
        [TestMethod]
        public void GetEndLineNumber()
        {
            this.textBoxCmd.Text = "if counter=5 then \r\n circle 25 " +
                "\r\n rectangle 100,250 \r\n endif";
            int expectedOutcome = 4;
            int realOutcome;
            CmdUtilities cmU = new CmdUtilities();
            realOutcome = cmU.GetEndLineNumber("endif");
            Assert.AreEqual(expectedOutcome, realOutcome);
        }
    }
}
