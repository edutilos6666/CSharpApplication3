using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpApplication3
{
    public partial class PersonDAOForm : Form
    {
        public PersonDAOForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private PersonDAO dao = new PersonDAOMyslqImpl(); 

        private void btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            lblStatus.Text = "Status: Save Button was clicked.";
            PersonSaveForm form = new PersonSaveForm(lblStatus, dao);
           // this.Dispose();
            form.Show(); 
        }

        private void btnUpdate_MouseClick(object sender, MouseEventArgs e)
        {
            lblStatus.Text = "Status: Update Button was clicked.";
            PersonUpdateForm form = new PersonUpdateForm(lblStatus, dao);
            form.Show(); 
        }

        private void btnDelete_MouseClick(object sender, MouseEventArgs e)
        {
            lblStatus.Text = "Status: Delete Button was clicked.";
            try
            {
                long id = Convert.ToInt64(tbDelete.Text);
                dao.Delete(id); 
            } catch(Exception ex)
            {
                lblStatus.Text = ex.Message; 
            }
        }

        private void btnFindById_MouseClick(object sender, MouseEventArgs e)
        {
            lblStatus.Text = "Status: FindById Button was clicked.";
            try
            {
                long id = Convert.ToInt64(tbFindById.Text);
                PersonFindByIdForm form = new PersonFindByIdForm(id, dao);
                form.Show(); 
            } catch(Exception ex)
            {
                lblStatus.Text = ex.Message; 
            }
        }

        private void btnFindAll_MouseClick(object sender, MouseEventArgs e)
        {
            lblStatus.Text = "Status: FindAll Button was clicked.";
            PersonFindAllForm form = new PersonFindAllForm(dao);
            form.Show(); 
        }
    }
}
