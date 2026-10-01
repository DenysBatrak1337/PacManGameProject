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
    public partial class RegisterForm : Form
    {
        private InitialForm initialForm;

        DataBase database = new DataBase();
        public RegisterForm(InitialForm initialForm)
        {
            InitializeComponent();
            this.initialForm = initialForm;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            CenterToScreen();
        }

        private void Go_To_Menu_button1_Click(object sender, EventArgs e)
        {
            if (checkuser())
            {
                MessageBox.Show("Користувач з таким ім'ям вже існує!");
                return;
            }
            var login = Login_textBox1.Text;
            var password = Password_textBox1.Text;

            string quertystring = $"insert into register(login_user, password_user) values ('{login}', '{password}')";

            SqlCommand command = new SqlCommand(quertystring, database.getConnection());

            database.openConnection();

            if(command.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("Акаунт успішно створено!", "Успіх!");
                this.Hide();
                MainMenuForm mainMenuForm = new MainMenuForm();
                mainMenuForm.ShowDialog();

            }

            database.closeConnection();
        }

        private Boolean checkuser()
        {
            var loginUser = Login_textBox1.Text;
            var passwordUser = Password_textBox1.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string quertystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passwordUser}'";

            SqlCommand command = new SqlCommand(quertystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0 ) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Go_To_Initial_Form_button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            initialForm.Show();
        }

    }
}
