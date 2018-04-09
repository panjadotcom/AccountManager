using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;


namespace AccountManager
{
    public partial class frm_account_transaction_details : Form
    {
        static string frm_acctxndtl_constring = ConfigurationSettings.AppSettings["constr"];
        MySqlConnection frm_acctxndtl_connection = new MySqlConnection(frm_acctxndtl_constring);
        MySqlDataAdapter frm_acctxndtl_dataadopter = null;
        DataTable frm_acctxndtl_datatable = null;
        DataSet frm_acctxndtl_dataset = null;
        BindingSource frm_acctxndtl_bind_source = null;
        MyGlobals myglobal = new MyGlobals();
        public frm_account_transaction_details()
        {
            InitializeComponent();
        }

        private void frm_account_transaction_clear_datagridview()
        {
            myglobal.print_log("inside Function frm_account_transaction_clear_datagridview");
            Int32 number_of_rows = dtgrdvu_acc_txn_details.Rows.Count;
            for (int i = 0; i < number_of_rows; i++)
            {
                dtgrdvu_acc_txn_details.Rows.RemoveAt(0);
             }
        }

        private void frm_account_transaction_load_datagridview()
        {
            myglobal.print_log("inside Function frm_account_transaction_load_datagridview");
            //load datagridview
            DateTime datetime_start_date = dttmpkr_acctxndtl_from_date.Value;
            DateTime datetime_end_date = dttmpkr_acctxndtl_to_date.Value;
            String index = cmbbx_acctxndtl_account_name.SelectedValue.ToString();
            Int32 index_int = Convert.ToInt32(index);

            if (index_int > 0 && index_int < 10)
                index = "00" + Convert.ToString(index_int);
            else if (index_int >= 10 && index_int < 100)
                index = "0" + Convert.ToString(index_int);
            else if (index_int >= 100 && index_int < 1000)
                index = Convert.ToString(index_int);
            else if (index_int == 1000)
                index = "INFO";
            string basic_select_command = "SELECT TxnDate as Date, TxnOtherAcc as `TXN ID`, TxnFromAcc as `From Account`, TxnToAcc as `To Account`, TxnCheaqueNumber as `Transaction Mode`, TxnParticulars as `Particulars`, TxnDebited as `Debit Amount`, TxnCredited as `Credit Amount` FROM `Transaction_" + index + "` ";
            string basic_where_command_from_time = "TxnDate > '" + datetime_start_date.Year.ToString() + "-" + datetime_start_date.Month.ToString() + "-" + datetime_start_date.Day.ToString() + " 00:00:00" + "'";
            string basic_where_command_to_time = "TxnDate < '" + datetime_end_date.Year.ToString() + "-" + datetime_end_date.Month.ToString() + "-" + datetime_end_date.Day.ToString() + " 23:59:59" + "'";
            MySqlCommand mysql_command = frm_acctxndtl_connection.CreateCommand();
            mysql_command.Connection = frm_acctxndtl_connection;
            mysql_command.CommandType = CommandType.Text;
            frm_acctxndtl_dataadopter = new MySqlDataAdapter();
            frm_acctxndtl_datatable = new DataTable();
            frm_acctxndtl_bind_source = new BindingSource();
            mysql_command.CommandText = basic_select_command + " WHERE " + basic_where_command_from_time + " AND " + basic_where_command_to_time + " ORDER BY TxnDate";
            myglobal.print_log("Command is to be executed = " + mysql_command.CommandText + "");
            mysql_command.Prepare();
            try
            {
                //frm_acctxndtl_connection.Open();
                frm_acctxndtl_dataadopter.SelectCommand = mysql_command;
                frm_acctxndtl_dataadopter.Fill(frm_acctxndtl_datatable);
                frm_acctxndtl_bind_source.DataSource = frm_acctxndtl_datatable;
                dtgrdvu_acc_txn_details.DataSource = frm_acctxndtl_bind_source;
                myglobal.print_log("DataGridView filled successfully with " + dtgrdvu_acc_txn_details.Rows.Count.ToString() + " Rows");
                //frm_acctxndtl_connection.Close();
            }
            catch (Exception dtbnd)
            {
                myglobal.print_log("Data Grid cannot Be filled because " + dtbnd.Message + "\n\n\n Provide Proper Details of the Database");
                MessageBox.Show("Data Grid cannot Be filled because " + dtbnd.Message + "\n\n\n Provide Proper Details of the Database");
            }
        }

