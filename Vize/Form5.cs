using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Vize
{
    public partial class Form5 : Form
    {
        private Form Form2;
        public Form5(Form Form2)
        {
            InitializeComponent();
            this.Form2 = Form2;
            Form2.Hide();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.Show();
        }

        private void btnSil_Click(object sender, EventArgs e) //delete user
        {
            int userAvailable = 0;
            string file = @"user.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            foreach (XmlNode xNode in doc.SelectNodes("panel/user"))
            {
                if (xNode.SelectSingleNode("username").InnerText==txtUsername.Text) // deletes if there is a user whose username matches
                {
                    xNode.ParentNode.RemoveChild(xNode);
                    userAvailable = 1;
                    MessageBox.Show(txtUsername.Text+ " user deleted", "Successfully deleted", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    break;
                }
            }
            if (txtUsername.Text.Equals("")) 
            {
                MessageBox.Show("The field cannot be left blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (userAvailable==0) //error if there is no user
            {
                MessageBox.Show("No user found!", "No User", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            txtUsername.Clear();
            doc.Save(file);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2.Show();
        }
    }
}
