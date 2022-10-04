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
            this.prenesiIndeksButton = new System.Windows.Forms.Button();
            this.izvozCsvButton = new System.Windows.Forms.Button();
            this.displayIndeksGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.displayIndeksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // prenesiIndeksButton
            // 
            this.prenesiIndeksButton.Location = new System.Drawing.Point(12, 234);
            this.prenesiIndeksButton.Name = "prenesiIndeksButton";
            this.prenesiIndeksButton.Size = new System.Drawing.Size(203, 64);
            this.prenesiIndeksButton.TabIndex = 1;
            this.prenesiIndeksButton.Text = "Prenesi PEGAS indekse";
            this.prenesiIndeksButton.UseVisualStyleBackColor = true;
            this.prenesiIndeksButton.Click += new System.EventHandler(this.prenesiIndeksButton_Click);
            // 
            // izvozCsvButton
            // 
            this.izvozCsvButton.Location = new System.Drawing.Point(12, 322);
            this.izvozCsvButton.Name = "izvozCsvButton";
            this.izvozCsvButton.Size = new System.Drawing.Size(203, 64);
            this.izvozCsvButton.TabIndex = 2;
            this.izvozCsvButton.Text = "Izvozi v CSV";
            this.izvozCsvButton.UseVisualStyleBackColor = true;
            this.izvozCsvButton.Click += new System.EventHandler(this.izvozCsvButton_Click);
            // 
            // displayIndeksGridView
            // 
            this.displayIndeksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayIndeksGridView.Location = new System.Drawing.Point(235, 12);
            this.displayIndeksGridView.Name = "displayIndeksGridView";
            this.displayIndeksGridView.Size = new System.Drawing.Size(506, 617);
            this.displayIndeksGridView.TabIndex = 3;
            // 
            // mainDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 657);
            this.Controls.Add(this.displayIndeksGridView);
            this.Controls.Add(this.izvozCsvButton);
            this.Controls.Add(this.prenesiIndeksButton);
            this.Name = "mainDisplay";
            this.Text = "Gas hub Index - PEGAS platform";
            ((System.ComponentModel.ISupportInitialize)(this.displayIndeksGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button prenesiIndeksButton;
        private System.Windows.Forms.Button izvozCsvButton;
        private System.Windows.Forms.DataGridView displayIndeksGridView;
    }
}