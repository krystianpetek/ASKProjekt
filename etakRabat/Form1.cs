using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etakRabat
{
    public partial class Form1 : Form
    {
        
        string oblicz;
        string wejscie;
        string wejscie2;
        double kwota;
        double rabatView = 20;

        public Form1()
        {
            InitializeComponent();
            richTextBoxRabat.Text = 20 + "%";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxKwota_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxOblicz_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void buttonOblicz_Click(object sender, EventArgs e)
        {
            if (richTextBoxKwota.Text.Length == 0)
            {
                return;
            }
            else
            {
                wejscie = richTextBoxKwota.Text;
                if (wejscie.Contains(','))
                    wejscie = wejscie.Replace(',','.');
                kwota = Convert.ToDouble(wejscie);


                wejscie2 = richTextBoxRabat.Text;
                if (wejscie2.Contains(','))
                    wejscie2 = wejscie2.Replace(',', '.');
                rabatView = (Convert.ToDouble(wejscie2.TrimEnd('%')));

                double obliczenia = 100 - rabatView;
                double rabat = (Convert.ToDouble(obliczenia)/100);
                
                oblicz = richTextBoxOblicz.Text.ToString();
                oblicz = (kwota * rabat).ToString("0.00");
                richTextBoxOblicz.Text = oblicz.ToString();
                richTextBoxRabat.Text = rabatView.ToString() + "%";
                
            }
        }

        private void richTextBoxRabat_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
