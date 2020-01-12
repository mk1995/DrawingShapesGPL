using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DrawingShapesGPL
{
    /// <summary>
    ///   CmdUtilities Class
    /// </summary>
    /// <seealso cref="DrawingShapesGPL.Main" />
    public class CmdUtilities : Main
    {
        public int mouseX = 200;
        public int mouseY = 200;
        public Boolean hasDrawOrMoved = false;

        public int radius = 0;
        public int width = 0;
        public int height = 0;
        public int counter = 0;
        public int hypotenuse = 0;

        /// <summary>The loop number</summary>
        int loopNumber = 0;
        /// <summary>The shape factory</summary>
        DrawingFactory shapeFactory = new DrawingFactory();
        /// <summary>The i shape</summary>
        IDrawShape IShape;

        /// <summary>Loads the command.</summary>
        /// <param name="textBoxCmd">The text box command.</param>
        /// <param name="panelDraw">The panel draw.</param>
        public void loadCommand(TextBox textBoxCmd, Panel panelDraw)
        {
            this.textBoxCmd = textBoxCmd;
            this.panelDraw = panelDraw;
            g = panelDraw.CreateGraphics();
            int numberOfLines = textBoxCmd.Lines.Length;
            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = textBoxCmd.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (!oneLineCommand.Equals(""))
                {
                    Boolean hasDrawToKeyWord = Regex.IsMatch(oneLineCommand.ToLower(), @"\bdrawto\b");
                    Boolean hasMoveToKeyWord = Regex.IsMatch(oneLineCommand.ToLower(), @"\bmoveto\b");
                    if (hasDrawToKeyWord || hasMoveToKeyWord)
                    {
                        String args = oneLineCommand.Substring(6, (oneLineCommand.Length - 6));
                        String[] parms = args.Split(',');
                        for (int j = 0; j < parms.Length; j++) { parms[j] = parms[j].Trim(); }
                        mouseX = int.Parse(parms[0]);
                        mouseY = int.Parse(parms[1]);
                        hasDrawOrMoved = true;
                    }
                    else { hasDrawOrMoved = false; }
                    if (hasMoveToKeyWord) { panelDraw.Refresh();}
                }
            }
            for (loopNumber = 0; loopNumber < numberOfLines; loopNumber++)
            {
                String oneLineCommand = textBoxCmd.Lines[loopNumber];
                oneLineCommand = oneLineCommand.Trim();
                if (!oneLineCommand.Equals(""))
                {
                    RunCommand(oneLineCommand);
                }

            }
        }
        
        /// <summary>Runs the command.</summary>
        /// <param name="singleLineCommand">The single line command.</param>
        private void RunCommand(String singleLineCommand)
        {
            Boolean hasEquals = singleLineCommand.Contains("=");
            Boolean hasRepeat = singleLineCommand.Contains("+");
            singleLineCommand = Regex.Replace(singleLineCommand, @"\s+", " ");
            //set the value of  defined variables
            if (hasEquals)
            {
                string[] words = singleLineCommand.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].Trim();
                }
                String firstWord = words[0].ToLower();
                string[] words2 = singleLineCommand.Split('=');
                for (int j = 0; j < words2.Length; j++)
                    {
                        words2[j] = words2[j].Trim();
                    }
                if (words2[0].ToLower().Equals("radius"))
                    {
                        radius = int.Parse(words2[1]);
                    }
                else if (words2[0].ToLower().Equals("width"))
                    {
                        width = int.Parse(words2[1]);
                    }
                else if (words2[0].ToLower().Equals("height"))
                    {
                        height = int.Parse(words2[1]);
                    }
                else if (words2[0].ToLower().Equals("counter"))
                    {
                        counter = int.Parse(words2[1]);
                    }
                else if (words2[0].ToLower().Equals("hypotenuse"))
                    {
                        hypotenuse = int.Parse(words2[1]);
                    }
            }
            else
            {
                sendDrawCommand(singleLineCommand);
            }


        }

        /// <summary>Sends the draw command.</summary>
        /// <param name="lineOfCommand">The line of command.</param>
        private void sendDrawCommand(string lineOfCommand)
        {
            String[] shapes = { "circle", "rectangle", "triangle" };
            String[] variable = { "radius", "width", "height", "counter", "hypotenuse" };

            lineOfCommand = Regex.Replace(lineOfCommand, @"\s+", " ");
            string[] words = lineOfCommand.Split(' ');
            //removing white spaces in between words
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
            String firstWord = words[0].ToLower();
            Boolean firstWordShape = shapes.Contains(firstWord);
            if (firstWordShape)
            {
                if (firstWord.Equals("circle"))
                {
                    Boolean secondWordIsVariable = variable.Contains(words[1].ToLower());
                    if (secondWordIsVariable)
                    {
                        if (words[1].ToLower().Equals("radius"))
                        {
                            IShape = shapeFactory.getShape("CIRCLE");
                            IShape.SetShapeParam(radius, 0,0);
                            IShape.DrawShape(g);
                        }
                    }
                    else
                    {
                        IShape = shapeFactory.getShape("CIRCLE");
                        IShape.SetShapeParam(Int32.Parse(words[1]), 0,0);
                        IShape.DrawShape(g);
                    }

                }
                else if (firstWord.Equals("rectangle"))
                {
                    String args = lineOfCommand.Substring(9, (lineOfCommand.Length - 9));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    Boolean secondWordIsVariable = variable.Contains(parms[0].ToLower());
                    Boolean thirdWordIsVariable = variable.Contains(parms[1].ToLower());
                    if (secondWordIsVariable)
                    {
                        if (thirdWordIsVariable)
                        {
                            IShape = shapeFactory.getShape("RECTANGLE");
                            IShape.SetShapeParam(width, height,0);
                            IShape.DrawShape(g);
                        }
                        else
                        {
                            IShape = shapeFactory.getShape("RECTANGLE");
                            IShape.SetShapeParam(width, Int32.Parse(parms[1]),0);
                            IShape.DrawShape(g);
                        }

                    }
                    else
                    {
                        if (thirdWordIsVariable)
                        {
                            IShape = shapeFactory.getShape("RECTANGLE");
                            IShape.SetShapeParam(Int32.Parse(parms[0]), height, 0);
                            IShape.DrawShape(g);
                        }
                        else
                        {
                            IShape = shapeFactory.getShape("RECTANGLE");
                            IShape.SetShapeParam(Int32.Parse(parms[0]), Int32.Parse(parms[1]), 0);
                            IShape.DrawShape(g);
                        }
                    }
                }
                else if (firstWord.Equals("triangle"))
                {
                    String args = lineOfCommand.Substring(8, (lineOfCommand.Length - 8));
                    String[] parms = args.Split(',');
                    if (parms.Length == 3)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            parms[i] = parms[i].Trim();
                        }
                        IShape = shapeFactory.getShape("TRIANGLE");
                        IShape.SetShapeParam(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]));
                        IShape.DrawShape(g);

                    }
                }
            }
            else
            {
                if (firstWord.Equals("loop"))
                {
                    counter = int.Parse(words[1]);
                    int loopStartLine = (GetStartLineNumber("loop"));
                    int loopEndLine = (GetEndLineNumber("endloop") - 1);
                    loopNumber = loopEndLine;
                    for (int i = 0; i < counter; i++)
                    {
                        for (int j = loopStartLine; j <= loopEndLine; j++)
                        {
                            String oneLineCommand = textBoxCmd.Lines[j];
                            oneLineCommand = oneLineCommand.Trim();
                            if (!oneLineCommand.Equals(""))
                            {
                                RunCommand(oneLineCommand);
                            }
                        }
                    }
                }
                else if (firstWord.Equals("if"))
                {
                    Boolean loop = false;
                    if (words[1].ToLower().Equals("radius"))
                    {
                        if (radius == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("width"))
                    {
                        if (width == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("height"))
                    {
                        if (height == int.Parse(words[1]))
                        {
                            loop = true;
                        }

                    }
                    else if (words[1].ToLower().Equals("counter"))
                    {
                        if (counter == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    int ifStartLine = (GetStartLineNumber("if"));
                    int ifEndLine = (GetEndLineNumber("endif") - 1);
                    loopNumber = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            String oneLineCommand = textBoxCmd.Lines[j];
                            oneLineCommand = oneLineCommand.Trim();
                            if (!oneLineCommand.Equals(""))
                            {
                                RunCommand(oneLineCommand);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Return the line number of command</summary>
        /// <param name="syntax"></param>
        /// <returns>int lineNum</returns>
        public int GetStartLineNumber(string syntax)
        {
            //this.textBoxCmd.Text = "if counter=5 then \r\n circle 25 \r\n rectangle 100,250 \r\n endif";
            int numberOfCmdLines = textBoxCmd.Lines.Length;
            int lineNum = 0;
            for (int i = 0; i < numberOfCmdLines; i++)
            {
                String oneLineCommand = textBoxCmd.Lines[i];
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
                //removing white spaces in between words
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = words[j].Trim();
                }
                String firstWord = words[0].ToLower();
                if (firstWord.Equals(syntax))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;
        }

        /// <summary>Gets the end line number.</summary>
        /// <param name="syntax">The syntax.</param>
        /// <returns></returns>
        public int GetEndLineNumber(string syntax)
        {
            //this.textBoxCmd.Text = "if counter=5 then \r\n circle 25 \r\n rectangle 100,250 \r\n endif";
            int numberOfCmdLines = textBoxCmd.Lines.Length;
            int lineNum = 0;
            for (int i = 0; i < numberOfCmdLines; i++)
            {
                String oneLineCommand = textBoxCmd.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (oneLineCommand.ToLower().Equals(syntax))
                {
                    lineNum = i + 1;
                }
            }
            return lineNum;


        }
    }
}
