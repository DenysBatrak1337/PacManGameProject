namespace PAC_MAN_GAME
{
    partial class SettingForm
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
            this.Language_label1 = new System.Windows.Forms.Label();
            this.Go_To_Menu_button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
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
            // Language_label1
            // 
            this.Language_label1.AutoSize = true;
            this.Language_label1.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold);
            this.Language_label1.ForeColor = System.Drawing.Color.Black;
            this.Language_label1.Location = new System.Drawing.Point(375, 230);
            this.Language_label1.Name = "Language_label1";
            this.Language_label1.Size = new System.Drawing.Size(63, 26);
            this.Language_label1.TabIndex = 1;
            this.Language_label1.Text = "Мова";
            // 
            // Go_To_Menu_button1
            // 
            this.Go_To_Menu_button1.BackColor = System.Drawing.Color.Red;
            this.Go_To_Menu_button1.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Bold);
            this.Go_To_Menu_button1.Location = new System.Drawing.Point(345, 390);
            this.Go_To_Menu_button1.Name = "Go_To_Menu_button1";
            this.Go_To_Menu_button1.Size = new System.Drawing.Size(125, 45);
            this.Go_To_Menu_button1.TabIndex = 2;
            this.Go_To_Menu_button1.Text = "Повернутися";
            this.Go_To_Menu_button1.UseVisualStyleBackColor = false;
            this.Go_To_Menu_button1.Click += new System.EventHandler(this.Go_To_Menu_button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Yellow;
            this.radioButton1.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Bold);
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(346, 287);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(111, 22);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Українська";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Yellow;
            this.radioButton2.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Bold);
            this.radioButton2.Location = new System.Drawing.Point(345, 332);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(109, 22);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Англійська";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Go_To_Menu_button1);
            this.Controls.Add(this.Language_label1);
            this.Controls.Add(this.Logo1_panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Logo1_panel1;
        private System.Windows.Forms.Label Language_label1;
        private System.Windows.Forms.Button Go_To_Menu_button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}