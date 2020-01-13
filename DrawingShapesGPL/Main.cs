using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace DrawingShapesGPL
{
    /// <summary>Main Class:</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Main : Form
    {
        #region
        public int x = -1;
        public int y = -1;
        public Boolean moving = false;
        public Graphics g;
        public Pen p;
        #endregion
        /// <summary>Initializes a new instance of the <see cref="Main"/> class.</summary>
        public Main()
        {
            InitializeComponent();
            g = panelDraw.CreateGraphics();
            p = new Pen(Color.Black, 4);
            g.SmoothingMode = SmoothingMode.AntiAlias;

        }

        /// <summary>Handles the Load event of the Main Form.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Main_Load(object sender, EventArgs e)
        {
            panelDraw.Cursor = new Cursor(Properties.Resources.pencil1.GetHicon());
        }

        /// <summary>Handles the Click event of the btn_Run control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btn_Run_Click(object sender, EventArgs e)
        {
           if (textBoxCmd.Text != null && !textBoxCmd.Equals(""))
            {
                CmdValidation cmdValidateObj = new CmdValidation(textBoxCmd);
                if (!cmdValidateObj.IsSomethingInvalid)
                {
                    try
                    {
                        CmdUtilities cmdUtilitiesObj = new CmdUtilities();
                        cmdUtilitiesObj.loadCommand(textBoxCmd, panelDraw);
                    }
                    catch (Exception exc)
                    {
                        textBoxResultOutput.Text += "\r\n" + exc.ToString();
                    }
                }
                else if(!cmdValidateObj.IsSyntaxValid)
                {
                    textBoxResultOutput.Text += "\r\nCommand Syntax Error.";
                }
                else if (!cmdValidateObj.IsParameterValid)
                {
                    textBoxResultOutput.Text += "\r\nParamter Error.";
                }
                else
                {
                    textBoxResultOutput.Text += "\r\nSomething went wrong, try again.";

                }

            }
            else
            {
                textBoxResultOutput.Text += "Command field must not be empty.";
            }
        }

        /// <summary>Handles the MouseUp event of the panelDraw control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            x = -1;
            y = -1;
            moving = false;
        }

        /// <summary>Handles the MouseDown event of the panelDraw control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            moving = true;
        }

        /// <summary>Handles the MouseMove event of the panelDraw control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(p, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        /// <summary>Handles the Click event of the btn_ClearAll control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            textBoxCmd.Text = "";
            textBoxResultOutput.Text = "";
            panelDraw.Refresh();
        }

        /// <summary>Handles the Click event of the btn_ClearPanel control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btn_ClearPanel_Click(object sender, EventArgs e)
        {
            panelDraw.Refresh();
        }

        /// <summary>Handles the KeyDown event of the textBoxCmd control. When "ENTER" key is pressed, it validates run command and execute btnRun Click event.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void textBoxCmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                string[] cmds = textBoxCmd.Text.Split(new[] { System.Environment.NewLine }, StringSplitOptions.None);
                Array.Sort(cmds);
                for (int i = 0; i < cmds.Length; i++)
                {
                    cmds[i].ToLower().Trim();   
                }                
                Boolean runExists = cmds.Contains("run");
                if (runExists)
                {
                    btn_Run.PerformClick();
                }

            }
        }
    }
}
