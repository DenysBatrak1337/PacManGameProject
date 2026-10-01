namespace PAC_MAN_GAME
{
    partial class MainMenuForm
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
            this.Go_To_Level_button1 = new System.Windows.Forms.Button();
            this.Go_To_Initial_Form_button1 = new System.Windows.Forms.Button();
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
            // Go_To_Level_button1
            // 
            this.Go_To_Level_button1.BackColor = System.Drawing.Color.Yellow;
            this.Go_To_Level_button1.Font = new System.Drawing.Font("Wingdings", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Go_To_Level_button1.Location = new System.Drawing.Point(364, 267);
            this.Go_To_Level_button1.Name = "Go_To_Level_button1";
            this.Go_To_Level_button1.Size = new System.Drawing.Size(94, 45);
            this.Go_To_Level_button1.TabIndex = 1;
            this.Go_To_Level_button1.Text = ":";
            this.Go_To_Level_button1.UseVisualStyleBackColor = false;
            this.Go_To_Level_button1.Click += new System.EventHandler(this.Go_To_Level_button1_Click);
            // 
            // Go_To_Initial_Form_button1
            // 
            this.Go_To_Initial_Form_button1.BackColor = System.Drawing.Color.Red;
            this.Go_To_Initial_Form_button1.Font = new System.Drawing.Font("Webdings", 15F, System.Drawing.FontStyle.Bold);
            this.Go_To_Initial_Form_button1.Location = new System.Drawing.Point(364, 354);
            this.Go_To_Initial_Form_button1.Name = "Go_To_Initial_Form_button1";
            this.Go_To_Initial_Form_button1.Size = new System.Drawing.Size(94, 45);
            this.Go_To_Initial_Form_button1.TabIndex = 3;
            this.Go_To_Initial_Form_button1.Text = "r";
            this.Go_To_Initial_Form_button1.UseVisualStyleBackColor = false;
            this.Go_To_Initial_Form_button1.Click += new System.EventHandler(this.Go_To_Initial_Form_button1_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.Go_To_Initial_Form_button1);
            this.Controls.Add(this.Go_To_Level_button1);
            this.Controls.Add(this.Logo1_panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Logo1_panel1;
        private System.Windows.Forms.Button Go_To_Level_button1;
        private System.Windows.Forms.Button Go_To_Initial_Form_button1;
    }
}