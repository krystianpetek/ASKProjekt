using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intel8086
{
    public partial class Form1 : Form
    {
        string ax;
        string bx;
        string cx;
        string dx;

        string pierwszy;
        string drugi;

        public Form1()
        {
            InitializeComponent();
            ax = "0000";
            bx = "0000";
            cx = "0000";
            dx = "0000";
            axView.Text = ax;
            axText.Text = ax;
            bxView.Text = bx;
            bxText.Text = bx;
            cxView.Text = cx;
            cxText.Text = cx;
            dxView.Text = dx;
            dxText.Text = dx;
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (axText.Text.Length == 4)
                axView.Text = axText.Text.ToUpper();

            if (bxText.Text.Length == 4)
                bxView.Text = bxText.Text.ToUpper();

            if (cxText.Text.Length == 4)
                cxView.Text = cxText.Text.ToUpper();

            if (dxText.Text.Length == 4)
                dxView.Text = dxText.Text.ToUpper();

            if ((comboBoxFROM.Text.Length > 0) && (comboBoxTO.Text.Length > 0))
                movLabel.Text = $"MOV {pierwszy}, {drugi}";

            else if (comboBoxFROM.Text.Length > 0)
                movLabel.Text = $"MOV {pierwszy}";
            else
                movLabel.Text = "";
        }

        private void comboBoxFROM_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch(comboBoxFROM.Text)
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

            /*
            if(comboBoxFROM.Text == "AX") movLabel.Text = "MOV AX";
            
            if(comboBoxFROM.Text == "BX") movLabel.Text = "MOV BX";

            if (comboBoxFROM.Text == "CX") movLabel.Text = "MOV CX";

            if (comboBoxFROM.Text == "DX") movLabel.Text = "MOV DX";
            */
        }

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxFROM.SelectedIndex = -1;
            comboBoxTO.SelectedIndex = -1;
            movLabel.Text = "";
            axText.Text = "";
            bxText.Text = "";
            cxText.Text = "";
            dxText.Text = "";
        }
    }
}
