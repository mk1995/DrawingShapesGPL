using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/// <summary>
/// namespace DrawingShapesGPL
/// </summary>
namespace DrawingShapesGPL
{
    /// <summary>
    /// CmdValidation class helps to validate each and every text line.
    /// <list type="bullet">
    /// syntax: "drawto", "moveto", "loop", "endloop", "if", "endif",
    /// parameters and their respective datatypes
    /// variables such as radius, height, width, counter, hypotenuse
    /// </list>
    /// </summary>
    public class CmdValidation : Main
    {

        /// <summary>
        /// isCmdValid member of CmdValidation class which indicates
        /// whether the command line is "TRUE" or "FASLE"
        /// </summary>
        public Boolean isCmdValid = true;

        /// <summary>
        /// isSomethingInvalid member of CmdValidation class which indicates
        /// whether something exceptional is occured in command line or not.
        /// </summary>
        public Boolean isSomethingInvalid = false;

        /// <summary>
        /// lineNumber: indicates line number of the command in the multi-textline control.
        /// </summary>
        public int lineNumber = 0;

        /// <summary>
        /// doesCmdHasLoop: indicates whether command has "LOOP" keyword in the multi-textline control.
        /// </summary>
        public Boolean doesCmdHasLoop = false;

        /// <summary>
        /// doesCmdHasEndLoop: indicates whether command has "ENDLOOP" keyword in the multi-textline control.
        /// </summary>
        public Boolean doesCmdHasEndLoop = false;

        /// <summary>
        /// doesCmdHasIf: indicates whether command has "IF" keyword in the multi-textline control.
        /// </summary>
        public Boolean doesCmdHasIf = false;

        /// <summary>
        /// doesCmdHasEndif: indicates whether command has "ENDIF" keyword in the multi-textline control.
        /// </summary>
        public Boolean doesCmdHasEndif = false;

        /// <summary>
        /// doesCmdHasEndif: indicates whether command has "ENDIF" keyword in the multi-textline control.
        /// </summary>
        public int loopLineNo = 0, endLoopLineNo = 0, ifLineNo = 0, endIfLineNo = 0;

        /// <summary>
        /// CmdValidation(TextBox textBoxCmd): If text box is empty isCmdValid = "false"
        /// else validate the each single command line using CheckCmdLineValidation(string singleLineCmd)
        /// </summary>
        /// <param name="textBoxCmd">Windows text box control</param>
        public CmdValidation(TextBox textBoxCmd)
        {
            this.textBoxCmd = textBoxCmd;
            int numberOfCmdLines = textBoxCmd.Lines.Length;
            if (numberOfCmdLines == 0) { isCmdValid = false; }
            else
            {
                for (int i = 0; i < numberOfCmdLines; i++)
                {
                    String singleLineCmd = textBoxCmd.Lines[i];
                    singleLineCmd = singleLineCmd.Trim();
                    if (!singleLineCmd.Equals(""))
                    {
                        CheckCmdLineValidation(singleLineCmd);
                        lineNumber = (i + 1);
                        if (!isCmdValid)
                        {
                            MessageBox.Show("Command Validation error at: " + lineNumber);
                            isSomethingInvalid = true;
                        }
                        else
                        {
                            CheckCmdLoopAndIfValidation();
                        }
                    }

                }
            }
        }

