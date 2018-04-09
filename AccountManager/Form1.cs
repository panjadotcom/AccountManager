using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
//using Excel = Microsoft.Office.Interop.Excel;
//using System.Xml;

namespace AccountManager
{
    public partial class frm_accmgr_main : Form
    {
        static string frm_accmgr_constring = ConfigurationSettings.AppSettings["constr"];
        MySqlConnection frm_accmgr_connection = new MySqlConnection(frm_accmgr_constring);
        static Boolean validate_text_box_flag = false;
        MyGlobals myglobal = new MyGlobals();

        public frm_accmgr_main()
        {
            InitializeComponent();
        }

        private void frm_accmgr_main_Load(object sender, EventArgs e)
        {
            myglobal.print_log("inside Function frm_accmgr_main_Load");
            try
            {
                frm_accmgr_connection.Open();
                myglobal.print_log("DB Connection opened successfully");
            }
            catch (Exception exp)
            {
                myglobal.print_log("Exception occurs while opening DB Connection is " + exp.Message);
                MessageBox.Show("Exception occurs while opening DB Connection is " + exp.Message);
            }
            txtbx_acc_comment.Text = "Add Comment";
            txtbx_acc_location.Text = "";
            txtbx_acc_name.Text = "";
            txtbx_acc_owner.Text = "";
            txtbx_acc_phone.Text = "";
            MySqlCommand mysql_command = frm_accmgr_connection.CreateCommand();
            

            mysql_command.Connection = frm_accmgr_connection;
            try
            {
                mysql_command.CommandText = "CREATE TABLE AccountProfile(AccId SMALLINT AUTO_INCREMENT, AccName varchar(255) NOT NULL UNIQUE, AccOwner varchar(255) NOT NULL, AccPhoneNumber varchar(255) NOT NULL, AccLocation varchar(255) NOT NULL, AccAddedOn TIMESTAMP, AccState char(1) DEFAULT 'A', AccComments varchar(1000) default NULL, AccBalance DECIMAL(13,2) DEFAULT 0.00, PRIMARY KEY ( AccId ) )";
                mysql_command.ExecuteNonQuery();
                myglobal.print_log(mysql_command.CommandText + " executed successfully");
                mysql_command.CommandText = "INSERT INTO `AccountProfile` (`AccName`, `AccOwner`, `AccPhoneNumber`, `AccLocation`,`AccComments`) VALUES ( 'Select Account' , 'Owner' , 'PhoneNumber' , 'Location' , 'Comments' )";
                mysql_command.ExecuteNonQuery();
                myglobal.print_log(mysql_command.CommandText + " executed successfully");
                mysql_command.CommandText = "INSERT INTO `AccountProfile` (`AccName`, `AccOwner`, `AccPhoneNumber`, `AccLocation`,`AccComments`) VALUES ( 'NONE' , 'Admin' , 'PhoneNumber' , 'Location' , 'This Account entry is for One way transactions only' )";
                mysql_command.ExecuteNonQuery();
                myglobal.print_log(mysql_command.CommandText + " executed successfully");
                mysql_command.CommandText = "CREATE TABLE IF NOT EXISTS `Transaction_Info` ( TxnId SMALLINT AUTO_INCREMENT, TxnDate TIMESTAMP, TxnFromAcc varchar(255) NOT NULL, TxnToAcc varchar(255) NOT NULL, TxnParticulars varchar(1000) DEFAULT NULL, TxnCheaqueNumber varchar(25) NOT NULL DEFAULT 'CASH', TxnAmount DECIMAL(13,2) UNSIGNED DEFAULT NULL, PRIMARY KEY ( TxnId ) )";
                mysql_command.ExecuteNonQuery();
                myglobal.print_log(mysql_command.CommandText + " executed successfully");
                myglobal.print_log("BMD Data created successfully");
            }
            catch (Exception create)
            {
                myglobal.print_log("Exception occurs while creating BMD data as " + create.Message);
            }
        }

        private void frm_accmgr_main_validate_textbox_values()
        {
            //Validate Text Boxes
            myglobal.print_log("Inside Function frm_accmgr_main_validate_textbox_values");
            validate_text_box_flag = false;
            if (txtbx_acc_name.Text == "")
            {
                myglobal.print_log("Account's Name Field Cannot be Empty.\n\n Provide Proper Name");
                MessageBox.Show("Account's Name Field Cannot be Empty.\n\n Provide Proper Name");
                return;
            }
            else
            {
                myglobal.print_log("txtbx_acc_name.Text = " + txtbx_acc_name.Text);
            }

            if (txtbx_acc_owner.Text == "")
            {
                myglobal.print_log("Account's Owner Field Cannot be Empty. Provide Proper Owner");
                MessageBox.Show("Account's Owner Field Cannot be Empty.\n\n Provide Proper Owner");
                return;
            }
            else
            {
                myglobal.print_log("txtbx_acc_owner.Text = " + txtbx_acc_owner.Text );
            }

            if (txtbx_acc_phone.Text == "")
            {
                myglobal.print_log("Account's Phone Field Cannot be Empty.\n\n Provide Proper Phone Number");
                MessageBox.Show("Account's Phone Field Cannot be Empty.\n\n Provide Proper Phone Number");
                return;
            }
            else
            {
                myglobal.print_log("txtbx_acc_phone.Text = " + txtbx_acc_phone.Text );
            }

            if (txtbx_acc_location.Text == "")
            {
                myglobal.print_log("Account's Location Field Cannot be Empty.\n\n Provide Proper Location"); 
                MessageBox.Show("Account's Location Field Cannot be Empty.\n\n Provide Proper Location");
                return;
            }
            else
            {
                myglobal.print_log("txtbx_acc_location.Text = " + txtbx_acc_location.Text );
            }

            validate_text_box_flag = true;
            myglobal.print_log("frm_accmgr_main_validate_textbox_values returning with success");
        }

