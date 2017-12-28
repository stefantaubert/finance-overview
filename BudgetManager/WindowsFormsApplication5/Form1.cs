using System;
using System.IO;
using System.Windows.Forms;

namespace BudgetManager
{
    public partial class Form1 : Form
    {
        private readonly string path;
        private Model model;

        public Form1()
        {
            this.InitializeComponent();

            this.path = Path.Combine(Application.StartupPath, "model.xml");

            this.InitializeModel();

            this.HandleSizeChanged();
        }

        private void InitializeModel()
        {
            if (File.Exists(this.path))
            {
                this.model = this.model.Load(path);
            }

            if (this.model == default(Model))
            {
                this.model = new Model();
            }

            this.RenderEntries();
        }

        private void HandleFormClosing()
        {
            this.model.Save(this.path);
        }

        private void RenderEntries()
        {
            this.listView1.SuspendLayout();

            this.listView1.Items.Clear();

            for (int i = 0; i < this.model.Entries.Count; i++)
            {
                this.listView1.Items.Add(new EntryListViewItem(this.model.Entries[this.model.Entries.Count - 1 - i]));
            }

            this.listView1.ResumeLayout();
        }

        private void HandleComboBoxKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (AddEntry())
                {
                    e.Handled = e.SuppressKeyPress = true;
                }
            }
        }

        private bool AddEntry()
        {
            var value = this.comboBox1.Text.Trim();
            var result = default(Entry);
            var success = Entry.TryParse(value, out result);

            if (success)
            {
                this.comboBox1.Text = string.Empty;

                result.DateTime = dateTimePicker1.Value;

                this.model.AddEntry(result);

                this.RenderEntries();
            }

            return success;
        }

        private void ChangeSelectedItem()
        {
            var selectedItem = (this.listView1.SelectedItems[0] as EntryListViewItem).CurrentEntry;

            this.comboBox1.Text = selectedItem.ToString();
            this.dateTimePicker1.Value = selectedItem.DateTime;

            this.model.DeleteEntry(selectedItem);

            this.RenderEntries();
        }

        private void DeleteSelectedItems()
        {
            foreach (EntryListViewItem item in this.listView1.SelectedItems)
            {
                this.model.DeleteEntry(item.CurrentEntry);
            }

            this.RenderEntries();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.HandleComboBoxKeyDown(e);
        }

        private void ändernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeSelectedItem();
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedItems();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.HandleFormClosing();
        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            this.HandleSizeChanged();
        }

        private void HandleSizeChanged()
        {
            listView1.Columns[0].Width = 80;
            listView1.Columns[2].Width = 80;
            listView1.Columns[1].Width = listView1.Width - listView1.Columns[0].Width - listView1.Columns[2].Width - 20;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HandleContextMenuOpening(e);
        }

        private void HandleContextMenuOpening(System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items[0].Visible = this.listView1.SelectedItems.Count == 1;
            contextMenuStrip1.Items[1].Visible = this.listView1.SelectedItems.Count >= 1;

            //e.Cancel = this.listView1.SelectedItems.Count == 0;
        }

        private void HandleStatisticsShowHide()
        {
            richTextBox1.Visible = !richTextBox1.Visible;
            splitter1.Visible = richTextBox1.Visible;
        }

        private void statistikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.HandleStatisticsShowHide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.HandleStatisticsShowHide();
        }
    }
}
