namespace EcgChart
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.心电采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designByISEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("华光综艺_CNKI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(12, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "开始采集";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.UseWaitCursor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // message
            // 
            this.message.AllowDrop = true;
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.message.BackColor = System.Drawing.SystemColors.Menu;
            this.message.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.message.Enabled = false;
            this.message.Font = new System.Drawing.Font("华光综艺_CNKI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.message.ForeColor = System.Drawing.SystemColors.WindowText;
            this.message.FormattingEnabled = true;
            this.message.ImeMode = System.Windows.Forms.ImeMode.On;
            this.message.ItemHeight = 17;
            this.message.Location = new System.Drawing.Point(111, 39);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(632, 38);
            this.message.TabIndex = 4;
            this.message.UseWaitCursor = true;
            this.message.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.UseWaitCursor = true;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(749, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 38);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.UseWaitCursor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.心电采集ToolStripMenuItem,
            this.designByISEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(789, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 心电采集ToolStripMenuItem
            // 
            this.心电采集ToolStripMenuItem.Name = "心电采集ToolStripMenuItem";
            this.心电采集ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.心电采集ToolStripMenuItem.Text = "心电采集";
            this.心电采集ToolStripMenuItem.Click += new System.EventHandler(this.心电采集ToolStripMenuItem_Click);
            // 
            // designByISEToolStripMenuItem
            // 
            this.designByISEToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.designByISEToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.designByISEToolStripMenuItem.Name = "designByISEToolStripMenuItem";
            this.designByISEToolStripMenuItem.Size = new System.Drawing.Size(100, 21);
            this.designByISEToolStripMenuItem.Text = "Design by ISE";
            this.designByISEToolStripMenuItem.Click += new System.EventHandler(this.designByDSYToolStripMenuItem_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.Gainsboro;
            this.zedGraphControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("zedGraphControl1.BackgroundImage")));
            this.zedGraphControl1.Font = new System.Drawing.Font("华光综艺_CNKI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 93);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(756, 353);
            this.zedGraphControl1.TabIndex = 9;
            this.zedGraphControl1.UseWaitCursor = true;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(789, 437);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.message);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ECG实时采集系统";
            this.UseWaitCursor = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox message;
        private System.Windows.Forms.ToolStripMenuItem 心电采集ToolStripMenuItem;
        protected internal System.Windows.Forms.ToolStripMenuItem designByISEToolStripMenuItem;

        
       
    }
}

