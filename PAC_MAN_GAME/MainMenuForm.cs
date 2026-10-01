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
    public partial class MainMenuForm : Form
    {
        private InitialForm initialForm;
        public MainMenuForm()
        {
            InitializeComponent();
            this.initialForm = initialForm;
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            CenterToScreen();
        }

        private void Go_To_Level_button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LevelForm levelForm = new LevelForm();
            levelForm.ShowDialog();
        }

        private void Go_To_Initial_Form_button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InitialForm initialForm = new InitialForm();
            initialForm.ShowDialog();
        }


    }
}
