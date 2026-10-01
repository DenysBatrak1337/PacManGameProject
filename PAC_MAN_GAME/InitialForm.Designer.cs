namespace PAC_MAN_GAME
{
    partial class InitialForm
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
            this.Login_button1 = new System.Windows.Forms.Button();
            this.Register_button1 = new System.Windows.Forms.Button();
            this.Exit_button1 = new System.Windows.Forms.Button();
            this.Logo3_panel1 = new System.Windows.Forms.Panel();
            this.Logo2_panel1 = new System.Windows.Forms.Panel();
            this.Logo1_panel1 = new System.Windows.Forms.Panel();
            this.Setting_button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Logo1_panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login_button1
            // 
            this.Login_button1.BackColor = System.Drawing.Color.Yellow;
            this.Login_button1.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Bold);
            this.Login_button1.Location = new System.Drawing.Point(346, 210);
            this.Login_button1.Name = "Login_button1";
            this.Login_button1.Size = new System.Drawing.Size(140, 45);
            this.Login_button1.TabIndex = 1;
            this.Login_button1.Text = "Вхід";
            this.Login_button1.UseVisualStyleBackColor = false;
            this.Login_button1.Click += new System.EventHandler(this.Login_button1_Click);
            // 
            // Register_button1
            // 
            this.Register_button1.BackColor = System.Drawing.Color.Yellow;
            this.Register_button1.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Bold);
            this.Register_button1.Location = new System.Drawing.Point(346, 273);
            this.Register_button1.Name = "Register_button1";
            this.Register_button1.Size = new System.Drawing.Size(140, 45);
            this.Register_button1.TabIndex = 2;
            this.Register_button1.Text = "Реєстрація";
            this.Register_button1.UseVisualStyleBackColor = false;
            this.Register_button1.Click += new System.EventHandler(this.Register_button1_Click);
            // 
            // Exit_button1
            // 
            this.Exit_button1.BackColor = System.Drawing.Color.Red;
            this.Exit_button1.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Bold);
            this.Exit_button1.Location = new System.Drawing.Point(346, 390);
            this.Exit_button1.Name = "Exit_button1";
            this.Exit_button1.Size = new System.Drawing.Size(140, 45);
            this.Exit_button1.TabIndex = 3;
            this.Exit_button1.Text = "Вихід";
            this.Exit_button1.UseVisualStyleBackColor = false;
            this.Exit_button1.Click += new System.EventHandler(this.Exit_button1_Click);
            // 
            // Logo3_panel1
            // 
            this.Logo3_panel1.BackgroundImage = global::PAC_MAN_GAME.Properties.Resources.Pacman_Logo2;
            this.Logo3_panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Logo3_panel1.Location = new System.Drawing.Point(525, 206);
            this.Logo3_panel1.Name = "Logo3_panel1";
            this.Logo3_panel1.Size = new System.Drawing.Size(295, 229);
            this.Logo3_panel1.TabIndex = 5;
            // 
            // Logo2_panel1
            // 
            this.Logo2_panel1.BackgroundImage = global::PAC_MAN_GAME.Properties.Resources.Pacman_Logo1;
            this.Logo2_panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Logo2_panel1.Location = new System.Drawing.Point(12, 206);
            this.Logo2_panel1.Name = "Logo2_panel1";
            this.Logo2_panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Logo2_panel1.Size = new System.Drawing.Size(287, 229);
            this.Logo2_panel1.TabIndex = 4;
            // 
            // Logo1_panel1
            // 
            this.Logo1_panel1.BackColor = System.Drawing.Color.Black;
            this.Logo1_panel1.BackgroundImage = global::PAC_MAN_GAME.Properties.Resources.LOGO;
            this.Logo1_panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Logo1_panel1.Controls.Add(this.label1);
            this.Logo1_panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logo1_panel1.Location = new System.Drawing.Point(0, 0);
            this.Logo1_panel1.Name = "Logo1_panel1";
            this.Logo1_panel1.Size = new System.Drawing.Size(832, 200);
            this.Logo1_panel1.TabIndex = 0;
            // 
            // Setting_button1
            // 
            this.Setting_button1.BackColor = System.Drawing.Color.Yellow;
            this.Setting_button1.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Bold);
            this.Setting_button1.Location = new System.Drawing.Point(346, 334);
            this.Setting_button1.Name = "Setting_button1";
            this.Setting_button1.Size = new System.Drawing.Size(140, 45);
            this.Setting_button1.TabIndex = 6;
            this.Setting_button1.Text = "Налаштування";
            this.Setting_button1.UseVisualStyleBackColor = false;
            this.Setting_button1.Click += new System.EventHandler(this.Setting_button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(294, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 80);
            this.label1.TabIndex = 7;
            this.label1.Text = "Курсовий проєкт на тему\r\n\"Розробка алгоритму гри \"Pac-Man\"\"\r\nВиконав студент 351 " +
    "групи\r\nБатрак Денис Володимирович\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.Setting_button1);
            this.Controls.Add(this.Logo3_panel1);
            this.Controls.Add(this.Logo2_panel1);
            this.Controls.Add(this.Exit_button1);
            this.Controls.Add(this.Register_button1);
            this.Controls.Add(this.Login_button1);
            this.Controls.Add(this.Logo1_panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InitialForm";
            this.Text = "InitialForm";
            this.Load += new System.EventHandler(this.InitialForm_Load);
            this.Logo1_panel1.ResumeLayout(false);
            this.Logo1_panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Logo1_panel1;
        private System.Windows.Forms.Button Login_button1;
        private System.Windows.Forms.Button Register_button1;
        private System.Windows.Forms.Button Exit_button1;
        private System.Windows.Forms.Panel Logo2_panel1;
        private System.Windows.Forms.Panel Logo3_panel1;
        private System.Windows.Forms.Button Setting_button1;
        private System.Windows.Forms.Label label1;
    }
}