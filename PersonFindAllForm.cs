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
    public partial class PersonFindAllForm : Form
    {
        private PersonDAO dao; 

        public PersonFindAllForm(PersonDAO dao)
        {
            InitializeComponent();
            this.dao = dao; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose(); 
        }

        private void PersonFindAll_Load(object sender, EventArgs e)
        {
            List<Person> all = dao.FindAll();
            String res = "", nl = "\r\n"; 
            foreach(var p in all)
            {
                res += p.ToString() + nl; 
            }
            tbPerson.Text = res; 
        }
    }
}
