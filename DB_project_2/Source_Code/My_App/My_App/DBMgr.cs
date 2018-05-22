using MySql.Data.MySqlClient;
using System.Data;

namespace My_App
{
    public class DBMgr
    {
        MySqlConnection myConn;

        public void Connect_DB()
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=root123;Database=security";
            myConn = new MySqlConnection(myConnection);
            myConn.Open();
        }

        public void Disconnect_DB()
        {
            myConn.Close();
        }

        public DataTable Get_DB_Data(string tablename)
        {
            try
            {
                Connect_DB();
                MySqlCommand cmd = myConn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM " + tablename + ";";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(cmd);
                myDataAdapter.Fill(dt);
                Disconnect_DB();
                return dt;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Execute_Query(string query)
        {
            Connect_DB();
            MySqlTransaction sqlTran = myConn.BeginTransaction();
            try
            {
                MySqlCommand cmd = myConn.CreateCommand();
                cmd.Transaction = sqlTran;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                sqlTran.Commit();
                Disconnect_DB();  
            }
            catch (System.Exception)
            {
                sqlTran.Rollback();
                Disconnect_DB();
                throw;
            }
            
        }

        public DataTable Get_UserRole_Privilege_Data(string rolename)
        {
            try
            {
                Connect_DB();
                MySqlCommand cmd = myConn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select A.P_Name As 'Privilege Name', P_Type As 'Privilege Type' from privileges P, account_permissions A where P.P_Name = A.P_Name" +
                                " and A.Role_Name = '" + rolename + "'" + " UNION" +
                                " select T.P_Name As 'Privilege Name', P_Type As 'Privilege Type' from privileges P, table_permissions T where P.P_Name = T.P_Name" +
                                " and T.Role_Name = '" + rolename + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(cmd);
                myDataAdapter.Fill(dt);
                Disconnect_DB();
                return dt;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public DataTable Get_UserAccount_Privilege_Data(int UserId)
        {
            try
            {
                Connect_DB();
                MySqlCommand cmd = myConn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select A.P_Name As 'Privilege Name', P_Type As 'Privilege Type' from privileges P, account_permissions A where P.P_Name = A.P_Name" +
                                " and A.Role_Name = (select  Role_Name from user_accounts where Idno = " + UserId + ") UNION" +
                                " select T.P_Name As 'Privilege Name', P_Type As 'Privilege Type' from privileges P, table_permissions T where P.P_Name = T.P_Name" +
                                " and T.Role_Name = (select  Role_Name from user_accounts where Idno = " + UserId + ")";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(cmd);
                myDataAdapter.Fill(dt);
                Disconnect_DB();
                return dt;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool Check_UserAccount_Privilege_Data(string UserId, string PrivilegeName)
        {
            try
            {
                Connect_DB();
                MySqlCommand cmd = myConn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select A.P_Name As 'Privilege Name', P_Type As 'Privilege Type' from privileges P, account_permissions A where P.P_Name = A.P_Name" +
                                " and A.Role_Name = (select  Role_Name from user_accounts where Idno = '" + UserId + "') and A.P_Name = '" + PrivilegeName + "' UNION" +
                                " select T.P_Name As 'Privilege Name', P_Type As 'Privilege Type' from privileges P, table_permissions T where P.P_Name = T.P_Name" +
                                " and T.Role_Name = (select  Role_Name from user_accounts where Idno = '" + UserId + "') and T.P_Name = '" + PrivilegeName + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(cmd);
                myDataAdapter.Fill(dt);
                Disconnect_DB();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
