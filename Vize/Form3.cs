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

namespace Vize
{
    public partial class Form3 : Form
    {
        private Form Form1;

        private string username;
        public Form3(Form Form1,string username)
        {
            InitializeComponent();
            this.Form1 = Form1;
            this.username= username;
            Form1.Hide();

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Show();
        }

        ArrayList productNames = new ArrayList(); // to keep the names of products
        ArrayList productPrices = new ArrayList(); // to keep the prices of products
        private void Form3_Load(object sender, EventArgs e)
        {
            label4.Text = username; // to see our username at the top left
            richTextBox1.Text = "Product Name \tQuantity \tUnit Price(TL)"; // richtextbox default text
            using (XmlReader reader = XmlReader.Create("urunler.xml")) // reading the products file
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "name":
                                productNames.Add(reader.ReadElementContentAsString()); //add the name of the product to the arraylist
                                break;
                            case "price":
                                productPrices.Add(reader.ReadElementContentAsString()); //add the price of the product to the arraylist
                                break;

                        }
                    }
                }
            }
            checkBox1.Text = productNames[0].ToString(); //change the checkbox name to the corresponding element name in the arraylist
            checkBox2.Text = productNames[1].ToString();
            checkBox3.Text = productNames[2].ToString();
            checkBox4.Text = productNames[3].ToString();
        }
        
        private int totalSum = 0; // total sum of products

        private void button5_Click(object sender, EventArgs e)
        {
            int sum = int.Parse(textBox1.Text); //increase product quantity
            sum++;
            textBox1.Text = sum.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            totalSum = int.Parse(textBox1.Text) + int.Parse(textBox2.Text) + int.Parse(textBox3.Text) + int.Parse(textBox4.Text); //dynamically change the grand total if the product quantity changes
            textBox5.Text = totalSum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="0") //If not 0, reduce product quantity
            {
                int sum = int.Parse(textBox1.Text);
                sum--;
                textBox1.Text = sum.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int sum = int.Parse(textBox2.Text); //increase product quantity
            sum++;
            textBox2.Text = sum.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            totalSum = int.Parse(textBox1.Text) + int.Parse(textBox2.Text) + int.Parse(textBox3.Text) + int.Parse(textBox4.Text); //urun adet değiş ise genel toplamı dinamik olarak değiştir
            textBox5.Text = totalSum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "0") //Reduce product qty if not 0
            {
                int sum = int.Parse(textBox2.Text);
                sum--;
                textBox2.Text = sum.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sum = int.Parse(textBox3.Text); //increase product quantity
            sum++;
            textBox3.Text = sum.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            totalSum = int.Parse(textBox1.Text) + int.Parse(textBox2.Text) + int.Parse(textBox3.Text) + int.Parse(textBox4.Text); //urun adet değiş ise genel toplamı dinamik olarak değiştir
            textBox5.Text = totalSum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "0") //Reduce product qty if not 0
            {
                int sum = int.Parse(textBox3.Text);
                sum--;
                textBox3.Text = sum.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int sum = int.Parse(textBox4.Text); //increase product quantity
            sum++;
            textBox4.Text = sum.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            totalSum = int.Parse(textBox1.Text) + int.Parse(textBox2.Text) + int.Parse(textBox3.Text) + int.Parse(textBox4.Text); //dynamically change the grand total if the product quantity changes
            textBox5.Text = totalSum.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "0") //Reduce product qty if not 0
            {
                int sum = int.Parse(textBox4.Text);
                sum--;
                textBox4.Text = sum.ToString();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.Show();
        }

        private ArrayList addedProduct; //arraylists for invoice form

        private ArrayList addedProductQuantity;

        private ArrayList addedProductPrice;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            addedProduct = new ArrayList();
            addedProductQuantity = new ArrayList();
            addedProductPrice = new ArrayList();
            richTextBox1.Text = "Product Name \tQuantity \tUNIT PRICE(TL)";
            bool ck = checkBox1.Checked;
            bool ck2 = checkBox2.Checked;
            bool ck3 = checkBox3.Checked;
            bool ck4 = checkBox4.Checked;
            float price1 = 0, price2 = 0, price3 = 0, price4 = 0;
            
            if (ck) //If checkbox is selected
            {
                if (int.Parse(textBox1.Text) > 0) // and the quantity is greater than 0
                {
                    price1 = float.Parse(textBox1.Text) * float.Parse(productPrices[0].ToString()); //multiply quantity and price to find the total price

                    richTextBox1.Text = richTextBox1.Text + "\n" + checkBox1.Text + "\t\tx" + textBox1.Text + "\t\t" + productPrices[0]; //add product to richtextbox
                    addedProduct.Add(checkBox1.Text);
                    addedProductQuantity.Add(textBox1.Text);
                    addedProductPrice.Add(productPrices[0]);
                }
            }
            if (ck2)
            {
                if (int.Parse(textBox2.Text) > 0)
                {
                    price2 = float.Parse(textBox2.Text) * float.Parse(productPrices[1].ToString());

                    richTextBox1.Text = richTextBox1.Text + "\n" + checkBox2.Text + "\t\t\tx" + textBox2.Text + "\t\t" + productPrices[1];
                    addedProduct.Add(checkBox2.Text);
                    addedProductQuantity.Add(textBox2.Text);
                    addedProductPrice.Add(productPrices[1]);
                }
            }
            if (ck3)
            {
                if (int.Parse(textBox3.Text) > 0)
                {
                    price3 = float.Parse(textBox3.Text) * float.Parse(productPrices[2].ToString());

                    richTextBox1.Text = richTextBox1.Text + "\n" + checkBox3.Text + "\t\tx" + textBox3.Text + "\t\t" + productPrices[2];
                    addedProduct.Add(checkBox3.Text);
                    addedProductQuantity.Add(textBox3.Text);
                    addedProductPrice.Add(productPrices[2]);
                }
            }
            if (ck4)
            {
                if (int.Parse(textBox4.Text) > 0)
                {
                    price4 = float.Parse(textBox4.Text) * float.Parse(productPrices[3].ToString());

                    richTextBox1.Text = richTextBox1.Text + "\n" + checkBox4.Text + "\t\t\tx" + textBox4.Text + "\t\t" + productPrices[3];
                    addedProduct.Add(checkBox4.Text);
                    addedProductQuantity.Add(textBox4.Text);
                    addedProductPrice.Add(productPrices[3]);
                }
            }
            if ((ck||ck2||ck3||ck4)&&textBox5.Text!="0") //if no checkbox is selected and the general quantity value is not 0
            {
                richTextBox1.Text = richTextBox1.Text + "\n\nSum\t\t\t\t" + (price1 + price2 + price3 + price4+"TL"); //add total price
            }

            MessageBox.Show("Selected products calculated!", "Calculate", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void pictureBox3_Click(object sender, EventArgs e) //her şeyi temizle
        {
            checkBox1.Checked = false; 
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            richTextBox1.Text = "Product Name \tQuantity \tUNIT PRICE(TL)";
            MessageBox.Show("List Cleared!", "Clear", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Product Name \tQuantity \tUNIT PRICE(TL)") // if richtextbox is the default text
            {
                MessageBox.Show("Make calculations before printing an invoice!", "Calculate Invoice", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Form7 f7 = new Form7(this,addedProduct,addedProductQuantity,addedProductPrice); // if not open the invoice page
                f7.ShowDialog();
            }
            
        }
    }
}
