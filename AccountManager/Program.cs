using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace AccountManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_main_parent_screen());
        }
    }

    public class MyGlobals
    {
        public DateTime datetimelocal;
        public string time_str;

        public void print_log(string str)
        {
            datetimelocal = DateTime.Now;
            StreamWriter file = new StreamWriter("C:\\Documents\\Logs\\AccountManager_" + datetimelocal.Year.ToString() + "" + datetimelocal.Month.ToString() + "" + datetimelocal.Day.ToString() + ".log", true);
            time_str = datetimelocal.Year.ToString() + "-" + datetimelocal.Month.ToString() + "-" + datetimelocal.Day.ToString() + " " + datetimelocal.Hour.ToString() + ":" + datetimelocal.Minute.ToString() + ":" + datetimelocal.Second.ToString() + ":" + datetimelocal.Millisecond.ToString();
            file.WriteLine( time_str + "\t-> " + str);
            file.Flush();
            file.Close();
        }

        /// Encrypts a file using Rijndael algorithm.
        public void EncryptFile(string inputString, string outputFile, string password )
        {

            try
            {
                //string password = @"myKey123"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                int data = 0;
                int strlen = inputString.Length;
                while (data < strlen)
                {
                    cs.WriteByte((byte)inputString[data]);
                    data = data + 1;
                }

                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Encryption failed!", "Error");
                this.print_log("Encryption failed!" + exp.Message);
            }
        }
        
        /// Decrypts a file using Rijndael algorithm.
        public String DecryptFile(string inputFile, string password)
        {
            try
            {
                //string password = @"myKey123"; // Your Key Here
                string decrypted_text;
                var builder = new StringBuilder();
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    builder.Append((char)data);
                decrypted_text = builder.ToString();
                cs.Close();
                fsCrypt.Close();
                return (decrypted_text);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Decryption failed!", "Error");
                this.print_log("Decryption failed!" + exp.Message);
                return ("FAILURE");
            }
        }

        public string returnMacAddress()
        {
            /* this function return all mac addresses */
            string macAddresses = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                        macAddresses += nic.GetPhysicalAddress().ToString() + ";";
                    }
                }
            }
            return (macAddresses);
        }

        /*
        public string time_in_str()
        { 
            //print time in current format
            datetimelocal = DateTime.Now;
            time_str = datetimelocal.Year.ToString() + "-" + datetimelocal.Month.ToString() + "-" + datetimelocal.Day.ToString() + " " + datetimelocal.Hour.ToString() + ":" + datetimelocal.Minute.ToString() + ":" + datetimelocal.Second.ToString() + ":" + datetimelocal.Millisecond.ToString();
            return (time_str);
        }

        public string date_in_string()
        {
            datetimelocal = DateTime.Today;
            time_str = datetimelocal.Year.ToString() + "" + datetimelocal.Month.ToString() + "" + datetimelocal.Day.ToString();
            return (time_str);
        }
         */
    }
}
