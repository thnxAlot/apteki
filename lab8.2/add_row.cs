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
    public partial class add_row : Form
    {

        string aptek = "";
        string prep = "";
        string data = "";
        string srok = "";
        string price = "";
        string ammount = "";
        public add_row()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (aptek == "" || prep == ""
                || data == "" || srok == ""
                || price == ""
                || ammount == "")
            {
                DialogResult result = MessageBox.Show(
                                    "введите все поля...",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int a;
            if(!int.TryParse(aptek,out a) ||
                !int.TryParse(srok, out a) ||
                !int.TryParse(price, out a) ||
                !int.TryParse(ammount, out a))
            {
                
                DialogResult result = MessageBox.Show(
                                    "номер аптеки, срок, цена и количество должны быть целыми числами",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int.TryParse(ammount, out a);
            if (a <= 0)
            {
                DialogResult result = MessageBox.Show(
                                    "количество не может быть неположительным",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int.TryParse(aptek, out a);
            if (a <= 0)
            {
                DialogResult result = MessageBox.Show(
                                    "номер аптеки не положительный",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int.TryParse(price, out a);
            if (a < 0)
            {
                DialogResult result = MessageBox.Show(
                                    "цена отрицательная!",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int.TryParse(srok, out a);
            if (a <= 0)
            {
                DialogResult result = MessageBox.Show(
                                    "срок отрицательный",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            XElement root = Form1._f.info.root;

            IEnumerable<XElement> apteka;
            apteka =
                    from el in root.Elements("aptek")
                   // where (string)el.Attribute("number") == apteks
                    select el;
            XElement to_add = new XElement("aptek");
            XAttribute ap_at = new XAttribute("number", aptek);
            XElement prepor = new XElement("medicine");
            XAttribute med_at = new XAttribute("type", prep);
            XElement dat = new XElement("data");
            XAttribute dat_at = new XAttribute("var", data);
            XElement ost = new XElement("srok",srok);
            XElement pr = new XElement("price", price);
            XElement amm = new XElement("ammount", ammount);
            dat.Add(dat_at, ost, pr, amm);
            prepor.Add(med_at,dat);
            to_add.Add(ap_at, prepor);

            int n = 0;
            foreach(XElement aps in apteka)
            {
                if (aps.Attribute("number").Value == aptek)
                {
                    IEnumerable<XElement> medicine;
                    medicine =
                            from el in aps.Elements("medicine")
                                // where (string)el.Attribute("number") == apteks
                            select el;
                    int n2 = 0;
                    foreach (XElement meds in medicine)
                    {
                        if (meds.Attribute("type").Value == prep)
                        {
                            IEnumerable<XElement> dats;
                            dats =
                                    from el in meds.Elements("data")
                                        // where (string)el.Attribute("number") == apteks
                            select el;
                            int n3 = 0;
                            foreach (XElement dates in dats)
                            {
                                if (dates.Attribute("var").Value == data)
                                {
                                    DialogResult result = MessageBox.Show(
                                    "Такая запись уже есть, заменить?",
                                    "ERROR",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );

                                    if (result == DialogResult.Yes)
                                    {
                                        dates.Remove();
                                        meds.Add(dat);
                                    }
                                    else
                                    {
                                        
                                    }

                                }
                                else
                                {
                                    n3++;
                                    
                                }
                            }
                            if(n3 == dats.Count())
                            {
                                meds.Add(dat);
                            }
                        }
                        else
                        {
                            n2++;
                        }
                        
                    }
                    if(n2==medicine.Count())
                    {
                        aps.Add(prepor);
                        
                    }
                    
                }
                else
                {
                    n++;
                }
            }
            if(n==apteka.Count())
            {
                root.Add(to_add);
                
            }
            Form1._f.info.root = root;
            Form1._f.info.set_tree();

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
            data = dateTimePicker1.Value.ToString().Substring(0, 10);
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

        private void button2_Click(object sender, EventArgs e)
        {
           if(aptek=="" || prep ==""
                ||data=="" || srok==""
                || price==""
                || ammount=="")
            {
                DialogResult result = MessageBox.Show(
                                    "введите все поля...",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int a;
            if (!int.TryParse(aptek, out a) ||
                 !int.TryParse(srok, out a) ||
                 !int.TryParse(price, out a) ||
                 !int.TryParse(ammount, out a))
            {

                DialogResult result = MessageBox.Show(
                                    "номер аптеки, срок, цена и количество должны быть целыми числами",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int.TryParse(ammount, out a);
            if(a<=0)
            {
                DialogResult result = MessageBox.Show(
                                    "количество не может быть неположительным",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int.TryParse(aptek, out a);
            if (a <= 0)
            {
                DialogResult result = MessageBox.Show(
                                    "номер аптеки не положительный",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int.TryParse(price, out a);
            if (a < 0)
            {
                DialogResult result = MessageBox.Show(
                                    "цена отрицательная!",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            int.TryParse(srok, out a);
            if (a <= 0)
            {
                DialogResult result = MessageBox.Show(
                                    "срок отрицательный",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );
                return;
            }
            XElement root = Form1._f.info.root;

            IEnumerable<XElement> apteka;
            apteka =
                    from el in root.Elements("aptek")
                        // where (string)el.Attribute("number") == apteks
                    select el;
            XElement to_add = new XElement("aptek");
            XAttribute ap_at = new XAttribute("number", aptek);
            XElement prepor = new XElement("medicine");
            XAttribute med_at = new XAttribute("type", prep);
            XElement dat = new XElement("data");
            XAttribute dat_at = new XAttribute("var", data);
            XElement ost = new XElement("srok", srok);
            XElement pr = new XElement("price", price);
            XElement amm = new XElement("ammount", ammount);
            dat.Add(dat_at, ost, pr, amm);
            prepor.Add(med_at, dat);
            to_add.Add(ap_at, prepor);

            int n = 0;
            foreach (XElement aps in apteka)
            {
                if (aps.Attribute("number").Value == aptek)
                {
                    IEnumerable<XElement> medicine;
                    medicine =
                            from el in aps.Elements("medicine")
                                // where (string)el.Attribute("number") == apteks
                            select el;
                    int n2 = 0;
                    foreach (XElement meds in medicine)
                    {
                        if (meds.Attribute("type").Value == prep)
                        {
                            IEnumerable<XElement> dats;
                            dats =
                                    from el in meds.Elements("data")
                                        // where (string)el.Attribute("number") == apteks
                                    select el;
                            int n3 = 0;
                            foreach (XElement dates in dats)
                            {
                                if (dates.Attribute("var").Value == data)
                                {
                                    DialogResult result = MessageBox.Show(
                                    "Подтвердите удаление",
                                    "CONFIRM",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button2
                                    );

                                    if (result == DialogResult.OK)
                                    {
                                        dates.Remove();
                                        if(dats.Count()==0)
                                        {
                                            meds.Remove();
                                            if(medicine.Count()==0)
                                            {
                                                aps.Remove();
                                            }
                                        }
                                        Form1._f.info.root = root;
                                        Form1._f.info.set_tree();
                                        return;
                                        //meds.Add(dat);
                                    }
                                    else
                                    {

                                    }

                                }
                                else
                                {
                                    n3++;

                                }
                            }
                            if (n3 == dats.Count())
                            {
                                DialogResult result = MessageBox.Show(
                                    "Такой записи нет(",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );

                                
                            }
                        }
                        else
                        {
                            n2++;
                        }

                    }
                    if (n2 == medicine.Count())
                    {
                        DialogResult result = MessageBox.Show(
                                    "Такой записи нет(",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );

                    }

                }
                else
                {
                    n++;
                }
            }
            if (n == apteka.Count())
            {
                DialogResult result = MessageBox.Show(
                                    "Такой записи нет(",
                                    "ERROR",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1
                                    );

            }
            Form1._f.info.root = root;
            Form1._f.info.set_tree();
        }
    }
}
