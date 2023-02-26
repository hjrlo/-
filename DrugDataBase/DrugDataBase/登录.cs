using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugDataBase
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                             
            sqlConnection.ConnectionString =
                "Server=(local);Database=DrugBase;Integrated Security=sspi";            
            SqlCommand sqlCommand = new SqlCommand();                                   
            sqlCommand.Connection = sqlConnection;                                          
            sqlCommand.CommandText =                                                       
                $"SELECT COUNT(1) FROM tb_User" +
                $" WHERE Name='{this.txb_UserName.Text.Trim()}'" +								
                $" AND Password=HASHBYTES('MD5','{this.txb_Password.Text.Trim()}');";
            sqlConnection.Open();                                                           
            int rowCount = (int)sqlCommand.ExecuteScalar();                                
                                                                                           
            sqlConnection.Close();                                                         
            if (rowCount == 1)                                                              
            {
                MessageBox.Show("登录成功。");												
            }
            else                                                                            
            {
                MessageBox.Show("用户号/密码有误，请重新输入！");								
                this.txb_Password.Focus();                                                 
                this.txb_Password.SelectAll();                                             
            }
        }
    }
}
