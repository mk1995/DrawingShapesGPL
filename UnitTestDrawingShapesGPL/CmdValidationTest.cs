using System;
using DrawingShapesGPL;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDrawingShapesGPL
{
    [TestClass]
    public class CmdValidationTest
    {
        [TestMethod]
        public void CmdValidation()
        {
            TextBox textbox = new TextBox();
            textbox.Text = "Rectangle 100, 100";

            CmdValidation validation = new CmdValidation(textbox);

            Boolean expectedOutcome = true;
            Boolean realOutcome;

            validation.CheckCmdLineValidation(textbox.Text);
            realOutcome = validation.IsCmdValid;

            Assert.AreEqual(expectedOutcome, realOutcome);

        }

        [TestMethod]
        public void CheckCmdLoopAndIfValidation()
        {
            TextBox textbox = new TextBox();
            textbox.Text = "counter = 5 " +
                "\r\n If counter = 5 then " +
                "\r\n radius = 25 " +
                "\r\n Circle 5 " +
                "\r\n EndIf";

            CmdValidation validation = new CmdValidation(textbox);

            Boolean expectedOutcome = true;
            Boolean realOutcome;

            validation.CheckCmdLoopAndIfValidation();
            realOutcome = validation.IsCmdValid;

            Assert.AreEqual(expectedOutcome, realOutcome);

        }
    }
}
