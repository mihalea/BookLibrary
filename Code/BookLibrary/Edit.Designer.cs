namespace BookLibrary
{
    partial class Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit));
            this.rtxTags = new System.Windows.Forms.RichTextBox();
            this.lbTags = new System.Windows.Forms.Label();
            this.lbPublisher = new System.Windows.Forms.Label();
            this.tbxPublisher = new System.Windows.Forms.TextBox();
            this.tbxAuthor = new System.Windows.Forms.TextBox();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxTags
            // 
            this.rtxTags.Location = new System.Drawing.Point(113, 99);
            this.rtxTags.Name = "rtxTags";
            this.rtxTags.Size = new System.Drawing.Size(188, 74);
            this.rtxTags.TabIndex = 18;
            this.rtxTags.Text = "";
            this.rtxTags.Validating += new System.ComponentModel.CancelEventHandler(this.rtxTags_Validating);
            // 
            // lbTags
            // 
            this.lbTags.AutoSize = true;
            this.lbTags.CausesValidation = false;
            this.lbTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbTags.Location = new System.Drawing.Point(47, 100);
            this.lbTags.Name = "lbTags";
            this.lbTags.Size = new System.Drawing.Size(44, 17);
            this.lbTags.TabIndex = 17;
            this.lbTags.Text = "Tags:";
            // 
            // lbPublisher
            // 
            this.lbPublisher.AutoSize = true;
            this.lbPublisher.CausesValidation = false;
            this.lbPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbPublisher.Location = new System.Drawing.Point(20, 71);
            this.lbPublisher.Name = "lbPublisher";
            this.lbPublisher.Size = new System.Drawing.Size(71, 17);
            this.lbPublisher.TabIndex = 16;
            this.lbPublisher.Text = "Publisher:";
            // 
            // tbxPublisher
            // 
            this.tbxPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbxPublisher.Location = new System.Drawing.Point(113, 68);
            this.tbxPublisher.Name = "tbxPublisher";
            this.tbxPublisher.Size = new System.Drawing.Size(188, 22);
            this.tbxPublisher.TabIndex = 15;
            this.tbxPublisher.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPublisher_Validating);
            // 
            // tbxAuthor
            // 
            this.tbxAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbxAuthor.Location = new System.Drawing.Point(113, 40);
            this.tbxAuthor.Name = "tbxAuthor";
            this.tbxAuthor.Size = new System.Drawing.Size(188, 22);
            this.tbxAuthor.TabIndex = 14;
            this.tbxAuthor.Validating += new System.ComponentModel.CancelEventHandler(this.tbxAuthor_Validating);
            // 
            // lbAuthor
            // 
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.CausesValidation = false;
            this.lbAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbAuthor.Location = new System.Drawing.Point(37, 43);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(54, 17);
            this.lbAuthor.TabIndex = 13;
            this.lbAuthor.Text = "Author:";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbxTitle.Location = new System.Drawing.Point(113, 12);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(188, 22);
            this.tbxTitle.TabIndex = 12;
            this.tbxTitle.Validating += new System.ComponentModel.CancelEventHandler(this.tbxTitle_Validating);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.CausesValidation = false;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbTitle.Location = new System.Drawing.Point(52, 15);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(39, 17);
            this.lbTitle.TabIndex = 11;
            this.lbTitle.Text = "Title:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(169, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.CausesValidation = false;
            this.btnOK.Location = new System.Drawing.Point(88, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(348, 231);
            this.Controls.Add(this.rtxTags);
            this.Controls.Add(this.lbTags);
            this.Controls.Add(this.lbPublisher);
            this.Controls.Add(this.tbxPublisher);
            this.Controls.Add(this.tbxAuthor);
            this.Controls.Add(this.lbAuthor);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxTags;
        private System.Windows.Forms.Label lbTags;
        private System.Windows.Forms.Label lbPublisher;
        private System.Windows.Forms.TextBox tbxPublisher;
        private System.Windows.Forms.TextBox tbxAuthor;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}