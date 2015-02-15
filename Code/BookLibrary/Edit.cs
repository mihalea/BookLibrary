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
    public partial class Edit : Form
    {
        public Book newBook;
        private Logger logger;

        public Edit(Book b, Logger l)
        {
            InitializeComponent();

            this.logger = l;

            newBook = new Book();

            tbxAuthor.Text = b.author;
            tbxPublisher.Text = b.publisher;
            tbxTitle.Text = b.title;
            rtxTags.Text = b.tags.ToString();
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

        private void abortForm()
        {
            this.DialogResult = DialogResult.Abort;
            destroyBook();
            this.Close();
        }

        private void tryForm()
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                createBook();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                destroyBook();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            abortForm();    
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            tryForm();
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
