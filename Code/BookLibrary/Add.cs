using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLibrary
{
    public partial class Add : Form
    {
        public Book newBook;
        private Logger logger;

        public Add(Logger logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.AutoValidate = AutoValidate.Disable;
            newBook = new Book();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                tryForm();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                abortForm();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void rtxTags_Click(object sender, EventArgs e)
        {
            rtxTags.Text = String.Empty;
        }

        private void createBook()
        {
            newBook = new Book();
            newBook.author = tbxAuthor.Text;
            newBook.publisher = tbxPublisher.Text;
            newBook.tags = rtxTags.Text;
            newBook.title = tbxTitle.Text;
        }

        private void destroyBook()
        {
            newBook = null;
        }

        private void tryForm()
        {
            errorProvider.Clear();

            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                createBook();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                destroyBook();
        }

        private void abortForm()
        {
            destroyBook();
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            tryForm();    
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            abortForm();    
        }
        
        private void tbxTitle_Validating(object sender, CancelEventArgs e)
        {
            bool cancel;

            if (String.IsNullOrWhiteSpace(tbxTitle.Text))
            {
                this.errorProvider.SetError(this.tbxTitle, "Empty field");
                cancel = true;
            }
            else
                cancel = false;
                
            e.Cancel = cancel;
        }

        private void tbxAuthor_Validating(object sender, CancelEventArgs e)
        {
            bool cancel;

            if (String.IsNullOrWhiteSpace(tbxAuthor.Text))
            {
                this.errorProvider.SetError(this.tbxAuthor, "Empty field");
                cancel = true;
            }
            else
                cancel = false;

            e.Cancel = cancel;
        }

        private void tbxPublisher_Validating(object sender, CancelEventArgs e)
        {
            bool cancel;

            if (String.IsNullOrWhiteSpace(tbxPublisher.Text))
            {
                this.errorProvider.SetError(this.tbxPublisher, "Empty field");
                cancel = true;
            }
            else
                cancel = false;

            e.Cancel = cancel;
        }

        private void rtxTags_Validating(object sender, CancelEventArgs e)
        {
            bool cancel;

            if (String.IsNullOrWhiteSpace(rtxTags.Text) || rtxTags.Text.Contains(','))
            {
                this.errorProvider.SetError(this.rtxTags, "Empty field");
                cancel = true;
            }
            else
                cancel = false;

            e.Cancel = cancel;
        }



    }
}
