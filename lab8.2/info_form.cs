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
    public class check_class
    {
        public bool check_tree(string path)
        {
            XElement root = XElement.Load(path);

            IEnumerable<XElement> apteka;


            apteka =
                from el in root.Elements("aptek")
                    // where (string)el.Attribute("number") == apteks
                    select el;



            foreach (XElement apk in apteka)
            {
                int a;
                if (!int.TryParse(apk.Attribute("number").Value, out a))
                {

                    return false;
                }
                else
                {
                    if (a <= 0)
                    {

                        return false;
                    }
                }


                IEnumerable<XElement> medicine;

                medicine =
                from el in apk.Elements("medicine")
                        //where (string)el.Attribute("number") == "10"
                select el;


                foreach (XElement meds in medicine)
                {

                    IEnumerable<XElement> data;

                    data =
                        from el in meds.Elements("data")
                            //where (string)el.Attribute("number") == "10"
                            select el;


                    foreach (XElement dats in data)
                    {





                        int b;
                        if (!int.TryParse(dats.Element("srok").Value, out b))
                        {

                            return false;
                        }
                        else
                        {
                            if (b <= 0)
                            {

                                return false;
                            }
                        }
                        if (!int.TryParse(dats.Element("ammount").Value, out b))
                        {

                            return false;
                        }
                        else
                        {
                            if (b <= 0)
                            {

                                return false;
                            }
                        }
                        if (!int.TryParse(dats.Element("price").Value, out b))
                        {

                            return false;
                        }
                        else
                        {
                            if (b <= 0)
                            {

                                return false;
                            }
                        }



                    }

                }

            }
            return true;
        }

    }

    public partial class info_form : Form
    {
        public static info_form _i;
        public XElement root;
        public filter fil;
        public add_row add_rem;
        
        public info_form()
        {
            _i = this;
            fil = new filter();
            InitializeComponent();
        }

        private void info_form_Load(object sender, EventArgs e)
        {
            MaximumSize = new Size(800, 920);
            MinimumSize = new Size(700, 600);
            this.Text = "apteki";
            BackColor = Color.White;
            

            
        }

        private void info_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1._f.Show();
        }

        
        public void set_tree(string apteks = "", string prepors = "", 
            string datas = "", string sroks="", 
            string prices="", string ammounts= "")
        {
            richTextBox1.Text = "";
            IEnumerable<XElement> apteka;
            if (apteks != "")
            {
                apteka =
                    from el in root.Elements("aptek")
                    where (string)el.Attribute("number") == apteks
                    select el;
            }
            else
            {
                apteka =
                    from el in root.Elements("aptek")
                    // where (string)el.Attribute("number") == apteks
                    select el;
            }
            
            
            foreach (XElement apk in apteka)
            {
                int a;
                if(!int.TryParse(apk.Attribute("number").Value,out a))
                {
                    DialogResult result = MessageBox.Show(
                                    "одна из аптек имела неверный номер",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                    return;
                }
                else
                {
                    if(a<=0)
                    {
                        DialogResult result = MessageBox.Show(
                                    "одна из аптек имела неверный номер",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                        return;
                    }
                }
                string new_zapis="";
                string otstup = "";
                richTextBox1.Text += "Аптека ";
                richTextBox1.Text += apk.Attribute("number").Value;
                richTextBox1.Text += "\n";

                IEnumerable<XElement> medicine;
                if (prepors != "")
                {
                medicine =
                from el in apk.Elements("medicine")
                where (string)el.Attribute("type") == prepors
                select el;
                }
                else
                {
                medicine =
                from el in apk.Elements("medicine")
                    //where (string)el.Attribute("number") == "10"
                select el;
                }
                
                foreach (XElement meds in medicine)
                {
                    otstup = "       ";
                    richTextBox1.Text += otstup + "Препарат ";
                    richTextBox1.Text += meds.Attribute("type").Value;
                    richTextBox1.Text += "\n";
                    IEnumerable<XElement> data;
                    if (datas != "")
                    {
                       data  =
                            from el in meds.Elements("data")
                            where (string)el.Attribute("var") == datas
                            select el;
                    }
                    else
                    {
                        data =
                            from el in meds.Elements("data")
                            //where (string)el.Attribute("number") == "10"
                            select el;
                    }
                    
                    foreach (XElement dats in data)
                    {
                        otstup = "              ";
                        richTextBox1.Text += otstup + "Дата ";
                        richTextBox1.Text += dats.Attribute("var").Value;
                        richTextBox1.Text += "\n";

                        //foreach (XElement vals in dats)
                        //{

                        //}
                        otstup = "                      ";
                        if(
                            (dats.Element("srok").Value==sroks && sroks!="" || sroks=="")
                            &&
                            (dats.Element("price").Value == prices && prices!="" || prices =="")
                            &&
                            (dats.Element("ammount").Value == ammounts && ammounts!="" || ammounts=="")
                            
                            )
                        {
                            int b;
                            if (!int.TryParse(dats.Element("srok").Value, out b))
                            {
                                DialogResult result = MessageBox.Show(
                                                "один из сроков имел неверное значение",
                                                "ERROR",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error,
                                                MessageBoxDefaultButton.Button1
                                                );
                                return;
                            }
                            else
                            {
                                if (b <= 0)
                                {
                                    DialogResult result = MessageBox.Show(
                                                "один из сроков имел неверное значение",
                                                "ERROR",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error,
                                                MessageBoxDefaultButton.Button1
                                                );
                                    return;
                                }
                            }
                            if (!int.TryParse(dats.Element("ammount").Value, out b))
                            {
                                DialogResult result = MessageBox.Show(
                                                "одно количество имело неверное значение",
                                                "ERROR",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error,
                                                MessageBoxDefaultButton.Button1
                                                );
                                return;
                            }
                            else
                            {
                                if (b <= 0)
                                {
                                    DialogResult result = MessageBox.Show(
                                                "одно количество имело неверное значение",
                                                "ERROR",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error,
                                                MessageBoxDefaultButton.Button1
                                                );
                                    return;
                                }
                            }
                            if (!int.TryParse(dats.Element("price").Value, out b))
                            {
                                DialogResult result = MessageBox.Show(
                                                "одна из цен имела неверное значение",
                                                "ERROR",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error,
                                                MessageBoxDefaultButton.Button1
                                                );
                                return;
                            }
                            else
                            {
                                if (b <= 0)
                                {
                                    DialogResult result = MessageBox.Show(
                                                "одна из цен имела неверное значение",
                                                "ERROR",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error,
                                                MessageBoxDefaultButton.Button1
                                                );
                                    return;
                                }
                            }
                            richTextBox1.Text += otstup + "срок " + dats.Element("srok").Value + " дней\n";
                            richTextBox1.Text += otstup + "цена за одну упаковку " + dats.Element("price").Value + " рублей\n";
                            richTextBox1.Text += otstup + "количество " + dats.Element("ammount").Value + " упаковок\n";
                        }
                        
                    }
                    
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fil = new filter();
            fil.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_rem = new add_row();
            add_rem.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "xml (*.xml)|*.xml|txt (*.txt)|*.txt";
            if (save.ShowDialog() == DialogResult.Cancel)
                return;
            
            string filename = save.FileName;

            root.Save(filename);
            MessageBox.Show("Файл сохранен");

        }
    }
}
