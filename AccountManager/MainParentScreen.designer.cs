namespace AccountManager
{
    partial class frm_main_parent_screen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main_parent_screen));
            this.btn_main_scr_acc_mgmt = new System.Windows.Forms.Button();
            this.btn_main_scr_upd_txn = new System.Windows.Forms.Button();
            this.btn_main_scr_acc_txn_dtls = new System.Windows.Forms.Button();
            this.pictbx_mnprntscr_logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictbx_mnprntscr_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_main_scr_acc_mgmt
            // 
            this.btn_main_scr_acc_mgmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_main_scr_acc_mgmt.Location = new System.Drawing.Point(12, 467);
            this.btn_main_scr_acc_mgmt.Name = "btn_main_scr_acc_mgmt";
            this.btn_main_scr_acc_mgmt.Size = new System.Drawing.Size(240, 23);
            this.btn_main_scr_acc_mgmt.TabIndex = 1;
            this.btn_main_scr_acc_mgmt.Text = "Account Manager";
            this.btn_main_scr_acc_mgmt.UseVisualStyleBackColor = true;
            this.btn_main_scr_acc_mgmt.Click += new System.EventHandler(this.btn_main_scr_acc_mgmt_Click);
            // 
            // btn_main_scr_upd_txn
            // 
            this.btn_main_scr_upd_txn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_main_scr_upd_txn.Location = new System.Drawing.Point(277, 467);
            this.btn_main_scr_upd_txn.Name = "btn_main_scr_upd_txn";
            this.btn_main_scr_upd_txn.Size = new System.Drawing.Size(240, 23);
            this.btn_main_scr_upd_txn.TabIndex = 2;
            this.btn_main_scr_upd_txn.Text = "Update Transaction";
            this.btn_main_scr_upd_txn.UseVisualStyleBackColor = true;
            this.btn_main_scr_upd_txn.Click += new System.EventHandler(this.btn_main_scr_upd_txn_Click);
            // 
            // btn_main_scr_acc_txn_dtls
            // 
            this.btn_main_scr_acc_txn_dtls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_main_scr_acc_txn_dtls.Location = new System.Drawing.Point(542, 467);
            this.btn_main_scr_acc_txn_dtls.Name = "btn_main_scr_acc_txn_dtls";
            this.btn_main_scr_acc_txn_dtls.Size = new System.Drawing.Size(240, 23);
            this.btn_main_scr_acc_txn_dtls.TabIndex = 3;
            this.btn_main_scr_acc_txn_dtls.Text = "Account Transaction Details";
            this.btn_main_scr_acc_txn_dtls.UseVisualStyleBackColor = true;
            this.btn_main_scr_acc_txn_dtls.Click += new System.EventHandler(this.btn_main_scr_acc_txn_dtls_Click);
            // 
            // pictbx_mnprntscr_logo
            // 
            this.pictbx_mnprntscr_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictbx_mnprntscr_logo.Image")));
            this.pictbx_mnprntscr_logo.Location = new System.Drawing.Point(12, 12);
            this.pictbx_mnprntscr_logo.Name = "pictbx_mnprntscr_logo";
            this.pictbx_mnprntscr_logo.Size = new System.Drawing.Size(60, 77);
            this.pictbx_mnprntscr_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictbx_mnprntscr_logo.TabIndex = 4;
            this.pictbx_mnprntscr_logo.TabStop = false;
            // 
            // frm_main_parent_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(795, 502);
            this.Controls.Add(this.pictbx_mnprntscr_logo);
            this.Controls.Add(this.btn_main_scr_acc_txn_dtls);
            this.Controls.Add(this.btn_main_scr_upd_txn);
            this.Controls.Add(this.btn_main_scr_acc_mgmt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_main_parent_screen";
            this.Text = "MainParentScreen";
            this.Load += new System.EventHandler(this.frm_main_parent_screen_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_main_parent_screen_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictbx_mnprntscr_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_main_scr_acc_mgmt;
        private System.Windows.Forms.Button btn_main_scr_upd_txn;
        private System.Windows.Forms.Button btn_main_scr_acc_txn_dtls;
        private System.Windows.Forms.PictureBox pictbx_mnprntscr_logo;
    }
}