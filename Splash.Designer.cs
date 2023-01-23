namespace DairyFarmSystem
{
    partial class Splash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Myprogress = new Bunifu.UI.Winforms.BunifuProgressBar();
            this.bunifuProgressBar2 = new Bunifu.UI.Winforms.BunifuProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(250, 142);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(152, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dairy Farm Software";
            // 
            // Myprogress
            // 
            this.Myprogress.Animation = 0;
            this.Myprogress.AnimationStep = 10;
            this.Myprogress.BackColor = System.Drawing.Color.SlateGray;
            this.Myprogress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Myprogress.BackgroundImage")));
            this.Myprogress.BorderColor = System.Drawing.Color.White;
            this.Myprogress.BorderRadius = 5;
            this.Myprogress.BorderThickness = 2;
            this.Myprogress.Location = new System.Drawing.Point(3, 370);
            this.Myprogress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Myprogress.MaximumValue = 100;
            this.Myprogress.MinimumValue = 0;
            this.Myprogress.Name = "Myprogress";
            this.Myprogress.ProgressBackColor = System.Drawing.Color.Teal;
            this.Myprogress.ProgressColorLeft = System.Drawing.Color.White;
            this.Myprogress.ProgressColorRight = System.Drawing.Color.White;
            this.Myprogress.Size = new System.Drawing.Size(699, 19);
            this.Myprogress.TabIndex = 2;
            this.Myprogress.Value = 0;
            // 
            // bunifuProgressBar2
            // 
            this.bunifuProgressBar2.Animation = 0;
            this.bunifuProgressBar2.AnimationStep = 10;
            this.bunifuProgressBar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuProgressBar2.BackgroundImage")));
            this.bunifuProgressBar2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(53)))), ((int)(((byte)(85)))));
            this.bunifuProgressBar2.BorderRadius = 5;
            this.bunifuProgressBar2.BorderThickness = 2;
            this.bunifuProgressBar2.Location = new System.Drawing.Point(648, 389);
            this.bunifuProgressBar2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuProgressBar2.MaximumValue = 100;
            this.bunifuProgressBar2.MinimumValue = 0;
            this.bunifuProgressBar2.Name = "bunifuProgressBar2";
            this.bunifuProgressBar2.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(53)))), ((int)(((byte)(85)))));
            this.bunifuProgressBar2.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.bunifuProgressBar2.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.bunifuProgressBar2.Size = new System.Drawing.Size(379, 12);
            this.bunifuProgressBar2.TabIndex = 3;
            this.bunifuProgressBar2.Value = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(707, 391);
            this.Controls.Add(this.bunifuProgressBar2);
            this.Controls.Add(this.Myprogress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.Winforms.BunifuProgressBar Myprogress;
        private Bunifu.UI.Winforms.BunifuProgressBar bunifuProgressBar2;
        private System.Windows.Forms.Timer timer1;
    }
}