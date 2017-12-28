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
    public partial class AddTransactionDialog : Form
    {
        public AddTransactionDialog()
        {
            InitializeComponent();

            this.numericUpDown1.Maximum = decimal.MaxValue;
            this.numericUpDown1.Minimum = decimal.MinValue;
            this.RenderPresets();
            this.nameTextBox.Focus();
            this.nameTextBox.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.nameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid name!");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
            else
            {
                var transaction = new Transaction();

                transaction.Date = dateTimePicker1.Value;
                transaction.Amount = this.numericUpDown1.Value;
                transaction.Name = this.nameTextBox.Text;

                ModelLoader.CurrentModel.Transactions.Add(transaction);
                ModelLoader.SaveModel();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            this.numericUpDown1.Select(0, this.numericUpDown1.Text.Length);
        }

        private string CurrentPreset
        {
            get
            {
                return string.Format("{0} {1}", this.numericUpDown1.Value.ToString(), this.nameTextBox.Text);
            }
        }

        private void AddPreset()
        {
            ModelLoader.CurrentModel.Presets.Add(this.CurrentPreset);

            ModelLoader.SaveModel();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetFormState();
        }

        private void SetFormState()
        {
            this.addPresetToolStripMenuItem.Enabled = !string.IsNullOrWhiteSpace(this.nameTextBox.Text);
        }

        private void RenderPresets()
        {
            this.SuspendLayout();

            this.toolStripComboBox1.Items.Clear();

            foreach (var item in ModelLoader.CurrentModel.Presets)
            {
                this.toolStripComboBox1.Items.Add(item);
            }

            this.toolStripComboBox1.SelectedIndex = -1;

            this.ResumeLayout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.AddPreset();

            this.RenderPresets();
        }

        private void toolStripComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.toolStripComboBox1.SelectedIndex >= 0)
            {
                var numValue = Convert.ToDecimal(toolStripComboBox1.Text.Substring(0, toolStripComboBox1.Text.IndexOf(" ")));
                this.numericUpDown1.Value = numValue;

                this.nameTextBox.Text = toolStripComboBox1.Text.Substring(toolStripComboBox1.Text.IndexOf(" ") + 1);

                this.toolStripComboBox1.SelectedIndex = -1;

                if (numValue == 0)
                {
                    this.numericUpDown1.Focus();
                }
                else
                {
                    this.button1.Focus();
                }
            }
        }

        private void addPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddPreset();

            this.RenderPresets();
        }

        private void removePresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RemovePreset();

            this.RenderPresets();
        }

        private void RemovePreset()
        {
            ModelLoader.CurrentModel.Presets.Remove(this.CurrentPreset);

            ModelLoader.SaveModel();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            var containsPreset = ModelLoader.CurrentModel.Presets.Contains(this.CurrentPreset);

            this.addPresetToolStripMenuItem.Enabled = !containsPreset && !string.IsNullOrWhiteSpace(this.nameTextBox.Text);
            this.removePresetToolStripMenuItem.Enabled = containsPreset;
        }
    }
}
