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

namespace AccountManager
{
    public partial class frm_transaction_update : Form
    {
        static string frm_txnupd_constring = ConfigurationSettings.AppSettings["constr"];
        MySqlConnection frm_txnupd_connection = new MySqlConnection(frm_txnupd_constring);
        MySqlDataAdapter frm_txnupd_dataadopter = null;
        MyGlobals myglobal = new MyGlobals();
        public frm_transaction_update()
        {
            InitializeComponent();
        }

        private void frm_create_mysql_string(string from_index_str, string to_index_str, string Particulars,string cheaque,string amount,string fromAccName , string toAccName)
        {
            myglobal.print_log("inside Function frm_create_mysql_string");
            myglobal.print_log("Value of from_index_str passed is " + from_index_str );
            myglobal.print_log("Value of to_index_str passed is " + to_index_str );
            myglobal.print_log("Value of Particulars passed is " + Particulars );
            myglobal.print_log("Value of cheaque passed is " + cheaque );
            myglobal.print_log("Value of amount passed is " + amount );
            myglobal.print_log("Value of fromAccName passed is " + fromAccName );
            myglobal.print_log("Value of toAccName passed is " + toAccName );
            Int32 from_index = Convert.ToInt32(from_index_str);
            Int32 to_index = Convert.ToInt32(to_index_str);
            Int16 transactionId = 0;
            string index_from = "";
            if (from_index > 0 && from_index < 10)
                index_from = "00" + Convert.ToString(from_index);
            else if (from_index >= 10 && from_index < 100)
                index_from = "0" + Convert.ToString(from_index);
            else
                index_from = Convert.ToString(from_index);
            string index_to = "";
            if (to_index > 0 && to_index < 10)
                index_to = "00" + Convert.ToString(to_index);
            else if (to_index >= 10 && to_index < 100)
                index_to = "0" + Convert.ToString(to_index);
            else
                index_to = Convert.ToString(to_index);
            MySqlTransaction mysql_transaction = frm_txnupd_connection.BeginTransaction();
            MySqlCommand mysql_command = frm_txnupd_connection.CreateCommand();
            mysql_command.Connection = frm_txnupd_connection;
            mysql_command.Transaction = mysql_transaction;
            try
            {
                mysql_command.CommandText = "INSERT INTO `Transaction_Info` (`TxnFromAcc`, `TxnToAcc`, `TxnParticulars`, `TxnCheaqueNumber`, `TxnAmount` ) VALUES ( '" + fromAccName + "' , '" + toAccName + "' , '" + Particulars + "', '" + cheaque + "', " + amount + " ) ";
                mysql_command.ExecuteNonQuery();
                myglobal.print_log("Command " + mysql_command.CommandText + " Executed Successfully ");
                mysql_command.CommandText = "SELECT count(*) FROM `Transaction_Info`";
                transactionId = Convert.ToInt16(mysql_command.ExecuteScalar());
                myglobal.print_log("Command " + mysql_command.CommandText + " Return value as " + transactionId.ToString());
                if (from_index > 2)
                {
                    mysql_command.CommandText = "INSERT INTO `Transaction_" + index_from + "` (`TxnOtherAcc`, `TxnFromAcc`, `TxnToAcc`, `TxnParticulars`, `TxnCheaqueNumber`, `TxnCredited`, `TxnDebited` ) VALUES ( " + Convert.ToString(transactionId) + " , '" + fromAccName + "' , '" + toAccName + "' , '" + Particulars + "', '" + cheaque + "', 0.00 , " + amount + " ) ";
                    mysql_command.ExecuteNonQuery();
                    myglobal.print_log("Command " + mysql_command.CommandText + " Executed Successfully ");
                }
                if (to_index > 2)
                {
                    mysql_command.CommandText = "INSERT INTO `Transaction_" + index_to + "` (`TxnOtherAcc`, `TxnFromAcc`, `TxnToAcc`, `TxnParticulars`, `TxnCheaqueNumber`, `TxnCredited`, `TxnDebited` ) VALUES ( " + Convert.ToString(transactionId) + " , '" + fromAccName + "' , '" + toAccName + "' , '" + Particulars + "', '" + cheaque + "', " + amount + ", 0.00 ) ";
                    mysql_command.ExecuteNonQuery();
                    myglobal.print_log("Command " + mysql_command.CommandText + " Executed Successfully ");
                }
                mysql_transaction.Commit();
                //MessageBox.Show("Records for Transaction from " + index_from + " to " + index_to + "is updated Succesfully");
            }
            catch (Exception cmd)
            {
                myglobal.print_log("An error occur during updating transaction number 1 because " + cmd.Message + " Trying to rollback ");
                MessageBox.Show("An error occur during updating transaction number 1 because " + cmd.Message + " Try again later by entering currect information");
                try
                {
                    //rolback
                    mysql_transaction.Rollback();
                    myglobal.print_log("Records for Transaction number 1 is Rolled Back Succesfully");
                }
                catch (MySqlException mysqlexcption)
                {
                    myglobal.print_log("An exception " + mysqlexcption.Message + " was encountered while attempting to roll back the transaction.");
                    if (mysql_transaction.Connection != null)
                    {
                        myglobal.print_log("An exception of type " + mysqlexcption.GetType() + " was encountered while attempting to roll back the transaction.");
                    }
                }
            }
        }

