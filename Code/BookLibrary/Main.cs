using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BookLibrary
{
    public partial class Main : Form
    {
        private DataSet dataSet;
        private DataTable dataTable;
        private String savePath, saveName;
        private DataGridViewPrinter tablePrinter;
        private Logger logger;
        private List<Tuple<String, String>> extensions;
        private String lastOpenProject;
        private int filterState;
        private String root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                    ".bookLibrary");


        public Main()
        {
            InitializeComponent();
            dataSet = new DataSet();
            dataTable = dataSet.Tables.Add("Books");

            lastOpenProject = String.Empty;

            extensions = new List<Tuple<String, String>>();
            extensions.Add(new Tuple<string, string>("Library", "xml"));
            extensions.Add(new Tuple<string, string>("Comma-separated values", "csv"));
            extensions.Add(new Tuple<string, string>("HTML", "html"));

            savePath = saveName = String.Empty;

            saveDialog.FileName = "Untitled";
            saveDialog.Filter = String.Empty;
            //saveDialog.Filter = "Library (*.xml)|*xml|Microsoft Excel (*.xls)|*xls|HTML (*.html)|*html";
            foreach (Tuple<String, String> tuple in extensions)
            {
                String sep = String.Empty;
                if (saveDialog.Filter != String.Empty)
                    sep = "|";
                saveDialog.Filter += sep + tuple.Item1 + " (*." + tuple.Item2 + ")|*" + tuple.Item2;
                
            }

            openDialog.Filter = "Libraries saved (*.xml)|*xml";
            openDialog.FileName = String.Empty;

            dataTable.Columns.Add("Title", typeof(String));
            dataTable.Columns.Add("Author", typeof(String));
            dataTable.Columns.Add("Publisher", typeof(String));
            dataTable.Columns.Add("Tags", typeof(String));
            dataTable.Rows.Clear();

            cobxFilter.Items.Add("All");
            cobxFilter.Items.Add("Title");
            cobxFilter.Items.Add("Author");
            cobxFilter.Items.Add("Publisher");
            cobxFilter.Items.Add("Tags");
            cobxFilter.SelectedIndex = 0;

            dgvTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvTable.AllowUserToResizeRows = false;

            logger = new Logger();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                tbxSearch.Focus();
                return true;
            }
            if (keyData == (Keys.Escape) && tbxSearch.Focused == true)
            {
                dgvTable.Focus();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //dataTable.Rows.Add("Jocurile Foamei", "Suzanne Collins", "Nemira", "dark");*/
            logger.startService();
            readCookies();

            loadTable();
            try
            {
                dgvTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvTable.Select();

            }
            catch (Exception ex)
            {
                logger.writeLine(this.getName(), "Main_Load", ex);
            }
        }

        private bool setupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            printDocument.DocumentName = saveName;
            printDocument.PrinterSettings =
                                MyPrintDialog.PrinterSettings;
            printDocument.DefaultPageSettings =
            MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument.DefaultPageSettings.Margins =
                             new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Do you want the report to be centered on the page",
                "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                tablePrinter = new DataGridViewPrinter(dgvTable,
                printDocument, true, true, saveName, new Font("Tahoma", 18,
                FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                tablePrinter = new DataGridViewPrinter(dgvTable,
                printDocument, false, true, saveName, new Font("Tahoma", 18,
                FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void readCookies()
        {
            try
            {
                using (FileStream fs = File.Open(Path.Combine(root, "cookies.ini"), FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);
                    lastOpenProject = sr.ReadLine();
                    savePath = lastOpenProject;
                    saveName = savePath.Substring(savePath.LastIndexOf('\\') + 1, savePath.LastIndexOf('.') - (savePath.LastIndexOf('\\') + 1));
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                logger.writeLine(this.getName(), "readCookies", ex);
            }
        }

        private void saveCookies()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(root, "cookies.ini")))
                {
                    sw.WriteLine(lastOpenProject);
                }
            }
            catch (Exception ex)
            {
                logger.writeLine(this.getName(), "saveCookies", ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add addBook = new Add(logger);
            DialogResult result = addBook.ShowDialog();

            if (result == DialogResult.OK)
            {
                addBookToTable(addBook.newBook);
                saveTable(".xml");
            }

            dgvTable.Select();
        }

        private void saveTable(String path)
        {
            switch (Path.GetExtension(path))
            {
                case ".xml":
                    try
                    {
                        lastOpenProject = savePath;
                        dataSet.Tables["Books"].WriteXml(savePath);
                    }
                    catch (Exception e)
                    {
                        logger.writeLine(this.getName(), "saveTable", e);
                    }
                    break;
                case ".csv":

                    using (StreamWriter file = new StreamWriter(path))
                    {
                        int columns = dataTable.Columns.Count;

                        for (int i = 0; i < columns; i++)
                        {
                            if (i != 0)
                                file.Write(", ");
                            file.Write(dataTable.Columns[i].ColumnName);
                        }
                        file.WriteLine();

                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                if (j != 0)
                                    file.Write(", ");
                                file.Write(dataTable.Rows[i].ItemArray[j]);
                            }
                            file.WriteLine();
                        }
                    }
                    break;
                case ".html":
                    using (StreamWriter file = new StreamWriter(path))
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.Append("<html><head>");
                        sb.Append("<h1>" + saveName + "</h1>");
                        sb.Append("</head>");


                        sb.Append("<body><table border='1' cellpadding='5' cellspacing='1'>");
                        sb.Append("<tr>");
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            sb.Append("<th>" + column.ColumnName + "</th>");
                        }
                        sb.Append("</tr>");

                        foreach (DataRow row in dataTable.Rows)
                        {
                            sb.Append("<tr>");
                            foreach (String cell in row.ItemArray)
                            {
                                sb.Append("<td>" + cell + "</td>");
                            }
                            sb.Append("</tr>");
                        }

                        sb.Append("</table></body></html>");

                        file.Write(sb.ToString());
                    }
                    break;
            }
        }

        private void loadTable()
        {
            try
            {
                dataSet.Tables["Books"].Rows.Clear();
                dataSet.ReadXml(savePath);
                this.Text = "Book Library - " + saveName;
                lastOpenProject = savePath;
            }
            catch (Exception e)
            {
                logger.writeLine(this.getName(), "loadTable", e);
            }
            finally
            {
                //dataSet.Tables.Add(dataTable);
                dgvTable.DataSource = dataSet.Tables["Books"];
            }
        }

        private void addBookToTable(Book b)
        {
            try
            {
                //dgvTable.Rows.Add(b.title, b.author, b.Publisher, sb);
                dataSet.Tables["Books"].Rows.Add(b.title, b.author, b.publisher, b.tags);
            }
            catch (Exception e)
            {
                logger.writeLine(this.getName(), "addBookToTable", e);
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxSearch.Text) == false)
            {
                try
                {
                    switch(filterState)
                    {
                        case 0:
                            dataSet.Tables["Books"].DefaultView.RowFilter = "Title like '%" + tbxSearch.Text.Trim().Replace("'", "''") + "%' or " +
                                                                            "Author like '%" + tbxSearch.Text.Trim().Replace("'", "''") + "%' or " +
                                                                            "Publisher like '%" + tbxSearch.Text.Trim().Replace("'", "''") + "%' or " +
                                                                            "Tags like '%" + tbxSearch.Text.Trim().Replace("'", "''") + "%'";
                            break;
                        case 1:
                            dataSet.Tables["Books"].DefaultView.RowFilter = "Title like '%" + tbxSearch.Text.Trim().Replace("'", "''") + "%'";
                            break;
                        case 2:
                            dataSet.Tables["Books"].DefaultView.RowFilter = "Author like '%" + tbxSearch.Text.Trim().Replace("'", "''") + "%'";
                            break;
                        case 3:
                            dataSet.Tables["Books"].DefaultView.RowFilter = "Publisher like '%" + tbxSearch.Text.Trim().Replace("'", "''") + "%'";
                            break;
                        case 4:
                            dataSet.Tables["Books"].DefaultView.RowFilter = "Tags like '%" + tbxSearch.Text.Trim().Replace("'", "''") + "%'";
                            break;
                        default:
                            dataSet.Tables["Books"].DefaultView.RowFilter = String.Empty;
                            break;
                    }
                }
                catch (Exception er)
                {
                    logger.writeLine(this.getName(), "tbxSearch_TextChanged", er);
                }
            }
            else
            {
                dataSet.Tables["Books"].DefaultView.RowFilter = String.Empty;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedCells.Count > 0 && 
                (MessageBox.Show("Are you sure you want to remove the selected books ?",
                "Delete books",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation)) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewCell item in dgvTable.SelectedCells)
                    {
                        if (item.RowIndex >= 0)
                            dataSet.Tables["Books"].Rows.RemoveAt(item.RowIndex);
                    }
                }
                catch (Exception ex)
                {
                    logger.writeLine(this.getName(), "btnRemove_Click", ex);
                }
                finally
                {
                    saveTable(".xml");
                }
            }

            dgvTable.Select();
        }

        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            tbxSearch.Text = String.Empty;
            tbxSearch.ForeColor = System.Drawing.SystemColors.WindowText;
        }

        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                tbxSearch.ForeColor = System.Drawing.SystemColors.InactiveCaption;
                tbxSearch.Text = "Search";
                dataSet.Tables["Books"].DefaultView.RowFilter = String.Empty;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedCells.Count > 0)
            {
                Book b = new Book();
                DataRow dr = dataSet.Tables["Books"].Rows[dgvTable.SelectedCells[0].RowIndex];
                b.author = dr.Field<String>("Author");
                b.publisher = dr.Field<String>("Publisher");
                b.tags = dr.Field<String>("Tags");
                b.title = dr.Field<String>("Title");
                Edit edit = new Edit(b, logger);
                DialogResult result = edit.ShowDialog();

                if (result == DialogResult.OK)
                {
                    dr.SetField<String>("Author", edit.newBook.author);
                    dr.SetField<String>("Title", edit.newBook.title);
                    dr.SetField<String>("Publisher", edit.newBook.publisher);
                    dr.SetField<String>("Tags", edit.newBook.tags);
                    saveTable(".xml");
                }
            }

            dgvTable.Select();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(savePath))
            {
                //saveDialog.FileName = saveName;
                saveDialog.ShowDialog();
            }
            else saveTable(".xml");
        }

        private void saveDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool found = false;
            for (int i = 0; i < extensions.Count; i++)
            {
                if (String.Equals(Path.GetExtension(saveDialog.FileName).ToLower(), "." + extensions[i].Item2))
                    found = true;
            }

            if (!found)
                saveDialog.FileName += "." + extensions[saveDialog.FilterIndex - 1].Item2;

            if (String.Equals(Path.GetExtension(saveDialog.FileName).ToLower(), ".xml"))
            {
                savePath = saveDialog.FileName;
                saveName = Path.GetFileNameWithoutExtension(savePath.Substring(savePath.LastIndexOf('\\')));
                this.Text = "Book Library - " + saveName;
            }
            saveTable(saveDialog.FileName);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDialog.FileName = "Untitled";
            saveDialog.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDialog.ShowDialog();
        }

        private void openDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            savePath = openDialog.FileName;
            saveName = openDialog.SafeFileName.Substring(0,openDialog.SafeFileName.Length-4);
            loadTable();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables.Count != 0)
            {
                saveTable(".xml");
                savePath = String.Empty;
                saveName = String.Empty;
                this.Text = "Book Library - Untitled";

                dataSet.Tables["Books"].Rows.Clear();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setupThePrinting())
                printDocument.Print();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = tablePrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;            
        }


        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (savePath != null && savePath != String.Empty)
                saveCookies();

            logger.stopService();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = printDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void sendByEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email email = new Email(logger);
            email.Owner = this;
            email.ShowDialog();
        }

        public DataSet getDataSet()
        {
            return dataSet;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About(logger);
            about.ShowDialog();
        }

        private void columnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tagsToolStripMenuItem.Checked = !tagsToolStripMenuItem.Checked;
            dgvTable.Columns["Tags"].Visible = tagsToolStripMenuItem.Checked;
        }

        private void cobxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterState = cobxFilter.SelectedIndex;
        }

        private String getName()
        {
            return "Main";
        }

        public String getSaveName()
        {
            return saveName;
        }

        public String getSavePath()
        {
            return savePath;
        }

        public String getTemporaryFilePath(String extension)
        {
            String path = Path.Combine(Path.GetTempPath(), "bookLibrary" + extension);

            try
            {
                switch (extension)
                {
                    case ".csv":
                        using (StreamWriter file = new StreamWriter(path))
                        {
                            int columns = dataTable.Columns.Count;

                            for (int i = 0; i < columns; i++)
                            {
                                if (i != 0)
                                    file.Write(", ");
                                file.Write(dataTable.Columns[i].ColumnName);
                            }
                            file.WriteLine();

                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                for (int j = 0; j < columns; j++)
                                {
                                    if (j != 0)
                                        file.Write(", ");
                                    file.Write(dataTable.Rows[i].ItemArray[j]);
                                }
                                file.WriteLine();
                            }
                        }
                        break;
                    case ".html":
                        using (StreamWriter file = new StreamWriter(path))
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.Append("<html><head>");
                            sb.Append("<h1>" + saveName + "</h1>");
                            sb.Append("</head>");


                            sb.Append("<body><table border='1' cellpadding='5' cellspacing='1'>");
                            sb.Append("<tr>");
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                sb.Append("<th>" + column.ColumnName + "</th>");
                            }
                            sb.Append("</tr>");

                            foreach (DataRow row in dataTable.Rows)
                            {
                                sb.Append("<tr>");
                                foreach (String cell in row.ItemArray)
                                {
                                    sb.Append("<td>" + cell + "</td>");
                                }
                                sb.Append("</tr>");
                            }

                            sb.Append("</table></body></html>");

                            file.Write(sb.ToString());
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.writeLine(this.getName(), "getTemporaryFilePath", ex);
            }

            return path;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(savePath);
            MessageBox.Show("Project size: " + (file.Length / 1024.0).ToString("0.##") + " kB" + Environment.NewLine +
                            "Book count: " + dataTable.Rows.Count);
        }

        private void menu_Enter(object sender, EventArgs e)
        {
            dgvTable.Select();
        }

    }
}
