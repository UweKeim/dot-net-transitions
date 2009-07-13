namespace TestSample
{
    partial class PictureControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPicture
            // 
            this.ctrlPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPicture.Location = new System.Drawing.Point(0, 0);
            this.ctrlPicture.Name = "ctrlPicture";
            this.ctrlPicture.Size = new System.Drawing.Size(150, 150);
            this.ctrlPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ctrlPicture.TabIndex = 0;
            this.ctrlPicture.TabStop = false;
            // 
            // PictureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPicture);
            this.Name = "PictureControl";
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ctrlPicture;
    }
}
