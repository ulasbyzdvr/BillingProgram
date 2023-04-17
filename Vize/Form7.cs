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

namespace Vize
{
    public partial class Form7 : Form
    {
        private Form Form3;
        private ArrayList addedProduct;
        private ArrayList addedProductQuantity;
        private ArrayList addedProductPrice;
        public Form7(Form Form3,ArrayList addedProduct,ArrayList addedProductQuantity,ArrayList addedProductPrice) // getting arrays from other form
        {
            InitializeComponent();
            this.Form3 = Form3;
            this.addedProduct = addedProduct; 
            this.addedProductQuantity= addedProductQuantity;
            this.addedProductPrice= addedProductPrice;
            label1.Parent = pictureBox1; //transparent for texts
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label4.Parent = pictureBox1;
            label5.Parent = pictureBox1;
            label6.Parent = pictureBox1;
            label7.Parent = pictureBox1;
            label8.Parent = pictureBox1;
            label9.Parent = pictureBox1;
            label10.Parent = pictureBox1;
            label11.Parent = pictureBox1;
            label12.Parent = pictureBox1;
            label13.Parent = pictureBox1;
            label14.Parent = pictureBox1;
            label15.Parent = pictureBox1;
            label16.Parent = pictureBox1;
            label17.Parent = pictureBox1;
            label18.Parent = pictureBox1;
            label19.Parent = pictureBox1;
            label20.Parent = pictureBox1;
            pictureBox2.Parent= pictureBox1;
            pictureBox1.BackColor = Color.Transparent;
            Form3.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
           

            if (addedProduct.Count==1) // bring the invoice with the number of products added
            {
                pictureBox1.Image = Image.FromFile(@"faturalar\fatura2.png");
            }
            if (addedProduct.Count == 2)
            {
                pictureBox1.Image = Image.FromFile(@"faturalar\fatura3.png");
            }
            if (addedProduct.Count == 3)
            {
                pictureBox1.Image = Image.FromFile(@"faturalar\fatura4.png");
            }
            if (addedProduct.Count == 4)
            {
                pictureBox1.Image = Image.FromFile(@"faturalar\fatura1.png");
            }

            float sum = 0;

            for (int i = 0; i < addedProduct.Count; i++) // return the number of products added and assign values to labels
            {
                if (i==0)
                {
                    float price = float.Parse(addedProductQuantity[i].ToString()) * float.Parse(addedProductPrice[i].ToString());

                    label1.Text = addedProduct[i].ToString();
                    label5.Text = addedProductQuantity[i].ToString();
                    label9.Text = addedProductPrice[i].ToString() + "TL";
                    label16.Text = price.ToString() + "TL";

                    sum += price;
                }
                if (i == 1)
                {
                    float price = float.Parse(addedProductQuantity[i].ToString()) * float.Parse(addedProductPrice[i].ToString());

                    label2.Text = addedProduct[i].ToString();
                    label6.Text = addedProductQuantity[i].ToString();
                    label10.Text = addedProductPrice[i].ToString() + "TL";
                    label15.Text = price.ToString() + "TL";

                    sum += price;
                }
                if (i == 2)
                {
                    float price = float.Parse(addedProductQuantity[i].ToString()) * float.Parse(addedProductPrice[i].ToString());

                    label3.Text = addedProduct[i].ToString();
                    label7.Text = addedProductQuantity[i].ToString();
                    label11.Text = addedProductPrice[i].ToString() + "TL";
                    label14.Text = price.ToString() + "TL";

                    sum += price;
                }
                if (i == 3)
                {
                    float price = float.Parse(addedProductQuantity[i].ToString()) * float.Parse(addedProductPrice[i].ToString());

                    label4.Text = addedProduct[i].ToString();
                    label8.Text = addedProductQuantity[i].ToString();
                    label12.Text = addedProductPrice[i].ToString() + "TL";
                    label13.Text = price.ToString() + "TL";

                    sum += price;
                }
            }
            label17.Text = sum.ToString()+"TL";
            label19.Text = sum.ToString()+"TL";
            DateTime date = DateTime.Now; //keeps the current date and time
            label20.Text = date.ToString(); 
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3.Show();
        }
    }
}
