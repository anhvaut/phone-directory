namespace InstallerClassDLL
{
    partial class SerialNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialNumber));
            this.txtProductKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.imgPass = new System.Windows.Forms.PictureBox();
            this.imgFail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductKey
            // 
            this.txtProductKey.Location = new System.Drawing.Point(37, 55);
            this.txtProductKey.MaxLength = 29;
            this.txtProductKey.Name = "txtProductKey";
            this.txtProductKey.Size = new System.Drawing.Size(239, 20);
            this.txtProductKey.TabIndex = 0;
            this.txtProductKey.TextChanged += new System.EventHandler(this.txtProductKey_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Number (xxxxx-xxxxx-xxxxx-xxxxx-xxxxx)";
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(124, 94);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // imgPass
            // 
            this.imgPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgPass.BackgroundImage")));
            this.imgPass.Location = new System.Drawing.Point(283, 55);
            this.imgPass.Name = "imgPass";
            this.imgPass.Size = new System.Drawing.Size(38, 29);
            this.imgPass.TabIndex = 3;
            this.imgPass.TabStop = false;
            this.imgPass.Visible = false;
            // 
            // imgFail
            // 
            this.imgFail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgFail.BackgroundImage")));
            this.imgFail.Location = new System.Drawing.Point(283, 48);
            this.imgFail.Name = "imgFail";
            this.imgFail.Size = new System.Drawing.Size(38, 36);
            this.imgFail.TabIndex = 4;
            this.imgFail.TabStop = false;
            this.imgFail.Visible = false;
            // 
            // SerialNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 129);
            this.Controls.Add(this.imgFail);
            this.Controls.Add(this.imgPass);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProductKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SerialNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Serial Number";
            ((System.ComponentModel.ISupportInitialize)(this.imgPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox imgPass;
        private System.Windows.Forms.PictureBox imgFail;
    }
}