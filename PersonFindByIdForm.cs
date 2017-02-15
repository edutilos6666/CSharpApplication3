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
    public partial class PersonFindByIdForm : Form
    {
        private PersonDAO dao;
        private long personId; 
        public PersonFindByIdForm(long personId , PersonDAO dao)
        {
            InitializeComponent();
            this.personId = personId;
            this.dao = dao; 
        }

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide(); 
        }

        private void PersonFindByIdForm_Load(object sender, EventArgs e)
        {
            var person = dao.FindById(personId);
            tbId.Text = person.Id.ToString();
            tbName.Text = person.Name;
            tbAge.Text = person.Age.ToString();
            tbWage.Text = person.Wage.ToString();  
        }
    }
}
