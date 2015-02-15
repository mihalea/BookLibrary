namespace BookLibrary
{
    partial class Email
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Email));
            this.lbSenderEmail = new System.Windows.Forms.Label();
            this.tbxSenderEmail = new System.Windows.Forms.TextBox();
            this.tbxRecipientName = new System.Windows.Forms.TextBox();
            this.lbRecipientName = new System.Windows.Forms.Label();
            this.tbxSubject = new System.Windows.Forms.TextBox();
            this.lbSubject = new System.Windows.Forms.Label();
            this.lbProvider = new System.Windows.Forms.Label();
            this.cobxProviders = new System.Windows.Forms.ComboBox();
            this.cbxAdvanced = new System.Windows.Forms.CheckBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.tbxServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.cbxEncryption = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cobxTypes = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.rbxMessage = new System.Windows.Forms.RichTextBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.tbxSenderName = new System.Windows.Forms.TextBox();
            this.lbSenderName = new System.Windows.Forms.Label();
            this.tbxRecipientEmail = new System.Windows.Forms.TextBox();
            this.lbRecipientEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSenderEmail
            // 
            this.lbSenderEmail.AutoSize = true;
            this.lbSenderEmail.CausesValidation = false;
            this.lbSenderEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbSenderEmail.Location = new System.Drawing.Point(93, 80);
            this.lbSenderEmail.Name = "lbSenderEmail";
            this.lbSenderEmail.Size = new System.Drawing.Size(79, 17);
            this.lbSenderEmail.TabIndex = 0;
            this.lbSenderEmail.Text = "Your email:";
            // 
            // tbxSenderEmail
            // 
            this.tbxSenderEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbxSenderEmail.Location = new System.Drawing.Point(178, 77);
            this.tbxSenderEmail.Name = "tbxSenderEmail";
            this.tbxSenderEmail.Size = new System.Drawing.Size(331, 23);
            this.tbxSenderEmail.TabIndex = 2;
            this.tbxSenderEmail.Validating += new System.ComponentModel.CancelEventHandler(this.tbxSenderEmail_Validating);
            // 
            // tbxRecipientName
            // 
            this.tbxRecipientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbxRecipientName.Location = new System.Drawing.Point(178, 135);
            this.tbxRecipientName.Name = "tbxRecipientName";
            this.tbxRecipientName.Size = new System.Drawing.Size(331, 23);
            this.tbxRecipientName.TabIndex = 4;
            this.tbxRecipientName.Validating += new System.ComponentModel.CancelEventHandler(this.tbxRecipientName_Validating);
            // 
            // lbRecipientName
            // 
            this.lbRecipientName.AutoSize = true;
            this.lbRecipientName.CausesValidation = false;
            this.lbRecipientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbRecipientName.Location = new System.Drawing.Point(52, 138);
            this.lbRecipientName.Name = "lbRecipientName";
            this.lbRecipientName.Size = new System.Drawing.Size(120, 17);
            this.lbRecipientName.TabIndex = 2;
            this.lbRecipientName.Text = "Recipient\'s name:";
            // 
            // tbxSubject
            // 
            this.tbxSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbxSubject.Location = new System.Drawing.Point(178, 193);
            this.tbxSubject.Name = "tbxSubject";
            this.tbxSubject.Size = new System.Drawing.Size(331, 23);
            this.tbxSubject.TabIndex = 6;
            this.tbxSubject.Validating += new System.ComponentModel.CancelEventHandler(this.tbxSubject_Validating);
            // 
            // lbSubject
            // 
            this.lbSubject.AutoSize = true;
            this.lbSubject.CausesValidation = false;
            this.lbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbSubject.Location = new System.Drawing.Point(113, 196);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(59, 17);
            this.lbSubject.TabIndex = 4;
            this.lbSubject.Text = "Subject:";
            // 
            // lbProvider
            // 
            this.lbProvider.AutoSize = true;
            this.lbProvider.CausesValidation = false;
            this.lbProvider.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbProvider.Location = new System.Drawing.Point(75, 223);
            this.lbProvider.Name = "lbProvider";
            this.lbProvider.Size = new System.Drawing.Size(97, 17);
            this.lbProvider.TabIndex = 6;
            this.lbProvider.Text = "Email Service:";
            this.lbProvider.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cobxProviders
            // 
            this.cobxProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobxProviders.FormattingEnabled = true;
            this.cobxProviders.Location = new System.Drawing.Point(178, 222);
            this.cobxProviders.Name = "cobxProviders";
            this.cobxProviders.Size = new System.Drawing.Size(331, 21);
            this.cobxProviders.TabIndex = 7;
            // 
            // cbxAdvanced
            // 
            this.cbxAdvanced.AutoSize = true;
            this.cbxAdvanced.CausesValidation = false;
            this.cbxAdvanced.Location = new System.Drawing.Point(362, 453);
            this.cbxAdvanced.Name = "cbxAdvanced";
            this.cbxAdvanced.Size = new System.Drawing.Size(147, 17);
            this.cbxAdvanced.TabIndex = 6;
            this.cbxAdvanced.TabStop = false;
            this.cbxAdvanced.Text = "Advanced SMTP settings";
            this.cbxAdvanced.UseVisualStyleBackColor = true;
            this.cbxAdvanced.CheckedChanged += new System.EventHandler(this.cbxAdvanced_CheckedChanged);
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbxPassword.Location = new System.Drawing.Point(178, 106);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '•';
            this.tbxPassword.Size = new System.Drawing.Size(331, 23);
            this.tbxPassword.TabIndex = 3;
            this.tbxPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPassword_Validating);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.CausesValidation = false;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbPassword.Location = new System.Drawing.Point(65, 109);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(107, 17);
            this.lbPassword.TabIndex = 9;
            this.lbPassword.Text = "Your Password:";
            // 
            // tbxPort
            // 
            this.tbxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbxPort.Location = new System.Drawing.Point(178, 424);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(331, 23);
            this.tbxPort.TabIndex = 11;
            this.tbxPort.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPort_Validating);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.CausesValidation = false;
            this.lbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbPort.Location = new System.Drawing.Point(134, 427);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(38, 17);
            this.lbPort.TabIndex = 15;
            this.lbPort.Text = "Port:";
            // 
            // tbxServer
            // 
            this.tbxServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbxServer.Location = new System.Drawing.Point(178, 395);
            this.tbxServer.Name = "tbxServer";
            this.tbxServer.Size = new System.Drawing.Size(331, 23);
            this.tbxServer.TabIndex = 10;
            this.tbxServer.Validating += new System.ComponentModel.CancelEventHandler(this.tbxServer_Validating);
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.CausesValidation = false;
            this.lbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbServer.Location = new System.Drawing.Point(118, 398);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(54, 17);
            this.lbServer.TabIndex = 11;
            this.lbServer.Text = "Server:";
            // 
            // cbxEncryption
            // 
            this.cbxEncryption.AutoSize = true;
            this.cbxEncryption.CausesValidation = false;
            this.cbxEncryption.Location = new System.Drawing.Point(178, 453);
            this.cbxEncryption.Name = "cbxEncryption";
            this.cbxEncryption.Size = new System.Drawing.Size(71, 17);
            this.cbxEncryption.TabIndex = 12;
            this.cbxEncryption.Text = "TLS/SSL";
            this.cbxEncryption.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnSend.Location = new System.Drawing.Point(230, 500);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 18;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(311, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // cobxTypes
            // 
            this.cobxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobxTypes.FormattingEnabled = true;
            this.cobxTypes.Location = new System.Drawing.Point(178, 249);
            this.cobxTypes.Name = "cobxTypes";
            this.cobxTypes.Size = new System.Drawing.Size(331, 21);
            this.cobxTypes.TabIndex = 8;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.CausesValidation = false;
            this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbType.Location = new System.Drawing.Point(128, 250);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(44, 17);
            this.lbType.TabIndex = 21;
            this.lbType.Text = "Type:";
            this.lbType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rbxMessage
            // 
            this.rbxMessage.Location = new System.Drawing.Point(178, 276);
            this.rbxMessage.Name = "rbxMessage";
            this.rbxMessage.Size = new System.Drawing.Size(331, 109);
            this.rbxMessage.TabIndex = 9;
            this.rbxMessage.Text = "";
            this.rbxMessage.Validating += new System.ComponentModel.CancelEventHandler(this.rbxMessage_Validating);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.CausesValidation = false;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbMessage.Location = new System.Drawing.Point(103, 277);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(69, 17);
            this.lbMessage.TabIndex = 23;
            this.lbMessage.Text = "Message:";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbxSenderName
            // 
            this.tbxSenderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbxSenderName.Location = new System.Drawing.Point(178, 48);
            this.tbxSenderName.Name = "tbxSenderName";
            this.tbxSenderName.Size = new System.Drawing.Size(331, 23);
            this.tbxSenderName.TabIndex = 1;
            this.tbxSenderName.Validating += new System.ComponentModel.CancelEventHandler(this.tbxSenderName_Validating);
            // 
            // lbSenderName
            // 
            this.lbSenderName.AutoSize = true;
            this.lbSenderName.CausesValidation = false;
            this.lbSenderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbSenderName.Location = new System.Drawing.Point(91, 51);
            this.lbSenderName.Name = "lbSenderName";
            this.lbSenderName.Size = new System.Drawing.Size(81, 17);
            this.lbSenderName.TabIndex = 24;
            this.lbSenderName.Text = "Your name:";
            // 
            // tbxRecipientEmail
            // 
            this.tbxRecipientEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbxRecipientEmail.Location = new System.Drawing.Point(178, 164);
            this.tbxRecipientEmail.Name = "tbxRecipientEmail";
            this.tbxRecipientEmail.Size = new System.Drawing.Size(331, 23);
            this.tbxRecipientEmail.TabIndex = 5;
            this.tbxRecipientEmail.Validating += new System.ComponentModel.CancelEventHandler(this.tbxRecipientEmail_Validating);
            // 
            // lbRecipientEmail
            // 
            this.lbRecipientEmail.AutoSize = true;
            this.lbRecipientEmail.CausesValidation = false;
            this.lbRecipientEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbRecipientEmail.Location = new System.Drawing.Point(54, 167);
            this.lbRecipientEmail.Name = "lbRecipientEmail";
            this.lbRecipientEmail.Size = new System.Drawing.Size(118, 17);
            this.lbRecipientEmail.TabIndex = 26;
            this.lbRecipientEmail.Text = "Recipient\'s email:";
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.tbxRecipientEmail);
            this.Controls.Add(this.lbRecipientEmail);
            this.Controls.Add(this.tbxSenderName);
            this.Controls.Add(this.lbSenderName);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.rbxMessage);
            this.Controls.Add(this.cobxTypes);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cbxEncryption);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.tbxServer);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.cbxAdvanced);
            this.Controls.Add(this.cobxProviders);
            this.Controls.Add(this.lbProvider);
            this.Controls.Add(this.tbxSubject);
            this.Controls.Add(this.lbSubject);
            this.Controls.Add(this.tbxRecipientName);
            this.Controls.Add(this.lbRecipientName);
            this.Controls.Add(this.tbxSenderEmail);
            this.Controls.Add(this.lbSenderEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Email";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Send by email";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSenderEmail;
        private System.Windows.Forms.TextBox tbxSenderEmail;
        private System.Windows.Forms.TextBox tbxRecipientName;
        private System.Windows.Forms.Label lbRecipientName;
        private System.Windows.Forms.TextBox tbxSubject;
        private System.Windows.Forms.Label lbSubject;
        private System.Windows.Forms.Label lbProvider;
        private System.Windows.Forms.ComboBox cobxProviders;
        private System.Windows.Forms.CheckBox cbxAdvanced;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox tbxServer;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.CheckBox cbxEncryption;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cobxTypes;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.RichTextBox rbxMessage;
        private System.Windows.Forms.TextBox tbxSenderName;
        private System.Windows.Forms.Label lbSenderName;
        private System.Windows.Forms.TextBox tbxRecipientEmail;
        private System.Windows.Forms.Label lbRecipientEmail;
    }
}