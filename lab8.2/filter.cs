using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8._2
{
    public partial class filter : Form
    {
        string aptek="";
        string prep="";
        string data="";
        string srok="";
        string price="";
        string ammount="";
        public filter()
        {
            InitializeComponent();
            //AutoSize = false;
        }

        private void aptekBox_TextChanged(object sender, EventArgs e)
        {
            aptek = aptekBox.Text;
            prep = prepBox.Text;
            data = dateTimePicker1.Value.ToString().Substring(0, 10);
            srok = srokBox.Text;
            price = priceBox.Text;
            ammount = ammountBox.Text;
        }

        private void prepBox_TextChanged(object sender, EventArgs e)
        {
            aptek = aptekBox.Text;
            prep = prepBox.Text;
            data = dateTimePicker1.Value.ToString().Substring(0, 10);
            srok = srokBox.Text;
            price = priceBox.Text;
            ammount = ammountBox.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            aptek = aptekBox.Text;
            prep = prepBox.Text;
            data = dateTimePicker1.Value.ToString().Substring(0, 10);
            srok = srokBox.Text;
            price = priceBox.Text;
            ammount = ammountBox.Text;
        }

        private void srokBox_TextChanged(object sender, EventArgs e)
        {
            aptek = aptekBox.Text;
            prep = prepBox.Text;
            data = dateTimePicker1.Value.ToString().Substring(0,10);
            srok = srokBox.Text;
            price = priceBox.Text;
            ammount = ammountBox.Text;
        }

        private void priceBox_TextChanged(object sender, EventArgs e)
        {
            aptek = aptekBox.Text;
            prep = prepBox.Text;
            data = dateTimePicker1.Value.ToString().Substring(0, 10);
            srok = srokBox.Text;
            price = priceBox.Text;
            ammount = ammountBox.Text;
        }

        private void ammountBox_TextChanged(object sender, EventArgs e)
        {
            aptek = aptekBox.Text;
            prep = prepBox.Text;
            data = dateTimePicker1.Value.ToString().Substring(0, 10);
            srok = srokBox.Text;
            price = priceBox.Text;
            ammount = ammountBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                Form1._f.info.set_tree(aptek,
                                prep,
                                data,
                                srok,
                                price,
                                ammount);
            }
            else
            {
                Form1._f.info.set_tree(aptek,
                                prep,
                                "",
                                srok,
                                price,
                                ammount);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1._f.info.set_tree();
        }
    }
}
