using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace Bp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics grafik;
        int Sayac;
        string CizimModu = null;
        int X11 = 0; //1. çubuğun X1'i
        int Y11 = 0; //1. çubuğun Y1'i
        int X12 = 0; //1. çubuğun X2'si
        int Y12 = 0; //1. çubuğun Y2'si
        int X21 = 0; //2. çubuğun X1'i
        int Y21 = 0; //2. çubuğun Y1'i
        int X22 = 0; //2. çubuğun X2'si
        int Y22 = 0; //2. çubuğun Y2'si
        int X31 = 0; //3. çubuğun X1'i
        int Y31 = 0; //3. çubuğun Y1'i
        int X32 = 0; //3. çubuğun X2'si
        int Y32 = 0; //3. çubuğun Y2'si
        Pen Kalem = new Pen(System.Drawing.Color.White, 1);
        int say = 0;
        int say1 = 0; 


        double r11, r22, r33, r44;
        double tet2, tet3, tet4;
        double ahizz;

        private void Form1_MouseClick_1(object sender, MouseEventArgs e)
        {
            grafik.DrawLine(Pens.Yellow, 20, 300, 50, 300);
            grafik.DrawLine(Pens.Yellow, 50, 300, 35, 274);
            grafik.DrawLine(Pens.Yellow, 35, 274, 20, 300);

            grafik.DrawLine(Pens.Yellow, 410, 300, 440, 300);
            grafik.DrawLine(Pens.Yellow, 440, 300, 425, 274);
            grafik.DrawLine(Pens.Yellow, 425, 274, 410, 300);
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (say == 0)
            {
                X11 = 35;
                Y11 = 274;
                X12 = e.X;
                Y12 = e.Y;
                grafik.DrawLine(Pens.Yellow, X11, Y11, X12, Y12);

                say++;

                //if (say1 == 0 && X1 < 38 && X1 > 32 && Y1 < 277 && Y1 > 271)
                //{
                //    say1++;
                //    int X1 = e.X;
                //    int Y1 = e.Y;
                //}
                //else if (say1 == 1)
                //{
                //    X2 = e.X;
                //    Y2 = e.Y;
                //    grafik.DrawLine(Pens.Yellow, X1, Y1, X2, Y2);
                //    say++;
                //    say1 = 0;
                //}
                //else
                //    MessageBox.Show("Lütfen ilk Mesnetten Başlayınız");
            }
            else if (say == 1)
            {
                X22 = e.X;
                Y22 = e.Y;
                grafik.DrawLine(Pens.Yellow, X12, Y12, X22, Y22);
                say++;

            }
            else if (say == 2)
            {

                grafik.DrawLine(Pens.Yellow, X22, Y22, 425, 274);
                say++;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            grafik = pictureBox1.CreateGraphics();
        }

        double hiztet3, ivmetet3, hiztet4, ivmetet4;

        double z1t3, z2t3, z1t4, z2t4, gustet3, gustet4;

        private void listBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox4.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox4.SelectedItems.OfType<string>()));
            }
        }

        private void listBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox5.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox5.SelectedItems.OfType<string>()));
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void listBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox3.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox3.SelectedItems.OfType<string>()));
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox2.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox2.SelectedItems.OfType<string>()));
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox1.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox1.SelectedItems.OfType<string>()));
            }
        }

        double z1t3us, z2t3us, z1t4us, z2t4us, gusus;
        double gusustet3, gusustet4;
        double teta21, f, ahizderece, saniye;

        
        ArrayList Dizihiztet3 = new ArrayList();
        ArrayList Dizihiztet4 = new ArrayList();
        ArrayList Diziivmetet3 = new ArrayList();
        ArrayList Diziivmetet4 = new ArrayList();
        ArrayList Dizitet2 = new ArrayList();
        ArrayList Dizisaniye = new ArrayList();
        private void button1_Click_1(object sender, EventArgs e)
        {

            r11 = double.Parse(r1.Text);
            r22 = double.Parse(r2.Text);
            r33 = double.Parse(r3.Text);
            r44 = double.Parse(r4.Text);
            tet2 = 56.19; /*double.Parse(teta2.Text);*/
            //tet3 = double.Parse(teta3.Text);
            //tet4 = double.Parse(teta4.Text);
            ahizz = double.Parse(ahiz.Text);
            teta21 = tet2;
            
            
            ////if(tet4<90)
            ////{
            //    r11 = r22 * Math.Cos(tet2 * Math.PI / 180) + r33 * Math.Cos(tet3 * Math.PI / 180) - r44 * Math.Cos(tet4 * Math.PI / 180); 
            ////}
            ////else
            ////{
            ////    r11 = r22 * Math.Cos(tet2 * Math.PI / 180) + r33 * Math.Cos(tet3 * Math.PI / 180) + r44 * Math.Cos(tet4 * Math.PI / 180); 
            ////}


            int i = 0;
            while (i < 360)
            {
                //*************************KONUM TETA 3 ve TETA 4  **********************
                tet2 = tet2 * (Math.PI / 180);
                double a = Math.Sin(tet2);
                double b = Math.Cos(tet2) - (r11 / r22);
                double c = ((r11 * r11 + r22 * r22 + r33 * r33 - r44 * r44) / (2 * r22 * r33)) - ((r11 / r33) * Math.Cos(tet2));
                double d = (r11 / r44) * Math.Cos(tet2) - (r11 * r11 + r22 * r22 - r33 * r33 + r44 * r44) / (2 * r22 * r44);

                tet3 = 2 * Math.Atan((a - Math.Sqrt(a * a + b * b - c * c)) / (b - c));
                tet4 = 2 * Math.Atan((a - Math.Sqrt(a * a + b * b - d * d)) / (b - d));

                //**************************HIZ TETA 3 VE TETA 4    **********************

                z1t3 = Math.Sin(tet2 - tet3) - (r11 / r33) * Math.Sin(tet2);
                z2t3 = Math.Sin(tet2 - tet3) + (r11 / r22) * Math.Sin(tet3);
                z1t4 = Math.Sin(tet2 - tet4) + (r11 / r44) * Math.Sin(tet2);
                z2t4 = Math.Sin(tet2 - tet4) + (r11 / r22) * Math.Sin(tet4);
                gustet3 = z1t3 / z2t3;
                gustet4 = z1t4 / z2t4;

                hiztet3 = gustet3 * ahizz;
                hiztet4 = gustet4 * ahizz;

                //************************* İVME TETA 3 VE TETA 4   *******************

                z1t3us = Math.Cos(tet2 - tet3) * (1 - gustet3) - (r11 / r33) * Math.Cos(tet2);
                z2t3us = Math.Cos(tet2 - tet3) * (1 - gustet3) + (r11 / r22) * gustet3 * Math.Cos(tet3);
                z1t4us = Math.Cos(tet2 - tet4) * (1 - gustet4) + (r11 / r44) * Math.Cos(tet2);
                z2t4us = Math.Cos(tet2 - tet4) * (1 - gustet4) + (r11 / r22) * gustet4 * Math.Cos(tet4);
                gusustet3 = (z1t3us * z2t3 - z1t3 * z2t3us) / (z2t3 * z2t3);
                gusustet4 = (z1t4us * z2t4 - z1t4 * z2t4us) / (z2t4 * z2t4);

                ivmetet3 = gusustet3 * ahizz * ahizz;
                ivmetet4 = gusustet4 * ahizz * ahizz;


                tet2 = tet2 * 180 / Math.PI;
                if (tet2 > 360)
                {
                    tet2 = tet2 % 360;
                }
                

                f = tet2 - teta21;
                ahizderece = ahizz * 180 / Math.PI;
                saniye = f / ahizderece;

                Dizitet2.Add(tet2);
                Dizihiztet3.Add(hiztet3);
                Dizihiztet4.Add(hiztet4);
                Diziivmetet3.Add(ivmetet3);
                Diziivmetet4.Add(ivmetet4);
                Dizisaniye.Add(saniye);

                listBox1.Items.Add("Hizteta3" + "" + "=" +Dizihiztet3[i]);
                listBox2.Items.Add("Hizteta4:" + "" +  "=" + Dizihiztet4[i]);
                listBox3.Items.Add("İvmeteta3:" + "" +  "=" + Diziivmetet3[i]);
                listBox4.Items.Add("İvmeteta4:" + "" +  "=" + Diziivmetet4[i]);
                listBox5.Items.Add("Saniye:" + "" + Dizisaniye[i]);
                i++;
                tet2++;





 
            }
            
            



            //cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            //{
            //    Title = "Saniye",
            //    Labels = new[] { "0", "3,14", "6,18" }
            //});

            //cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            //{
            //    Title = "Rad/Sn",
            //    Labels = new[] { "-0,6", "0", "0,4" }
            //});
            //cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;


        }
        double s = 0;
        double _r1, _r2, _ahiz;


        ArrayList Dizihizs = new ArrayList();
        ArrayList Dizihiztet = new ArrayList();
        ArrayList Diziivmes = new ArrayList();
        ArrayList Diziivmetet = new ArrayList();
        ArrayList Dizitet = new ArrayList();
        ArrayList _Dizisaniye = new ArrayList();


        private void button3_Click(object sender, EventArgs e)
        {
            double fi = 56.19;
            double fi1 = 56.19;
            _r1 = double.Parse(x1.Text);
            _r2 = double.Parse(x2.Text);
            _ahiz = double.Parse(acisalhiz.Text);
            double tet = 0;
            double z1s, z2s, z1t, z2t;
            double sgus, tgus, hizs, hizt;
            double z1sus, z2sus, z1tus, z2tus;
            double gsusus, gtusus, sivme, tetivme;
            double ff;
            double _ahizderece, _saniye;

            int j = 0;
            while (j < 360)
            {
                //**************************KONUM*********************************//

                fi = fi * Math.PI / 180;
                s = Math.Sqrt(_r1 * _r1 + _r2 * _r2 - 2 * _r1 * _r2 * Math.Cos(fi));

                tet = Math.Atan((_r2 * Math.Sin(fi)) / (_r2 * Math.Cos(fi) - _r1));


                //****************************HIZ******************************//

                z1s = _r1 * _r2 * Math.Sin(fi);
                z2s = s;
                sgus = z1s / z2s;
                
                hizs = sgus * _ahiz;

                z1t = ((_r2 * _r2 - _r1 * _r2 * Math.Cos(fi)) * (Math.Cos(tet) * Math.Cos(tet)));
                z2t = (_r2 * Math.Cos(fi) - _r1) * (_r2 * Math.Cos(fi) - _r1);
                tgus = z1t / z2t;

                hizt = tgus * _ahiz;

                //***************************İVME*****************************//
                z1sus = _r1 * _r2 * Math.Cos(fi);
                z2sus = sgus;
                gsusus = (z1sus * z2s - z1s * z2sus) / (z2s * z2s);

                sivme = gsusus * _ahiz * _ahiz;

                z1tus = _r1 * _r2 * Math.Sin(fi) * Math.Cos(tet) * Math.Cos(tet) - 2 * tgus * (_r2 * _r2 - _r1 * _r2 * Math.Cos(fi) * Math.Sin(tet) * Math.Cos(tet));
                z2tus = 2 * _r2 * (_r1 - _r2 * Math.Cos(fi)) * Math.Sin(fi);
                gtusus = (z1tus * z2t - z1t * z2tus) / (z2t * z2t);

                tetivme = gtusus * _ahiz * _ahiz;

                fi = fi * 180 / Math.PI;
                if(fi >360)
                fi = fi % 360;
                ff = fi - fi1;
                _ahizderece = _ahiz * 180 / Math.PI;
                _saniye = ff / _ahizderece;

                Dizihizs.Add(hizs);
                Dizihiztet.Add(hizt);
                Diziivmes.Add(sivme);
                Diziivmetet.Add(tetivme);
                Diziivmes.Add(sivme);
                _Dizisaniye.Add(_saniye);




                listBox1.Items.Add("S Hız" + "" + "=" + Dizihizs[j]);
                listBox2.Items.Add("TetaHiz:" + "" + "=" + Dizihiztet[j]);
                listBox3.Items.Add("S İvme:" + "" + "=" + Diziivmes[j]);
                listBox4.Items.Add("Teta İvme:" + "" + "=" + Diziivmetet[j]);
                listBox5.Items.Add("Saniye:" + "" + _Dizisaniye[j]);
                j++;
                fi++;

            }







        }




    }
}