        private void frm_account_transaction_update_balances()
        {
            myglobal.print_log("Inside Function frm_account_transaction_update_balances");
            //Update textboxes of the screen
            Double current_balance = 0.00;
            String current_balance_str = "";
            Double opening_balance = 0.00;
            String opening_balance_str = "";
            Double closing_balance = 0.00;
            String closing_balance_str = "";
            Double current_transaction = 0.00;
            String current_transaction_str = "";
            DateTime datetime_start_date = dttmpkr_acctxndtl_from_date.Value;
            DateTime datetime_end_date = dttmpkr_acctxndtl_to_date.Value;
            String index = cmbbx_acctxndtl_account_name.SelectedValue.ToString();
            Int32 index_int = Convert.ToInt32(index);

            if (index_int > 0 && index_int < 10)
                index = "00" + Convert.ToString(index_int);
            else if (index_int >= 10 && index_int < 100)
                index = "0" + Convert.ToString(index_int);
            else
                index = Convert.ToString(index_int);
            string basic_select_command = "SELECT SUM(TxnCredited) - SUM(TxnDebited) AS BALACE FROM `Transaction_" + index + "`";
            string basic_where_command_from_time = "TxnDate < '" + datetime_start_date.Year.ToString() + "-" + datetime_start_date.Month.ToString() + "-" + datetime_start_date.Day.ToString() + " 00:00:00" + "'";
            string basic_where_command_from_to_time = "TxnDate > '" + datetime_start_date.Year.ToString() + "-" + datetime_start_date.Month.ToString() + "-" + datetime_start_date.Day.ToString() + " 00:00:00" + "'"; 
            string basic_where_command_to_time = "TxnDate < '" + datetime_end_date.Year.ToString() + "-" + datetime_end_date.Month.ToString() + "-" + datetime_end_date.Day.ToString() + " 23:59:59" + "'";
            MySqlCommand mysql_command = frm_acctxndtl_connection.CreateCommand();
            mysql_command.Connection = frm_acctxndtl_connection;
            mysql_command.CommandType = CommandType.Text;
            try
            {
                mysql_command.CommandText = basic_select_command;
                mysql_command.Prepare();
                try
                {
                    current_balance = Convert.ToDouble(mysql_command.ExecuteScalar());
                    myglobal.print_log("Command Executed is " + mysql_command.CommandText + " returns value as current_balance = " + current_balance.ToString() + "");
                    if (current_balance > 0)
                    {
                        current_balance_str = current_balance.ToString() + " CR";
                    }
                    else if (current_balance < 0)
                    {
                        current_balance_str = (0 - current_balance).ToString() + " DR";
                    }
                    else
                    {
                        current_balance_str = "NILL";
                    }
                }
                catch (Exception e)
                {
                    current_balance = 0.00;
                    current_balance_str = "NILL";
                    myglobal.print_log("Command Executed is " + mysql_command.CommandText + " returns value as current_balance = FAILURE because " + e.Message + "");
                }
                mysql_command.CommandText = basic_select_command + " WHERE " + basic_where_command_from_time;
                mysql_command.Prepare();
                try
                {
                    opening_balance = Convert.ToDouble(mysql_command.ExecuteScalar());
                    myglobal.print_log("Command Executed is " + mysql_command.CommandText + " returns value as opening_balance = " + opening_balance.ToString() + "");
                    if (opening_balance > 0)
                    {
                        opening_balance_str = opening_balance.ToString() + " CR";
                    }
                    else if (opening_balance < 0)
                    {
                        opening_balance_str = (0 - opening_balance).ToString() + " DR";
                    }
                    else
                    {
                        opening_balance_str = "NILL";
                    }
                }
                catch (Exception e)
                {
                    opening_balance = 0.00;
                    opening_balance_str = "NILL";
                    myglobal.print_log("Command Executed is " + mysql_command.CommandText + " returns value as opening_balance = FAILURE because " + e.Message + "");
                }
                mysql_command.CommandText = basic_select_command + " WHERE " + basic_where_command_to_time;
                mysql_command.Prepare();
                try
                {
                    closing_balance = Convert.ToDouble(mysql_command.ExecuteScalar());
                    myglobal.print_log("Command Executed is " + mysql_command.CommandText + " returns value as closing_balance = " + closing_balance.ToString() + "");
                    if (closing_balance > 0)
                    {
                        closing_balance_str = closing_balance.ToString() + " CR";
                    }
                    else if (closing_balance < 0)
                    {
                        closing_balance_str = (0 - closing_balance).ToString() + " DR";
                    }
                    else
                    {
                        closing_balance_str = "NILL";
                    }
                }
                catch (Exception e)
                {
                    closing_balance = 0.00;
                    closing_balance_str = "NILL";
                    myglobal.print_log("Command Executed is " + mysql_command.CommandText + " returns value as closing_balance = FAILURE because " + e.Message + "");
                }
                mysql_command.CommandText = basic_select_command + " WHERE " + basic_where_command_from_to_time + " AND " + basic_where_command_to_time;
                mysql_command.Prepare();
                try
                {
                    current_transaction = Convert.ToDouble(mysql_command.ExecuteScalar());
                    myglobal.print_log("Command Executed is " + mysql_command.CommandText + " returns value as current_transaction = " + current_transaction.ToString() + "");
                    if (current_transaction > 0)
                    {
                        current_transaction_str = current_transaction.ToString() + " CR";
                    }
                    else if (current_transaction < 0)
                    {
                        current_transaction_str = (0 - current_transaction).ToString() + " DR";
                    }
                    else
                    {
                        current_transaction_str = "NILL";
                    }
                }
                catch (Exception e)
                {
                    current_transaction = 0.00;
                    current_transaction_str = "NILL";
                    myglobal.print_log("Command Executed is " + mysql_command.CommandText + " returns value as current_transaction =  FAILURE because " + e.Message + "");
                }
            }
            catch( Exception updttxtbx )
            {
                myglobal.print_log(" Balance Box Cannot be updated \n\n because \n\n " + updttxtbx.Message + "\n\n Provide Proper Details of the Account");
                MessageBox.Show(" Balance Box Cannot be updated \n\n because \n\n " + updttxtbx.Message + "\n\n Provide Proper Details of the Account");
                return;
            }
            txtbx_acctxndtl_opening_balance.Text = opening_balance_str;
            myglobal.print_log("opening_balance_str = " + opening_balance_str + "");
            txtbx_acctxndtl_current_balance.Text = current_balance_str;
            myglobal.print_log("current_balance_str = " + current_balance_str + "");
            txtbx_acctxndtl_closing_balance.Text = closing_balance_str;
            myglobal.print_log("closing_balance_str = " + closing_balance_str + "");
            txtbx_acctxndtl_transactions.Text = current_transaction_str;
            myglobal.print_log("current_transaction_str = " + current_transaction_str + "");
            myglobal.print_log("Returning from Function frm_account_transaction_update_balances");
        }