        private void btn_acc_add_Click(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function btn_acc_add_Click");
            String index;
            Int16 index_int;
            this.frm_accmgr_main_validate_textbox_values();
            if (validate_text_box_flag)
            {
                txtbx_acc_name.Enabled = false;
                txtbx_acc_owner.Enabled = false;
                txtbx_acc_phone.Enabled = false;
                txtbx_acc_location.Enabled = false;
                txtbx_acc_comment.Enabled = false;
                try
                {
                    MySqlCommand mysql_command = frm_accmgr_connection.CreateCommand();
                    mysql_command.Connection = frm_accmgr_connection;
                    mysql_command.CommandType = CommandType.Text;
                    string sql_nonquery_command = "INSERT INTO `AccountProfile` (`AccName`, `AccOwner`, `AccPhoneNumber`, `AccLocation`,`AccComments`) VALUES ( @AccName_var , @AccOwner_var , @AccPhoneNumber_var , @AccLocation_var , @AccComments_var )";
                    mysql_command.CommandText = sql_nonquery_command;
                    mysql_command.Prepare();
                    mysql_command.Parameters.AddWithValue("@AccName_var", txtbx_acc_name.Text);
                    mysql_command.Parameters["@AccName_var"].Value = txtbx_acc_name.Text;
                    mysql_command.Parameters.AddWithValue("@AccOwner_var", txtbx_acc_owner.Text);
                    mysql_command.Parameters["@AccOwner_var"].Value = txtbx_acc_owner.Text;
                    mysql_command.Parameters.AddWithValue("@AccPhoneNumber_var", txtbx_acc_phone.Text);
                    mysql_command.Parameters["@AccPhoneNumber_var"].Value = txtbx_acc_phone.Text;
                    mysql_command.Parameters.AddWithValue("@AccLocation_var", txtbx_acc_location.Text);
                    mysql_command.Parameters["@AccLocation_var"].Value = txtbx_acc_location.Text;
                    mysql_command.Parameters.AddWithValue("@AccComments_var", txtbx_acc_comment.Text);
                    mysql_command.Parameters["@AccComments_var"].Value = txtbx_acc_comment.Text;
                    mysql_command.ExecuteNonQuery();
                    myglobal.print_log("Command " + mysql_command.CommandText + " Executed Successfully");
                    mysql_command.CommandText = "SELECT count(*) FROM `AccountProfile`";
                    index_int = Convert.ToInt16(mysql_command.ExecuteScalar());
                    myglobal.print_log("Command " + mysql_command.CommandText + " returns " + index_int.ToString());
                    if (index_int > 0 && index_int < 10)
                        index = "00" + Convert.ToString(index_int);
                    else if (index_int >= 10 && index_int < 100)
                        index = "0" + Convert.ToString(index_int);
                    else
                        index = Convert.ToString(index_int);
                    sql_nonquery_command = "CREATE TABLE IF NOT EXISTS Transaction_" + index + " ( TxnId SMALLINT AUTO_INCREMENT, TxnDate TIMESTAMP, TxnOtherAcc SMALLINT NOT NULL, TxnFromAcc varchar(255) NOT NULL, TxnToAcc varchar(255) NOT NULL, TxnParticulars varchar(1000) DEFAULT NULL, TxnCheaqueNumber varchar(25) NOT NULL DEFAULT 'CASH', TxnCredited DECIMAL(13,2) UNSIGNED DEFAULT NULL, TxnDebited DECIMAL(13,2) UNSIGNED DEFAULT NULL, PRIMARY KEY ( TxnId ), FOREIGN KEY (TxnOtherAcc) REFERENCES Transaction_Info(TxnId) ON DELETE CASCADE  )";
                    mysql_command.CommandText = sql_nonquery_command;
                    mysql_command.ExecuteNonQuery();
                    myglobal.print_log("Command " + mysql_command.CommandText + " Executed Successfully");
                    myglobal.print_log("New Account Created Successfuly with Account Index of " + index);
                    MessageBox.Show("New Account Created Successfuly");
                    btn_acc_add.Enabled = false;
                    btn_acc_reset.Text = "Add More";
                }
                catch (Exception addacc)
                {
                    myglobal.print_log("New Account cannot be created because " + addacc.Message + "\n\n\n Provide Proper Details of the account or Database");
                    MessageBox.Show("New Account cannot be created because " + addacc.Message + "\n\n\n Provide Proper Details of the account or Database");
                }
            }
        }

        private void btn_acc_reset_Click(object sender, EventArgs e)
        {
            myglobal.print_log("Inside Function btn_acc_reset_Click");
            txtbx_acc_comment.Enabled = true;
            txtbx_acc_location.Enabled = true;
            txtbx_acc_name.Enabled = true;
            txtbx_acc_owner.Enabled = true;
            txtbx_acc_phone.Enabled = true;
            btn_acc_add.Enabled = true;

            txtbx_acc_comment.Text = "Add Comment";
            txtbx_acc_location.Text = "";
            txtbx_acc_name.Text = "";
            txtbx_acc_owner.Text = "";
            txtbx_acc_phone.Text = "";
            btn_acc_reset.Text = "Reset";
        }

        private void frm_accmgr_main_Closed(object sender, FormClosedEventArgs e)
        {
            myglobal.print_log("Inside Function frm_accmgr_main_Closed");
            try
            {
                frm_accmgr_connection.Close();
            }
            catch (Exception exp)
            {
                myglobal.print_log("Connection cannot be closed because " + exp.Message);
                MessageBox.Show("Connection cannot be closed because " + exp.Message);
            }
        }
    }
}
