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

    public partial class Form1 : Form
    {
        string ax, bx, cx, dx;
        string si, di, bp, disp;
        string XCHG;
        string[] TABLICA = new string[65536];
        string starszyAdres, mlodszyAdres;
        int siDec, diDec, dispDec, sumDec;
        int bxDec, bpDec;
        string sumHex, pobierz, odczyt, zamiana;

        string[] STOS = new string[65536];
        int wskaznikStosu = 0;

        public Form1()
        {
            InitializeComponent();
            ax = "0000";
            axView.Text = ax;
            axText.Text = ax;
            bx = "0000";
            bxView.Text = bx;
            bxText.Text = bx;
            cx = "0000";
            cxView.Text = cx;
            cxText.Text = cx;
            dx = "0000";
            dxView.Text = dx;
            dxText.Text = dx;
            si = "0000";
            siView.Text = si;
            siText.Text = si;
            di = "0000";
            diView.Text = di;
            diText.Text = di;
            bp = "0000";
            bpView.Text = bp;
            bpText.Text = bp;
            disp = "0000";
            dispView.Text = disp;
            dispText.Text = disp;

            spView.Text = "0";

            comboBoxBazowy.Visible = false;
            comboBoxIndeksowy.Visible = false;
            comboBoxIndeksowoBazowy.Visible = false;
            comboBoxWymiana.Visible = false;
            labelAdresowanie.Visible = false;
            labelPrzesuniecie.Visible = false;
            buttonMOV2.Visible = false;
            buttonXCHG2.Visible = false;
            listBoxRejestZapisu.Visible = false;
            labelMOV2.Visible = false;
            labelXCHG2.Visible = false;
            labelRejestrZapisu.Visible = false;

            comboBoxFROM.SelectedIndex = 0;
            comboBoxTO.SelectedIndex = 0;
            comboBoxKierunek.SelectedIndex = 0;
            comboBoxIndeksowy.SelectedIndex = 0;
            comboBoxBazowy.SelectedIndex = 0;
            comboBoxIndeksowoBazowy.SelectedIndex = 0;
            comboBoxWymiana.SelectedIndex = 0;
            comboBoxStos.SelectedIndex = 0;


            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            for (int i = 0; i < TABLICA.Length; i++)
            {
                TABLICA[i] = "00";
            }

            axView.ReadOnly = true;
            bxView.ReadOnly = true;
            cxView.ReadOnly = true;
            dxView.ReadOnly = true;
            siView.ReadOnly = true;
            diView.ReadOnly = true;
            bpView.ReadOnly = true;
            dispView.ReadOnly = true;
        }

        // 1. PRZYCISK PRZYPISZ
        private void buttonPrzypisz_Click(object sender, EventArgs e)
        {
            if (axText.Text.IsHexString() != true)
                return;
            if (bxText.Text.IsHexString() != true)
                return;
            if (cxText.Text.IsHexString() != true)
                return;
            if (dxText.Text.IsHexString() != true)
                return;


            if (axText.Text.Length == 4 && axText.Text.ToUpper() != axView.Text)
            {
                axView.Text = axText.Text.ToUpper();
                listBoxRejestrOperacji.Items.Insert(0, $"MOV AX, {axText.Text.ToUpper()}                     PRZYPISZ");
            }
            else if (axText.Text.Length < 4)
            {
                // KOMENTARZ ZEBY WPROWADZIC DANE
            }
            else
            {
                // KOMENTARZ ZE WARTOSC JEST ZŁA, nie jest HEX
            }

            if (bxText.Text.Length == 4 && bxText.Text.ToUpper() != bxView.Text)
            {
                bxView.Text = bxText.Text.ToUpper();
                listBoxRejestrOperacji.Items.Insert(0, $"MOV BX, {bxText.Text.ToUpper()}                     PRZYPISZ");
            }
            else if (bxText.Text.Length < 4)
            {
                // KOMENTARZ ZEBY WPROWADZIC DANE
            }
            else
            {
                // KOMENTARZ ZE WARTOSC JEST ZŁA, nie jest HEX
            }

            if (cxText.Text.Length == 4 && cxText.Text.ToUpper() != cxView.Text)
            {
                cxView.Text = cxText.Text.ToUpper();
                listBoxRejestrOperacji.Items.Insert(0, $"MOV CX, {cxText.Text.ToUpper()}                     PRZYPISZ");
            }
            else if (cxText.Text.Length < 4)
            {
                // KOMENTARZ ZEBY WPROWADZIC DANE
            }
            else
            {
                // KOMENTARZ ZE WARTOSC JEST ZŁA, nie jest HEX
            }

            if (dxText.Text.Length == 4 && dxText.Text.ToUpper() != dxView.Text)
            {
                dxView.Text = dxText.Text.ToUpper();
                listBoxRejestrOperacji.Items.Insert(0, $"MOV DX, {dxText.Text.ToUpper()}                     PRZYPISZ");
            }
            else if (dxText.Text.Length < 4)
            {
                // KOMENTARZ ZEBY WPROWADZIC DANE
            }
            else
            {
                // KOMENTARZ ZE WARTOSC JEST ZŁA, nie jest HEX
            }
        }

        // 2. PRZYCISK WYCZYŚĆ
        private void buttonWyczysc_Click(object sender, EventArgs e)
        {
            axText.Text = "";
            bxText.Text = "";
            cxText.Text = "";
            dxText.Text = "";
        }


        // 3. PRZYCISK RANDOM
        private void buttonRandom_Click(object sender, EventArgs e)
        {
            string[] tablicaLiczbLosowych = new string[16];
            int y = 0;
            for (int i = 48; i <= 57; i++)
            {
                tablicaLiczbLosowych[y] += Convert.ToChar(i).ToString();
                y++;
            }

            for (int i = 65; i <= 70; i++)
            {
                tablicaLiczbLosowych[y] = Convert.ToChar(i).ToString();
                y++;
            }

            Random losowanie = new Random();
            char[] ilosc = new char[16];
            string los;
            for (int i = 0; i < tablicaLiczbLosowych.Length; i++)
            {
                los = tablicaLiczbLosowych[losowanie.Next(0, tablicaLiczbLosowych.Length)];
                ilosc[i] = Convert.ToChar(los);
            }
            axView.Text = ilosc[0].ToString() + ilosc[1].ToString() + ilosc[2].ToString() + ilosc[3].ToString();
            bxView.Text = ilosc[4].ToString() + ilosc[5].ToString() + ilosc[6].ToString() + ilosc[7].ToString();
            cxView.Text = ilosc[8].ToString() + ilosc[9].ToString() + ilosc[10].ToString() + ilosc[11].ToString();
            dxView.Text = ilosc[12].ToString() + ilosc[13].ToString() + ilosc[14].ToString() + ilosc[15].ToString();

            listBoxRejestrOperacji.Items.Insert(0, $"MOV AX, {axView.Text}                     RANDOM");
            listBoxRejestrOperacji.Items.Insert(0, $"MOV BX, {bxView.Text}                     RANDOM");
            listBoxRejestrOperacji.Items.Insert(0, $"MOV CX, {cxView.Text}                     RANDOM");
            listBoxRejestrOperacji.Items.Insert(0, $"MOV DX, {dxView.Text}                     RANDOM");
        }

        // 4. PRZYCISK RESET
        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (axView.Text != "0000")
                listBoxRejestrOperacji.Items.Insert(0, $"MOV AX, 0000                            RESET");
            if (bxView.Text != "0000")
                listBoxRejestrOperacji.Items.Insert(0, $"MOV BX, 0000                            RESET");
            if (cxView.Text != "0000")
                listBoxRejestrOperacji.Items.Insert(0, $"MOV CX, 0000                            RESET");
            if (dxView.Text != "0000")
                listBoxRejestrOperacji.Items.Insert(0, $"MOV DX, 0000                            RESET");

            axView.Text = "0000";
            bxView.Text = "0000";
            cxView.Text = "0000";
            dxView.Text = "0000";
        }
        // 5. PRZYCISK MOV
        private void buttonMOV_Click(object sender, EventArgs e)
        {
            switch (comboBoxFROM.Text)
            {
                case "AX":
                    switch (comboBoxTO.Text)
                    {
                        case "BX":
                            if (bxView.Text != axView.Text)
                            {
                                bxView.Text = axView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV BX, AX                               MOV");
                            }
                            break;
                        case "CX":
                            if (cxView.Text != axView.Text)
                            {
                                cxView.Text = axView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV CX, AX                               MOV");
                            }
                            break;
                        case "DX":
                            if (dxView.Text != axView.Text)
                            {
                                dxView.Text = axView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV DX, AX                               MOV");
                            }
                            break;
                    }
                    break;
                case "BX":
                    switch (comboBoxTO.Text)
                    {
                        case "AX":
                            if (axView.Text != bxView.Text)
                            {
                                axView.Text = bxView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV AX, BX                               MOV");
                            }
                            break;
                        case "CX":
                            if (cxView.Text != bxView.Text)
                            {
                                cxView.Text = bxView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV CX, BX                               MOV");
                            }
                            break;
                        case "DX":
                            if (dxView.Text != bxView.Text)
                            {
                                dxView.Text = bxView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV DX, BX                               MOV");
                            }
                            break;
                    }
                    break;
                case "CX":
                    switch (comboBoxTO.Text)
                    {
                        case "AX":
                            if (axView.Text != cxView.Text)
                            {
                                axView.Text = cxView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV AX, CX                               MOV");
                            }
                            break;
                        case "BX":
                            if (bxView.Text != cxView.Text)
                            {
                                bxView.Text = cxView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV BX, CX                               MOV");
                            }
                            break;
                        case "DX":
                            if (dxView.Text != cxView.Text)
                            {
                                dxView.Text = cxView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV DX, CX                               MOV");
                            }
                            break;
                    }
                    break;
                case "DX":
                    switch (comboBoxTO.Text)
                    {
                        case "AX":
                            if (axView.Text != dxView.Text)
                            {
                                axView.Text = dxView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV AX, DX                               MOV");
                            }
                            break;
                        case "BX":
                            if (bxView.Text != dxView.Text)
                            {
                                bxView.Text = dxView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV BX, DX                               MOV");
                            }
                            break;
                        case "CX":
                            if (cxView.Text != dxView.Text)
                            {
                                cxView.Text = dxView.Text;
                                listBoxRejestrOperacji.Items.Insert(0, $"MOV CX, DX                               MOV");
                            }
                            break;
                    }
                    break;
            }
        }

        private void panelCzwarty_Paint(object sender, PaintEventArgs e)
        {

        }

        // 6. PRZYCISK XCHG
        private void buttonXCHG_Click(object sender, EventArgs e)
        {
            switch (comboBoxFROM.Text)
            {
                case "AX":
                    {
                        switch (comboBoxTO.Text)
                        {
                            case "BX":
                                {
                                    XCHG = axView.Text;
                                    axView.Text = bxView.Text;
                                    bxView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG BX, AX                              XCHG");
                                    break;
                                }
                            case "CX":
                                {
                                    XCHG = axView.Text;
                                    axView.Text = cxView.Text;
                                    cxView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG CX, AX                              XCHG");
                                    break;
                                }
                            case "DX":
                                {
                                    XCHG = axView.Text;
                                    axView.Text = dxView.Text;
                                    dxView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG DX, AX                              XCHG");
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
                                    XCHG = bxView.Text;
                                    bxView.Text = axView.Text;
                                    axView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG AX, BX                              XCHG");
                                    break;
                                }
                            case "CX":
                                {
                                    XCHG = bxView.Text;
                                    bxView.Text = cxView.Text;
                                    cxView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG CX, BX                              XCHG");
                                    break;
                                }
                            case "DX":
                                {
                                    XCHG = bxView.Text;
                                    bxView.Text = dxView.Text;
                                    dxView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG DX, BX                              XCHG");
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
                                    XCHG = cxView.Text;
                                    cxView.Text = axView.Text;
                                    axView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG AX, CX                              XCHG");
                                    break;
                                }
                            case "BX":
                                {
                                    XCHG = cxView.Text;
                                    cxView.Text = bxView.Text;
                                    bxView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG BX, CX                              XCHG");
                                    break;
                                }
                            case "DX":
                                {
                                    XCHG = cxView.Text;
                                    cxView.Text = dxView.Text;
                                    dxView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG DX, CX                              XCHG");
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
                                    XCHG = dxView.Text;
                                    dxView.Text = axView.Text;
                                    axView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG AX, DX                              XCHG");
                                    break;
                                }
                            case "BX":
                                {
                                    XCHG = dxView.Text;
                                    dxView.Text = bxView.Text;
                                    bxView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG BX, DX                              XCHG");
                                    break;
                                }
                            case "CX":
                                {
                                    XCHG = dxView.Text;
                                    dxView.Text = cxView.Text;
                                    cxView.Text = XCHG;
                                    listBoxRejestrOperacji.Items.Insert(0, $"XCHG CX, DX                              XCHG");
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        // 7. PRZYCISK RADIO INDEKSOWY
        private void radioButtonIndeksowy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIndeksowy.Checked)
            {
                comboBoxBazowy.Visible = false;
                comboBoxIndeksowy.Visible = true;
                comboBoxIndeksowoBazowy.Visible = false;
                comboBoxWymiana.Visible = true;
                labelAdresowanie.Visible = true;
                labelPrzesuniecie.Visible = true;
                buttonMOV2.Visible = true;
                buttonXCHG2.Visible = true;
                listBoxRejestZapisu.Visible = true;
                labelMOV2.Visible = true;
                labelXCHG2.Visible = true;
                labelRejestrZapisu.Visible = true;
                //labelAdresowanie.Text = "Adresowanie indeksowe";
                //labelAdresowanie.Top = 206;
            }

        }
        // 8. PRZYCISK RADIO BAZOWY
        private void radioButtonBazowy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBazowy.Checked)
            {
                comboBoxBazowy.Visible = true;
                comboBoxIndeksowy.Visible = false;
                comboBoxIndeksowoBazowy.Visible = false;
                comboBoxWymiana.Visible = true;
                labelAdresowanie.Visible = true;
                labelPrzesuniecie.Visible = true;
                buttonMOV2.Visible = true;
                buttonXCHG2.Visible = true;
                listBoxRejestZapisu.Visible = true;
                labelMOV2.Visible = true;
                labelXCHG2.Visible = true;
                labelRejestrZapisu.Visible = true;
                //labelAdresowanie.Text = "Adresowanie bazowe";
                //labelAdresowanie.Top = 206;
            }

        }
        // 9. PRZYCISK RADIO INDEKSOWO-BAZOWY
        private void radioButtonIndeksowoBazowy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIndeksowoBazowy.Checked)
            {
                comboBoxBazowy.Visible = false;
                comboBoxIndeksowy.Visible = false;
                comboBoxIndeksowoBazowy.Visible = true;
                comboBoxWymiana.Visible = true;
                labelAdresowanie.Visible = true;
                labelPrzesuniecie.Visible = true;
                buttonMOV2.Visible = true;
                buttonXCHG2.Visible = true;
                listBoxRejestZapisu.Visible = true;
                labelMOV2.Visible = true;
                labelXCHG2.Visible = true;
                labelRejestrZapisu.Visible = true;
                //labelAdresowanie.Text = "Adresowanie indeksowo\n                          bazowe";
                //labelAdresowanie.Top = 199;
            }
        }
        // 10. COMBOBOX KIERUNEK
        private void comboBoxKierunek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKierunek.SelectedIndex == 1)
            {
                labelAdresowanie.Text = "Przenieś dane z pamięci do rejestru";
                labelPrzesuniecie.Text = "bazując na rejestrze";
            }
            if (comboBoxKierunek.SelectedIndex == 0)
            {
                labelAdresowanie.Text = "Przenieś dane z rejestru";
                labelPrzesuniecie.Text = "do pamięci bazując na rejestrze";
            }
        }
        // 11. BUTTON PRZYPISZ 2
        private void buttonPrzypisz2_Click(object sender, EventArgs e)
        {
            if (siText.Text.IsHexString() != true)
                return;
            if (diText.Text.IsHexString() != true)
                return;
            if (bpText.Text.IsHexString() != true)
                return;
            if (dispText.Text.IsHexString() != true)
                return;


            if (siText.Text.Length == 4 && siText.Text.ToUpper() != siView.Text)
            {
                siView.Text = siText.Text.ToUpper();
                listBoxRejestrOperacji.Items.Insert(0, $"MOV SI, {siText.Text.ToUpper()}                     PRZYPISZ");
            }
            if (diText.Text.Length == 4 && diText.Text.ToUpper() != diView.Text)
            {
                diView.Text = diText.Text.ToUpper();
                listBoxRejestrOperacji.Items.Insert(0, $"MOV DI, {diText.Text.ToUpper()}                     PRZYPISZ");
            }
            if (bpText.Text.Length == 4 && bpText.Text.ToUpper() != bpView.Text)
            {
                bpView.Text = bpText.Text.ToUpper();
                listBoxRejestrOperacji.Items.Insert(0, $"MOV BP, {bpText.Text.ToUpper()}                     PRZYPISZ");
            }
            if (dispText.Text.Length == 4 && dispText.Text.ToUpper() != dispView.Text)
            {
                dispView.Text = dispText.Text.ToUpper();
                listBoxRejestrOperacji.Items.Insert(0, $"MOV DISP, {dispText.Text.ToUpper()}                 PRZYPISZ");
            }
        }
        // 12. BUTTON WYCZYSC 2
        private void buttonWyczysc2_Click(object sender, EventArgs e)
        {
            siText.Text = "";
            diText.Text = "";
            bpText.Text = "";
            dispText.Text = "";
        }

        // 13. BUTTON RESET 2
        private void buttonReset2_Click(object sender, EventArgs e)
        {
            if (siView.Text != "0000")
                listBoxRejestrOperacji.Items.Insert(0, $"MOV SI, 0000                            RESET");
            if (diView.Text != "0000")
                listBoxRejestrOperacji.Items.Insert(0, $"MOV DI, 0000                            RESET");
            if (bpView.Text != "0000")
                listBoxRejestrOperacji.Items.Insert(0, $"MOV BP, 0000                            RESET");
            if (dispView.Text != "0000")
                listBoxRejestrOperacji.Items.Insert(0, $"MOV DISP, 0000                         RESET");

            siView.Text = "0000";
            diView.Text = "0000";
            bpView.Text = "0000";
            dispView.Text = "0000";
        }
        // 14. BUTTON MOV 2
        private void buttonMOV2_Click(object sender, EventArgs e)
        {
            switch (comboBoxWymiana.Text)
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

            if (comboBoxKierunek.SelectedIndex == 0) // Z REJESTRU DO PAMIECI
            {
                if (radioButtonIndeksowy.Checked == true)
                {
                    if (comboBoxIndeksowy.SelectedIndex == 0) // SI
                    {
                        starszyAdres = pobierz.Substring(0, 2);
                        mlodszyAdres = pobierz.Substring(2, 2);

                        siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber); // SI decymalne
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber); // DISP decymalne
                        sumDec = (siDec + dispDec);

                        TABLICA[sumDec] = mlodszyAdres;
                        TABLICA[sumDec + 1] = starszyAdres;

                        listBoxRejestrOperacji.Items.Insert(0, $"MOV [SI+{dispView.Text}], {comboBoxWymiana.Text}                      MOV");
                    }
                    else if (comboBoxIndeksowy.SelectedIndex == 1) // DI
                    {
                        starszyAdres = pobierz.Substring(0, 2);
                        mlodszyAdres = pobierz.Substring(2, 2);

                        diDec = int.Parse(diView.Text, System.Globalization.NumberStyles.HexNumber);
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        sumDec = (diDec + dispDec);

                        TABLICA[sumDec] = mlodszyAdres;
                        TABLICA[sumDec + 1] = starszyAdres;

                        listBoxRejestrOperacji.Items.Insert(0, $"MOV [DI+{dispView.Text}], {comboBoxWymiana.Text}                      MOV");
                    }
                    else
                    {
                        return;
                    }
                }
                else if (radioButtonBazowy.Checked == true)
                {
                    if (comboBoxBazowy.SelectedIndex == 0) // BX
                    {
                        starszyAdres = pobierz.Substring(0, 2);
                        mlodszyAdres = pobierz.Substring(2, 2);

                        bxDec = int.Parse(bxView.Text, System.Globalization.NumberStyles.HexNumber); // BX decymalne
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber); // DISP decymalne
                        sumDec = (bxDec + dispDec);

                        TABLICA[sumDec] = mlodszyAdres;
                        TABLICA[sumDec + 1] = starszyAdres;

                        listBoxRejestrOperacji.Items.Insert(0, $"MOV [BX+{dispView.Text}], {comboBoxWymiana.Text}                      MOV");
                    }
                    else if (comboBoxBazowy.SelectedIndex == 1) // BP
                    {
                        starszyAdres = pobierz.Substring(0, 2);
                        mlodszyAdres = pobierz.Substring(2, 2);

                        bpDec = int.Parse(bpView.Text, System.Globalization.NumberStyles.HexNumber); // BP decymalne
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber); // DISP decymalne
                        sumDec = (bpDec + dispDec);

                        TABLICA[sumDec] = mlodszyAdres;
                        TABLICA[sumDec + 1] = starszyAdres;

                        listBoxRejestrOperacji.Items.Insert(0, $"MOV [BP+{dispView.Text}], {comboBoxWymiana.Text}                      MOV");
                    }
                    else
                    {
                        return;
                    }
                }
                else if (radioButtonIndeksowoBazowy.Checked == true)
                {
                    if (comboBoxIndeksowoBazowy.SelectedIndex == 0) // SI + BX
                    {
                        starszyAdres = pobierz.Substring(0, 2);
                        mlodszyAdres = pobierz.Substring(2, 2);

                        siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber); // SI decymalne
                        bxDec = int.Parse(bxView.Text, System.Globalization.NumberStyles.HexNumber); // BX decymalne
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber); // DISP decymalne
                        sumDec = (siDec + bxDec + dispDec);

                        TABLICA[sumDec] = mlodszyAdres;
                        TABLICA[sumDec + 1] = starszyAdres;

                        listBoxRejestrOperacji.Items.Insert(0, $"MOV [SI+BX+{dispView.Text}], {comboBoxWymiana.Text}                MOV");
                    }
                    else if (comboBoxIndeksowoBazowy.SelectedIndex == 1) // SI + BP
                    {
                        starszyAdres = pobierz.Substring(0, 2);
                        mlodszyAdres = pobierz.Substring(2, 2);

                        siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber); // SI decymalne
                        bpDec = int.Parse(bpView.Text, System.Globalization.NumberStyles.HexNumber); // BX decymalne
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber); // DISP decymalne
                        sumDec = (siDec + bpDec + dispDec);

                        TABLICA[sumDec] = mlodszyAdres;
                        TABLICA[sumDec + 1] = starszyAdres;
                        listBoxRejestrOperacji.Items.Insert(0, $"MOV [SI+BP+{dispView.Text}], {comboBoxWymiana.Text}                MOV");
                    }
                    else if (comboBoxIndeksowoBazowy.SelectedIndex == 2) // DI + BX
                    {
                        starszyAdres = pobierz.Substring(0, 2);
                        mlodszyAdres = pobierz.Substring(2, 2);

                        diDec = int.Parse(diView.Text, System.Globalization.NumberStyles.HexNumber); // SI decymalne
                        bxDec = int.Parse(bxView.Text, System.Globalization.NumberStyles.HexNumber); // BX decymalne
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber); // DISP decymalne
                        sumDec = (diDec + bxDec + dispDec);

                        TABLICA[sumDec] = mlodszyAdres;
                        TABLICA[sumDec + 1] = starszyAdres;

                        listBoxRejestrOperacji.Items.Insert(0, $"MOV [DI+BX+{dispView.Text}], {comboBoxWymiana.Text}                MOV");
                    }
                    else if (comboBoxIndeksowoBazowy.SelectedIndex == 3) // DI + BP
                    {
                        starszyAdres = pobierz.Substring(0, 2);
                        mlodszyAdres = pobierz.Substring(2, 2);

                        diDec = int.Parse(diView.Text, System.Globalization.NumberStyles.HexNumber); // SI decymalne
                        bpDec = int.Parse(bpView.Text, System.Globalization.NumberStyles.HexNumber); // BX decymalne
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber); // DISP decymalne
                        sumDec = (diDec + bpDec + dispDec);

                        TABLICA[sumDec] = mlodszyAdres;
                        TABLICA[sumDec + 1] = starszyAdres;

                        listBoxRejestrOperacji.Items.Insert(0, $"MOV [DI+BP+{dispView.Text}], {comboBoxWymiana.Text}                MOV");
                    }
                    else
                        return;
                }
                else
                    return;

            }
            else // Z PAMIĘCI DO REJESTRU
            {
                if (radioButtonIndeksowy.Checked == true)
                {
                    if (comboBoxIndeksowy.SelectedIndex == 0) // SI
                    {

                        siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber);
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        sumDec = (siDec + dispDec);

                        odczyt = TABLICA[sumDec + 1] + TABLICA[sumDec];
                        sumHex = sumDec.ToString("X");

                        switch (comboBoxWymiana.Text)
                        {
                            case "AX":
                                axView.Text = odczyt;
                                break;
                            case "BX":
                                bxView.Text = odczyt;
                                break;
                            case "CX":
                                cxView.Text = odczyt;
                                break;
                            case "DX":
                                dxView.Text = odczyt;
                                break;
                        }

                        listBoxRejestrOperacji.Items.Insert(0, $"MOV {comboBoxWymiana.Text}, [SI+{dispView.Text}]                MOV");
                    }
                    else // DI
                    {
                        diDec = int.Parse(diView.Text, System.Globalization.NumberStyles.HexNumber);
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        sumDec = (diDec + dispDec);

                        odczyt = TABLICA[sumDec + 1] + TABLICA[sumDec];
                        sumHex = sumDec.ToString("X");
                        switch (comboBoxWymiana.Text)
                        {
                            case "AX":
                                axView.Text = odczyt;
                                break;
                            case "BX":
                                bxView.Text = odczyt;
                                break;
                            case "CX":
                                cxView.Text = odczyt;
                                break;
                            case "DX":
                                dxView.Text = odczyt;
                                break;
                        }
                        listBoxRejestrOperacji.Items.Insert(0, $"MOV {comboBoxWymiana.Text}, [DI+{dispView.Text}]                MOV");
                    }
                }
                else if (radioButtonBazowy.Checked == true)
                {
                    if (comboBoxBazowy.SelectedIndex == 0) // BX
                    {
                        bxDec = int.Parse(bxView.Text, System.Globalization.NumberStyles.HexNumber);
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        sumDec = (bxDec + dispDec);

                        odczyt = TABLICA[sumDec + 1] + TABLICA[sumDec];
                        sumHex = sumDec.ToString("X");
                        switch (comboBoxWymiana.Text)
                        {
                            case "AX":
                                axView.Text = odczyt;
                                break;
                            case "BX":
                                bxView.Text = odczyt;
                                break;
                            case "CX":
                                cxView.Text = odczyt;
                                break;
                            case "DX":
                                dxView.Text = odczyt;
                                break;
                        }
                        listBoxRejestrOperacji.Items.Insert(0, $"MOV {comboBoxWymiana.Text}, [BX+{dispView.Text}]                MOV");
                    }
                    else // BP
                    {
                        bpDec = int.Parse(bpView.Text, System.Globalization.NumberStyles.HexNumber);
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        sumDec = (bpDec + dispDec);

                        odczyt = TABLICA[sumDec + 1] + TABLICA[sumDec];
                        sumHex = sumDec.ToString("X");
                        switch (comboBoxWymiana.Text)
                        {
                            case "AX":
                                axView.Text = odczyt;
                                break;
                            case "BX":
                                bxView.Text = odczyt;
                                break;
                            case "CX":
                                cxView.Text = odczyt;
                                break;
                            case "DX":
                                dxView.Text = odczyt;
                                break;
                        }
                        listBoxRejestrOperacji.Items.Insert(0, $"MOV {comboBoxWymiana.Text}, [BP+{dispView.Text}]                MOV");
                    }
                }
                else if (radioButtonIndeksowoBazowy.Checked == true)
                {
                    if (comboBoxIndeksowoBazowy.SelectedIndex == 0) // SI + BX
                    {
                        siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber);
                        bxDec = int.Parse(bxView.Text, System.Globalization.NumberStyles.HexNumber);
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        sumDec = (siDec + bxDec + dispDec);

                        odczyt = TABLICA[sumDec + 1] + TABLICA[sumDec];
                        sumHex = sumDec.ToString("X");
                        switch (comboBoxWymiana.Text)
                        {
                            case "AX":
                                axView.Text = odczyt;
                                break;
                            case "BX":
                                bxView.Text = odczyt;
                                break;
                            case "CX":
                                cxView.Text = odczyt;
                                break;
                            case "DX":
                                dxView.Text = odczyt;
                                break;
                        }
                        listBoxRejestrOperacji.Items.Insert(0, $"MOV {comboBoxWymiana.Text}, [SI+BX+{dispView.Text}]                MOV");
                    }
                    else if (comboBoxIndeksowoBazowy.SelectedIndex == 1) // SI + BP
                    {
                        siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber);
                        bpDec = int.Parse(bpView.Text, System.Globalization.NumberStyles.HexNumber);
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        sumDec = (siDec + bpDec + dispDec);

                        odczyt = TABLICA[sumDec + 1] + TABLICA[sumDec];
                        sumHex = sumDec.ToString("X");
                        switch (comboBoxWymiana.Text)
                        {
                            case "AX":
                                axView.Text = odczyt;
                                break;
                            case "BX":
                                bxView.Text = odczyt;
                                break;
                            case "CX":
                                cxView.Text = odczyt;
                                break;
                            case "DX":
                                dxView.Text = odczyt;
                                break;
                        }
                        listBoxRejestrOperacji.Items.Insert(0, $"MOV {comboBoxWymiana.Text}, [SI+BP+{dispView.Text}]                MOV");
                    }
                    else if (comboBoxIndeksowoBazowy.SelectedIndex == 2) // DI + BX
                    {
                        diDec = int.Parse(diView.Text, System.Globalization.NumberStyles.HexNumber);
                        bxDec = int.Parse(bxView.Text, System.Globalization.NumberStyles.HexNumber);
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        sumDec = (diDec + bxDec + dispDec);

                        odczyt = TABLICA[sumDec + 1] + TABLICA[sumDec];
                        sumHex = sumDec.ToString("X");
                        switch (comboBoxWymiana.Text)
                        {
                            case "AX":
                                axView.Text = odczyt;
                                break;
                            case "BX":
                                bxView.Text = odczyt;
                                break;
                            case "CX":
                                cxView.Text = odczyt;
                                break;
                            case "DX":
                                dxView.Text = odczyt;
                                break;
                        }
                        listBoxRejestrOperacji.Items.Insert(0, $"MOV {comboBoxWymiana.Text}, [DI+BX+{dispView.Text}]                MOV");
                    }
                    else if (comboBoxIndeksowoBazowy.SelectedIndex == 3) // DI + BP
                    {
                        diDec = int.Parse(diView.Text, System.Globalization.NumberStyles.HexNumber);
                        bpDec = int.Parse(bpView.Text, System.Globalization.NumberStyles.HexNumber);
                        dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                        sumDec = (diDec + bpDec + dispDec);

                        odczyt = TABLICA[sumDec + 1] + TABLICA[sumDec];
                        sumHex = sumDec.ToString("X");
                        switch (comboBoxWymiana.Text)
                        {
                            case "AX":
                                axView.Text = odczyt;
                                break;
                            case "BX":
                                bxView.Text = odczyt;
                                break;
                            case "CX":
                                cxView.Text = odczyt;
                                break;
                            case "DX":
                                dxView.Text = odczyt;
                                break;
                        }
                        listBoxRejestrOperacji.Items.Insert(0, $"MOV {comboBoxWymiana.Text}, [DI+BP+{dispView.Text}]                MOV");
                    }
                    else
                        return;
                }
                else
                    return;



            }
            if (comboBoxKierunek.SelectedIndex != 1)
            {
                if (!listBoxRejestZapisu.Items.Contains($"{sumDec.ToString("X")}: {TABLICA[sumDec]}"))
                    listBoxRejestZapisu.Items.Insert(0, $"{sumDec.ToString("X")}: {TABLICA[sumDec]}");

                if (!listBoxRejestZapisu.Items.Contains($"{(sumDec + 1).ToString("X")}: {TABLICA[sumDec + 1]}"))
                    listBoxRejestZapisu.Items.Insert(1, $"{(sumDec + 1).ToString("X")}: {TABLICA[sumDec + 1]}");
            }
        }
        // 15. BUTTON XCHG 2
        private void buttonXCHG2_Click(object sender, EventArgs e)
        {
            switch (comboBoxWymiana.Text)
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

            // Z REJESTRU DO PAMIECI
            if (radioButtonIndeksowy.Checked == true)
            {
                if (comboBoxIndeksowy.SelectedIndex == 0) // SI
                {
                    siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber);
                    dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                    sumDec = (siDec + dispDec);
                    zamiana = TABLICA[sumDec + 1] + TABLICA[sumDec];

                    TABLICA[sumDec + 1] = pobierz.Substring(0, 2);
                    TABLICA[sumDec] = pobierz.Substring(2, 2);

                    switch (comboBoxWymiana.Text)
                    {
                        case "AX":
                            axView.Text = zamiana;
                            break;
                        case "BX":
                            bxView.Text = zamiana;
                            break;
                        case "CX":
                            cxView.Text = zamiana;
                            break;
                        case "DX":
                            dxView.Text = zamiana;
                            break;
                    }
                    if (comboBoxKierunek.SelectedIndex == 0)
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG [SI+{dispView.Text}], {comboBoxWymiana.Text}                   XCHG");
                    else
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG {comboBoxWymiana.Text}, [SI+{dispView.Text}]                   XCHG");
                }
                else // DI
                {
                    diDec = int.Parse(diView.Text, System.Globalization.NumberStyles.HexNumber);
                    dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                    sumDec = (diDec + dispDec);
                    zamiana = TABLICA[sumDec + 1] + TABLICA[sumDec];

                    TABLICA[sumDec + 1] = pobierz.Substring(0, 2);
                    TABLICA[sumDec] = pobierz.Substring(2, 2);

                    switch (comboBoxWymiana.Text)
                    {
                        case "AX":
                            axView.Text = zamiana;
                            break;
                        case "BX":
                            bxView.Text = zamiana;
                            break;
                        case "CX":
                            cxView.Text = zamiana;
                            break;
                        case "DX":
                            dxView.Text = zamiana;
                            break;
                    }
                    if (comboBoxKierunek.SelectedIndex == 0)
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG [DI+{dispView.Text}], {comboBoxWymiana.Text}                   XCHG");
                    else
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG {comboBoxWymiana.Text}, [DI+{dispView.Text}]                   XCHG");

                }

            }
            else if (radioButtonBazowy.Checked == true)
            {
                if (comboBoxBazowy.SelectedIndex == 0) // BX
                {
                    bxDec = int.Parse(bxView.Text, System.Globalization.NumberStyles.HexNumber);
                    dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                    sumDec = (bxDec + dispDec);
                    zamiana = TABLICA[sumDec + 1] + TABLICA[sumDec];

                    TABLICA[sumDec + 1] = pobierz.Substring(0, 2);
                    TABLICA[sumDec] = pobierz.Substring(2, 2);

                    switch (comboBoxWymiana.Text)
                    {
                        case "AX":
                            axView.Text = zamiana;
                            break;
                        case "BX":
                            bxView.Text = zamiana;
                            break;
                        case "CX":
                            cxView.Text = zamiana;
                            break;
                        case "DX":
                            dxView.Text = zamiana;
                            break;
                    }
                    if (comboBoxKierunek.SelectedIndex == 0)
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG [BX+{dispView.Text}], {comboBoxWymiana.Text}                  XCHG");
                    else
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG {comboBoxWymiana.Text}, [BX+{dispView.Text}]                  XCHG");
                }
                else //BP
                {
                    bpDec = int.Parse(bpView.Text, System.Globalization.NumberStyles.HexNumber);
                    dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                    sumDec = (bpDec + dispDec);
                    zamiana = TABLICA[sumDec + 1] + TABLICA[sumDec];

                    TABLICA[sumDec + 1] = pobierz.Substring(0, 2);
                    TABLICA[sumDec] = pobierz.Substring(2, 2);

                    switch (comboBoxWymiana.Text)
                    {
                        case "AX":
                            axView.Text = zamiana;
                            break;
                        case "BX":
                            bxView.Text = zamiana;
                            break;
                        case "CX":
                            cxView.Text = zamiana;
                            break;
                        case "DX":
                            dxView.Text = zamiana;
                            break;
                    }
                    if (comboBoxKierunek.SelectedIndex == 0)
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG [BP+{dispView.Text}], {comboBoxWymiana.Text}                  XCHG");
                    else
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG {comboBoxWymiana.Text}, [BP+{dispView.Text}]                  XCHG");
                }
            }
            else if (radioButtonIndeksowoBazowy.Checked == true)
            {
                if (comboBoxIndeksowoBazowy.SelectedIndex == 0) // SI+BX
                {
                    siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber);
                    bxDec = int.Parse(bxView.Text, System.Globalization.NumberStyles.HexNumber);
                    dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                    sumDec = (siDec + bxDec + dispDec);
                    zamiana = TABLICA[sumDec + 1] + TABLICA[sumDec];

                    TABLICA[sumDec + 1] = pobierz.Substring(0, 2);
                    TABLICA[sumDec] = pobierz.Substring(2, 2);

                    switch (comboBoxWymiana.Text)
                    {
                        case "AX":
                            axView.Text = zamiana;
                            break;
                        case "BX":
                            bxView.Text = zamiana;
                            break;
                        case "CX":
                            cxView.Text = zamiana;
                            break;
                        case "DX":
                            dxView.Text = zamiana;
                            break;
                    }
                    if (comboBoxKierunek.SelectedIndex == 0)
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG [SI+BX+{dispView.Text}], {comboBoxWymiana.Text}            XCHG");
                    else
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG {comboBoxWymiana.Text}, [SI+BX+{dispView.Text}]            XCHG");
                }
                else if (comboBoxIndeksowoBazowy.SelectedIndex == 1) // SI+BP
                {
                    siDec = int.Parse(siView.Text, System.Globalization.NumberStyles.HexNumber);
                    bpDec = int.Parse(bpView.Text, System.Globalization.NumberStyles.HexNumber);
                    dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                    sumDec = (siDec + bpDec + dispDec);
                    zamiana = TABLICA[sumDec + 1] + TABLICA[sumDec];

                    TABLICA[sumDec + 1] = pobierz.Substring(0, 2);
                    TABLICA[sumDec] = pobierz.Substring(2, 2);

                    switch (comboBoxWymiana.Text)
                    {
                        case "AX":
                            axView.Text = zamiana;
                            break;
                        case "BX":
                            bxView.Text = zamiana;
                            break;
                        case "CX":
                            cxView.Text = zamiana;
                            break;
                        case "DX":
                            dxView.Text = zamiana;
                            break;
                    }
                    if (comboBoxKierunek.SelectedIndex == 0)
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG [SI+BP+{dispView.Text}], {comboBoxWymiana.Text}            XCHG");
                    else
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG {comboBoxWymiana.Text}, [SI+BP+{dispView.Text}]            XCHG");
                }
                else if (comboBoxIndeksowoBazowy.SelectedIndex == 2) // DI+BX
                {
                    diDec = int.Parse(diView.Text, System.Globalization.NumberStyles.HexNumber);
                    bxDec = int.Parse(bxView.Text, System.Globalization.NumberStyles.HexNumber);
                    dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                    sumDec = (diDec + bxDec + dispDec);
                    zamiana = TABLICA[sumDec + 1] + TABLICA[sumDec];

                    TABLICA[sumDec + 1] = pobierz.Substring(0, 2);
                    TABLICA[sumDec] = pobierz.Substring(2, 2);

                    switch (comboBoxWymiana.Text)
                    {
                        case "AX":
                            axView.Text = zamiana;
                            break;
                        case "BX":
                            bxView.Text = zamiana;
                            break;
                        case "CX":
                            cxView.Text = zamiana;
                            break;
                        case "DX":
                            dxView.Text = zamiana;
                            break;
                    }
                    if (comboBoxKierunek.SelectedIndex == 0)
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG [DI+BX+{dispView.Text}], {comboBoxWymiana.Text}            XCHG");
                    else
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG {comboBoxWymiana.Text}, [DI+BX+{dispView.Text}]            XCHG");
                }
                else // DI+BP
                {
                    diDec = int.Parse(diView.Text, System.Globalization.NumberStyles.HexNumber);
                    bpDec = int.Parse(bpView.Text, System.Globalization.NumberStyles.HexNumber);
                    dispDec = int.Parse(dispView.Text, System.Globalization.NumberStyles.HexNumber);
                    sumDec = (diDec + bpDec + dispDec);
                    zamiana = TABLICA[sumDec + 1] + TABLICA[sumDec];

                    TABLICA[sumDec + 1] = pobierz.Substring(0, 2);
                    TABLICA[sumDec] = pobierz.Substring(2, 2);

                    switch (comboBoxWymiana.Text)
                    {
                        case "AX":
                            axView.Text = zamiana;
                            break;
                        case "BX":
                            bxView.Text = zamiana;
                            break;
                        case "CX":
                            cxView.Text = zamiana;
                            break;
                        case "DX":
                            dxView.Text = zamiana;
                            break;
                    }
                    if (comboBoxKierunek.SelectedIndex == 0)
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG [DI+BP+{dispView.Text}], {comboBoxWymiana.Text}            XCHG");
                    else
                        listBoxRejestrOperacji.Items.Insert(0, $"XCHG {comboBoxWymiana.Text}, [DI+BP+{dispView.Text}]            XCHG");
                }
            }
            else
                return;
        }
        // COMBO BOX TO
        private void comboBoxFROM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFROM.Text == "AX")
            {
                comboBoxTO.Items.Clear();
                comboBoxTO.Items.Add("BX");
                comboBoxTO.Items.Add("CX");
                comboBoxTO.Items.Add("DX");
                comboBoxTO.SelectedIndex = 0;
            }
            else if (comboBoxFROM.Text == "BX")
            {
                comboBoxTO.Items.Clear();
                comboBoxTO.Items.Add("AX");
                comboBoxTO.Items.Add("CX");
                comboBoxTO.Items.Add("DX");
                comboBoxTO.SelectedIndex = 0;
            }
            else if (comboBoxFROM.Text == "CX")
            {
                comboBoxTO.Items.Clear();
                comboBoxTO.Items.Add("AX");
                comboBoxTO.Items.Add("BX");
                comboBoxTO.Items.Add("DX");
                comboBoxTO.SelectedIndex = 0;
            }
            else if (comboBoxFROM.Text == "DX")
            {
                comboBoxTO.Items.Clear();
                comboBoxTO.Items.Add("AX");
                comboBoxTO.Items.Add("BX");
                comboBoxTO.Items.Add("CX");
                comboBoxTO.SelectedIndex = 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBoxPodgladPamieci.Items.Clear();
            for (int i = 0; i < TABLICA.Length; i++)
            {
                if (TABLICA[i] != "00")
                    listBoxPodgladPamieci.Items.Add($"{i.ToString("X")}: {TABLICA[i]}");
            }
        }


        private void buttonPush_Click(object sender, EventArgs e)
        {
                if (comboBoxStos.SelectedIndex == 0)
                {
                    string pierwszaPolowa = axView.Text.Substring(0, 2);
                    string drugaPolowa = axView.Text.Substring(2, 2);
                    STOS[wskaznikStosu] = drugaPolowa;
                    wskaznikStosu++;
                    STOS[wskaznikStosu] = pierwszaPolowa;
                    wskaznikStosu++;
                    spView.Text = wskaznikStosu.ToString();
                }
                else if (comboBoxStos.SelectedIndex == 1)
                {
                    string pierwszaPolowa = bxView.Text.Substring(0, 2);
                    string drugaPolowa = bxView.Text.Substring(2, 2);
                    STOS[wskaznikStosu] = drugaPolowa;
                    wskaznikStosu++;
                    STOS[wskaznikStosu] = pierwszaPolowa;
                    wskaznikStosu++;
                    spView.Text = wskaznikStosu.ToString();
                }
                else if (comboBoxStos.SelectedIndex == 2)
                {
                    string pierwszaPolowa = cxView.Text.Substring(0, 2);
                    string drugaPolowa = cxView.Text.Substring(2, 2);
                    STOS[wskaznikStosu] = drugaPolowa;
                    wskaznikStosu++;
                    STOS[wskaznikStosu] = pierwszaPolowa;
                    wskaznikStosu++;
                    spView.Text = wskaznikStosu.ToString();
                }
                else
                {
                    string pierwszaPolowa = dxView.Text.Substring(0, 2);
                    string drugaPolowa = dxView.Text.Substring(2, 2);
                    STOS[wskaznikStosu] = drugaPolowa;
                    wskaznikStosu++;
                    STOS[wskaznikStosu] = pierwszaPolowa;
                    wskaznikStosu++;
                    spView.Text = wskaznikStosu.ToString();
                }
        }

        private void buttonPop_Click(object sender, EventArgs e)
        {
            if (wskaznikStosu >= 2)
                if (comboBoxStos.SelectedIndex == 0)
                {
                    wskaznikStosu--;
                    string drugaPolowa = STOS[wskaznikStosu];
                    wskaznikStosu--;
                    string pierwszaPolowa = STOS[wskaznikStosu];
                    axView.Text = drugaPolowa + pierwszaPolowa;
                    spView.Text = wskaznikStosu.ToString();
                }
                else if (comboBoxStos.SelectedIndex == 1)
                {
                    wskaznikStosu--;
                    string drugaPolowa = STOS[wskaznikStosu];
                    wskaznikStosu--;
                    string pierwszaPolowa = STOS[wskaznikStosu];
                    bxView.Text = drugaPolowa + pierwszaPolowa;
                    spView.Text = wskaznikStosu.ToString();
                }
                else if (comboBoxStos.SelectedIndex == 2)
                {
                    wskaznikStosu--;
                    string drugaPolowa = STOS[wskaznikStosu];
                    wskaznikStosu--;
                    string pierwszaPolowa = STOS[wskaznikStosu];
                    cxView.Text = drugaPolowa + pierwszaPolowa;
                    spView.Text = wskaznikStosu.ToString();
                }
                else
                {
                    wskaznikStosu--;
                    string drugaPolowa = STOS[wskaznikStosu];
                    wskaznikStosu--;
                    string pierwszaPolowa = STOS[wskaznikStosu];
                    dxView.Text = drugaPolowa + pierwszaPolowa;
                    spView.Text = wskaznikStosu.ToString();
                }
            else
                return;        
        }



    }
    /*private void buttonCLEAR2_Click(object sender, EventArgs e)
        {
            siText.Text = "";
            diText.Text = "";
            bpText.Text = "";
            dispText.Text = "";
            Array.Clear(TABLICA, 0, TABLICA.Length - 1);
        }*/
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
}
