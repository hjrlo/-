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

namespace DrugDataBase
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                                          
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()    
            {                                                                                           
                DataSource = this.txb_Server.Text                                                                                       
                ,
                InitialCatalog = this.txb_Database.Text                                              
                ,
                IntegratedSecurity = this.ckb_IsWindowsAuthentication.Checked                         
            };
            sqlConnection.ConnectionString = sqlConnectionStringBuilder.ConnectionString;             
            sqlConnection.Open();                                                                      
            MessageBox.Show                                                                            
                ($"连接状态：{sqlConnection.State}" +                                                    
                 $"\n工作站标识：{sqlConnection.WorkstationId}" +
                 $"\n服务器地址：{sqlConnection.DataSource}" +
                 $"\n服务器版本：{sqlConnection.ServerVersion}" +
                 $"\n数据库名称：{sqlConnection.Database}" +
                 $"\n\n（单击【确定】后将关闭SQL连接）");
            sqlConnection.Close();
        }
    }
}
