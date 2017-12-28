using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinanceMananger.Core;

namespace FinanceManager.Gui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.RenderForm();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.AddTransaction();
        }

        private void RenderForm()
        {
            this.dataGridView1.SuspendLayout();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = ModelLoader.CurrentModel.Transactions.OrderBy(s => s.Date).Reverse().ToList();
            this.dataGridView1.ResumeLayout();
        }

        private void AddTransaction()
        {
            using (var addDialog = new AddTransactionDialog())
            {
                if (addDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.RenderForm();
                }
            }
        }

        private void addPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddTransaction();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EditTransaction();
        }

        private void EditTransaction()
        {

        }

        private void removePresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RemoveTransaction();
        }

        private void RemoveTransaction()
        {
            var d = this.dataGridView1.SelectedRows[0];
            if (MessageBox.Show(string.Format("Are you sure to delete {0}?", this.dataGridView1.SelectedRows[0].Cells[this.NameCol.Index].Value), "Delete?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
            }
        }
    }
}
