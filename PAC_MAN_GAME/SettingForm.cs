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
    public partial class SettingForm : Form
    {
        private InitialForm initialForm;
        public SettingForm(InitialForm initialForm)
        {
            InitializeComponent();
            this.initialForm = initialForm;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            CenterToScreen();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) 
            {
                radioButton1.Text = "Українська";
                radioButton2.Text = "Англійська";
                Language_label1.Text = "Мова";
                Go_To_Menu_button1.Text = "Повернутися";
                initialForm.ChangeButtonText1("Вхід");
                initialForm.ChangeButtonText2("Реєстрація");
                initialForm.ChangeButtonText3("Налаштування");
                initialForm.ChangeButtonText4("Вихід");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Text = "Ukrainian";
                radioButton2.Text = "English";
                Language_label1.Text = "Language";
                Go_To_Menu_button1.Text = "Go back";
                initialForm.ChangeButtonText1("Login");
                initialForm.ChangeButtonText2("Registration");
                initialForm.ChangeButtonText3("Settings");
                initialForm.ChangeButtonText4("Exit");
            }
        }

        private void Go_To_Menu_button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            initialForm.Show();
        }
    }
}
