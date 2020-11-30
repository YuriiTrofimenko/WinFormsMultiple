using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMultiple
{
    public partial class EmployeesForm : Form
    {
        public EmployeesForm()
        {
            InitializeComponent();
            employeesListView.Items.AddRange(new ListViewItem[] { 
                new ListViewItem("Emp 1"),
                new ListViewItem("Emp 2"),
                new ListViewItem("Emp 3")
            });
        }

        private void add_Click(object sender, EventArgs e)
        {
            /* dynamic employee = new EmployeeModel { Name = "" };
            var addForm = new AddEmployeeForm(employee); */
            var addForm =
                new AddEmployeeForm(
                    employee => employeesListView.Items.Add(new ListViewItem(employee.Name))
                );
            if (addForm.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show(
                    "Nothing was added",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            /* if (addForm.ShowDialog() == DialogResult.OK)
            {
                employeesListView.Items.Add(new ListViewItem(employee.Name));
            }
            else
            {
                MessageBox.Show(
                    "Nothing was added",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            } */
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "All files (*.*)|*.*|(*.txt)|*.txt";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.Text =
                    File.ReadAllText(openDialog.FileName);
            }
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            // saveDialog.CheckFileExists = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveDialog.FileName);
                writer.Write(richTextBox1.Text);
                writer.Close();
            }
        }
    }
}
