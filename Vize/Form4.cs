using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Vize.Properties;

namespace Vize
{
    public partial class Form4 : Form
    {
        private Form Form2;
        public Form4(Form Form2)
        {
            InitializeComponent();
            this.Form2 = Form2;
            Form2.Hide();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.Show();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            String name = "",Password ="";
            int userAlreadyHave = 0;
            using (XmlReader reader = XmlReader.Create("user.xml")) // read users file
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "username":
                                name = reader.ReadElementContentAsString();
                                if (txtUsername.Text==name) //check if the user is present
                                {
                                    userAlreadyHave = 1;
                                }
                                break;
                            case "password":
                                Password = reader.ReadElementContentAsString();
                                break;
                        }
                        
                    }
                    
                }
                if (txtUsername.Text =="admin") // give an error if the user name entered is admin
                {
                    MessageBox.Show("You cannot add admin!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
                else if(txtUsername.Text.Equals("")||txtPassword.Text.Equals("")) // if fields are empty
                {
                    MessageBox.Show("Fields cannot be left blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
                else if (userAlreadyHave==1) // If there is a user
                {
                    MessageBox.Show("User already exists", "User Available!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
                else if (userAlreadyHave==0) // add the user if there is no user
                {
                    reader.Close();
                    name = txtUsername.Text;
                    Password = txtPassword.Text;
                    string file = @"user.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);
                    XmlNode user = doc.CreateElement("user");
                    XmlNode username = doc.CreateElement("username");
                    username.InnerText = name;
                    XmlNode password = doc.CreateElement("password");
                    password.InnerText = Password;
                    user.AppendChild(username);
                    user.AppendChild(password);
                    doc.DocumentElement.AppendChild(user);
                    doc.Save(file);
                    txtUsername.Clear();
                    txtPassword.Clear();
                    MessageBox.Show("New User Added", "User Added!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2.Show();
        }
    }
}
