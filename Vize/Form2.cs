using System;
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
    public partial class Form2 : Form
    {
        private Form Form1;
        public Form2(Form Form1)
        {
            InitializeComponent();
            this.Form1 = Form1;
            Form1.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Show();
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(this); //add user panel
            f4.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close(); //to come back
            Form1.Show();
        }

        private void btnUrunFiyatGuncelle_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(this); //product price change page
            f6.ShowDialog();
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(this); //delete user panel
            f5.ShowDialog();
        }
    }
}
