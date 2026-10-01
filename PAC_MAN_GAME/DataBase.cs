using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PAC_MAN_GAME
{
    internal class DataBase
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=PAC_MAN_GAME_INFO;Integrated Security=True");
        
        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed) 
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
       
        
    }
}
