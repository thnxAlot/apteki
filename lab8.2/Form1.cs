using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace lab8._2
{
    public partial class Form1 : Form
    {
        public static Form1 _f;

        public info_form info;
        OpenFileDialog openFileDialog;
        public Form1()
        {
            _f = this;
            InitializeComponent();
            
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml files(*.xml)|*.xml|txt files(*.txt)|*.txt";
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            MaximumSize = new Size(350, 100);
            MinimumSize = new Size(300, 75);
            


            XElement root = XElement.Load("cons.xml");
            IEnumerable<XElement> apteka =
                from el in root.Elements("aptek")
                where (string)el.Attribute("number") == "10"
                select el;

            IEnumerable<XElement> medicine =
                from el in apteka.Elements("medicine")
                where (string)el.Attribute("type") == "pills1"
                select el;
            IEnumerable<XElement> dat =
                from el in medicine.Elements("data")
                where (string)el.Attribute("var") == "12.12.12"
                select el;
            //foreach (XElement el in dat)
                //richTextBox1.Text += el.Parent.Parent;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            
            string filename = openFileDialog.FileName;
            this.Hide();
            info = new info_form();
            info.Show();
            info.root = XElement.Load(filename);
            info.set_tree();

        }

        public static void show_again()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XElement newRoot = new XElement("apteki");
            this.Hide();
            info = new info_form();
            info.Show();
            info.root = newRoot;
            info.set_tree();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
