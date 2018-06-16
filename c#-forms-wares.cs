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

namespace FormsArtikelliste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<ClassArtikel> artikel = new List<ClassArtikel>();

        int index;



      
        private void button1_Click(object sender, EventArgs e) 
        {
            
            ClassArtikel artikel1 = new ClassArtikel(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text));
            artikel.Add(artikel1);
            listeSpeichern();
            MessageBox.Show(artikel1.getBezeichnung() + " ist eingetragen");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }



        private void button3_Click(object sender, EventArgs e) 
        {
            index = 0;
            if (artikel.Count > index) {
                anzeigen(index);
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            index = artikel.Count -1;
            anzeigen(index);
            indexGleichsetzen(index);
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            
            if (index > 0) {
                index -= 1;
                anzeigen(index);
                indexGleichsetzen(index);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            

            if (index < artikel.Count-1) {
                index += 1;
                anzeigen(index);
                indexGleichsetzen(index);

            }
        }

        private void button7_Click(object sender, EventArgs e) 
        {
            ClassArtikel artikel1 = new ClassArtikel(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text));
            artikel[index] = artikel1;
            MessageBox.Show("Änderung übernommen");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listeAnzeigen();
        }


        private void Artikelliste_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (Artikelliste.SelectedIndex != -1) {
                anzeigen(Artikelliste.SelectedIndex);
                comboBox1.SelectedIndex = Artikelliste.SelectedIndex;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                anzeigen(comboBox1.SelectedIndex);
                Artikelliste.SelectedIndex = comboBox1.SelectedIndex;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        { 
            comboBox1.Items.Clear();
            Artikelliste.Items.Clear();

            FileStream fs = new FileStream("artikel.txt", FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() != -1) {

                ClassArtikel artikel1 = new ClassArtikel(sr.ReadLine(), Convert.ToDouble(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
                artikel.Add(artikel1);
            }
            sr.Close();
            fs.Close();

            listeAnzeigen();
        }

       
        private void button10_Click(object sender, EventArgs e) 
        {

            listeSpeichern();

            Application.Exit();
        }

        private void listeSpeichern() { 
            FileStream fs = new FileStream("artikel.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            foreach (ClassArtikel a in artikel)
            {
                sw.WriteLine(a.getBezeichnung());
                sw.WriteLine(a.getPreis());
                sw.WriteLine(a.getArtNr());
            }

            sw.Close();
            fs.Close();
        }

        private void listeAnzeigen() 
        {
            Artikelliste.Items.Clear();
            comboBox1.Items.Clear();

            foreach (ClassArtikel a in artikel)
            {
                Artikelliste.Items.Add(a.getBezeichnung());
                comboBox1.Items.Add(a.getBezeichnung());

            }
        }
        private void anzeigen(int which) 
        {
            textBox1.Text = artikel[which].getBezeichnung();
            textBox2.Text = artikel[which].getPreis().ToString();
            textBox3.Text = artikel[which].getArtNr().ToString();
        }

        private void indexGleichsetzen(int i)
        {
            comboBox1.SelectedIndex = i;
            Artikelliste.SelectedIndex = i;
        }

    }
}