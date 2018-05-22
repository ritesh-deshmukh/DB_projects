using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace My_App
{
    public partial class Form1 : Form
    {
        DBMgr objDB = new DBMgr();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fill_Grid();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Grid();
        }

        private void Fill_Grid()
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPage1":
                    dgvPrivileges.AutoGenerateColumns = false;
                    dgvPrivileges.DataSource = objDB.Get_DB_Data("privileges");
                    break;
                case "tabPage2":
                    dgvUserRoles.AutoGenerateColumns = false;
                    dgvUserRoles.DataSource =  objDB.Get_DB_Data("user_roles");
                    break;
                case "tabPage3":
                    dgvUserAccunts.AutoGenerateColumns = false;
                    dgvUserAccunts.DataSource =    objDB.Get_DB_Data("user_accounts");
                    Fill_UserRole_Combo();
                    break;
                case "tabPage4":
                    dgvTables.AutoGenerateColumns = false;
                    dgvTables.DataSource = objDB.Get_DB_Data("tables");
                    Fill_TableOwner_Combo();
                    break;
                case "tabPage5":
                    dgvTablePermissions.AutoGenerateColumns = false;
                    dgvTablePermissions.DataSource = objDB.Get_DB_Data("table_permissions");
                    Fill_Privileges_Combo();
                    Fill_UserRole_Combo();
                    Fill_TableName_Combo();
                    break;
                case "tabPage6":
                    dgvAccountPermissions.AutoGenerateColumns = false;
                    dgvAccountPermissions.DataSource = objDB.Get_DB_Data("account_permissions");
                    Fill_UserRole_Combo();
                    Fill_Privileges_Combo();
                    break;
                case "tabPage7":
                    cboUserPrivilege.SelectedIndexChanged -= cboUserPrivilege_SelectedIndexChanged;
                    cboAccountPrivilege.SelectedIndexChanged -= cboAccountPrivilege_SelectedIndexChanged;
                    dgvAccountPrivilege.AutoGenerateColumns = false;
                    dgvUserPrivilege.AutoGenerateColumns = false;
                    Fill_UserRole_Combo();
                    Fill_TableOwner_Combo();
                    dgvUserPrivilege.DataSource = objDB.Get_UserRole_Privilege_Data(cboUserPrivilege.Text);
                    dgvAccountPrivilege.DataSource = objDB.Get_UserAccount_Privilege_Data((int)cboAccountPrivilege.SelectedValue);
                    cboUserPrivilege.SelectedIndexChanged += cboUserPrivilege_SelectedIndexChanged;
                    cboAccountPrivilege.SelectedIndexChanged += cboAccountPrivilege_SelectedIndexChanged;
                    break;
                case "tabPage8":
                    Fill_Privileges_Combo();
                    Fill_TableOwner_Combo();
                    break;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string query = "";
            try
            {
                switch (tabControl1.SelectedTab.Name)
                {
                    case "tabPage1":
                        query = "insert into security.privileges values('" 
                            + textBox1.Text + "','" + cboPType.Text + "')";
                        break;
                    case "tabPage2":
                        query = "insert into security.user_roles values('" 
                            + textBox8.Text + "','" + textBox7.Text + "')";
                        break;
                    case "tabPage3":
                        query = "insert into security.user_accounts(name,phone,role_name) values('" 
                            + textBox10.Text + "','" + textBox11.Text + "','" + cboUserRole.Text + "')";
                        break;
                    case "tabPage4":
                        query = "insert into security.tables values('" 
                            + textBox18.Text + "','" + cboTableOwner.SelectedValue + "')";
                        break;
                    case "tabPage5":
                        query = "insert into security.table_permissions values('" 
                            + cboRelationPName.Text + "','" + cboTabUserRole.Text + "','" + cboTableName.Text + "')";
                        break;
                    case "tabPage6":
                        query = "insert into security.account_permissions values('" 
                            + cboAccountPName.Text + "','" + cboAccRoleName.Text + "')";
                        break;
                }
                objDB.Execute_Query(query);
                MessageBox.Show("Record inserted successfully");
                Fill_Grid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "";
            try
            {
                switch (tabControl1.SelectedTab.Name)
                {
                    case "tabPage1":
                        query = "update security.privileges set P_Name='" + textBox1.Text + 
                            "', P_Type='" + cboPType.Text + "' where P_Name='" + dgvPrivileges.SelectedCells[0].Value + "'";
                        break;
                    case "tabPage2":
                        query = "update security.user_roles set Role_Name='" + textBox8.Text + 
                            "', Description='" + textBox7.Text + "' where Role_Name='" + dgvUserRoles.SelectedCells[0].Value + "'";
                        break;
                    case "tabPage3":
                        query = "update security.user_accounts set Name='" + textBox10.Text + 
                            "', Phone='" + textBox11.Text + "', Role_Name='" + cboUserRole.Text + 
                            "' where IdNo='" + dgvUserAccunts.SelectedCells[0].Value + "'";
                        break;
                    case "tabPage4":
                        query = "update security.tables set Table_Name='" + textBox18.Text + "' ,Owner_Id ='" + 
                            cboTableOwner.SelectedValue.ToString() + "' where Table_Name='" + dgvTables.SelectedCells[0].Value + "'";
                        break;
                    case "tabPage5":
                        query = "update security.table_permissions set P_Name='" + cboRelationPName.Text + "', Role_Name='" + cboTabUserRole.Text +
                            "', Table_Name='" + cboTableName.Text + "' where P_Name='" + dgvTablePermissions.SelectedCells[0].Value + 
                            "' and Role_Name='" + dgvTablePermissions.SelectedCells[1].Value + 
                            "' and Table_Name='" + dgvTablePermissions.SelectedCells[2].Value + "'";
                        break;
                    case "tabPage6":
                        query = "update security.account_permissions set P_Name='" + cboAccountPName.Text + 
                            "', Role_Name='" + cboAccRoleName.Text  + "' where P_Name='" + dgvAccountPermissions.SelectedCells[0].Value 
                            + "' and Role_Name='" + dgvAccountPermissions.SelectedCells[1].Value  + "'";
                        break;
                }
                objDB.Execute_Query(query);
                MessageBox.Show("Record updated successfully");
                Fill_Grid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "";
            try
            {
                switch (tabControl1.SelectedTab.Name)
                {
                    case "tabPage1":
                        query = "delete from security.privileges where P_Name='" + dgvPrivileges.SelectedCells[0].Value + "'";
                        break;
                    case "tabPage2":
                        query = "delete from security.user_roles where Role_Name='" + textBox8.Text + "'";
                        break;
                    case "tabPage3":
                        query = "delete from security.user_accounts where IdNo='" + dgvUserAccunts.SelectedCells[0].Value + "'";
                        break;
                    case "tabPage4":
                        query = "delete from security.tables where Table_Name='" + textBox18.Text + "'";
                        break;
                    case "tabPage5":
                        query = "delete from security.table_permissions where P_Name='" + cboRelationPName.Text + "' and Role_Name='" + cboTabUserRole.Text +
                            "' and Table_Name='" + cboTableName.Text + "'";
                        break;
                    case "tabPage6":
                        query = "delete from security.account_permissions where P_Name='" + cboAccountPName.Text + "' and " +
                            "Role_Name ='" + cboAccRoleName.Text + "'";
                        break;
                }
                objDB.Execute_Query(query);
                MessageBox.Show("Record deleted successfully");
                Fill_Grid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Fill Combo Box
        private void Fill_UserRole_Combo()
        {
            DataTable dt;
            try
            {
                dt = objDB.Get_DB_Data("user_roles");
                if (tabControl1.SelectedTab.Name == "tabPage3")
                {
                    cboUserRole.DataSource = dt;
                    cboUserRole.DisplayMember = "Role_Name";
                    cboUserRole.ValueMember = "Role_Name";
                }
                else if (tabControl1.SelectedTab.Name == "tabPage5")
                {
                    cboTabUserRole.DataSource = dt;
                    cboTabUserRole.DisplayMember = "Role_Name";
                    cboTabUserRole.ValueMember = "Role_Name";
                }
                else if (tabControl1.SelectedTab.Name == "tabPage6")
                {
                    cboAccRoleName.DataSource = dt;
                    cboAccRoleName.DisplayMember = "Role_Name";
                    cboAccRoleName.ValueMember = "Role_Name";
                }
                else if (tabControl1.SelectedTab.Name == "tabPage7")
                {
                    cboUserPrivilege.DataSource = dt;
                    cboUserPrivilege.DisplayMember = "Role_Name";
                    cboUserPrivilege.ValueMember = "Role_Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Fill_TableOwner_Combo()
        {
            DataTable dt;
            try
            {
                dt = objDB.Get_DB_Data("user_accounts");
                if (tabControl1.SelectedTab.Name == "tabPage4")
                {
                    cboTableOwner.DataSource = dt;
                    cboTableOwner.DisplayMember = "Name";
                    cboTableOwner.ValueMember = "IdNo";
                }
                else if (tabControl1.SelectedTab.Name == "tabPage7")
                {
                    cboAccountPrivilege.DataSource = dt;
                    cboAccountPrivilege.DisplayMember = "Name";
                    cboAccountPrivilege.ValueMember = "IdNo";
                }
                else if (tabControl1.SelectedTab.Name == "tabPage8")
                {
                    cboCheckUserAccount.DataSource = dt;
                    cboCheckUserAccount.DisplayMember = "Name";
                    cboCheckUserAccount.ValueMember = "IdNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Fill_TableName_Combo()
        {
            DataTable dt;
            try
            {
                dt = objDB.Get_DB_Data("tables");
                cboTableName.DataSource = dt;
                cboTableName.DisplayMember = "Table_Name";
                cboTableName.ValueMember = "Table_Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Fill_Privileges_Combo()
        {
            DataTable dt;
            try
            {
                dt = objDB.Get_DB_Data("privileges");
                if (tabControl1.SelectedTab.Name == "tabPage5")
                {
                    dt = dt.Select("P_Type='Relation'").CopyToDataTable();
                    cboRelationPName.DataSource = dt;
                    cboRelationPName.DisplayMember = "P_Name";
                    cboRelationPName.ValueMember = "P_Name";
                }
                else if (tabControl1.SelectedTab.Name == "tabPage6")
                {
                    dt = dt.Select("P_Type='Account'").CopyToDataTable();
                    cboAccountPName.DataSource = dt;
                    cboAccountPName.DisplayMember = "P_Name";
                    cboAccountPName.ValueMember = "P_Name";
                }
                else if (tabControl1.SelectedTab.Name == "tabPage8")
                {
                    cboCheckPrivilege.DataSource = dt;
                    cboCheckPrivilege.DisplayMember = "P_Name";
                    cboCheckPrivilege.ValueMember = "P_Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Grid Cell Click Events
    private void dgvPrivileges_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dgvPrivileges.Rows[e.RowIndex].Cells[clmPName.Index].Value.ToString();
            cboPType.SelectedIndex = cboPType.Items.IndexOf(dgvPrivileges.Rows[e.RowIndex].Cells[clmPType.Index].Value.ToString());
        }

        private void dgvUserRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dgvUserRoles.Rows[e.RowIndex].Cells[clmnRoleName.Index].Value.ToString();
            textBox7.Text = dgvUserRoles.Rows[e.RowIndex].Cells[clmnRoleDescription.Index].Value.ToString();
        }

        private void dgvUserAccunts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = dgvUserAccunts.Rows[e.RowIndex].Cells[clmnUserName.Index].Value.ToString();
            textBox11.Text = dgvUserAccunts.Rows[e.RowIndex].Cells[clmnUserPhone.Index].Value.ToString();
            cboUserRole.Text = dgvUserAccunts.Rows[e.RowIndex].Cells[clmnUserRole.Index].Value.ToString();
        }

        private void dgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox18.Text = dgvTables.Rows[e.RowIndex].Cells[clmnTableName.Index].Value.ToString();
            cboTableOwner.SelectedValue = dgvTables.Rows[e.RowIndex].Cells[clmnOwnerName.Index].Value.ToString();
        }

        private void dgvTablePermissions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboRelationPName.Text = dgvTablePermissions.Rows[e.RowIndex].Cells[clmnPName.Index].Value.ToString();
            cboTabUserRole.Text = dgvTablePermissions.Rows[e.RowIndex].Cells[clmnTabUserRole.Index].Value.ToString();
            cboTableName.Text = dgvTablePermissions.Rows[e.RowIndex].Cells[clmnTTableName.Index].Value.ToString();
        }

        private void dgvAccountPermissions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboAccountPName.Text = dgvAccountPermissions.Rows[e.RowIndex].Cells[clmAccPName.Index].Value.ToString();
            cboAccRoleName.Text = dgvAccountPermissions.Rows[e.RowIndex].Cells[clmnAccPRoleName.Index].Value.ToString();
        }
        #endregion

        private void cboUserPrivilege_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvUserPrivilege.DataSource = objDB.Get_UserRole_Privilege_Data(cboUserPrivilege.Text);
        }

        private void cboAccountPrivilege_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAccountPrivilege.DataSource = objDB.Get_UserAccount_Privilege_Data((int)cboAccountPrivilege.SelectedValue);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            bool blnCheck;
            try
            {
                blnCheck = objDB.Check_UserAccount_Privilege_Data(cboCheckUserAccount.SelectedValue.ToString(), cboCheckPrivilege.Text);
                if (blnCheck)
                {
                    label16.ForeColor = System.Drawing.Color.SteelBlue;
                    label16.Text =  "Privilege '" + cboCheckPrivilege.Text + "' is granted for " + cboCheckUserAccount.Text;
                }
                else
                {
                    label16.ForeColor = System.Drawing.Color.Red;
                    label16.Text = "Privilege '" + cboCheckPrivilege.Text + "' is not granted for user " + cboCheckUserAccount.Text;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
