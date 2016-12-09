namespace SoftEngProject
{
    partial class SaveResponse
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
            this.templateSelectComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.templateSaveButton = new System.Windows.Forms.Button();
            this.responseNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // templateSelectComboBox
            // 
            this.templateSelectComboBox.FormattingEnabled = true;
            this.templateSelectComboBox.Location = new System.Drawing.Point(55, 62);
            this.templateSelectComboBox.Name = "templateSelectComboBox";
            this.templateSelectComboBox.Size = new System.Drawing.Size(137, 21);
            this.templateSelectComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Template To Append";
            // 
            // templateSaveButton
            // 
            this.templateSaveButton.Location = new System.Drawing.Point(124, 179);
            this.templateSaveButton.Name = "templateSaveButton";
            this.templateSaveButton.Size = new System.Drawing.Size(68, 23);
            this.templateSaveButton.TabIndex = 2;
            this.templateSaveButton.Text = "Save";
            this.templateSaveButton.UseVisualStyleBackColor = true;
            this.templateSaveButton.Click += new System.EventHandler(this.templateSaveButton_Click);
            // 
            // responseNameTextBox
            // 
            this.responseNameTextBox.Location = new System.Drawing.Point(55, 142);
            this.responseNameTextBox.Name = "responseNameTextBox";
            this.responseNameTextBox.Size = new System.Drawing.Size(137, 20);
            this.responseNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Response Group Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 220);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // SaveResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 392);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.responseNameTextBox);
            this.Controls.Add(this.templateSaveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.templateSelectComboBox);
            this.Name = "SaveResponse";
            this.Text = "SaveResponse";
            this.Load += new System.EventHandler(this.SaveResponse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox templateSelectComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button templateSaveButton;
        private System.Windows.Forms.TextBox responseNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}