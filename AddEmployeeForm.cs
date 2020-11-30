using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMultiple
{
    public partial class AddEmployeeForm : Form
    {
        private EmployeeModel employee = new EmployeeModel();
        public delegate void AddHandlerDelegate(EmployeeModel employee);
        private AddHandlerDelegate addHandler;
        /* public AddEmployeeForm(EmployeeModel employee)
        {
            InitializeComponent();
            this.employee = employee;
        } */
        public AddEmployeeForm(AddHandlerDelegate addHandler)
        {
            InitializeComponent();
            this.addHandler = addHandler;
        }

        private void finishAddButton_Click(object sender, EventArgs e)
        {
            addHandler.Invoke(employee);
            this.DialogResult = DialogResult.OK;
        }

        private void employeeNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // employee.Name = employeeNameTextBox.Text;
            employee.Name = employeeNameTextBox.Text;
        }
    }
}
