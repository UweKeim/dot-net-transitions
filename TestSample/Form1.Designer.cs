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
            this.cmdBounceMe = new System.Windows.Forms.Button();
            this.cmdFlashMe = new System.Windows.Forms.Button();
            this.cmdRipple = new System.Windows.Forms.Button();
            this.ctrlRipple = new TestSample.RippleControl();
            this.cmdDropAndBounce = new System.Windows.Forms.Button();
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
            // cmdRipple
            // 
            this.cmdRipple.Location = new System.Drawing.Point(12, 70);
            this.cmdRipple.Name = "cmdRipple";
            this.cmdRipple.Size = new System.Drawing.Size(119, 45);
            this.cmdRipple.TabIndex = 9;
            this.cmdRipple.Text = "Ripple";
            this.cmdRipple.UseVisualStyleBackColor = true;
            this.cmdRipple.Click += new System.EventHandler(this.cmdRipple_Click);
            // 
            // ctrlRipple
            // 
            this.ctrlRipple.Location = new System.Drawing.Point(158, 70);
            this.ctrlRipple.Name = "ctrlRipple";
            this.ctrlRipple.Size = new System.Drawing.Size(122, 103);
            this.ctrlRipple.TabIndex = 8;
            // 
            // cmdDropAndBounce
            // 
            this.cmdDropAndBounce.Location = new System.Drawing.Point(163, 213);
            this.cmdDropAndBounce.Name = "cmdDropAndBounce";
            this.cmdDropAndBounce.Size = new System.Drawing.Size(105, 40);
            this.cmdDropAndBounce.TabIndex = 10;
            this.cmdDropAndBounce.Text = "Drop and bounce";
            this.cmdDropAndBounce.UseVisualStyleBackColor = true;
            this.cmdDropAndBounce.Click += new System.EventHandler(this.cmdDropAndBounce_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(292, 447);
            this.Controls.Add(this.cmdDropAndBounce);
            this.Controls.Add(this.cmdRipple);
            this.Controls.Add(this.ctrlRipple);
            this.Controls.Add(this.cmdFlashMe);
            this.Controls.Add(this.cmdBounceMe);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Opacity = 0;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdBounceMe;
        private System.Windows.Forms.Button cmdFlashMe;
        private RippleControl ctrlRipple;
        private System.Windows.Forms.Button cmdRipple;
        private System.Windows.Forms.Button cmdDropAndBounce;
    }
}

