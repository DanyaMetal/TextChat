using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class NewUser : Form
    {

        public MainForm form; 

        public NewUser(MainForm mainForm)
        {
            InitializeComponent();

            form = mainForm;
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.nameClient = nameTextBox1.Text;
           // form.i = 2;
            this.Close();
        }
    }
}