        private void frm_account_transaction_details_Load(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function frm_account_transaction_details_Load");
            try
            {
                frm_acctxndtl_connection.Open();
            }
            catch (Exception erropen)
            {
                myglobal.print_log("Connection cannot be opened because " + erropen.Message + "");
                MessageBox.Show("Connection cannot be opened because " + erropen.Message + "");
            }
            string sql_datareader_query = "SELECT AccId, AccName FROM AccountProfile order by AccId";
            frm_acctxndtl_dataset = new DataSet();
            frm_acctxndtl_dataadopter = new MySqlDataAdapter(sql_datareader_query, frm_acctxndtl_connection);
            try
            {
                frm_acctxndtl_dataadopter.Fill(frm_acctxndtl_dataset, "COMBO_BOX");
                if (frm_acctxndtl_dataset != null)
                {
                    cmbbx_acctxndtl_account_name.DataSource = frm_acctxndtl_dataset.Tables["COMBO_BOX"];
                    cmbbx_acctxndtl_account_name.ValueMember = "AccId";
                    cmbbx_acctxndtl_account_name.DisplayMember = "AccName";
                }
                myglobal.print_log("Combo box initialize Successfully with command " + sql_datareader_query + "");
            }
            catch (Exception combo)
            {
                myglobal.print_log("Combo Box cannot be Initialize " + combo.Message + "\n\n\n Provide Proper Details of the Database");
                MessageBox.Show("Combo Box cannot be Initialize " + combo.Message + "\n\n\n Provide Proper Details of the Database");
            }
            //cmbbx_acctxndtl_account_name.Text = "select Account";
            cmbbx_acctxndtl_account_name.SelectedIndex = 0;// commented
            dttmpkr_acctxndtl_from_date.MaxDate = DateTime.Today;
            dttmpkr_acctxndtl_to_date.MaxDate = DateTime.Today;
            txtbx_acctxndtl_closing_balance.Text = "";
            txtbx_acctxndtl_current_balance.Text = "";
            txtbx_acctxndtl_opening_balance.Text = "";
            myglobal.print_log("Returning from Function frm_account_transaction_details_Load");
        }

