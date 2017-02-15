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
    public partial class PersonSaveForm : Form
    {
        private Label lblStatus;
        private PersonDAO dao; 
        public PersonSaveForm(Label lblStatus, PersonDAO dao)
        {
            InitializeComponent();
            this.lblStatus = lblStatus;
            this.dao = dao; 
        }

        private void btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                long id = Convert.ToInt64(tbId.Text);
                string name = tbName.Text;
                int age = Convert.ToInt32(tbAge.Text);
                double wage = Convert.ToDouble(tbWage.Text);
                dao.Save(new Person(id, name, age, wage));
                
            } catch(Exception ex)
            {
                lblStatus.Text = ex.Message; 
            } finally
            {
                this.Dispose();
            }
        }

        private void btnCancel_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose(); 
        }
    }
}