        private void frm_transaction_update_Load(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function frm_transaction_update_Load ");
            try
            {
                frm_txnupd_connection.Open();
            }
            catch (Exception erropen)
            {
                myglobal.print_log("connection cannot be opened because " + erropen.Message + "");
                MessageBox.Show("connection cannot be opened because " + erropen.Message + "");
            }
            string sql_datareader_query = "SELECT AccId, AccName FROM AccountProfile order by AccId";
            //MySqlCommand mysql_command = new MySqlCommand(sql_datareader_query,frm_txnupd_connection);
            DataSet from_dataset_1 = new DataSet();
            DataSet to_dataset_1 = new DataSet();
            DataSet from_dataset_2 = new DataSet();
            DataSet to_dataset_2 = new DataSet();
            DataSet from_dataset_3 = new DataSet();
            DataSet to_dataset_3 = new DataSet();
            DataSet from_dataset_4 = new DataSet();
            DataSet to_dataset_4 = new DataSet();
            DataSet from_dataset_5 = new DataSet();
            DataSet to_dataset_5 = new DataSet();
            //frm_txnupd_dataset = new DataSet();
            frm_txnupd_dataadopter = new MySqlDataAdapter(sql_datareader_query, frm_txnupd_connection);
            try
            {
                //frm_txnupd_connection.Open();
                //frm_txnupd_dataadopter.Fill(frm_txnupd_dataset , "COMBO_BOX");
                //frm_txn_datareader = mysql_command.ExecuteReader();
                frm_txnupd_dataadopter.Fill(from_dataset_1, "COMBO_BOX");
                frm_txnupd_dataadopter.Fill(to_dataset_1, "COMBO_BOX");
                frm_txnupd_dataadopter.Fill(from_dataset_2, "COMBO_BOX");
                frm_txnupd_dataadopter.Fill(to_dataset_2, "COMBO_BOX");
                frm_txnupd_dataadopter.Fill(from_dataset_3, "COMBO_BOX");
                frm_txnupd_dataadopter.Fill(to_dataset_3, "COMBO_BOX");
                frm_txnupd_dataadopter.Fill(from_dataset_4, "COMBO_BOX");
                frm_txnupd_dataadopter.Fill(to_dataset_4, "COMBO_BOX");
                frm_txnupd_dataadopter.Fill(from_dataset_5, "COMBO_BOX");
                frm_txnupd_dataadopter.Fill(to_dataset_5, "COMBO_BOX");
                if (from_dataset_1 != null)
                {
                    cmbbx_txn_upd_from_acc_1.DataSource = from_dataset_1.Tables["COMBO_BOX"];//frm_txn_datareader
                    //cmbbx_txn_upd_from_acc_1.DataSource = frm_txn_datareader;
                    cmbbx_txn_upd_from_acc_1.ValueMember = "AccId";
                    cmbbx_txn_upd_from_acc_1.DisplayMember = "AccName";
                }
                if (from_dataset_2 != null)
                {
                    cmbbx_txn_upd_from_acc_2.DataSource = from_dataset_2.Tables["COMBO_BOX"];//frm_txn_datareader;
                    cmbbx_txn_upd_from_acc_2.ValueMember = "AccId";
                    cmbbx_txn_upd_from_acc_2.DisplayMember = "AccName";
                }
                if (from_dataset_3 != null)
                {
                    cmbbx_txn_upd_from_acc_3.DataSource = from_dataset_3.Tables["COMBO_BOX"];//frm_txn_datareader;
                    cmbbx_txn_upd_from_acc_3.ValueMember = "AccId";
                    cmbbx_txn_upd_from_acc_3.DisplayMember = "AccName";
                }
                if (from_dataset_4 != null)
                {
                    cmbbx_txn_upd_from_acc_4.DataSource = from_dataset_4.Tables["COMBO_BOX"];//frm_txn_datareader;
                    cmbbx_txn_upd_from_acc_4.ValueMember = "AccId";
                    cmbbx_txn_upd_from_acc_4.DisplayMember = "AccName";
                }
                if (from_dataset_5 != null)
                {
                    cmbbx_txn_upd_from_acc_5.DataSource = from_dataset_5.Tables["COMBO_BOX"];//frm_txn_datareader;
                    cmbbx_txn_upd_from_acc_5.ValueMember = "AccId";
                    cmbbx_txn_upd_from_acc_5.DisplayMember = "AccName";
                }
                if (to_dataset_1 != null)
                {
                    cmbbx_txn_upd_to_acc_1.DataSource = to_dataset_1.Tables["COMBO_BOX"];//frm_txn_datareader;
                    cmbbx_txn_upd_to_acc_1.ValueMember = "AccId";
                    cmbbx_txn_upd_to_acc_1.DisplayMember = "AccName";
                }
                if (to_dataset_2 != null)
                {
                    cmbbx_txn_upd_to_acc_2.DataSource = to_dataset_2.Tables["COMBO_BOX"];//frm_txn_datareader;
                    cmbbx_txn_upd_to_acc_2.ValueMember = "AccId";
                    cmbbx_txn_upd_to_acc_2.DisplayMember = "AccName";
                }
                if (to_dataset_3 != null)
                {
                    cmbbx_txn_upd_to_acc_3.DataSource = to_dataset_3.Tables["COMBO_BOX"];//frm_txn_datareader;
                    cmbbx_txn_upd_to_acc_3.ValueMember = "AccId";
                    cmbbx_txn_upd_to_acc_3.DisplayMember = "AccName";
                }
                if (to_dataset_4 != null)
                {
                    cmbbx_txn_upd_to_acc_4.DataSource = to_dataset_4.Tables["COMBO_BOX"];//frm_txn_datareader;
                    cmbbx_txn_upd_to_acc_4.ValueMember = "AccId";
                    cmbbx_txn_upd_to_acc_4.DisplayMember = "AccName";
                }
                if (to_dataset_5 != null)
                {
                    cmbbx_txn_upd_to_acc_5.DataSource = to_dataset_5.Tables["COMBO_BOX"];//frm_txn_datareader;
                    cmbbx_txn_upd_to_acc_5.ValueMember = "AccId";
                    cmbbx_txn_upd_to_acc_5.DisplayMember = "AccName";
                }
                myglobal.print_log("Combo Boxes Initialized Successfully");
                //frm_txn_datareader.Close();
            }
            catch (Exception combo)
            {
                myglobal.print_log("Combo Box cannot be Initialize " + combo.Message + " Provide Proper Details of the Database");
                MessageBox.Show("Combo Box cannot be Initialize " + combo.Message + "\n\n\n Provide Proper Details of the Database");
            }
            cmbbx_txn_upd_from_acc_1.Enabled = true;
            cmbbx_txn_upd_to_acc_1.Enabled = true;
            txtbx_txn_upd_particular_1.Enabled = true;
            txtbx_txn_upd_amount_1.Enabled = true;
            txtbx_txn_upd_cheque_number_1.Enabled = true;
            chkbx_txn_upd_ask_update_1.Enabled = true;
            cmbbx_txn_upd_to_acc_1.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_1.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_1.Text = "";
            txtbx_txn_upd_cheque_number_1.Text = "";
            txtbx_txn_upd_particular_1.Text = "";
            chkbx_txn_upd_ask_update_1.Checked = false;
            cmbbx_txn_upd_from_acc_2.Enabled = true;
            cmbbx_txn_upd_to_acc_2.Enabled = true;
            txtbx_txn_upd_particular_2.Enabled = true;
            txtbx_txn_upd_amount_2.Enabled = true;
            txtbx_txn_upd_cheque_number_2.Enabled = true;
            chkbx_txn_upd_ask_update_2.Enabled = true;
            cmbbx_txn_upd_to_acc_2.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_2.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_2.Text = "";
            txtbx_txn_upd_cheque_number_2.Text = "";
            txtbx_txn_upd_particular_2.Text = "";
            chkbx_txn_upd_ask_update_2.Checked = false;
            cmbbx_txn_upd_from_acc_3.Enabled = true;
            cmbbx_txn_upd_to_acc_3.Enabled = true;
            txtbx_txn_upd_particular_3.Enabled = true;
            txtbx_txn_upd_amount_3.Enabled = true;
            txtbx_txn_upd_cheque_number_3.Enabled = true;
            chkbx_txn_upd_ask_update_3.Enabled = true;
            cmbbx_txn_upd_to_acc_3.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_3.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_3.Text = "";
            txtbx_txn_upd_cheque_number_3.Text = "";
            txtbx_txn_upd_particular_3.Text = "";
            chkbx_txn_upd_ask_update_3.Checked = false;
            cmbbx_txn_upd_from_acc_4.Enabled = true;
            cmbbx_txn_upd_to_acc_4.Enabled = true;
            txtbx_txn_upd_particular_4.Enabled = true;
            txtbx_txn_upd_amount_4.Enabled = true;
            txtbx_txn_upd_cheque_number_4.Enabled = true;
            chkbx_txn_upd_ask_update_4.Enabled = true;
            cmbbx_txn_upd_to_acc_4.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_4.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_4.Text = "";
            txtbx_txn_upd_cheque_number_4.Text = "";
            txtbx_txn_upd_particular_4.Text = "";
            chkbx_txn_upd_ask_update_4.Checked = false;
            cmbbx_txn_upd_from_acc_5.Enabled = true;
            cmbbx_txn_upd_to_acc_5.Enabled = true;
            txtbx_txn_upd_particular_5.Enabled = true;
            txtbx_txn_upd_amount_5.Enabled = true;
            txtbx_txn_upd_cheque_number_5.Enabled = true;
            chkbx_txn_upd_ask_update_5.Enabled = true;
            cmbbx_txn_upd_to_acc_5.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_5.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_5.Text = "";
            txtbx_txn_upd_cheque_number_5.Text = "";
            txtbx_txn_upd_particular_5.Text = "";
            chkbx_txn_upd_ask_update_5.Checked = false;
            myglobal.print_log("Returning from Function frm_transaction_update_Load ");
        }

