namespace PreberiIndekse
{
    partial class mainDisplay
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
            this.displayIndexListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // displayIndexListBox
            // 
            this.displayIndexListBox.FormattingEnabled = true;
            this.displayIndexListBox.Location = new System.Drawing.Point(289, 147);
            this.displayIndexListBox.Name = "displayIndexListBox";
            this.displayIndexListBox.Size = new System.Drawing.Size(604, 446);
            this.displayIndexListBox.TabIndex = 0;
            // 
            // mainDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 641);
            this.Controls.Add(this.displayIndexListBox);
            this.Name = "mainDisplay";
            this.Text = "mainDisplay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox displayIndexListBox;
    }
}