using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace Intel8086
{
    public static class StringExtensions
    {
        public static bool IsHexString(this string str)
        {
            foreach (var c in str)
            {
                var isHex = ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));

                if (!isHex)
                {
                    return false;
                }
            }

            return true;
        }

        //bonus, verify whether a string can be parsed as byte[]
        public static bool IsParseableToByteArray(this string str)
        {
            return IsHexString(str) && str.Length % 2 == 0;
        }
    }
    public partial class Form1 : Form
    {
        string ax, bx, cx, dx;
        string si, di, bp, disp;

        string pierwszy;
        string drugi;
        string zamiana;

        string[] TABLICA = new string[65536];

        public Form1()
        {
            InitializeComponent();
            
            ax = "0000";
            bx = "0000";
            cx = "0000";
            dx = "0000";
            si = "0000";
            di = "0000";
            bp = "0000";
            disp = "0000";
            axView.Text = ax;
            axText.Text = ax;
            bxView.Text = bx;
            bxText.Text = bx;
            cxView.Text = cx;
            cxText.Text = cx;
            dxView.Text = dx;
            dxText.Text = dx;

            siView.Text = si;
            siText.Text = si;
            diView.Text = di;
            diText.Text = di;
            bpView.Text = bp;
            bpText.Text = bp;
            dispView.Text = disp;
            dispText.Text = disp;

            comboBoxBazowy.Visible = false;
            comboBoxIndeksowy.Visible = false;
            comboBoxIB.Visible = false;
            comboBoxPOLACZENIE.Visible = false;

            comboBoxKierunek.SelectedIndex = 0;

        }
        
        /* Po kliknięciu klawisza MOV*/
        private void buttonMOV_Click(object sender, EventArgs e)
        {
            if(axText.Text.IsHexString() != true)
            {
                return;
            }
            if(bxText.Text.IsHexString() != true)
            {
                return;
            }
            if(cxText.Text.IsHexString() != true)
            {
                return;
            }
            if(dxText.Text.IsHexString() != true)
            {
                return;
            }

            if (comboBoxFROM.Text.Length > 0 && comboBoxTO.Text.Length > 0)
            {
                if (axText.Text.Length == 4 || bxText.Text.Length == 4 || cxText.Text.Length == 4 || dxText.Text.Length == 4)
                    movLabel.Text = $"MOV {drugi}, {pierwszy}";
            }
            else if (comboBoxFROM.Text.Length > 0)
                movLabel.Text = $"MOV {drugi}";
            else
                movLabel.Text = "";

            switch (comboBoxFROM.Text)
            {
                case "AX":
                    {
                        switch (comboBoxTO.Text)
                        {
                            case "AX":
                                {
                                    if (axText.Text.Length == 4) axView.Text = axText.Text.ToUpper();
                                    break;
                                }
                            case "BX":
                                {
                                    if (axText.Text.Length == 4) bxView.Text = axText.Text.ToUpper();
                                    break;
                                }
                            case "CX":
                                {
                                    if (axText.Text.Length == 4) cxView.Text = axText.Text.ToUpper();
                                    break;
                                }
                            case "DX":
                                {
                                    if (axText.Text.Length == 4) dxView.Text = axText.Text.ToUpper();
                                    break;
                                }
                        }
                        break;
                    }
                case "BX":
                    {
                        switch (comboBoxTO.Text)
                        {
                            case "AX":
                                {
                                    if (bxText.Text.Length == 4) axView.Text = bxText.Text.ToUpper();
                                    break;
                                }
                            case "BX":
                                {
                                    if (bxText.Text.Length == 4) bxView.Text = bxText.Text.ToUpper();
                                    break;
                                }
                            case "CX":
                                {
                                    if (bxText.Text.Length == 4) cxView.Text = bxText.Text.ToUpper();
                                    break;
                                }
                            case "DX":
                                {
                                    if (bxText.Text.Length == 4) dxView.Text = bxText.Text.ToUpper();
                                    break;
                                }
                        }
                        break;
                    }
                case "CX":
                    {
                        switch (comboBoxTO.Text)
                        {
                            case "AX":
                                {
                                    if (cxText.Text.Length == 4) axView.Text = cxText.Text.ToUpper();
                                    break;
                                }
                            case "BX":
                                {
                                    if (cxText.Text.Length == 4) bxView.Text = cxText.Text.ToUpper();
                                    break;
                                }
                            case "CX":
                                {
                                    if (cxText.Text.Length == 4) cxView.Text = cxText.Text.ToUpper();
                                    break;
                                }
                            case "DX":
                                {
                                    if (cxText.Text.Length == 4) dxView.Text = cxText.Text.ToUpper();
                                    break;
                                }
                        }
                        break;
                    }
                case "DX":
                    {
                        switch (comboBoxTO.Text)
                        {
                            case "AX":
                                {
                                    if (dxText.Text.Length == 4) axView.Text = dxText.Text.ToUpper();
                                    break;
                                }
                            case "BX":
                                {
                                    if (dxText.Text.Length == 4) bxView.Text = dxText.Text.ToUpper();
                                    break;
                                }
                            case "CX":
                                {
                                    if (dxText.Text.Length == 4) cxView.Text = dxText.Text.ToUpper();
                                    break;
                                }
                            case "DX":
                                {
                                    if (dxText.Text.Length == 4) dxView.Text = dxText.Text.ToUpper();
                                    break;
                                }
                        }
                        break;
                    }
            }

        }

        /*Przypisanie do zmiennej wartości labelu po wybraniu opcji w combo boxie */
        private void comboBoxFROM_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBoxFROM.Text)
            {
                case "AX":
                    pierwszy = "AX";
                    break;
                case "BX":
                    pierwszy = "BX";
                    break;
                case "CX":
                    pierwszy = "CX";
                    break;
                case "DX":
                    pierwszy = "DX";
                    break;
            }
        }
        /* Przypisanie do zmiennej wartości labelu po wybraniu opcji w combo boxie */
        private void comboBoxTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTO.Text)
            {
                case "AX":
                    drugi = "AX";
                    break;
                case "BX":
                    drugi = "BX";
                    break;
                case "CX":
                    drugi = "CX";
                    break;
                case "DX":
                    drugi = "DX";
                    break;
            }
        }

        /* Wyczyszczenie pól po naciśnięciu klawisza WYCZYŚĆ */
        private void buttonCLEAR_Click(object sender, EventArgs e)
        {
            comboBoxFROM.SelectedIndex = -1;
            comboBoxTO.SelectedIndex = -1;
            movLabel.Text = "";
            axText.Text = "";
            bxText.Text = "";
            cxText.Text = "";
            dxText.Text = "";
        }
        // ZAMIANA danych instrukcja XCHG
        private void buttonXCHG_Click(object sender, EventArgs e)
        {
            switch (comboBoxFROM.Text)
            {
                case "AX":
                    {
                        switch (comboBoxTO.Text)
                        {
                            case "AX":
                                {
                                    break;
                                }
                            case "BX":
                                {
                                    zamiana = axView.Text;
                                    axView.Text = bxView.Text;
                                    bxView.Text = zamiana;
                                    break;
                                }
                            case "CX":
                                {
                                    zamiana = axView.Text;
                                    axView.Text = cxView.Text;
                                    cxView.Text = zamiana;
                                    break;
                                }
                            case "DX":
                                {
                                    zamiana = axView.Text;
                                    axView.Text = dxView.Text;
                                    dxView.Text = zamiana;
                                    break;
                                }
                        }
                        break;
                    }
                case "BX":
                    {
                        switch (comboBoxTO.Text)
                        {
                            case "AX":
                                {
                                    zamiana = bxView.Text;
                                    bxView.Text = axView.Text;
                                    axView.Text = zamiana;
                                    break;
                                }
                            case "BX":
                                {
                                    break;
                                }
                            case "CX":
                                {
                                    zamiana = bxView.Text;
                                    bxView.Text = cxView.Text;
                                    cxView.Text = zamiana;
                                    break;
                                }
                            case "DX":
                                {
                                    zamiana = bxView.Text;
                                    bxView.Text = dxView.Text;
                                    dxView.Text = zamiana;
                                    break;
                                }
                        }
                        break;
                    }
                case "CX":
                    {
                        switch (comboBoxTO.Text)
                        {
                            case "AX":
                                {
                                    zamiana = cxView.Text;
                                    cxView.Text = axView.Text;
                                    axView.Text = zamiana;
                                    break;
                                }
                            case "BX":
                                {
                                    zamiana = cxView.Text;
                                    cxView.Text = bxView.Text;
                                    bxView.Text = zamiana;
                                    break;
                                }
                            case "CX":
                                {
                                    break;
                                }
                            case "DX":
                                {
                                    zamiana = cxView.Text;
                                    cxView.Text = dxView.Text;
                                    dxView.Text = zamiana;
                                    break;
                                }
                        }
                        break;
                    }
                case "DX":
                    {
                        switch (comboBoxTO.Text)
                        {
                            case "AX":
                                {
                                    zamiana = dxView.Text;
                                    dxView.Text = axView.Text;
                                    axView.Text = zamiana;
                                    break;
                                }
                            case "BX":
                                {
                                    zamiana = dxView.Text;
                                    dxView.Text = bxView.Text;
                                    bxView.Text = zamiana;
                                    break;
                                }
                            case "CX":
                                {
                                    zamiana = dxView.Text;
                                    dxView.Text = cxView.Text;
                                    cxView.Text = zamiana;
                                    break;
                                }
                            case "DX":
                                {
                                    break;
                                }
                        }
                        break;
                    }
            }

            if (comboBoxFROM.Text.Length > 0 && comboBoxTO.Text.Length > 0)
                movLabel.Text = $"XCHG {pierwszy}, {drugi}";
            else if (comboBoxFROM.Text.Length > 0)
                movLabel.Text = $"XCHG {pierwszy}";
            else
                movLabel.Text = "";
        }

        private void buttonRANDOM_Click(object sender, EventArgs e)
        {
            // ASCII + losowanie

            string[] tab = new string[16];
            int y = 0;
            for (int i = 48; i <= 57; i++)
            {
                tab[y] += Convert.ToChar(i).ToString();
                y++;
            }

            for (int i = 65; i <= 70; i++)
            {
                tab[y] = Convert.ToChar(i).ToString();
                y++;
            }

            Random losowanie = new Random();
            char[] ilosc = new char[16];
            string los;
            for (int i = 0; i < tab.Length; i++)
            {
                los = tab[losowanie.Next(0, tab.Length)];
                ilosc[i] = Convert.ToChar(los);
            }
            axView.Text = ilosc[0].ToString() + ilosc[1].ToString() + ilosc[2].ToString() + ilosc[3].ToString();
            bxView.Text = ilosc[4].ToString() + ilosc[5].ToString() + ilosc[6].ToString() + ilosc[7].ToString();
            cxView.Text = ilosc[8].ToString() + ilosc[9].ToString() + ilosc[10].ToString() + ilosc[11].ToString();
            dxView.Text = ilosc[12].ToString() + ilosc[13].ToString() + ilosc[14].ToString() + ilosc[15].ToString();

        }

        private void siText_TextChanged(object sender, EventArgs e)
        {

        }

        private void axText_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonPrzypisz_Click(object sender, EventArgs e)
        {
            if (siText.Text.IsHexString() != true)
            {
                return;
            }
            if (diText.Text.IsHexString() != true)
            {
                return;
            }
            if (bpText.Text.IsHexString() != true)
            {
                return;
            }
            if (dispText.Text.IsHexString() != true)
            {
                return;
            }

            if (siText.Text.Length == 4)
                siView.Text = siText.Text.ToUpper();
            if (diText.Text.Length == 4)
                diView.Text = diText.Text.ToUpper();
            if (bpText.Text.Length == 4)
                bpView.Text = bpText.Text.ToUpper();
            if (dispText.Text.Length == 4)
                dispView.Text = dispText.Text.ToUpper();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonCLEAR2_Click(object sender, EventArgs e)
        {
            siText.Text = "";
            diText.Text = "";
            bpText.Text = "";
            dispText.Text = "";
        }

        private void buttonMOV2_Click(object sender, EventArgs e)
        {
            string pobierz = "";
            switch (comboBoxPOLACZENIE.Text)
            {
                case "AX":
                    pobierz = axView.Text;
                    break;
                case "BX":
                    pobierz = bxView.Text;
                    break;
                case "CX":
                    pobierz = cxView.Text;
                    break;
                case "DX":
                    pobierz = dxView.Text;
                    break;
            }

            if (comboBoxKierunek.SelectedIndex == 0) // z rejestru do pamięci
            {
                if (radioButtonINDEKSOWY.Checked == true)
                {
                    if (comboBoxIndeksowy.SelectedIndex == 0) // SI
                    {
                        string starszy = pobierz.Substring(0, 2);
                        string mlodszy  = pobierz.Substring(2, 2);
                        int siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber);
                        int dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        int sumDec = (siDec + dispDec);

                        TABLICA[sumDec] = mlodszy;
                        TABLICA[sumDec + 1] = starszy;

                        labelAutor.Text = "nr. Indeksu" + sumDec + " " + TABLICA[siDec + dispDec]; //+ mlodszy + starszy
                    }
                    else // DI
                    {
                        string starszy = pobierz.Substring(0, 2);
                        string mlodszy = pobierz.Substring(2, 2);
                    }
                }
                else if (radioButtonBAZOWY.Checked == true)
                {
                    if (comboBoxBazowy.SelectedIndex == 0) // BX
                    {

                    }
                    else // BP
                    {

                    }
                }
                else if (radioButtonIB.Checked == true)
                {
                    if (comboBoxIB.SelectedIndex == 0) // SI + BX
                    {

                    }
                    else if (comboBoxIB.SelectedIndex == 1) // SI + BP
                    {

                    }
                    else if (comboBoxIB.SelectedIndex == 2) // DI + BX
                    {

                    }
                    else // DI + BP
                    {

                    }
                }
                else
                {
                    return;
                }
            }
            else // z pamięci do rejestru
            {
                if (radioButtonINDEKSOWY.Checked == true)
                {
                    if (comboBoxIndeksowy.SelectedIndex == 0) // SI
                    {

                        int siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber);
                        int dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        int sumDec = (siDec + dispDec);

                        string sumHex = sumDec.ToString("X");

                        switch (comboBoxPOLACZENIE.Text)
                        {
                            case "AX":
                                axView.Text = sumHex;
                                break;
                            case "BX":
                                bxView.Text = sumHex;
                                break;
                            case "CX":
                                cxView.Text = sumHex;
                                break;
                            case "DX":
                                dxView.Text = sumHex;
                                break;
                        }

                        labelAutor.Text = sumHex; //+ mlodszy + starszy
                    }
                    else // DI
                    {

                    }
                }
                else if (radioButtonBAZOWY.Checked == true)
                {
                    if (comboBoxBazowy.SelectedIndex == 0) // BX
                    {

                    }
                    else // BP
                    {

                    }
                }
                else if (radioButtonIB.Checked == true)
                {
                    if (comboBoxIB.SelectedIndex == 0) // SI + BX
                    {

                    }
                    else if (comboBoxIB.SelectedIndex == 1) // SI + BP
                    {

                    }
                    else if (comboBoxIB.SelectedIndex == 2) // DI + BX
                    {

                    }
                    else // DI + BP
                    {

                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonINDEKSOWY_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonINDEKSOWY.Checked)
            {
                comboBoxBazowy.Visible = false;
                comboBoxIndeksowy.Visible = true;
                comboBoxIB.Visible = false;
                comboBoxPOLACZENIE.Visible = true;
            }
        }

        private void radioButtonIB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIB.Checked)
            {
                comboBoxBazowy.Visible = false;
                comboBoxIndeksowy.Visible = false;
                comboBoxIB.Visible = true;
                comboBoxPOLACZENIE.Visible = true;

            }
        }

        private void radioButtonBAZOWY_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBAZOWY.Checked)
            {
                comboBoxBazowy.Visible = true;
                comboBoxIndeksowy.Visible = false;
                comboBoxIB.Visible = false;
                comboBoxPOLACZENIE.Visible = true;

            }

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioPamiecRejestr_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonRESET_Click(object sender, EventArgs e)
        {
            axView.Text = "0000";
            bxView.Text = "0000";
            cxView.Text = "0000";
            dxView.Text = "0000";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void siView_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
