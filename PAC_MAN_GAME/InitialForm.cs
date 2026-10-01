using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_MAN_GAME
{
    public partial class InitialForm : Form
    {
        private SettingForm settingForm;
        public static InitialForm instance { get; private set; }
        public InitialForm()
        {
            InitializeComponent();
            instance = this;
            this.settingForm = settingForm;
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            CenterToScreen();
        }

        private void Login_button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this);
            this.Hide();
            loginForm.ShowDialog();
        }

        private void Register_button1_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this);
            this.Hide();
            registerForm.ShowDialog();
        }

        private void Exit_button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Setting_button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingForm settingForm = new SettingForm(this);
            settingForm.Show();
        }

        public void ChangeButtonText1(string newText)
        {
            Login_button1.Text = newText;
        }
        public void ChangeButtonText2(string newText) 
        { 
            Register_button1.Text = newText;
        }
        public void ChangeButtonText3(string newText)
        {
            Setting_button1.Text = newText;
        }
        public void ChangeButtonText4(string newText)  
        {
            Exit_button1.Text = newText;
        }
    }
}
