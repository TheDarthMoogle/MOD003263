namespace SoftEngProject
{
    partial class Preview
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
            this.tbxPreview = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxPreview
            // 
            this.tbxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxPreview.Location = new System.Drawing.Point(0, 0);
            this.tbxPreview.Multiline = true;
            this.tbxPreview.Name = "tbxPreview";
            this.tbxPreview.Size = new System.Drawing.Size(576, 456);
            this.tbxPreview.TabIndex = 0;
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 456);
            this.Controls.Add(this.tbxPreview);
            this.Name = "Preview";
            this.Text = "Preview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPreview;
    }
}