        /// <summary>
        /// CheckCmdLineValidation(string cmd): get single line command from TextBox Control and
        /// check whether syntax, shapes, variables exist or not. If not, isValidCmd = "false" and
        /// isSomethingInvalid = "true"
        /// </summary>
        /// <param name="cmd">String Single line command</param>
        public void CheckCmdLineValidation(string cmd)
        {
            String[] syntaxs = { "drawto", "moveto", "loop", "endloop", "if", "endif", "run"};
            String[] shapes = { "circle", "rectangle", "triangle" };
            String[] variables = { "radius", "width", "height", "counter", "hypotenuse"};
            cmd = Regex.Replace(cmd, @"\s+", " ");
            string[] commandsAfterSpliting = cmd.Split(' ');
            for (int i = 0; i < commandsAfterSpliting.Length; i++)
            {
                commandsAfterSpliting[i] = commandsAfterSpliting[i].Trim();
            }
            String firstWord = commandsAfterSpliting[0].ToLower();
            Boolean firstWordIsSyntax = syntaxs.Contains(firstWord);
            Boolean firstWordIsShape = shapes.Contains(firstWord);
            Boolean firstWordIsVariable = variables.Contains(firstWord);

            if (firstWordIsSyntax)
            {
                if (firstWord.Equals("drawto") || firstWord.Equals("moveto"))
                {
                    String args = cmd.Substring(6, (cmd.Length - 6));
                    String[] parms = args.Split(',');

                    if (parms.Length == 2)
                    {
                        for (int i = 0; i < parms.Length; i++)
                        {
                            if (!parms[i].Trim().All(char.IsDigit))
                            {
                                isCmdValid = false;
                            }
                        }
                    }
                    else
                    {
                        isCmdValid = false;
                    }
                }
                else if (firstWord.Equals("loop"))
                {
                    if (commandsAfterSpliting.Length == 2)
                    {
                        if (!commandsAfterSpliting[1].Trim().All(char.IsDigit))
                        {
                            isCmdValid = false;
                        }
                    }
                    else
                    {
                        isCmdValid = false;
                    }
                }
                else if (firstWord.Equals("endloop"))
                {
                    if (commandsAfterSpliting.Length == 1)
                    {
                        if (!commandsAfterSpliting[0].Equals("endloop"))
                        {
                            isCmdValid = false;
                        }
                    }
                    else
                    {
                        isCmdValid = false;
                    }
                }//endif
                else if (firstWord.Equals("if"))//if radius = x then
                {
                    if (commandsAfterSpliting.Length == 5)
                    {
                        if (variables.Contains(commandsAfterSpliting[1].ToLower()))
                        {
                            if (commandsAfterSpliting[2].Equals("="))
                            {
                                if (commandsAfterSpliting[3].Trim().All(char.IsDigit))
                                {
                                    if (!commandsAfterSpliting[4].ToLower().Equals("then"))
                                    {
                                        isCmdValid = false;
                                    }
                                }
                                else { isCmdValid = false; }

                            }
                            else { isCmdValid = false; }
                        }
                        else { isCmdValid = false; }

                    }
                    else { isCmdValid = false; }

                }
                else if (firstWord.Equals("endif"))
                {
                    if (commandsAfterSpliting.Length != 1)
                    {
                        isCmdValid = false;
                    }
                }
                else if (firstWord.Equals("run"))
                {
                    if (commandsAfterSpliting.Length != 1)
                    {
                        isCmdValid = false;
                    }
                }

            }
            else if (firstWordIsShape)
            {
                if (firstWord.ToLower().Equals("circle"))
                {
                    if (commandsAfterSpliting.Length == 2)
                    {
                        if (commandsAfterSpliting[1].Trim().All(char.IsDigit)) { }
                        else if (commandsAfterSpliting[1].Trim().All(char.IsLetter))
                        {
                            if (variables.Contains(commandsAfterSpliting[1].ToLower())) { }
                            else { isCmdValid = false; }
                        }
                        else { isCmdValid = false; }
                    }
                    else { isCmdValid = false; }
                }
                else if (firstWord.ToLower().Equals("rectangle"))
                {
                    String args = cmd.Substring(9, (cmd.Length - 9));
                    String[] parms = args.Split(',');

                    if (parms.Length == 2)
                    {
                        for (int i = 0; i < parms.Length; i++)
                        {
                            parms[i] = parms[i].Trim();
                            if (parms[i].All(char.IsDigit)) { }
                            else if (parms[i].All(char.IsLetter))
                            {
                                if (variables.Contains(parms[i].ToLower())) { }
                                else { isCmdValid = false; }
                            }
                            else { isCmdValid = false; }

                        }
                    }
                    else { isCmdValid = false; }
                }
                else if (firstWord.ToLower().Equals("triangle"))
                {
                    String args = cmd.Substring(8, (cmd.Length - 8));
                    String[] parms = args.Split(',');

                    if (parms.Length == 3)
                    {
                        for (int i = 0; i < parms.Length; i++)
                        {
                            parms[i] = parms[i].Trim();
                            if (!parms[i].All(char.IsDigit))
                            {
                                isCmdValid = false;
                            }
                        }
                    }
                    else { isCmdValid = false; }
                }
            }
            else if (firstWordIsVariable) // radius = 6;
            {
                if (commandsAfterSpliting.Length == 3)
                {
                    if (commandsAfterSpliting[1].Equals("="))
                    {
                        if (!commandsAfterSpliting[2].Trim().All(char.IsDigit)) { isCmdValid = false; }
                        else { }
                    }
                    else { isCmdValid = false; }
                }
                else { isCmdValid = false; }
            }
            else { isCmdValid = false; }
            if (!isCmdValid) { isSomethingInvalid = true; }

        }

        /// <summary>
        /// Checks the command loop and if validation.
        /// </summary>
        public void CheckCmdLoopAndIfValidation()
        {
            int numberOfLines = textBoxCmd.Lines.Length;
            for (int i = 0; i < numberOfLines; i++)
            {
                String singleLineCmd = textBoxCmd.Lines[i];
                singleLineCmd = singleLineCmd.Trim();
                if (!singleLineCmd.Equals(""))
                {
                    doesCmdHasLoop = Regex.IsMatch(singleLineCmd.ToLower(), "loop");
                    if (doesCmdHasLoop)
                    {
                        loopLineNo = (i + 1);
                    }
                    doesCmdHasEndLoop = singleLineCmd.ToLower().Contains("endloop");
                    if (doesCmdHasEndLoop)
                    {
                        endLoopLineNo = (i + 1);
                    }
                    doesCmdHasIf = Regex.IsMatch(singleLineCmd.ToLower(), "if");
                    if (doesCmdHasIf)
                    {
                        ifLineNo = (i + 1);
                    }
                    doesCmdHasEndif = singleLineCmd.ToLower().Contains("endif");
                    if (doesCmdHasEndif)
                    {
                        endIfLineNo = (i + 1);
                    }
                }
            }
            if (doesCmdHasLoop)
            {
                if (doesCmdHasEndLoop)
                {
                    if (loopLineNo > endLoopLineNo)
                    {
                        isCmdValid = false;
                        MessageBox.Show("'ENDLOOP' must be after loop start: Loop starts at" + loopLineNo + " Loop ends at: " + endLoopLineNo);
                    }
                }
                else
                {
                    isCmdValid = false;
                    MessageBox.Show("Loop Not Ended with 'ENDLOOP'");
                }
            }
            if (doesCmdHasIf)
            {
                if (doesCmdHasEndif)
                {
                    if (endIfLineNo < ifLineNo)
                    {
                        isCmdValid = false;
                        MessageBox.Show("'ENDIF' must be after IF: If starts at" + ifLineNo + " and ends at: " + endIfLineNo);
                    }
                }
                else
                {
                    isCmdValid = false;
                    MessageBox.Show("IF Not Ended with 'ENDIF'");
                }
            }
        }

    }
}
