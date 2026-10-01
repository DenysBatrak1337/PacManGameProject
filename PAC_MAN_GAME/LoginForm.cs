using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PAC_MAN_GAME
{
    public partial class LoginForm : Form
    {
        private InitialForm initialForm;

        DataBase database = new DataBase();

        public LoginForm(InitialForm initialForm)
        {
            InitializeComponent();
            this.initialForm = initialForm;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            CenterToScreen();
        }

        private void Go_To_Menu_button1_Click(object sender, EventArgs e)
        {
            var loginUser = Login_textBox1.Text;
            var passwordUser = Password_textBox1.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1 ) 
            {
                MessageBox.Show("Ви успішно увійшли!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information );
                this.Hide();
                MainMenuForm mainMenuForm = new MainMenuForm();
                mainMenuForm.ShowDialog();

            }
            else
                MessageBox.Show("Такого акаунту не існує!", "Акаунт не існує!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            

        }

        private void Back_To_Initial_Form_button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            initialForm.Show();
        }


    }
}
