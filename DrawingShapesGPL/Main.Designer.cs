namespace DrawingShapesGPL
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerCmdField = new System.Windows.Forms.SplitContainer();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_ClearAll = new System.Windows.Forms.Button();
            this.btn_ClearPanel = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.textBoxResultOutput = new System.Windows.Forms.TextBox();
            this.textBoxCmdInfo = new System.Windows.Forms.TextBox();
            this.textBoxCmd = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelDraw = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCmdField)).BeginInit();
            this.splitContainerCmdField.Panel1.SuspendLayout();
            this.splitContainerCmdField.Panel2.SuspendLayout();
            this.splitContainerCmdField.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerCmdField
            // 
            this.splitContainerCmdField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCmdField.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCmdField.Name = "splitContainerCmdField";
            // 
            // splitContainerCmdField.Panel1
            // 
            this.splitContainerCmdField.Panel1.Controls.Add(this.btn_Save);
            this.splitContainerCmdField.Panel1.Controls.Add(this.btn_ClearAll);
            this.splitContainerCmdField.Panel1.Controls.Add(this.btn_ClearPanel);
            this.splitContainerCmdField.Panel1.Controls.Add(this.btn_Run);
            this.splitContainerCmdField.Panel1.Controls.Add(this.textBoxResultOutput);
            this.splitContainerCmdField.Panel1.Controls.Add(this.textBoxCmdInfo);
            this.splitContainerCmdField.Panel1.Controls.Add(this.textBoxCmd);
            this.splitContainerCmdField.Panel1.Controls.Add(this.splitter1);
            // 
            // splitContainerCmdField.Panel2
            // 
            this.splitContainerCmdField.Panel2.Controls.Add(this.panelDraw);
            this.splitContainerCmdField.Size = new System.Drawing.Size(1045, 517);
            this.splitContainerCmdField.SplitterDistance = 380;
            this.splitContainerCmdField.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(295, 12);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(76, 35);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_ClearAll
            // 
            this.btn_ClearAll.Location = new System.Drawing.Point(203, 12);
            this.btn_ClearAll.Name = "btn_ClearAll";
            this.btn_ClearAll.Size = new System.Drawing.Size(76, 35);
            this.btn_ClearAll.TabIndex = 6;
            this.btn_ClearAll.Text = "Clear All";
            this.btn_ClearAll.UseVisualStyleBackColor = true;
            this.btn_ClearAll.Click += new System.EventHandler(this.btn_ClearAll_Click);
            // 
            // btn_ClearPanel
            // 
            this.btn_ClearPanel.Location = new System.Drawing.Point(104, 12);
            this.btn_ClearPanel.Name = "btn_ClearPanel";
            this.btn_ClearPanel.Size = new System.Drawing.Size(93, 35);
            this.btn_ClearPanel.TabIndex = 5;
            this.btn_ClearPanel.Text = "Clear Draw";
            this.btn_ClearPanel.UseVisualStyleBackColor = true;
            this.btn_ClearPanel.Click += new System.EventHandler(this.btn_ClearPanel_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(9, 12);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(76, 35);
            this.btn_Run.TabIndex = 4;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // textBoxResultOutput
            // 
            this.textBoxResultOutput.ForeColor = System.Drawing.Color.Red;
            this.textBoxResultOutput.Location = new System.Drawing.Point(9, 311);
            this.textBoxResultOutput.Multiline = true;
            this.textBoxResultOutput.Name = "textBoxResultOutput";
            this.textBoxResultOutput.ReadOnly = true;
            this.textBoxResultOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResultOutput.Size = new System.Drawing.Size(362, 194);
            this.textBoxResultOutput.TabIndex = 3;
            // 
            // textBoxCmdInfo
            // 
            this.textBoxCmdInfo.Location = new System.Drawing.Point(203, 53);
            this.textBoxCmdInfo.Multiline = true;
            this.textBoxCmdInfo.Name = "textBoxCmdInfo";
            this.textBoxCmdInfo.ReadOnly = true;
            this.textBoxCmdInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCmdInfo.Size = new System.Drawing.Size(168, 256);
            this.textBoxCmdInfo.TabIndex = 2;
            // 
            // textBoxCmd
            // 
            this.textBoxCmd.Location = new System.Drawing.Point(9, 53);
            this.textBoxCmd.Multiline = true;
            this.textBoxCmd.Name = "textBoxCmd";
            this.textBoxCmd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCmd.Size = new System.Drawing.Size(188, 256);
            this.textBoxCmd.TabIndex = 1;
            this.textBoxCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCmd_KeyDown);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 517);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // panelDraw
            // 
            this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDraw.Location = new System.Drawing.Point(0, 0);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(661, 517);
            this.panelDraw.TabIndex = 0;
            this.panelDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseDown);
            this.panelDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseMove);
            this.panelDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseUp);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 517);
            this.Controls.Add(this.splitContainerCmdField);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drawing Shapes";
            this.Load += new System.EventHandler(this.Main_Load);
            this.splitContainerCmdField.Panel1.ResumeLayout(false);
            this.splitContainerCmdField.Panel1.PerformLayout();
            this.splitContainerCmdField.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCmdField)).EndInit();
            this.splitContainerCmdField.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerCmdField;
        private System.Windows.Forms.Splitter splitter1;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Main.textBoxResultOutput'
        public System.Windows.Forms.TextBox textBoxResultOutput;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Main.textBoxResultOutput'
        private System.Windows.Forms.TextBox textBoxCmdInfo;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Main.textBoxCmd'
        public System.Windows.Forms.TextBox textBoxCmd;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Main.textBoxCmd'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Main.panelDraw'
        public System.Windows.Forms.Panel panelDraw;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Main.panelDraw'
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_ClearAll;
        private System.Windows.Forms.Button btn_ClearPanel;
        private System.Windows.Forms.Button btn_Run;
    }
}

