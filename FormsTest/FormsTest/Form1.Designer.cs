namespace FormsTest
{
    partial class Form1
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
            this.groupBoxResponse = new System.Windows.Forms.GroupBox();
            this.responsesComboBox = new System.Windows.Forms.ComboBox();
            this.templateCodeComboBox = new System.Windows.Forms.ComboBox();
            this.rbtn3 = new System.Windows.Forms.RadioButton();
            this.rbtn2 = new System.Windows.Forms.RadioButton();
            this.rbtn1 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxResponse.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxResponse
            // 
            this.groupBoxResponse.Controls.Add(this.responsesComboBox);
            this.groupBoxResponse.Controls.Add(this.templateCodeComboBox);
            this.groupBoxResponse.Controls.Add(this.rbtn3);
            this.groupBoxResponse.Controls.Add(this.rbtn2);
            this.groupBoxResponse.Controls.Add(this.rbtn1);
            this.groupBoxResponse.Location = new System.Drawing.Point(13, 64);
            this.groupBoxResponse.Name = "groupBoxResponse";
            this.groupBoxResponse.Size = new System.Drawing.Size(199, 222);
            this.groupBoxResponse.TabIndex = 0;
            this.groupBoxResponse.TabStop = false;
            this.groupBoxResponse.Text = "Test Template Section";
            // 
            // responsesComboBox
            // 
            this.responsesComboBox.FormattingEnabled = true;
            this.responsesComboBox.Location = new System.Drawing.Point(7, 47);
            this.responsesComboBox.Name = "responsesComboBox";
            this.responsesComboBox.Size = new System.Drawing.Size(121, 21);
            this.responsesComboBox.TabIndex = 4;
            this.responsesComboBox.SelectedIndexChanged += new System.EventHandler(this.responsesComboBox_SelectedIndexChanged);
            // 
            // templateCodeComboBox
            // 
            this.templateCodeComboBox.FormattingEnabled = true;
            this.templateCodeComboBox.Location = new System.Drawing.Point(7, 20);
            this.templateCodeComboBox.Name = "templateCodeComboBox";
            this.templateCodeComboBox.Size = new System.Drawing.Size(121, 21);
            this.templateCodeComboBox.TabIndex = 3;
            this.templateCodeComboBox.SelectedIndexChanged += new System.EventHandler(this.templateCodeComboBox_SelectedIndexChanged);
            // 
            // rbtn3
            // 
            this.rbtn3.AutoSize = true;
            this.rbtn3.Location = new System.Drawing.Point(7, 144);
            this.rbtn3.Name = "rbtn3";
            this.rbtn3.Size = new System.Drawing.Size(60, 17);
            this.rbtn3.TabIndex = 2;
            this.rbtn3.TabStop = true;
            this.rbtn3.Text = "unused";
            this.rbtn3.UseVisualStyleBackColor = true;
            // 
            // rbtn2
            // 
            this.rbtn2.AutoSize = true;
            this.rbtn2.Location = new System.Drawing.Point(7, 121);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(60, 17);
            this.rbtn2.TabIndex = 1;
            this.rbtn2.TabStop = true;
            this.rbtn2.Text = "unused";
            this.rbtn2.UseVisualStyleBackColor = true;
            // 
            // rbtn1
            // 
            this.rbtn1.AutoSize = true;
            this.rbtn1.Location = new System.Drawing.Point(6, 98);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(60, 17);
            this.rbtn1.TabIndex = 0;
            this.rbtn1.TabStop = true;
            this.rbtn1.Text = "unused";
            this.rbtn1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 292);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(200, 78);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(295, 84);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(777, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Debug";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBoxResponse);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxResponse.ResumeLayout(false);
            this.groupBoxResponse.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxResponse;
        private System.Windows.Forms.RadioButton rbtn3;
        private System.Windows.Forms.RadioButton rbtn2;
        private System.Windows.Forms.RadioButton rbtn1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox templateCodeComboBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox responsesComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
    }
}