        private void btn_acctxndtl_show_details_Click(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function btn_acctxndtl_show_details_Click");
            //dtgrdvu_acc_txn_details.Rows.Add();
            if (cmbbx_acctxndtl_account_name.SelectedIndex > 1)
            {
                this.frm_account_transaction_load_datagridview();
            }
            else
            {
                myglobal.print_log("Data Grid cannot Be filled because no account is selected \n\n\n Please select an Account");
                MessageBox.Show("Data Grid cannot Be filled because no account is selected \n\n\n Please select an Account");
            }
        }

        private void dttmpkr_acctxndtl_from_date_ValueChanged(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function dttmpkr_acctxndtl_from_date_ValueChanged");
            dttmpkr_acctxndtl_to_date.MinDate = dttmpkr_acctxndtl_from_date.Value;
            if (cmbbx_acctxndtl_account_name.SelectedIndex > 1)
            {
                this.frm_account_transaction_update_balances();
                this.frm_account_transaction_clear_datagridview();
                if (chkbx_acctxndtl_auto_update.Checked)
                {
                    //this.frm_account_transaction_clear_datagridview();
                    this.frm_account_transaction_load_datagridview();
                }
            }
        }

        private void dttmpkr_acctxndtl_to_date_ValueChanged(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function dttmpkr_acctxndtl_to_date_ValueChanged");
            dttmpkr_acctxndtl_from_date.MaxDate = dttmpkr_acctxndtl_to_date.Value;
            if (cmbbx_acctxndtl_account_name.SelectedIndex > 1)
            {
                this.frm_account_transaction_update_balances();
                this.frm_account_transaction_clear_datagridview();
                if (chkbx_acctxndtl_auto_update.Checked)
                {
                    //this.frm_account_transaction_clear_datagridview();
                    this.frm_account_transaction_load_datagridview();
                }
            }
        }

        private void cmbbx_acctxndtl_account_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function cmbbx_acctxndtl_account_name_SelectedIndexChanged");
            if (cmbbx_acctxndtl_account_name.SelectedIndex > 1)
            {
                this.frm_account_transaction_update_balances();
                this.frm_account_transaction_clear_datagridview();
                if (chkbx_acctxndtl_auto_update.Checked)
                {
                    //this.frm_account_transaction_clear_datagridview();
                    this.frm_account_transaction_load_datagridview();
                }
            }
        }

        private void chkbx_acctxndtl_auto_update_CheckedChanged(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function chkbx_acctxndtl_auto_update_CheckedChanged");
            if (cmbbx_acctxndtl_account_name.SelectedIndex > 1)
            {
                if (chkbx_acctxndtl_auto_update.Checked)
                {
                    this.frm_account_transaction_clear_datagridview();
                    this.frm_account_transaction_load_datagridview();
                }
            }
        }