        private void chkbx_txn_upd_ask_update_1_CheckedChanged(object sender, EventArgs e)
        {
            // lock values of that row in form
            myglobal.print_log("Inside Function chkbx_txn_upd_ask_update_1_CheckedChanged");
            if (chkbx_txn_upd_ask_update_1.Checked)
            {
                if (cmbbx_txn_upd_from_acc_1.SelectedIndex == cmbbx_txn_upd_to_acc_1.SelectedIndex)
                {
                    myglobal.print_log("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    MessageBox.Show("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    chkbx_txn_upd_ask_update_1.Checked = false;
                }
                else if ( ( cmbbx_txn_upd_from_acc_1.SelectedIndex < 1 ) || ( cmbbx_txn_upd_to_acc_1.SelectedIndex < 1 ) )
                {
                    myglobal.print_log(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    MessageBox.Show(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    chkbx_txn_upd_ask_update_1.Checked = false;
                }
                else if (txtbx_txn_upd_amount_1.Text == "")
                {
                    myglobal.print_log("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    MessageBox.Show("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    chkbx_txn_upd_ask_update_1.Checked = false;
                }
                else if (txtbx_txn_upd_particular_1.Text == "")
                {
                    myglobal.print_log("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    MessageBox.Show("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    chkbx_txn_upd_ask_update_1.Checked = false;
                }
                else if (txtbx_txn_upd_cheque_number_1.Text == "")
                {
                    myglobal.print_log("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box."); 
                    MessageBox.Show("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box.");
                    chkbx_txn_upd_ask_update_1.Checked = false;
                }
                else
                {
                    cmbbx_txn_upd_from_acc_1.Enabled = false;
                    cmbbx_txn_upd_to_acc_1.Enabled = false;
                    txtbx_txn_upd_particular_1.Enabled = false;
                    txtbx_txn_upd_amount_1.Enabled = false;
                    txtbx_txn_upd_cheque_number_1.Enabled = false;
                }
            }
            else
            {
                cmbbx_txn_upd_from_acc_1.Enabled = true;
                cmbbx_txn_upd_to_acc_1.Enabled = true;
                txtbx_txn_upd_particular_1.Enabled = true;
                txtbx_txn_upd_amount_1.Enabled = true;
                txtbx_txn_upd_cheque_number_1.Enabled = true;
            }
            myglobal.print_log("Returning from Function chkbx_txn_upd_ask_update_1_CheckedChanged");
        }

        private void chkbx_txn_upd_ask_update_2_CheckedChanged(object sender, EventArgs e)
        {
            // lock values of that row in form
            myglobal.print_log("Inside Function chkbx_txn_upd_ask_update_2_CheckedChanged");
            if (chkbx_txn_upd_ask_update_2.Checked)
            {
                if (cmbbx_txn_upd_from_acc_2.SelectedIndex == cmbbx_txn_upd_to_acc_2.SelectedIndex)
                {
                    myglobal.print_log("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    MessageBox.Show("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    chkbx_txn_upd_ask_update_2.Checked = false;
                }
                else if ((cmbbx_txn_upd_from_acc_2.SelectedIndex < 1) || (cmbbx_txn_upd_to_acc_2.SelectedIndex < 1))
                {
                    myglobal.print_log(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    MessageBox.Show(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    chkbx_txn_upd_ask_update_2.Checked = false;
                }
                else if (txtbx_txn_upd_amount_2.Text == "")
                {
                    myglobal.print_log("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    MessageBox.Show("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    chkbx_txn_upd_ask_update_2.Checked = false;
                }
                else if (txtbx_txn_upd_particular_2.Text == "")
                {
                    myglobal.print_log("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    MessageBox.Show("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    chkbx_txn_upd_ask_update_2.Checked = false;
                }
                else if (txtbx_txn_upd_cheque_number_2.Text == "")
                {
                    myglobal.print_log("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box."); 
                    MessageBox.Show("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box.");
                    chkbx_txn_upd_ask_update_2.Checked = false;
                }
                else
                {
                    cmbbx_txn_upd_from_acc_2.Enabled = false;
                    cmbbx_txn_upd_to_acc_2.Enabled = false;
                    txtbx_txn_upd_particular_2.Enabled = false;
                    txtbx_txn_upd_amount_2.Enabled = false;
                    txtbx_txn_upd_cheque_number_2.Enabled = false;
                }
            }
            else
            {
                cmbbx_txn_upd_from_acc_2.Enabled = true;
                cmbbx_txn_upd_to_acc_2.Enabled = true;
                txtbx_txn_upd_particular_2.Enabled = true;
                txtbx_txn_upd_amount_2.Enabled = true;
                txtbx_txn_upd_cheque_number_2.Enabled = true;
            }
            myglobal.print_log("Returning from Function chkbx_txn_upd_ask_update_2_CheckedChanged");
        }

        private void chkbx_txn_upd_ask_update_3_CheckedChanged(object sender, EventArgs e)
        {
            // lock values of that row in form
            myglobal.print_log("Inside Function chkbx_txn_upd_ask_update_3_CheckedChanged");
            if (chkbx_txn_upd_ask_update_3.Checked)
            {
                if (cmbbx_txn_upd_from_acc_3.SelectedIndex == cmbbx_txn_upd_to_acc_3.SelectedIndex)
                {
                    myglobal.print_log("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    MessageBox.Show("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    chkbx_txn_upd_ask_update_3.Checked = false;
                }
                else if ((cmbbx_txn_upd_from_acc_3.SelectedIndex < 1) || (cmbbx_txn_upd_to_acc_3.SelectedIndex < 1))
                {
                    myglobal.print_log(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    MessageBox.Show(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    chkbx_txn_upd_ask_update_3.Checked = false;
                }
                else if (txtbx_txn_upd_amount_3.Text == "")
                {
                    myglobal.print_log("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    MessageBox.Show("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    chkbx_txn_upd_ask_update_3.Checked = false;
                }
                else if (txtbx_txn_upd_particular_3.Text == "")
                {
                    myglobal.print_log("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    MessageBox.Show("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    chkbx_txn_upd_ask_update_3.Checked = false;
                }
                else if (txtbx_txn_upd_cheque_number_3.Text == "")
                {
                    myglobal.print_log("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box."); 
                    MessageBox.Show("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box.");
                    chkbx_txn_upd_ask_update_3.Checked = false;
                }
                else
                {
                    cmbbx_txn_upd_from_acc_3.Enabled = false;
                    cmbbx_txn_upd_to_acc_3.Enabled = false;
                    txtbx_txn_upd_particular_3.Enabled = false;
                    txtbx_txn_upd_amount_3.Enabled = false;
                    txtbx_txn_upd_cheque_number_3.Enabled = false;
                }
            }
            else
            {
                cmbbx_txn_upd_from_acc_3.Enabled = true;
                cmbbx_txn_upd_to_acc_3.Enabled = true;
                txtbx_txn_upd_particular_3.Enabled = true;
                txtbx_txn_upd_amount_3.Enabled = true;
                txtbx_txn_upd_cheque_number_3.Enabled = true;
            }
            myglobal.print_log("Returning from Function chkbx_txn_upd_ask_update_3_CheckedChanged");
        }

        private void chkbx_txn_upd_ask_update_4_CheckedChanged(object sender, EventArgs e)
        {
            // lock values of that row in form
            myglobal.print_log("Inside Function chkbx_txn_upd_ask_update_4_CheckedChanged");
            if (chkbx_txn_upd_ask_update_4.Checked)
            {
                if (cmbbx_txn_upd_from_acc_4.SelectedIndex == cmbbx_txn_upd_to_acc_4.SelectedIndex)
                {
                    myglobal.print_log("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    MessageBox.Show("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    chkbx_txn_upd_ask_update_4.Checked = false;
                }
                else if ((cmbbx_txn_upd_from_acc_4.SelectedIndex < 1) || (cmbbx_txn_upd_to_acc_4.SelectedIndex < 1))
                {
                    myglobal.print_log(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    MessageBox.Show(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    chkbx_txn_upd_ask_update_4.Checked = false;
                }
                else if (txtbx_txn_upd_amount_4.Text == "")
                {
                    myglobal.print_log("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    MessageBox.Show("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    chkbx_txn_upd_ask_update_4.Checked = false;
                }
                else if (txtbx_txn_upd_particular_4.Text == "")
                {
                    myglobal.print_log("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    MessageBox.Show("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    chkbx_txn_upd_ask_update_4.Checked = false;
                }
                else if (txtbx_txn_upd_cheque_number_4.Text == "")
                {
                    myglobal.print_log("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box."); 
                    MessageBox.Show("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box.");
                    chkbx_txn_upd_ask_update_4.Checked = false;
                }
                else
                {
                    cmbbx_txn_upd_from_acc_4.Enabled = false;
                    cmbbx_txn_upd_to_acc_4.Enabled = false;
                    txtbx_txn_upd_particular_4.Enabled = false;
                    txtbx_txn_upd_amount_4.Enabled = false;
                    txtbx_txn_upd_cheque_number_4.Enabled = false;
                }
            }
            else
            {
                cmbbx_txn_upd_from_acc_4.Enabled = true;
                cmbbx_txn_upd_to_acc_4.Enabled = true;
                txtbx_txn_upd_particular_4.Enabled = true;
                txtbx_txn_upd_amount_4.Enabled = true;
                txtbx_txn_upd_cheque_number_4.Enabled = true;
            }
            myglobal.print_log("Returning from Function chkbx_txn_upd_ask_update_4_CheckedChanged");
        }

        private void chkbx_txn_upd_ask_update_5_CheckedChanged(object sender, EventArgs e)
        {
            // lock values of that row in form
            myglobal.print_log("Inside Function chkbx_txn_upd_ask_update_5_CheckedChanged");
            if (chkbx_txn_upd_ask_update_5.Checked)
            {
                if (cmbbx_txn_upd_from_acc_5.SelectedIndex == cmbbx_txn_upd_to_acc_5.SelectedIndex)
                {
                    myglobal.print_log("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    MessageBox.Show("FromAccount and ToAccount cannot be same.\nPlease select proper Accounts and reselect Update box.");
                    chkbx_txn_upd_ask_update_5.Checked = false;
                }
                else if ((cmbbx_txn_upd_from_acc_5.SelectedIndex < 1) || (cmbbx_txn_upd_to_acc_5.SelectedIndex < 1))
                {
                    myglobal.print_log(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    MessageBox.Show(" From Account or To Account is not selected \n\nPlease Select Proper Account and reselect Update box.");
                    chkbx_txn_upd_ask_update_5.Checked = false;
                }
                else if (txtbx_txn_upd_amount_5.Text == "")
                {
                    myglobal.print_log("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    MessageBox.Show("Amount field cannot be empty.\nPlease Provide proper Amount and reselect Update box.");
                    chkbx_txn_upd_ask_update_5.Checked = false;
                }
                else if (txtbx_txn_upd_particular_5.Text == "")
                {
                    myglobal.print_log("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    MessageBox.Show("Particulars field cannot be empty.\nPlease Provide proper Particulars and reselect Update box.");
                    chkbx_txn_upd_ask_update_5.Checked = false;
                }
                else if (txtbx_txn_upd_cheque_number_5.Text == "")
                {
                    myglobal.print_log("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box.");
                    MessageBox.Show("Cheque field cannot be empty.\nPlease Provide proper Cheque number or write CASH and reselect Update box.");
                    chkbx_txn_upd_ask_update_5.Checked = false;
                }
                else
                {
                    cmbbx_txn_upd_from_acc_5.Enabled = false;
                    cmbbx_txn_upd_to_acc_5.Enabled = false;
                    txtbx_txn_upd_particular_5.Enabled = false;
                    txtbx_txn_upd_amount_5.Enabled = false;
                    txtbx_txn_upd_cheque_number_5.Enabled = false;
                }
            }
            else
            {
                cmbbx_txn_upd_from_acc_5.Enabled = true;
                cmbbx_txn_upd_to_acc_5.Enabled = true;
                txtbx_txn_upd_particular_5.Enabled = true;
                txtbx_txn_upd_amount_5.Enabled = true;
                txtbx_txn_upd_cheque_number_5.Enabled = true;
            }
            myglobal.print_log("Returning from Function chkbx_txn_upd_ask_update_5_CheckedChanged");
        }

        private void btn_txn_upd_reset_Click(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function btn_txn_upd_reset_Click");
            cmbbx_txn_upd_from_acc_1.Enabled = true;
            cmbbx_txn_upd_to_acc_1.Enabled = true;
            txtbx_txn_upd_particular_1.Enabled = true;
            txtbx_txn_upd_amount_1.Enabled = true;
            txtbx_txn_upd_cheque_number_1.Enabled = true;
            chkbx_txn_upd_ask_update_1.Enabled = true;
            cmbbx_txn_upd_to_acc_1.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_1.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_1.Text = "";
            txtbx_txn_upd_cheque_number_1.Text = "";
            txtbx_txn_upd_particular_1.Text = "";
            chkbx_txn_upd_ask_update_1.Checked = false;
            cmbbx_txn_upd_from_acc_2.Enabled = true;
            cmbbx_txn_upd_to_acc_2.Enabled = true;
            txtbx_txn_upd_particular_2.Enabled = true;
            txtbx_txn_upd_amount_2.Enabled = true;
            txtbx_txn_upd_cheque_number_2.Enabled = true;
            chkbx_txn_upd_ask_update_2.Enabled = true;
            cmbbx_txn_upd_to_acc_2.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_2.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_2.Text = "";
            txtbx_txn_upd_cheque_number_2.Text = "";
            txtbx_txn_upd_particular_2.Text = "";
            chkbx_txn_upd_ask_update_2.Checked = false;
            cmbbx_txn_upd_from_acc_3.Enabled = true;
            cmbbx_txn_upd_to_acc_3.Enabled = true;
            txtbx_txn_upd_particular_3.Enabled = true;
            txtbx_txn_upd_amount_3.Enabled = true;
            txtbx_txn_upd_cheque_number_3.Enabled = true;
            chkbx_txn_upd_ask_update_3.Enabled = true;
            cmbbx_txn_upd_to_acc_3.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_3.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_3.Text = "";
            txtbx_txn_upd_cheque_number_3.Text = "";
            txtbx_txn_upd_particular_3.Text = "";
            chkbx_txn_upd_ask_update_3.Checked = false;
            cmbbx_txn_upd_from_acc_4.Enabled = true;
            cmbbx_txn_upd_to_acc_4.Enabled = true;
            txtbx_txn_upd_particular_4.Enabled = true;
            txtbx_txn_upd_amount_4.Enabled = true;
            txtbx_txn_upd_cheque_number_4.Enabled = true;
            chkbx_txn_upd_ask_update_4.Enabled = true;
            cmbbx_txn_upd_to_acc_4.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_4.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_4.Text = "";
            txtbx_txn_upd_cheque_number_4.Text = "";
            txtbx_txn_upd_particular_4.Text = "";
            chkbx_txn_upd_ask_update_4.Checked = false;
            cmbbx_txn_upd_from_acc_5.Enabled = true;
            cmbbx_txn_upd_to_acc_5.Enabled = true;
            txtbx_txn_upd_particular_5.Enabled = true;
            txtbx_txn_upd_amount_5.Enabled = true;
            txtbx_txn_upd_cheque_number_5.Enabled = true;
            chkbx_txn_upd_ask_update_5.Enabled = true;
            cmbbx_txn_upd_to_acc_5.SelectedIndex = 0;// commentedText = "Select To Account";
            cmbbx_txn_upd_from_acc_5.SelectedIndex = 0;// commentedText = "Select From Account";
            txtbx_txn_upd_amount_5.Text = "";
            txtbx_txn_upd_cheque_number_5.Text = "";
            txtbx_txn_upd_particular_5.Text = "";
            chkbx_txn_upd_ask_update_5.Checked = false;
            myglobal.print_log("Returning from Function btn_txn_upd_reset_Click");
        }

        private void btn_txn_upd_update_transaction_Click(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function btn_txn_upd_update_transaction_Click");
            byte count_check = 0;
            if (chkbx_txn_upd_ask_update_1.Checked)
            {
                myglobal.print_log("chkbx_txn_upd_ask_update_1.Checked");
                // insert values for txn
                this.frm_create_mysql_string(cmbbx_txn_upd_from_acc_1.SelectedValue.ToString(), cmbbx_txn_upd_to_acc_1.SelectedValue.ToString(), txtbx_txn_upd_particular_1.Text, txtbx_txn_upd_cheque_number_1.Text, txtbx_txn_upd_amount_1.Text,cmbbx_txn_upd_from_acc_1.Text,cmbbx_txn_upd_to_acc_1.Text);
                //MessageBox.Show("Records for Transaction number 1 is updated Succesfully");
                chkbx_txn_upd_ask_update_1.Enabled = false;
                chkbx_txn_upd_ask_update_1.Checked = false;
                count_check++;
            }
            if (chkbx_txn_upd_ask_update_2.Checked)
            {
                myglobal.print_log("chkbx_txn_upd_ask_update_2.Checked");
                // insert values for txn
                this.frm_create_mysql_string(cmbbx_txn_upd_from_acc_2.SelectedValue.ToString(), cmbbx_txn_upd_to_acc_2.SelectedValue.ToString(), txtbx_txn_upd_particular_2.Text, txtbx_txn_upd_cheque_number_2.Text, txtbx_txn_upd_amount_2.Text, cmbbx_txn_upd_from_acc_2.Text, cmbbx_txn_upd_to_acc_2.Text);
                //MessageBox.Show("Records for Transaction number 2 is updated Succesfully");
                chkbx_txn_upd_ask_update_2.Enabled = false;
                chkbx_txn_upd_ask_update_2.Checked = false;
                count_check++;
            }
            if (chkbx_txn_upd_ask_update_3.Checked)
            {
                myglobal.print_log("chkbx_txn_upd_ask_update_3.Checked");
                // insert values for txn
                this.frm_create_mysql_string(cmbbx_txn_upd_from_acc_3.SelectedValue.ToString(), cmbbx_txn_upd_to_acc_3.SelectedValue.ToString(), txtbx_txn_upd_particular_3.Text, txtbx_txn_upd_cheque_number_3.Text, txtbx_txn_upd_amount_3.Text, cmbbx_txn_upd_from_acc_3.Text, cmbbx_txn_upd_to_acc_3.Text);
                //MessageBox.Show("Records for Transaction number 3 is updated Succesfully");
                chkbx_txn_upd_ask_update_3.Enabled = false;
                chkbx_txn_upd_ask_update_3.Checked = false;
                count_check++;
            }
            if (chkbx_txn_upd_ask_update_4.Checked)
            {
                myglobal.print_log("chkbx_txn_upd_ask_update_4.Checked");
                // insert values for txn
                this.frm_create_mysql_string(cmbbx_txn_upd_from_acc_4.SelectedValue.ToString(), cmbbx_txn_upd_to_acc_4.SelectedValue.ToString(), txtbx_txn_upd_particular_4.Text, txtbx_txn_upd_cheque_number_4.Text, txtbx_txn_upd_amount_4.Text, cmbbx_txn_upd_from_acc_4.Text, cmbbx_txn_upd_to_acc_4.Text);
                //MessageBox.Show("Records for Transaction number 4 is updated Succesfully");
                chkbx_txn_upd_ask_update_4.Enabled = false;
                chkbx_txn_upd_ask_update_4.Checked = false;
                count_check++;
            }
            if (chkbx_txn_upd_ask_update_5.Checked)
            {
                myglobal.print_log("chkbx_txn_upd_ask_update_5.Checked");
                // insert values for txn
                this.frm_create_mysql_string(cmbbx_txn_upd_from_acc_5.SelectedValue.ToString(), cmbbx_txn_upd_to_acc_5.SelectedValue.ToString(), txtbx_txn_upd_particular_5.Text, txtbx_txn_upd_cheque_number_5.Text, txtbx_txn_upd_amount_5.Text, cmbbx_txn_upd_from_acc_5.Text, cmbbx_txn_upd_to_acc_5.Text);
                //MessageBox.Show("Records for Transaction number 5 is updated Succesfully");
                chkbx_txn_upd_ask_update_5.Enabled = false;
                chkbx_txn_upd_ask_update_5.Checked = false;
                count_check++;
            }
            if (count_check == 0)
            {
                myglobal.print_log("Please select checkbox before update transaction");
                MessageBox.Show("Please select checkbox before update transaction");
            }
            else
            {
                myglobal.print_log(" " + count_check.ToString() + " Records of Transaction are updated Succesfully");
                MessageBox.Show(" " + count_check.ToString() + " Records of Transaction are updated Succesfully");
            }
            myglobal.print_log("Returning from Function btn_txn_upd_update_transaction_Click");
        }

        private void frm_transaction_update_FormClosed(object sender, FormClosedEventArgs e)
        {
            myglobal.print_log("Inside Function frm_transaction_update_FormClosed");
            try
            {
                frm_txnupd_connection.Close();
            }
            catch (Exception errclose)
            {
                myglobal.print_log("Connection cannot be close because " + errclose.Message + "");
                MessageBox.Show("Connection cannot be close because " + errclose.Message + "");
            }
        }
    }
}
