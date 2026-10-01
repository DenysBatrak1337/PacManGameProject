namespace PAC_MAN_GAME
{
    partial class RegisterForm
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
            this.Logo1_panel1 = new System.Windows.Forms.Panel();
            this.Login_textBox1 = new System.Windows.Forms.TextBox();
            this.Password_textBox1 = new System.Windows.Forms.TextBox();
            this.Login_pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Password_pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Go_To_Menu_button1 = new System.Windows.Forms.Button();
            this.Go_To_Initial_Form_button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Login_pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo1_panel1
            // 
            this.Logo1_panel1.BackColor = System.Drawing.Color.Black;
            this.Logo1_panel1.BackgroundImage = global::PAC_MAN_GAME.Properties.Resources.LOGO;
            this.Logo1_panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Logo1_panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logo1_panel1.Location = new System.Drawing.Point(0, 0);
            this.Logo1_panel1.Name = "Logo1_panel1";
            this.Logo1_panel1.Size = new System.Drawing.Size(832, 200);
            this.Logo1_panel1.TabIndex = 0;
            // 
            // Login_textBox1
            // 
            this.Login_textBox1.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Bold);
            this.Login_textBox1.Location = new System.Drawing.Point(350, 235);
            this.Login_textBox1.Name = "Login_textBox1";
            this.Login_textBox1.Size = new System.Drawing.Size(125, 29);
            this.Login_textBox1.TabIndex = 1;
            // 
            // Password_textBox1
            // 
            this.Password_textBox1.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Bold);
            this.Password_textBox1.Location = new System.Drawing.Point(350, 285);
            this.Password_textBox1.Name = "Password_textBox1";
            this.Password_textBox1.Size = new System.Drawing.Size(125, 29);
            this.Password_textBox1.TabIndex = 2;
            // 
            // Login_pictureBox1
            // 
            this.Login_pictureBox1.Image = global::PAC_MAN_GAME.Properties.Resources.loggin;
            this.Login_pictureBox1.Location = new System.Drawing.Point(315, 235);
            this.Login_pictureBox1.Name = "Login_pictureBox1";
            this.Login_pictureBox1.Size = new System.Drawing.Size(29, 29);
            this.Login_pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Login_pictureBox1.TabIndex = 3;
            this.Login_pictureBox1.TabStop = false;
            // 
            // Password_pictureBox1
            // 
            this.Password_pictureBox1.Image = global::PAC_MAN_GAME.Properties.Resources.pasword;
            this.Password_pictureBox1.Location = new System.Drawing.Point(315, 285);
            this.Password_pictureBox1.Name = "Password_pictureBox1";
            this.Password_pictureBox1.Size = new System.Drawing.Size(29, 29);
            this.Password_pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Password_pictureBox1.TabIndex = 4;
            this.Password_pictureBox1.TabStop = false;
            // 
            // Go_To_Menu_button1
            // 
            this.Go_To_Menu_button1.BackColor = System.Drawing.Color.Yellow;
            this.Go_To_Menu_button1.Font = new System.Drawing.Font("Webdings", 15F, System.Drawing.FontStyle.Bold);
            this.Go_To_Menu_button1.Location = new System.Drawing.Point(350, 335);
            this.Go_To_Menu_button1.Name = "Go_To_Menu_button1";
            this.Go_To_Menu_button1.Size = new System.Drawing.Size(125, 45);
            this.Go_To_Menu_button1.TabIndex = 5;
            this.Go_To_Menu_button1.Text = "8";
            this.Go_To_Menu_button1.UseVisualStyleBackColor = false;
            this.Go_To_Menu_button1.Click += new System.EventHandler(this.Go_To_Menu_button1_Click);
            // 
            // Go_To_Initial_Form_button1
            // 
            this.Go_To_Initial_Form_button1.BackColor = System.Drawing.Color.Red;
            this.Go_To_Initial_Form_button1.Font = new System.Drawing.Font("Webdings", 15F, System.Drawing.FontStyle.Bold);
            this.Go_To_Initial_Form_button1.Location = new System.Drawing.Point(350, 400);
            this.Go_To_Initial_Form_button1.Name = "Go_To_Initial_Form_button1";
            this.Go_To_Initial_Form_button1.Size = new System.Drawing.Size(125, 45);
            this.Go_To_Initial_Form_button1.TabIndex = 6;
            this.Go_To_Initial_Form_button1.Text = "r";
            this.Go_To_Initial_Form_button1.UseVisualStyleBackColor = false;
            this.Go_To_Initial_Form_button1.Click += new System.EventHandler(this.Go_To_Initial_Form_button1_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.Go_To_Initial_Form_button1);
            this.Controls.Add(this.Go_To_Menu_button1);
            this.Controls.Add(this.Password_pictureBox1);
            this.Controls.Add(this.Login_pictureBox1);
            this.Controls.Add(this.Password_textBox1);
            this.Controls.Add(this.Login_textBox1);
            this.Controls.Add(this.Logo1_panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Login_pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Logo1_panel1;
        private System.Windows.Forms.TextBox Login_textBox1;
        private System.Windows.Forms.TextBox Password_textBox1;
        private System.Windows.Forms.PictureBox Login_pictureBox1;
        private System.Windows.Forms.PictureBox Password_pictureBox1;
        private System.Windows.Forms.Button Go_To_Menu_button1;
        private System.Windows.Forms.Button Go_To_Initial_Form_button1;
    }
}