using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AccountManager
{
    public partial class frm_main_parent_screen : Form
    {
        static Boolean acc_mgmt_flag = false;
        static Boolean upd_txn_flag = false;
        static Boolean acc_txn_dtls_flag = false;
        MyGlobals myglobal = new MyGlobals();
        public frm_main_parent_screen()
        {
            InitializeComponent();
        }

        private Boolean validate_license_file()
        {
            Boolean valid_lic = false;
            /* validating method call here */
            string version;
            string exp_year;
            string exp_month;
            string exp_day;
            int no_of_mac;
            string[] mac_in_lic = new string[5];
            DateTime date_today = DateTime.Today;
            //DateTime date_license = DateTime.Today;
            var builder = new StringBuilder();
            string macAddr = myglobal.returnMacAddress();
            myglobal.print_log("Mac Adress of the machine returned by returnMacAddress() are " + macAddr + "");
            //string licenseContent = myglobal.DecryptFile("C:\\Documents\\LICENSE.txt", "PANJADOTCOM");
            string licenseContent = myglobal.DecryptFile("C:\\Documents\\LICENSE.DAT", "PANJA123");
            myglobal.print_log("License Content of the machine returned by DecryptFile() are " + licenseContent + "");
            /*
             VERSION=ACCMNGR1_1_1.1_1;EXP_YEAR=2013;EXP_MONTH=12;EXP_DAY=31;NO_OF_MAC=3;MAC1=28924A486665;MAC2=08EDB973F0BD;MAC3=08EDB973F0BC;
             012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678
             000000000011111111112222222222333333333344444444445555555555666666666677777777778888888888999999999900000000001111111111222222222
             000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000011111111111111111111111111111
             */
            for (int i = 8; i < 24; i++)
            {
                builder.Append(licenseContent[i]);
            }
            version = builder.ToString();
            builder = new StringBuilder();
            for (int i = 34; i < 38; i++)
            {
                builder.Append(licenseContent[i]);
            }
            exp_year = builder.ToString();
            //date_license.Year = Convert.ToInt32(exp_year);
            builder = new StringBuilder();
            for (int i = 49; i < 51; i++)
            {
                builder.Append(licenseContent[i]);
            }
            exp_month = builder.ToString();
            //date_license.Month = Convert.ToInt32(exp_month);
            builder = new StringBuilder();
            for (int i = 60; i < 62; i++)
            {
                builder.Append(licenseContent[i]);
            }
            exp_day = builder.ToString();
            //date_license.Day = Convert.ToInt32(exp_day);
            no_of_mac = licenseContent[73] - '0';
            if (no_of_mac > 0)
            {
                builder = new StringBuilder();
                for (int i = 80; i < 92; i++)
                {
                    builder.Append(licenseContent[i]);
                }
                mac_in_lic[0] = builder.ToString();
            }
            if (no_of_mac > 1)
            {
                builder = new StringBuilder();
                for (int i = 98; i < 110; i++)
                {
                    builder.Append(licenseContent[i]);
                }
                mac_in_lic[1] = builder.ToString();
            }
            if (no_of_mac > 2)
            {
                builder = new StringBuilder();
                for (int i = 116; i < 128; i++)
                {
                    builder.Append(licenseContent[i]);
                }
                mac_in_lic[2] = builder.ToString();
            }
            /*
             * validate mac first
             */
            builder = new StringBuilder();
            valid_lic = false;
            for (int i = 0; i < macAddr.Length; i++)
            {
                if (macAddr[i] == ';')
                {
                    // new mac address starts and older mac need to be verified
                    for (int j = 0; j < no_of_mac; j++)
                    {
                        if (mac_in_lic[j].Equals(builder.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            valid_lic = true;
                        }
                    }
                    if (valid_lic)
                        break;
                    else
                        builder = new StringBuilder();
                }
                else
                {
                    builder.Append(macAddr[i]);
                }
            }
            if (valid_lic)
            {
                myglobal.print_log("Mac Addr is Valid");
            }
            else
            {
                for (int j = 0; j < no_of_mac; j++)
                {
                    if (mac_in_lic[j].Equals("FFFFFFFFFFFF", StringComparison.OrdinalIgnoreCase))
                    {
                        myglobal.print_log("License is Valid for Trial Version");
                        valid_lic = true;
                    }
                }
                if (valid_lic)
                {
                    myglobal.print_log("Mac Addr is FOR DEMO");
                }
                else
                {
                    myglobal.print_log("Mac Addr is Not Valid");
                    MessageBox.Show("License is not Valid for this Machine");
                    return (false);
                }
            }
            /* validating Version */
            if (version.Equals("ACCMNGR1_1_1.1_1", StringComparison.OrdinalIgnoreCase))
            {
                myglobal.print_log("Version in License is Valid");
            }
            else
            {
                myglobal.print_log("Version in License is Not Valid");
                MessageBox.Show("License is not Valid for this Version of Application");
                return (false);
            }
            /* validating Date of the license */
            if (Convert.ToInt32(date_today.Year) > Convert.ToInt32(exp_year))
            {
                myglobal.print_log("License is Expired on " + exp_year + "-" + exp_month + "-" + exp_day + "");
                MessageBox.Show("License is Expired on " + exp_year + "-" + exp_month + "-" + exp_day + "");
                return (false);
            }
            if (Convert.ToInt32(date_today.Year) == Convert.ToInt32(exp_year))
            {
                if (Convert.ToInt32(date_today.Month) > Convert.ToInt32(exp_month))
                {
                    myglobal.print_log("License is Expired on " + exp_year + "-" + exp_month + "-" + exp_day + "");
                    MessageBox.Show("License is Expired on " + exp_year + "-" + exp_month + "-" + exp_day + "");
                    return (false);
                }
                if (Convert.ToInt32(date_today.Month) == Convert.ToInt32(exp_month))
                {
                    if (Convert.ToInt32(date_today.Day) > Convert.ToInt32(exp_day))
                    {
                        myglobal.print_log("License is Expired on " + exp_year + "-" + exp_month + "-" + exp_day + "");
                        MessageBox.Show("License is Expired on " + exp_year + "-" + exp_month + "-" + exp_day + "");
                        return (false);
                    }
                    else
                    {
                        myglobal.print_log("License will Expire Soon ie: on " + exp_year + "-" + exp_month + "-" + exp_day + "");
                        MessageBox.Show("License will Expire Soon ie: on " + exp_year + "-" + exp_month + "-" + exp_day + "");
                    }
                }
            }
            myglobal.print_log("License is OK and will Expire on " + exp_year + "-" + exp_month + "-" + exp_day + "");
            return (true);
        }

        private void btn_main_scr_acc_mgmt_Click(object sender, EventArgs e)
        {
            if (acc_mgmt_flag == false)
            {
                myglobal.print_log("btn_main_scr_acc_mgmt_Click Called");
                frm_accmgr_main frm_accmgr_main_new = new frm_accmgr_main();
                //frm_accmgr_main_new.MdiParent = this;
                this.Hide();
                frm_accmgr_main_new.ShowDialog();
                this.Show();
                //frm_accmgr_main_new.Show();
                myglobal.print_log("btn_main_scr_acc_mgmt_Click returning");
            }
        }

        private void btn_main_scr_upd_txn_Click(object sender, EventArgs e)
        {
            if (upd_txn_flag == false)
            {
                myglobal.print_log("btn_main_scr_upd_txn_Click Called");
                frm_transaction_update frm_transaction_update_new = new frm_transaction_update();
                //frm_transaction_update_new.MdiParent = this;
                this.Hide();
                frm_transaction_update_new.ShowDialog();
                this.Show();
                //frm_transaction_update_new.Show();
                myglobal.print_log("btn_main_scr_upd_txn_Click returned");
            }
        }

        private void btn_main_scr_acc_txn_dtls_Click(object sender, EventArgs e)
        {
            if (acc_txn_dtls_flag == false)
            {
                myglobal.print_log("btn_main_scr_acc_txn_dtls_Click Called");
                frm_account_transaction_details frm_account_transaction_details_new = new frm_account_transaction_details();
                //frm_account_transaction_details_new.MdiParent = this;
                this.Hide();
                frm_account_transaction_details_new.ShowDialog();
                this.Show();
                //frm_account_transaction_details_new.Show();
                myglobal.print_log("btn_main_scr_acc_txn_dtls_Click returns");
            }
        }

        private void frm_main_parent_screen_Load(object sender, EventArgs e)
        {
            myglobal.print_log("Programme Started ... ");
            myglobal.print_log("frm_main_parent_screen_Load function Called");
            myglobal.print_log("Validating License File");
            /* Call validate license file */
            Boolean valid_license_flag = validate_license_file();
            if (valid_license_flag)
            {
                myglobal.print_log("License Validated successfully");
                btn_main_scr_acc_mgmt.Visible = true;
                btn_main_scr_acc_txn_dtls.Visible = true;
                btn_main_scr_upd_txn.Visible = true;
            }
            else
            {
                myglobal.print_log("INVALID LICENSE"); 
                MessageBox.Show("INVALID LICENSE Please get the valid license");
                btn_main_scr_acc_mgmt.Visible = false;
                btn_main_scr_acc_txn_dtls.Visible = true;
                btn_main_scr_upd_txn.Visible = false;
            }
        }

        private void frm_main_parent_screen_FormClosed(object sender, FormClosedEventArgs e)
        {
            myglobal.print_log("Program Exiting ...");
            myglobal.print_log("");
            myglobal.print_log("");
            myglobal.print_log("");
        }
    }
}
