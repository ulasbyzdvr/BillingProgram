using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vize
{
    public partial class Form6 : Form
    {
        private Form Form2;
        public Form6(Form Form2)
        {
            InitializeComponent();
            this.Form2 = Form2;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            Form2.Hide();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2.Show();
        }

        private ArrayList prices = new ArrayList(); // arraylist for prices
        private void Form6_Load(object sender, EventArgs e)
        {
            string productName="";
            double productPrice=0;
            using (XmlReader reader = XmlReader.Create("urunler.xml")) //read product file
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "name":
                                productName = reader.ReadElementContentAsString();
                                comboBox1.Items.Add(productName); //add product name as a combobox item
                                break;
                            case "price":
                                productPrice =  double.Parse(reader.ReadElementContentAsString());
                                prices.Add(productPrice); //add product price
                                break;
                        }

                    }

                }
            }
            comboBox1.SelectedIndex= 0; //default selected index
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Clear();
            int index = comboBox1.SelectedIndex; // give selected index
            label4.Text = "Old Price: " + prices[index] +"TL"; //print selected product price
        }

        private void btnFiyatGüncelle_Click(object sender, EventArgs e)
        {
            float fiyat;
            bool sonuc = float.TryParse(txtPrice.Text, out fiyat); // tryparse product price
            if (sonuc) //change the price of the product if the result is true
            {
                string selectedProduct = comboBox1.SelectedItem.ToString();
                int priceIndex = comboBox1.SelectedIndex;
                string file = @"urunler.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                foreach (XmlNode xNode in doc.SelectNodes("products/product"))
                {
                    if (xNode.SelectSingleNode("name").InnerText == selectedProduct) //find the location in the file with the name of the selected product
                    {
                        xNode.SelectSingleNode("price").InnerText = txtPrice.Text; // change price to entered price
                        prices[priceIndex] = txtPrice.Text;
                        break;
                    }
                }
                doc.Save(file);
                int index = comboBox1.SelectedIndex;
                label4.Text = "Old Price: " + prices[index] + "TL";
                MessageBox.Show(selectedProduct+ " price updated to " + prices[priceIndex] + "TL!", "Price Update");
               
            }
            else
            {
                MessageBox.Show("Enter a valid value", "Value Invalid!", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
