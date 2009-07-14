namespace TestSample
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmdCrossFadePictures = new System.Windows.Forms.Button();
            this.cmdBounceMe = new System.Windows.Forms.Button();
            this.cmdFlashMe = new System.Windows.Forms.Button();
            this.pictureControl1 = new TestSample.PictureControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Bounce the screen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdCrossFadePictures
            // 
            this.cmdCrossFadePictures.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdCrossFadePictures.Location = new System.Drawing.Point(15, 78);
            this.cmdCrossFadePictures.Name = "cmdCrossFadePictures";
            this.cmdCrossFadePictures.Size = new System.Drawing.Size(115, 48);
            this.cmdCrossFadePictures.TabIndex = 3;
            this.cmdCrossFadePictures.Text = "Cross-fade Pictures";
            this.cmdCrossFadePictures.UseVisualStyleBackColor = false;
            this.cmdCrossFadePictures.Click += new System.EventHandler(this.cmdCrossFadePictures_Click);
            // 
            // cmdBounceMe
            // 
            this.cmdBounceMe.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdBounceMe.Location = new System.Drawing.Point(16, 207);
            this.cmdBounceMe.Name = "cmdBounceMe";
            this.cmdBounceMe.Size = new System.Drawing.Size(115, 47);
            this.cmdBounceMe.TabIndex = 5;
            this.cmdBounceMe.Text = "Bounce Me!";
            this.cmdBounceMe.UseVisualStyleBackColor = false;
            this.cmdBounceMe.Click += new System.EventHandler(this.cmdBounceMe_Click);
            // 
            // cmdFlashMe
            // 
            this.cmdFlashMe.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdFlashMe.Location = new System.Drawing.Point(16, 143);
            this.cmdFlashMe.Name = "cmdFlashMe";
            this.cmdFlashMe.Size = new System.Drawing.Size(115, 47);
            this.cmdFlashMe.TabIndex = 6;
            this.cmdFlashMe.Text = "Flash Me!";
            this.cmdFlashMe.UseVisualStyleBackColor = false;
            this.cmdFlashMe.Click += new System.EventHandler(this.cmdFlashMe_Click);
            // 
            // pictureControl1
            // 
            this.pictureControl1.Image = global::TestSample.Properties.Resources.kitten;
            this.pictureControl1.Location = new System.Drawing.Point(150, 12);
            this.pictureControl1.Name = "pictureControl1";
            this.pictureControl1.Size = new System.Drawing.Size(125, 108);
            this.pictureControl1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(292, 447);
            this.Controls.Add(this.pictureControl1);
            this.Controls.Add(this.cmdFlashMe);
            this.Controls.Add(this.cmdBounceMe);
            this.Controls.Add(this.cmdCrossFadePictures);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Opacity = 0;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdCrossFadePictures;
        private System.Windows.Forms.Button cmdBounceMe;
        private System.Windows.Forms.Button cmdFlashMe;
        private PictureControl pictureControl1;
    }
}

