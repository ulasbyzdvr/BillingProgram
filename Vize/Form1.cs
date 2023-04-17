using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Vize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            txtUsername.Clear(); //clear username
            txtPassword.Clear(); //clear password
        }
        private bool button = false;
        private void pictureBox1_Click(object sender, EventArgs e) //Are you sure without exiting the application
        {
            
            DialogResult result = MessageBox.Show("Are you sure you want to close the app?", "Application Exit", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                button= true;
                Application.Exit();
            }    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // the question that appears when the cross key of the form is pressed
        {
            if (button == false)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to close the app?", "Application Exit", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            
        }
        ArrayList users; // arraylist to keep user
        private void picGiris_Click(object sender, EventArgs e)
        {
            String name = "", password = "";
            using (XmlReader reader = XmlReader.Create("admin.xml")) //reading admin file
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "username":
                                name = reader.ReadElementContentAsString();
                                break;
                            case "password":
                                password = reader.ReadElementContentAsString();
                                break;

                        }
                    }
                }
            }
            if (txtUsername.Text.Equals(name) && txtPassword.Text.Equals(password)) //to open the admin panel if the value entered is admin and password
            {
                Form2 f2 = new Form2(this);
                f2.ShowDialog();

            }
            else if (txtUsername.Text.Equals(name) && !txtPassword.Text.Equals(password)) // If the admin password is entered incorrectly
            {
                MessageBox.Show("Admin password entered incorrectly!", "Password Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!txtUsername.Text.Equals("") && !txtPassword.Text.Equals("")) //to open the user panel if the value entered is not admin and password
            {
                users = new ArrayList(); // new arraylist
                int userAvailable = 0; // variable to check if there is a user
                String username = "", userPassword = ""; //variable to assign username and password
                using (XmlReader reader = XmlReader.Create("user.xml")) //reading users file
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name.ToString())
                            {
                                case "username":
                                    username = reader.ReadElementContentAsString();
                                    users.Add(username); // to add the username to the arraylist
                                    break;
                                case "password":
                                    userPassword = reader.ReadElementContentAsString();
                                    users.Add(userPassword); // to add the password to the arraylist
                                    break;

                            }
                        }
                    }
                }
                
                for (int i = 0; i < users.Count; i=i+2) //to return to the list of users and open the panel if there is a user
                {
                    if (users[i].ToString()==txtUsername.Text)//when the value entered in the username is found in the users arraylist
                    {
                        userAvailable = 1; //If there is a user 
                        if (users[i + 1].ToString() == txtPassword.Text) //if the password matches
                        {
                            Form3 f3 = new Form3(this, txtUsername.Text); // opens user panel
                            f3.ShowDialog();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("User password entered incorrectly", "Password Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        
                    }
                }
                if (userAvailable == 0) //works if there are no users
                {
                    MessageBox.Show("User cannot be found", "No User!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
            else
            {
                MessageBox.Show("Fields cannot be left blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