        private void frm_account_transaction_details_FormClosed(object sender, FormClosedEventArgs e)
        {
            myglobal.print_log("Inside Function frm_account_transaction_details_FormClosed");
            try
            {
                frm_acctxndtl_connection.Close();
            }
            catch (Exception errclose)
            {
                myglobal.print_log("Connection cannot be Closed because " + errclose.Message + "");
                MessageBox.Show("Connection cannot be Closed because " + errclose.Message + "");
            }
        }

        private void releaseObject(object obj)
        {
            myglobal.print_log("Inside Function releaseObject");
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                myglobal.print_log("Exception Occured while releasing object " + ex.ToString());
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
            myglobal.print_log("Returning from Function releaseObject");
        }

        private void btn_acctxndtl_save_to_file_Click(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function btn_acctxndtl_save_to_file_Click");
            if ((cmbbx_acctxndtl_account_name.SelectedIndex > 1)&& (dtgrdvu_acc_txn_details.Columns.Count > 1) && (dtgrdvu_acc_txn_details.Rows.Count > 0))
            {
                DateTime datetime_start_date = dttmpkr_acctxndtl_from_date.Value;
                DateTime datetime_end_date = dttmpkr_acctxndtl_to_date.Value;
                String accName = cmbbx_acctxndtl_account_name.Text;
                String xlFileName = accName + "-" + datetime_start_date.Year.ToString() + datetime_start_date.Month.ToString() + datetime_start_date.Day.ToString() + "-" + datetime_end_date.Year.ToString() + datetime_end_date.Month.ToString() + datetime_end_date.Day.ToString();
                save_file_dialog_acctxndtl.FileName = xlFileName;
                if (save_file_dialog_acctxndtl.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application xlapp;
                    Excel.Workbook xlworkbook;
                    Excel.Worksheet xlworksheet;
                    object misvalue = System.Reflection.Missing.Value;
                    xlapp = new Excel.ApplicationClass();
                    xlworkbook = xlapp.Workbooks.Add(misvalue);
                    xlworksheet = (Excel.Worksheet)xlworkbook.Worksheets.get_Item(1);
                    xlworksheet.Name = "Exported from Grid";
                    //save_file_dialog_acctxndtl save_file_dialog = new SaveFileDialog();
                    xlFileName = save_file_dialog_acctxndtl.FileName;
                    myglobal.print_log("xlFileName = " + xlFileName + "");
                    // storing header part in Excel
                    for (int i = 1; i < dtgrdvu_acc_txn_details.Columns.Count + 1; i++)
                    {
                        xlworksheet.Cells[1, i] = dtgrdvu_acc_txn_details.Columns[i - 1].HeaderText;
                    }



                    // storing Each row and column value to excel sheet
                    for (int i = 0; i < dtgrdvu_acc_txn_details.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtgrdvu_acc_txn_details.Columns.Count; j++)
                        {
                            xlworksheet.Cells[i + 2, j + 1] = dtgrdvu_acc_txn_details.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    try
                    {
                        xlworkbook.SaveAs(xlFileName, Excel.XlFileFormat.xlWorkbookNormal, misvalue, misvalue, misvalue, misvalue, Excel.XlSaveAsAccessMode.xlExclusive, misvalue, misvalue, misvalue, misvalue, misvalue);
                    }
                    catch (Exception eee)
                    {
                        myglobal.print_log("File Cannot be saved: " + eee.Message + "\n");
                        MessageBox.Show("File Cannot be saved: " + eee.Message + "\n");
                        MessageBox.Show("first Delete the existing file and then Retry \n");
                    }
                    xlworkbook.Close(true, misvalue, misvalue);
                    xlapp.Quit();

                    releaseObject(xlworksheet);
                    releaseObject(xlworkbook);
                    releaseObject(xlapp);
                    myglobal.print_log("excel file created");
                    MessageBox.Show("excel file created");
                }
                else
                {
                    myglobal.print_log("excel file Not created");
                    MessageBox.Show("excel file Not created");
                }
            }
            else
            {
                myglobal.print_log("file cannot Be created because either no account is selected or DataGrid is Empty");
                MessageBox.Show("file cannot Be created because either no account is selected or DataGrid is Empty");
            }
            myglobal.print_log("Returning from Function btn_acctxndtl_save_to_file_Click");
        }
    }
}
