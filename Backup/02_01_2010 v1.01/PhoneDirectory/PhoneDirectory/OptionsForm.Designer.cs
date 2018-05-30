namespace PhoneDirectory
{
    partial class OptionsForm
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
            this.ckActiveDirectory = new System.Windows.Forms.CheckBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckOutlook = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckHomePhone = new System.Windows.Forms.CheckBox();
            this.ckMobilePhone = new System.Windows.Forms.CheckBox();
            this.ckBusinessPhone = new System.Windows.Forms.CheckBox();
            this.ckBusinessFax = new System.Windows.Forms.CheckBox();
            this.ckAddress = new System.Windows.Forms.CheckBox();
            this.ckEmail = new System.Windows.Forms.CheckBox();
            this.ckWindowService = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckActiveDirectory
            // 
            this.ckActiveDirectory.AutoSize = true;
            this.ckActiveDirectory.Location = new System.Drawing.Point(20, 49);
            this.ckActiveDirectory.Name = "ckActiveDirectory";
            this.ckActiveDirectory.Size = new System.Drawing.Size(149, 17);
            this.ckActiveDirectory.TabIndex = 0;
            this.ckActiveDirectory.Text = "Search in Active Directory";
            this.ckActiveDirectory.UseVisualStyleBackColor = true;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(93, 83);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(224, 20);
            this.txtDomain.TabIndex = 1;
            this.txtDomain.Text = "WOLLUNDRA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Domain";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckOutlook);
            this.groupBox1.Controls.Add(this.ckActiveDirectory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // ckOutlook
            // 
            this.ckOutlook.AutoSize = true;
            this.ckOutlook.Location = new System.Drawing.Point(20, 23);
            this.ckOutlook.Name = "ckOutlook";
            this.ckOutlook.Size = new System.Drawing.Size(114, 17);
            this.ckOutlook.TabIndex = 4;
            this.ckOutlook.Text = "Search in Outlook ";
            this.ckOutlook.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckEmail);
            this.groupBox2.Controls.Add(this.ckAddress);
            this.groupBox2.Controls.Add(this.ckBusinessFax);
            this.groupBox2.Controls.Add(this.ckBusinessPhone);
            this.groupBox2.Controls.Add(this.ckMobilePhone);
            this.groupBox2.Controls.Add(this.ckHomePhone);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 147);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search for";
            // 
            // ckHomePhone
            // 
            this.ckHomePhone.AutoSize = true;
            this.ckHomePhone.Location = new System.Drawing.Point(20, 26);
            this.ckHomePhone.Name = "ckHomePhone";
            this.ckHomePhone.Size = new System.Drawing.Size(88, 17);
            this.ckHomePhone.TabIndex = 0;
            this.ckHomePhone.Text = "Home Phone";
            this.ckHomePhone.UseVisualStyleBackColor = true;
            // 
            // ckMobilePhone
            // 
            this.ckMobilePhone.AutoSize = true;
            this.ckMobilePhone.Location = new System.Drawing.Point(20, 62);
            this.ckMobilePhone.Name = "ckMobilePhone";
            this.ckMobilePhone.Size = new System.Drawing.Size(91, 17);
            this.ckMobilePhone.TabIndex = 1;
            this.ckMobilePhone.Text = "Mobile Phone";
            this.ckMobilePhone.UseVisualStyleBackColor = true;
            // 
            // ckBusinessPhone
            // 
            this.ckBusinessPhone.AutoSize = true;
            this.ckBusinessPhone.Location = new System.Drawing.Point(20, 98);
            this.ckBusinessPhone.Name = "ckBusinessPhone";
            this.ckBusinessPhone.Size = new System.Drawing.Size(102, 17);
            this.ckBusinessPhone.TabIndex = 2;
            this.ckBusinessPhone.Text = "Business Phone";
            this.ckBusinessPhone.UseVisualStyleBackColor = true;
            // 
            // ckBusinessFax
            // 
            this.ckBusinessFax.AutoSize = true;
            this.ckBusinessFax.Location = new System.Drawing.Point(174, 26);
            this.ckBusinessFax.Name = "ckBusinessFax";
            this.ckBusinessFax.Size = new System.Drawing.Size(88, 17);
            this.ckBusinessFax.TabIndex = 5;
            this.ckBusinessFax.Text = "Business Fax";
            this.ckBusinessFax.UseVisualStyleBackColor = true;
            this.ckBusinessFax.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // ckAddress
            // 
            this.ckAddress.AutoSize = true;
            this.ckAddress.Location = new System.Drawing.Point(174, 62);
            this.ckAddress.Name = "ckAddress";
            this.ckAddress.Size = new System.Drawing.Size(64, 17);
            this.ckAddress.TabIndex = 6;
            this.ckAddress.Text = "Address";
            this.ckAddress.UseVisualStyleBackColor = true;
            // 
            // ckEmail
            // 
            this.ckEmail.AutoSize = true;
            this.ckEmail.Location = new System.Drawing.Point(174, 98);
            this.ckEmail.Name = "ckEmail";
            this.ckEmail.Size = new System.Drawing.Size(51, 17);
            this.ckEmail.TabIndex = 7;
            this.ckEmail.Text = "Email";
            this.ckEmail.UseVisualStyleBackColor = true;
            // 
            // ckWindowService
            // 
            this.ckWindowService.AutoSize = true;
            this.ckWindowService.Location = new System.Drawing.Point(32, 313);
            this.ckWindowService.Name = "ckWindowService";
            this.ckWindowService.Size = new System.Drawing.Size(141, 17);
            this.ckWindowService.TabIndex = 5;
            this.ckWindowService.Text = "Run as Window Service";
            this.ckWindowService.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(106, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(199, 350);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(392, 394);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ckWindowService);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckActiveDirectory;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckOutlook;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckMobilePhone;
        private System.Windows.Forms.CheckBox ckHomePhone;
        private System.Windows.Forms.CheckBox ckEmail;
        private System.Windows.Forms.CheckBox ckAddress;
        private System.Windows.Forms.CheckBox ckBusinessFax;
        private System.Windows.Forms.CheckBox ckBusinessPhone;
        private System.Windows.Forms.CheckBox ckWindowService;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;

    }
}