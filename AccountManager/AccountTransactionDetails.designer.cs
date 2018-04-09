namespace AccountManager
{
    partial class frm_account_transaction_details
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_account_transaction_details));
            this.dtgrdvu_acc_txn_details = new System.Windows.Forms.DataGridView();
            this.dttmpkr_acctxndtl_from_date = new System.Windows.Forms.DateTimePicker();
            this.dttmpkr_acctxndtl_to_date = new System.Windows.Forms.DateTimePicker();
            this.cmbbx_acctxndtl_account_name = new System.Windows.Forms.ComboBox();
            this.lbl_acctxndtl_select_acc_name = new System.Windows.Forms.Label();
            this.lbl_acctxndtl_select_from_date = new System.Windows.Forms.Label();
            this.lbl_acctxndtl_select_to_date = new System.Windows.Forms.Label();
            this.btn_acctxndtl_show_details = new System.Windows.Forms.Button();
            this.lbl_acctxndtl_opening_balance = new System.Windows.Forms.Label();
            this.lbl_axxtxndtl_closing_balance = new System.Windows.Forms.Label();
            this.lbl_acctxndtl_current_balance = new System.Windows.Forms.Label();
            this.txtbx_acctxndtl_opening_balance = new System.Windows.Forms.TextBox();
            this.txtbx_acctxndtl_current_balance = new System.Windows.Forms.TextBox();
            this.txtbx_acctxndtl_closing_balance = new System.Windows.Forms.TextBox();
            this.txtbx_acctxndtl_transactions = new System.Windows.Forms.TextBox();
            this.lbl_acctxndtl_duration_balance = new System.Windows.Forms.Label();
            this.chkbx_acctxndtl_auto_update = new System.Windows.Forms.CheckBox();
            this.btn_acctxndtl_save_to_file = new System.Windows.Forms.Button();
            this.save_file_dialog_acctxndtl = new System.Windows.Forms.SaveFileDialog();
            this.pictbx_acctxndtls_logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvu_acc_txn_details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictbx_acctxndtls_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgrdvu_acc_txn_details
            // 
            this.dtgrdvu_acc_txn_details.AllowUserToAddRows = false;
            this.dtgrdvu_acc_txn_details.AllowUserToDeleteRows = false;
            this.dtgrdvu_acc_txn_details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrdvu_acc_txn_details.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrdvu_acc_txn_details.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgrdvu_acc_txn_details.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dtgrdvu_acc_txn_details.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgrdvu_acc_txn_details.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdvu_acc_txn_details.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgrdvu_acc_txn_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdvu_acc_txn_details.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgrdvu_acc_txn_details.Location = new System.Drawing.Point(0, 157);
            this.dtgrdvu_acc_txn_details.Name = "dtgrdvu_acc_txn_details";
            this.dtgrdvu_acc_txn_details.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdvu_acc_txn_details.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgrdvu_acc_txn_details.RowHeadersWidth = 40;
            this.dtgrdvu_acc_txn_details.Size = new System.Drawing.Size(958, 390);
            this.dtgrdvu_acc_txn_details.TabIndex = 0;
            // 
            // dttmpkr_acctxndtl_from_date
            // 
            this.dttmpkr_acctxndtl_from_date.Location = new System.Drawing.Point(168, 84);
            this.dttmpkr_acctxndtl_from_date.Name = "dttmpkr_acctxndtl_from_date";
            this.dttmpkr_acctxndtl_from_date.Size = new System.Drawing.Size(200, 20);
            this.dttmpkr_acctxndtl_from_date.TabIndex = 3;
            this.dttmpkr_acctxndtl_from_date.ValueChanged += new System.EventHandler(this.dttmpkr_acctxndtl_from_date_ValueChanged);
            // 
            // dttmpkr_acctxndtl_to_date
            // 
            this.dttmpkr_acctxndtl_to_date.Location = new System.Drawing.Point(168, 131);
            this.dttmpkr_acctxndtl_to_date.Name = "dttmpkr_acctxndtl_to_date";
            this.dttmpkr_acctxndtl_to_date.Size = new System.Drawing.Size(200, 20);
            this.dttmpkr_acctxndtl_to_date.TabIndex = 4;
            this.dttmpkr_acctxndtl_to_date.ValueChanged += new System.EventHandler(this.dttmpkr_acctxndtl_to_date_ValueChanged);
            // 
            // cmbbx_acctxndtl_account_name
            // 
            this.cmbbx_acctxndtl_account_name.FormattingEnabled = true;
            this.cmbbx_acctxndtl_account_name.Location = new System.Drawing.Point(168, 41);
            this.cmbbx_acctxndtl_account_name.Name = "cmbbx_acctxndtl_account_name";
            this.cmbbx_acctxndtl_account_name.Size = new System.Drawing.Size(121, 21);
            this.cmbbx_acctxndtl_account_name.TabIndex = 5;
            this.cmbbx_acctxndtl_account_name.SelectedIndexChanged += new System.EventHandler(this.cmbbx_acctxndtl_account_name_SelectedIndexChanged);
            // 
            // lbl_acctxndtl_select_acc_name
            // 
            this.lbl_acctxndtl_select_acc_name.AutoSize = true;
            this.lbl_acctxndtl_select_acc_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acctxndtl_select_acc_name.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_acctxndtl_select_acc_name.Location = new System.Drawing.Point(54, 43);
            this.lbl_acctxndtl_select_acc_name.Name = "lbl_acctxndtl_select_acc_name";
            this.lbl_acctxndtl_select_acc_name.Size = new System.Drawing.Size(108, 16);
            this.lbl_acctxndtl_select_acc_name.TabIndex = 7;
            this.lbl_acctxndtl_select_acc_name.Text = "Account Name";
            // 
            // lbl_acctxndtl_select_from_date
            // 
            this.lbl_acctxndtl_select_from_date.AutoSize = true;
            this.lbl_acctxndtl_select_from_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acctxndtl_select_from_date.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_acctxndtl_select_from_date.Location = new System.Drawing.Point(37, 86);
            this.lbl_acctxndtl_select_from_date.Name = "lbl_acctxndtl_select_from_date";
            this.lbl_acctxndtl_select_from_date.Size = new System.Drawing.Size(125, 16);
            this.lbl_acctxndtl_select_from_date.TabIndex = 8;
            this.lbl_acctxndtl_select_from_date.Text = "Select Start Date";
            // 
            // lbl_acctxndtl_select_to_date
            // 
            this.lbl_acctxndtl_select_to_date.AutoSize = true;
            this.lbl_acctxndtl_select_to_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acctxndtl_select_to_date.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_acctxndtl_select_to_date.Location = new System.Drawing.Point(40, 133);
            this.lbl_acctxndtl_select_to_date.Name = "lbl_acctxndtl_select_to_date";
            this.lbl_acctxndtl_select_to_date.Size = new System.Drawing.Size(122, 16);
            this.lbl_acctxndtl_select_to_date.TabIndex = 9;
            this.lbl_acctxndtl_select_to_date.Text = "Select End Time";
            // 
            // btn_acctxndtl_show_details
            // 
            this.btn_acctxndtl_show_details.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_acctxndtl_show_details.Location = new System.Drawing.Point(669, 128);
            this.btn_acctxndtl_show_details.Name = "btn_acctxndtl_show_details";
            this.btn_acctxndtl_show_details.Size = new System.Drawing.Size(128, 23);
            this.btn_acctxndtl_show_details.TabIndex = 10;
            this.btn_acctxndtl_show_details.Text = "Show Details";
            this.btn_acctxndtl_show_details.UseVisualStyleBackColor = true;
            this.btn_acctxndtl_show_details.Click += new System.EventHandler(this.btn_acctxndtl_show_details_Click);
            // 
            // lbl_acctxndtl_opening_balance
            // 
            this.lbl_acctxndtl_opening_balance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_acctxndtl_opening_balance.AutoSize = true;
            this.lbl_acctxndtl_opening_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acctxndtl_opening_balance.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_acctxndtl_opening_balance.Location = new System.Drawing.Point(376, 19);
            this.lbl_acctxndtl_opening_balance.Name = "lbl_acctxndtl_opening_balance";
            this.lbl_acctxndtl_opening_balance.Size = new System.Drawing.Size(127, 16);
            this.lbl_acctxndtl_opening_balance.TabIndex = 11;
            this.lbl_acctxndtl_opening_balance.Text = "Opening Balance";
            // 
            // lbl_axxtxndtl_closing_balance
            // 
            this.lbl_axxtxndtl_closing_balance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_axxtxndtl_closing_balance.AutoSize = true;
            this.lbl_axxtxndtl_closing_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_axxtxndtl_closing_balance.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_axxtxndtl_closing_balance.Location = new System.Drawing.Point(525, 19);
            this.lbl_axxtxndtl_closing_balance.Name = "lbl_axxtxndtl_closing_balance";
            this.lbl_axxtxndtl_closing_balance.Size = new System.Drawing.Size(121, 16);
            this.lbl_axxtxndtl_closing_balance.TabIndex = 12;
            this.lbl_axxtxndtl_closing_balance.Text = "Closing Balance";
            // 
            // lbl_acctxndtl_current_balance
            // 
            this.lbl_acctxndtl_current_balance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_acctxndtl_current_balance.AutoSize = true;
            this.lbl_acctxndtl_current_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acctxndtl_current_balance.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_acctxndtl_current_balance.Location = new System.Drawing.Point(528, 106);
            this.lbl_acctxndtl_current_balance.Name = "lbl_acctxndtl_current_balance";
            this.lbl_acctxndtl_current_balance.Size = new System.Drawing.Size(118, 16);
            this.lbl_acctxndtl_current_balance.TabIndex = 13;
            this.lbl_acctxndtl_current_balance.Text = "Current Balance";
            // 
            // txtbx_acctxndtl_opening_balance
            // 
            this.txtbx_acctxndtl_opening_balance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtbx_acctxndtl_opening_balance.Location = new System.Drawing.Point(407, 38);
            this.txtbx_acctxndtl_opening_balance.Name = "txtbx_acctxndtl_opening_balance";
            this.txtbx_acctxndtl_opening_balance.Size = new System.Drawing.Size(65, 20);
            this.txtbx_acctxndtl_opening_balance.TabIndex = 14;
            // 
            // txtbx_acctxndtl_current_balance
            // 
            this.txtbx_acctxndtl_current_balance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtbx_acctxndtl_current_balance.Location = new System.Drawing.Point(555, 128);
            this.txtbx_acctxndtl_current_balance.Name = "txtbx_acctxndtl_current_balance";
            this.txtbx_acctxndtl_current_balance.Size = new System.Drawing.Size(61, 20);
            this.txtbx_acctxndtl_current_balance.TabIndex = 15;
            // 
            // txtbx_acctxndtl_closing_balance
            // 
            this.txtbx_acctxndtl_closing_balance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtbx_acctxndtl_closing_balance.Location = new System.Drawing.Point(553, 38);
            this.txtbx_acctxndtl_closing_balance.Name = "txtbx_acctxndtl_closing_balance";
            this.txtbx_acctxndtl_closing_balance.Size = new System.Drawing.Size(65, 20);
            this.txtbx_acctxndtl_closing_balance.TabIndex = 16;
            // 
            // txtbx_acctxndtl_transactions
            // 
            this.txtbx_acctxndtl_transactions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtbx_acctxndtl_transactions.Location = new System.Drawing.Point(407, 128);
            this.txtbx_acctxndtl_transactions.Name = "txtbx_acctxndtl_transactions";
            this.txtbx_acctxndtl_transactions.Size = new System.Drawing.Size(65, 20);
            this.txtbx_acctxndtl_transactions.TabIndex = 18;
            // 
            // lbl_acctxndtl_duration_balance
            // 
            this.lbl_acctxndtl_duration_balance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_acctxndtl_duration_balance.AutoSize = true;
            this.lbl_acctxndtl_duration_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acctxndtl_duration_balance.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_acctxndtl_duration_balance.Location = new System.Drawing.Point(392, 106);
            this.lbl_acctxndtl_duration_balance.Name = "lbl_acctxndtl_duration_balance";
            this.lbl_acctxndtl_duration_balance.Size = new System.Drawing.Size(98, 16);
            this.lbl_acctxndtl_duration_balance.TabIndex = 17;
            this.lbl_acctxndtl_duration_balance.Text = "Transactions";
            // 
            // chkbx_acctxndtl_auto_update
            // 
            this.chkbx_acctxndtl_auto_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_acctxndtl_auto_update.AutoSize = true;
            this.chkbx_acctxndtl_auto_update.Location = new System.Drawing.Point(669, 105);
            this.chkbx_acctxndtl_auto_update.Name = "chkbx_acctxndtl_auto_update";
            this.chkbx_acctxndtl_auto_update.Size = new System.Drawing.Size(121, 17);
            this.chkbx_acctxndtl_auto_update.TabIndex = 19;
            this.chkbx_acctxndtl_auto_update.Text = "Auto Update Details";
            this.chkbx_acctxndtl_auto_update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkbx_acctxndtl_auto_update.UseVisualStyleBackColor = true;
            this.chkbx_acctxndtl_auto_update.CheckedChanged += new System.EventHandler(this.chkbx_acctxndtl_auto_update_CheckedChanged);
            // 
            // btn_acctxndtl_save_to_file
            // 
            this.btn_acctxndtl_save_to_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_acctxndtl_save_to_file.Location = new System.Drawing.Point(803, 128);
            this.btn_acctxndtl_save_to_file.Name = "btn_acctxndtl_save_to_file";
            this.btn_acctxndtl_save_to_file.Size = new System.Drawing.Size(128, 23);
            this.btn_acctxndtl_save_to_file.TabIndex = 20;
            this.btn_acctxndtl_save_to_file.Text = "Save To File";
            this.btn_acctxndtl_save_to_file.UseVisualStyleBackColor = true;
            this.btn_acctxndtl_save_to_file.Click += new System.EventHandler(this.btn_acctxndtl_save_to_file_Click);
            // 
            // save_file_dialog_acctxndtl
            // 
            this.save_file_dialog_acctxndtl.DefaultExt = "xls";
            this.save_file_dialog_acctxndtl.Filter = "Excel Documents (*.xls)|*.xls";
            // 
            // pictbx_acctxndtls_logo
            // 
            this.pictbx_acctxndtls_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictbx_acctxndtls_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictbx_acctxndtls_logo.Image")));
            this.pictbx_acctxndtls_logo.Location = new System.Drawing.Point(863, 12);
            this.pictbx_acctxndtls_logo.Name = "pictbx_acctxndtls_logo";
            this.pictbx_acctxndtls_logo.Size = new System.Drawing.Size(83, 110);
            this.pictbx_acctxndtls_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictbx_acctxndtls_logo.TabIndex = 21;
            this.pictbx_acctxndtls_logo.TabStop = false;
            // 
            // frm_account_transaction_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(958, 547);
            this.Controls.Add(this.pictbx_acctxndtls_logo);
            this.Controls.Add(this.btn_acctxndtl_save_to_file);
            this.Controls.Add(this.chkbx_acctxndtl_auto_update);
            this.Controls.Add(this.txtbx_acctxndtl_transactions);
            this.Controls.Add(this.lbl_acctxndtl_duration_balance);
            this.Controls.Add(this.txtbx_acctxndtl_closing_balance);
            this.Controls.Add(this.txtbx_acctxndtl_current_balance);
            this.Controls.Add(this.txtbx_acctxndtl_opening_balance);
            this.Controls.Add(this.lbl_acctxndtl_current_balance);
            this.Controls.Add(this.lbl_axxtxndtl_closing_balance);
            this.Controls.Add(this.lbl_acctxndtl_opening_balance);
            this.Controls.Add(this.btn_acctxndtl_show_details);
            this.Controls.Add(this.lbl_acctxndtl_select_to_date);
            this.Controls.Add(this.lbl_acctxndtl_select_from_date);
            this.Controls.Add(this.lbl_acctxndtl_select_acc_name);
            this.Controls.Add(this.cmbbx_acctxndtl_account_name);
            this.Controls.Add(this.dttmpkr_acctxndtl_to_date);
            this.Controls.Add(this.dttmpkr_acctxndtl_from_date);
            this.Controls.Add(this.dtgrdvu_acc_txn_details);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_account_transaction_details";
            this.Text = "Account Transaction Details";
            this.Load += new System.EventHandler(this.frm_account_transaction_details_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_account_transaction_details_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvu_acc_txn_details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictbx_acctxndtls_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgrdvu_acc_txn_details;
        private System.Windows.Forms.DateTimePicker dttmpkr_acctxndtl_from_date;
        private System.Windows.Forms.DateTimePicker dttmpkr_acctxndtl_to_date;
        private System.Windows.Forms.ComboBox cmbbx_acctxndtl_account_name;
        private System.Windows.Forms.Label lbl_acctxndtl_select_acc_name;
        private System.Windows.Forms.Label lbl_acctxndtl_select_from_date;
        private System.Windows.Forms.Label lbl_acctxndtl_select_to_date;
        private System.Windows.Forms.Button btn_acctxndtl_show_details;
        private System.Windows.Forms.Label lbl_acctxndtl_opening_balance;
        private System.Windows.Forms.Label lbl_axxtxndtl_closing_balance;
        private System.Windows.Forms.Label lbl_acctxndtl_current_balance;
        private System.Windows.Forms.TextBox txtbx_acctxndtl_opening_balance;
        private System.Windows.Forms.TextBox txtbx_acctxndtl_current_balance;
        private System.Windows.Forms.TextBox txtbx_acctxndtl_closing_balance;
        private System.Windows.Forms.TextBox txtbx_acctxndtl_transactions;
        private System.Windows.Forms.Label lbl_acctxndtl_duration_balance;
        private System.Windows.Forms.CheckBox chkbx_acctxndtl_auto_update;
        private System.Windows.Forms.Button btn_acctxndtl_save_to_file;
        public System.Windows.Forms.SaveFileDialog save_file_dialog_acctxndtl;
        private System.Windows.Forms.PictureBox pictbx_acctxndtls_logo;
    }
}