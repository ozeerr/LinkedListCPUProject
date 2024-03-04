using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İslemciOdev
{
    public partial class Form1 : Form
    {
        private CiftYonluBagliListe liste = new CiftYonluBagliListe();
        private CiftYonluBagliListe liste2 = new CiftYonluBagliListe();
        private CiftYonluBagliListe liste3 = new CiftYonluBagliListe();
        private CiftYonluBagliListe islemci = new CiftYonluBagliListe();
        public CiftYonluBagliListe proses = new CiftYonluBagliListe();
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int random = rnd.Next(0, 6);
            liste.SonaEkle(random);
            string listeIcerik = "";

            Dugum gecici = liste.bas;
            while (gecici != null)
            {
                listeIcerik += "P1-" + gecici.Veri + Environment.NewLine;
                gecici = gecici.Sonraki;
            }
            textBoxResult.Text = listeIcerik;



        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            int random = rnd.Next(0, 6);
            liste2.SonaEkle(random);
            string listeIcerik = "";

            Dugum gecici = liste2.bas;
            while (gecici != null)
            {
                listeIcerik += "P2-" + gecici.Veri + Environment.NewLine;
                gecici = gecici.Sonraki;
            }
            textBox4.Text = listeIcerik;
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
           
            int random = rnd.Next(0, 6);
            liste3.SonaEkle(random);
            string listeIcerik = "";

            Dugum gecici = liste3.bas;
            while (gecici != null)
            {
                listeIcerik += "P3-" + gecici.Veri + Environment.NewLine;
                gecici = gecici.Sonraki;
            }
            textBox5.Text = listeIcerik;
        }


     

        private void VeriyiFiltrele()
        {
            string Txtbx = textBox2.Text; 

            string[] satirlar = Txtbx.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            List<string> p1Listesi = new List<string>();
            List<string> p2Listesi = new List<string>();
            List<string> p3Listesi = new List<string>();

            foreach (string satir in satirlar)
            {
                if (satir.StartsWith("P1-"))
                {
                    p1Listesi.Add(satir);
                }
                else if (satir.StartsWith("P2-"))
                {
                    p2Listesi.Add(satir);
                }
                else if (satir.StartsWith("P3-"))
                {
                    p3Listesi.Add(satir);
                }
            }

            p1Listesi.Sort(new StringKarsilastirici());
            p2Listesi.Sort(new StringKarsilastirici());
            p3Listesi.Sort(new StringKarsilastirici());

            CheckboxlariFiltreleVeMetinKutularinaEkle(p1Listesi, p2Listesi, p3Listesi);
        }

        private void CheckboxlariFiltreleVeMetinKutularinaEkle(List<string> p1Listesi, List<string> p2Listesi, List<string> p3Listesi)
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

            if (checkBox1.Checked)
            {
                textBox6.Text = string.Join(Environment.NewLine, p1Listesi);
            }

            if (checkBox2.Checked)
            {
                textBox7.Text = string.Join(Environment.NewLine, p2Listesi);
            }

            if (checkBox3.Checked)
            {
                textBox8.Text = string.Join(Environment.NewLine, p3Listesi);
            }
        }

        public class StringKarsilastirici : IComparer<string>
        {
            public int Compare(string x, string y)
            {
              
                if (x.StartsWith("P1-") && y.StartsWith("P1-"))
                {
                    int sayiX = int.Parse(x.Split('-')[1]);
                    int sayiY = int.Parse(y.Split('-')[1]);

                    return sayiX.CompareTo(sayiY);
                }
                if (x.StartsWith("P2-") && y.StartsWith("P2-"))
                {
                    int sayiX = int.Parse(x.Split('-')[1]);
                    int sayiY = int.Parse(y.Split('-')[1]);

                    return sayiX.CompareTo(sayiY);
                }
                if (x.StartsWith("P3-") && y.StartsWith("P3-"))
                {
                    int sayiX = int.Parse(x.Split('-')[1]);
                    int sayiY = int.Parse(y.Split('-')[1]);

                    return sayiX.CompareTo(sayiY);
                }
             
                return 0;
            }
        }

        public void Sirala()
        {
          
            int birincibas=liste.bas.Veri;
            int ikincibas = liste2.bas.Veri;
            int ucuncubas = liste3.bas.Veri;
            string ab1 = "";
            string ab2 = "";
            string ab3 = "";
           
            if (birincibas>=ikincibas&&birincibas>=ucuncubas)
            {
                proses.BasaEkle(birincibas);
                ab1 = "P1-";
                if (ikincibas>=ucuncubas)
                {
                    proses.SonaEkle(ikincibas);
                     ab2 = "P2-";
                    proses.SonaEkle(ucuncubas);
                   ab3 = "P3-";
                }
                else
                {
                    proses.SonaEkle(ucuncubas);
                   ab2 = "P3-";
                    proses.SonaEkle(ikincibas);
                    ab3 = "P2-";
                }
            }
            else if (ikincibas>=birincibas&&ikincibas>=ucuncubas)
            {
                proses.BasaEkle(ikincibas);
               ab1 = "P2-";
                if (birincibas>=ucuncubas)
                {
                    proses.SonaEkle(birincibas);
                     ab2 = "P1-";
                    proses.SonaEkle(ucuncubas);
                     ab3 = "P3-";
                }
                else
                {
                    proses.SonaEkle(ucuncubas);
                     ab2 = "P3-";
                    proses.SonaEkle(birincibas);
                     ab3 = "P1-";
                }

            }
            else if (ucuncubas>=birincibas&&ucuncubas>=ikincibas)
            {
                proses.BasaEkle(ucuncubas);
                 ab1 = "P3-";
                if (birincibas >= ikincibas)
                {
                    proses.SonaEkle(birincibas);
                     ab2 = "P1-";
                    proses.SonaEkle(ikincibas);
                     ab3 = "P2-";
                }
                else
                {
                    proses.SonaEkle(ikincibas);
                     ab2 = "P2-";
                    proses.SonaEkle(birincibas);
                     ab3 = "P1-";
                }

            }

            string listeIcerik = "";

            Dugum gecici = proses.bas;
            while (gecici != null)
            {   

                listeIcerik = ab1 + proses.bas.Veri+ Environment.NewLine+ ab2 + proses.bas.Sonraki.Veri+ Environment.NewLine+ ab3 + proses.bas.Sonraki.Sonraki.Veri + Environment.NewLine;
             
                gecici = gecici.Sonraki;
            }
            textBox2.Text += listeIcerik;

            proses.bas = null;
            VeriyiFiltrele();
        }

        public class Dugum
        {
            public int Veri;
            public Dugum Onceki;
            public Dugum Sonraki;

            public Dugum(int veri)
            {
                Veri = veri;
                Onceki = null;
                Sonraki = null;
            }
        }

        public class CiftYonluBagliListe
        {
            public Dugum bas;

            public void SonaEkle(int veri)
            {

                Dugum yeniDugum = new Dugum(veri);
                if (bas == null)
                {
                    bas = yeniDugum;
                }
                else
                {
                    Dugum gecici = bas;
                    while (gecici.Sonraki != null)
                    {
                        gecici = gecici.Sonraki;
                    }
                    gecici.Sonraki = yeniDugum;
                    yeniDugum.Onceki = gecici;
                }
            }

            public void BasaEkle(int veri)
            {
                Dugum yeniDugum = new Dugum(veri);
                if (bas == null)
                {
                    bas = yeniDugum;
                }
                else
                {
                    yeniDugum.Sonraki = bas;
                    bas.Onceki = yeniDugum;
                    bas = yeniDugum;
                }
            }

            public void Sil(int veri)
            {
                Dugum gecici = bas;

                while (gecici != null)
                {
                    if (gecici.Veri == veri)
                    {
                        if (gecici.Onceki != null)
                        {
                            gecici.Onceki.Sonraki = gecici.Sonraki;
                        }
                        else
                        {
                            bas = gecici.Sonraki;
                        }

                        if (gecici.Sonraki != null)
                        {
                            gecici.Sonraki.Onceki = gecici.Onceki;
                        }
                        break;
                    }
                    gecici = gecici.Sonraki;
                }
            }

        
            public void BasindakiElemaniYazVeSil(CiftYonluBagliListe liste, TextBox textBox,string v)
            {
                  
                if (liste.bas != null)
                {
                   
                    int basEleman = liste.bas.Veri; 


                    textBox.Text +=v+"-"+basEleman + "---> ";

                    if (liste.bas.Sonraki != null)
                    {
                        liste.bas = liste.bas.Sonraki;
                        liste.bas.Onceki = null;
                    }
                    else
                    {
                        liste.bas = null;
                    }
                }
                else
                {
                    textBox.Text += "Liste boş!";
                }
            }
       

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / (trackBar1.Value+1);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled==true)
            {
                timer2.Enabled = false;
            }
            else
            {
                timer2.Enabled = true;
            }
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
         
            if (checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                textBox6.Visible = true;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = true;
            }
            else if (checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked)
            {
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = true;
            }
            else if (checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked)
            {
                textBox6.Visible = true;
                textBox7.Visible = false;
                textBox8.Visible = true;
                textBox2.Visible = false;
                textBox3.Visible = true;
            }
            else if (!checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked)
            {
                textBox6.Visible = false;
                textBox7.Visible = true;
                textBox8.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = true;
            }
            else if (!checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                textBox6.Visible = false;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox2.Visible = false;
                textBox3.Visible = true;
            }
            else if (!checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked)
            {
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = true;
                textBox2.Visible = false;
                textBox3.Visible = true;
            }
            else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox2.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = true;
            }
            Sirala();
            liste.BasindakiElemaniYazVeSil(liste, textBox1,"P1");
            liste2.BasindakiElemaniYazVeSil(liste2,textBox1,"P2");
            liste3.BasindakiElemaniYazVeSil(liste3, textBox1,"P3");
        
           
        }




        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            timer2.Interval = 1000 / (trackBar2.Value + 1);
           
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            timer3.Interval = 1000 / (trackBar3.Value + 1);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            timer4.Interval = 1000 / (trackBar4.Value + 1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == false)
            {
                MessageBox.Show("HATA");
            }
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            textBox3.Visible = true;
            textBox2.Visible = false;

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = true;
        }

       
    }
}

