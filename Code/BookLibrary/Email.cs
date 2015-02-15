using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLibrary
{
    public partial class Email : Form
    {
        private Logger logger;

        public Email(Logger logger)
        {
            InitializeComponent();
            hideAdvanced();
            this.AutoValidate = AutoValidate.Disable;
            this.logger = logger;

            initializeEmailTypes();
        }

        private void initializeEmailTypes()
        {
            this.cobxTypes.Items.Clear();
            this.cobxTypes.Items.Add("Embedded as message");
            this.cobxTypes.Items.Add("Library (*.xml)");
            this.cobxTypes.Items.Add("Comma-separated values (*.csv)");
            this.cobxTypes.Items.Add("HTML as attachment (*.html)");
            this.cobxTypes.SelectedIndex = 0;
        }

        private void initilizeEmailProviders()
        {
            this.cobxProviders.Enabled = true;
            this.cobxProviders.Items.Clear();
            this.cobxProviders.Items.Add("Google Mail");
            this.cobxProviders.Items.Add("Yahoo Mail");
            this.cobxProviders.Items.Add("Hotmail");
            this.cobxProviders.SelectedIndex = 0;
        }

        private void hideAdvanced()
        {
            lbServer.Visible = false;
            lbPort.Visible = false;
            tbxServer.Visible = false;
            tbxPort.Visible = false;
            cbxEncryption.Visible = false;
            btnSend.Location = new Point(227, 416);
            btnCancel.Location = new Point(308, 416);
            initilizeEmailProviders();
            this.Height = 515;
        }

        private void showAdvanced()
        {
            lbServer.Visible = true;
            lbPort.Visible = true;
            tbxServer.Visible = true;
            tbxPort.Visible = true;
            cbxEncryption.Visible = true;
            btnSend.Location = new Point(227, 491);
            btnCancel.Location = new Point(308, 491);
            this.cobxProviders.Items.Clear();
            this.cobxProviders.Items.Add("Custom");
            this.cobxProviders.SelectedIndex = 0;
            this.cobxProviders.Enabled = false;
            this.Height = 575;
        }

        private String createBody(bool embedded)
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = ((Main)this.Owner).getDataSet();

            sb.Append("<html><head>");
            sb.Append("<h1>" + ((Main)this.Owner).getSaveName() + "</h1>");
            sb.Append("</head>");

            sb.Append("<body>");
            sb.Append("<p><i>Hi, " + tbxRecipientName.Text.Trim() + "! "
                + tbxSenderName.Text.Trim() + " sent you his book collection along with the following message: </i></p>"
                + "<blockquote>" + rbxMessage.Text.Trim() + "</blockquote><br /><hr /><br />");

            if (embedded)
            {
                sb.Append("<table border='1' cellpadding='5' cellspacing='1'>");
                sb.Append("<tr>");
                foreach (DataColumn column in ds.Tables["Books"].Columns)
                {
                    sb.Append("<th>" + column.ColumnName + "</th>");
                }
                sb.Append("</tr>");

                foreach (DataRow row in ds.Tables["Books"].Rows)
                {
                    sb.Append("<tr>");
                    foreach (String cell in row.ItemArray)
                    {
                        sb.Append("<td>" + cell + "</td>");
                    }
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
            }
            sb.Append("</body>");

            sb.Append("<footer><br /><br />");
            sb.Append("<p style=\"color:light-grey;size:0.8em;\">This messsage was sent with Book Library &copy;."+
                "<br />Software created by mmimaa. <br />To learn more about the developing team" +
                " visit the following site: <a href=\"http://www.mmimaa.p.ht\">Developer Site</a></p>");
            sb.Append("</footer>");

            sb.Append("</html>");

            return sb.ToString();
        }

        private void cbxAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAdvanced.Checked == false)
                hideAdvanced();
            else
                showAdvanced();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (this.ValidateChildren(ValidationConstraints.Visible))
            {
                
                try
                {
                    SmtpClient client = new SmtpClient();

                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(tbxSenderEmail.Text.Trim(), tbxPassword.Text);

                    if (cbxAdvanced.Checked == false)
                    {
                        if (cobxProviders.SelectedIndex == 0)
                        {
                            client.EnableSsl = true;
                            client.Port = 587;
                            client.Host = "smtp.gmail.com";
                        }
                        else if (cobxProviders.SelectedIndex == 1)
                        {
                            client.EnableSsl = false;
                            client.Port = 587;
                            client.Host = "smtp.mail.yahoo.com";
                        }
                        else if (cobxProviders.SelectedIndex == 2)
                        {
                            client.EnableSsl = true;
                            client.Port = 587;
                            client.Host = "smtp.live.com";
                        }
                    }
                    else
                    {
                        client.Port = Int32.Parse(tbxPort.Text);
                        client.Host = tbxServer.Text;
                        client.EnableSsl = cbxEncryption.Checked;
                    }

                    MailAddress from = new MailAddress(tbxSenderEmail.Text.Trim(), tbxSenderName.Text.Trim());
                    MailAddress to = new MailAddress(tbxRecipientEmail.Text.Trim(), tbxRecipientName.Text.Trim());
                    MailMessage mail = new MailMessage(from,to);
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    mail.Subject = tbxSubject.Text;
                    mail.IsBodyHtml = true;

                    switch (cobxTypes.SelectedIndex)
                    {
                        case 0: // Embedded in body
                        {
                            mail.Body = createBody(true);
                            break;
                        }
                        case 1: // Library
                        {
                            mail.Body = createBody(false);
                            Attachment att = new Attachment(((Main)this.Owner).getSavePath());
                            mail.Attachments.Add(att);
                            break;
                            }
                        case 2: // CSV
                        {
                            mail.Body = createBody(false);
                            Attachment att = new Attachment(((Main)this.Owner).getTemporaryFilePath(".csv"));
                            mail.Attachments.Add(att);
                            break;
                        }
                        case 3: // HTML as attachment
                        {
                            mail.Body = createBody(false);
                            Attachment att = new Attachment(((Main)this.Owner).getTemporaryFilePath(".html"));
                            mail.Attachments.Add(att);
                            break;
                        }
                        default:
                            break;
                    }

                    client.Send(mail);
                    MessageBox.Show("Email succesfully sent!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Email failed to be sent");
                    logger.writeLine(this.getName(), "btnSend_Click", ex);
                }
            }
        }

        private void tbxPassword_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (String.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                cancel = true;
                this.errorProvider.SetError(tbxPassword, "Invalid password");
            }


            e.Cancel = cancel;
        }

        private void tbxSubject_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (String.IsNullOrWhiteSpace(tbxSubject.Text))
            {
                cancel = true;
                this.errorProvider.SetError(tbxSubject, "Invalid subject");
            }

            e.Cancel = cancel;
        }

        private void tbxServer_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (String.IsNullOrWhiteSpace(tbxServer.Text))
            {
                cancel = true;
                this.errorProvider.SetError(tbxServer, "Invalid server");
            }

            e.Cancel = cancel;
        }

        private void tbxPort_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            int nPort;
            if (Int32.TryParse(tbxPort.Text, out nPort) == false)
            {
                cancel = true;
                this.errorProvider.SetError(tbxPort, "Invalid port number");
            }
            else if (nPort > 65535 || nPort < 0)
            {
                cancel = true;
                this.errorProvider.SetError(tbxPort, "Port number out of range");
            }

            e.Cancel = cancel;
        }

        private String getName()
        {
            return "Email";
        }

        private void tbxSenderName_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (String.IsNullOrWhiteSpace(tbxSenderName.Text))
            {
                cancel = true;
                errorProvider.SetError(tbxSenderName, "Invalid name");
            }

            e.Cancel = cancel;
        }

        private void tbxSenderEmail_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            String text = tbxSenderEmail.Text;

            String[] split = text.Split(new Char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Count<String>() != 2 ||
                String.IsNullOrWhiteSpace(split[0]) ||
                String.IsNullOrWhiteSpace(split[1]))
            {
                cancel = true;
            }
            else
            {
                if (split[1].Split(new Char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Count<String>() != 2)
                    cancel = true;
            }

            if (cancel)
                this.errorProvider.SetError(tbxSenderEmail, "Invalid email");

            e.Cancel = cancel;
        }

        private void tbxRecipientName_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (String.IsNullOrWhiteSpace(tbxRecipientName.Text))
            {
                cancel = true;
                errorProvider.SetError(tbxRecipientName, "Invalid name");
            }

            e.Cancel = cancel;
        }

        private void tbxRecipientEmail_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            String text = tbxRecipientEmail.Text;

            String[] split = text.Split(new Char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Count<String>() != 2 ||
                String.IsNullOrWhiteSpace(split[0]) ||
                String.IsNullOrWhiteSpace(split[1]))
            {
                cancel = true;
            }
            else
            {
                if (split[1].Split(new Char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Count<String>() != 2)
                    cancel = true;
            }

            if (cancel)
                this.errorProvider.SetError(tbxRecipientEmail, "Invalid email");

            e.Cancel = cancel;
        }

        private void rbxMessage_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

    }
}
