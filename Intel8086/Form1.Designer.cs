
namespace Intel8086
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.axLabel = new System.Windows.Forms.Label();
            this.bxLabel = new System.Windows.Forms.Label();
            this.cxLabel = new System.Windows.Forms.Label();
            this.dxLabel = new System.Windows.Forms.Label();
            this.axView = new System.Windows.Forms.TextBox();
            this.bxView = new System.Windows.Forms.TextBox();
            this.cxView = new System.Windows.Forms.TextBox();
            this.dxView = new System.Windows.Forms.TextBox();
            this.dxText = new System.Windows.Forms.TextBox();
            this.cxText = new System.Windows.Forms.TextBox();
            this.bxText = new System.Windows.Forms.TextBox();
            this.axText = new System.Windows.Forms.TextBox();
            this.buttonMOV = new System.Windows.Forms.Button();
            this.comboBoxTO = new System.Windows.Forms.ComboBox();
            this.comboBoxFROM = new System.Windows.Forms.ComboBox();
            this.movLabel = new System.Windows.Forms.Label();
            this.buttonCLEAR = new System.Windows.Forms.Button();
            this.buttonXCHG = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.buttonRANDOM = new System.Windows.Forms.Button();
            this.labelAutor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // axLabel
            // 
            this.axLabel.AutoSize = true;
            this.axLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.axLabel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.axLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.axLabel.Location = new System.Drawing.Point(18, 82);
            this.axLabel.Name = "axLabel";
            this.axLabel.Size = new System.Drawing.Size(22, 18);
            this.axLabel.TabIndex = 0;
            this.axLabel.Text = "AX";
            // 
            // bxLabel
            // 
            this.bxLabel.AutoSize = true;
            this.bxLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.bxLabel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bxLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.bxLabel.Location = new System.Drawing.Point(18, 108);
            this.bxLabel.Name = "bxLabel";
            this.bxLabel.Size = new System.Drawing.Size(22, 18);
            this.bxLabel.TabIndex = 1;
            this.bxLabel.Text = "BX";
            // 
            // cxLabel
            // 
            this.cxLabel.AutoSize = true;
            this.cxLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cxLabel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cxLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cxLabel.Location = new System.Drawing.Point(18, 134);
            this.cxLabel.Name = "cxLabel";
            this.cxLabel.Size = new System.Drawing.Size(22, 18);
            this.cxLabel.TabIndex = 2;
            this.cxLabel.Text = "CX";
            // 
            // dxLabel
            // 
            this.dxLabel.AutoSize = true;
            this.dxLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.dxLabel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dxLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dxLabel.Location = new System.Drawing.Point(18, 160);
            this.dxLabel.Name = "dxLabel";
            this.dxLabel.Size = new System.Drawing.Size(22, 18);
            this.dxLabel.TabIndex = 3;
            this.dxLabel.Text = "DX";
            // 
            // axView
            // 
            this.axView.Enabled = false;
            this.axView.Location = new System.Drawing.Point(46, 77);
            this.axView.Name = "axView";
            this.axView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.axView.Size = new System.Drawing.Size(54, 23);
            this.axView.TabIndex = 4;
            this.axView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bxView
            // 
            this.bxView.Enabled = false;
            this.bxView.Location = new System.Drawing.Point(46, 103);
            this.bxView.Name = "bxView";
            this.bxView.Size = new System.Drawing.Size(54, 23);
            this.bxView.TabIndex = 5;
            this.bxView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cxView
            // 
            this.cxView.Enabled = false;
            this.cxView.Location = new System.Drawing.Point(46, 129);
            this.cxView.Name = "cxView";
            this.cxView.Size = new System.Drawing.Size(54, 23);
            this.cxView.TabIndex = 6;
            this.cxView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dxView
            // 
            this.dxView.Enabled = false;
            this.dxView.Location = new System.Drawing.Point(46, 155);
            this.dxView.Name = "dxView";
            this.dxView.Size = new System.Drawing.Size(54, 23);
            this.dxView.TabIndex = 7;
            this.dxView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dxText
            // 
            this.dxText.Location = new System.Drawing.Point(106, 155);
            this.dxText.MaxLength = 4;
            this.dxText.Name = "dxText";
            this.dxText.Size = new System.Drawing.Size(54, 23);
            this.dxText.TabIndex = 11;
            this.dxText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cxText
            // 
            this.cxText.Location = new System.Drawing.Point(106, 129);
            this.cxText.MaxLength = 4;
            this.cxText.Name = "cxText";
            this.cxText.Size = new System.Drawing.Size(54, 23);
            this.cxText.TabIndex = 10;
            this.cxText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bxText
            // 
            this.bxText.Location = new System.Drawing.Point(106, 103);
            this.bxText.MaxLength = 4;
            this.bxText.Name = "bxText";
            this.bxText.Size = new System.Drawing.Size(54, 23);
            this.bxText.TabIndex = 9;
            this.bxText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // axText
            // 
            this.axText.Location = new System.Drawing.Point(106, 77);
            this.axText.MaxLength = 4;
            this.axText.Name = "axText";
            this.axText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.axText.Size = new System.Drawing.Size(54, 23);
            this.axText.TabIndex = 8;
            this.axText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonMOV
            // 
            this.buttonMOV.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMOV.Location = new System.Drawing.Point(175, 77);
            this.buttonMOV.Name = "buttonMOV";
            this.buttonMOV.Size = new System.Drawing.Size(84, 23);
            this.buttonMOV.TabIndex = 12;
            this.buttonMOV.Text = "MOV";
            this.buttonMOV.UseVisualStyleBackColor = true;
            this.buttonMOV.Click += new System.EventHandler(this.buttonMOV_Click);
            // 
            // comboBoxTO
            // 
            this.comboBoxTO.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboBoxTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTO.FormattingEnabled = true;
            this.comboBoxTO.Items.AddRange(new object[] {
            "AX",
            "BX",
            "CX",
            "DX"});
            this.comboBoxTO.Location = new System.Drawing.Point(106, 199);
            this.comboBoxTO.Name = "comboBoxTO";
            this.comboBoxTO.Size = new System.Drawing.Size(54, 23);
            this.comboBoxTO.TabIndex = 13;
            this.comboBoxTO.SelectedIndexChanged += new System.EventHandler(this.comboBoxTO_SelectedIndexChanged);
            // 
            // comboBoxFROM
            // 
            this.comboBoxFROM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFROM.FormattingEnabled = true;
            this.comboBoxFROM.Items.AddRange(new object[] {
            "AX",
            "BX",
            "CX",
            "DX"});
            this.comboBoxFROM.Location = new System.Drawing.Point(46, 199);
            this.comboBoxFROM.Name = "comboBoxFROM";
            this.comboBoxFROM.Size = new System.Drawing.Size(54, 23);
            this.comboBoxFROM.TabIndex = 14;
            this.comboBoxFROM.SelectedIndexChanged += new System.EventHandler(this.comboBoxFROM_SelectedIndexChanged);
            // 
            // movLabel
            // 
            this.movLabel.AutoSize = true;
            this.movLabel.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.movLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.movLabel.Location = new System.Drawing.Point(46, 236);
            this.movLabel.Name = "movLabel";
            this.movLabel.Size = new System.Drawing.Size(0, 20);
            this.movLabel.TabIndex = 15;
            this.movLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonCLEAR
            // 
            this.buttonCLEAR.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCLEAR.Location = new System.Drawing.Point(175, 155);
            this.buttonCLEAR.Name = "buttonCLEAR";
            this.buttonCLEAR.Size = new System.Drawing.Size(84, 23);
            this.buttonCLEAR.TabIndex = 16;
            this.buttonCLEAR.Text = "WYCZYŚĆ";
            this.buttonCLEAR.UseVisualStyleBackColor = true;
            this.buttonCLEAR.Click += new System.EventHandler(this.buttonCLEAR_Click);
            // 
            // buttonXCHG
            // 
            this.buttonXCHG.Location = new System.Drawing.Point(175, 103);
            this.buttonXCHG.Name = "buttonXCHG";
            this.buttonXCHG.Size = new System.Drawing.Size(84, 23);
            this.buttonXCHG.TabIndex = 17;
            this.buttonXCHG.Text = "XCHG";
            this.buttonXCHG.UseVisualStyleBackColor = true;
            this.buttonXCHG.Click += new System.EventHandler(this.buttonXCHG_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.title.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.title.Location = new System.Drawing.Point(210, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(406, 27);
            this.title.TabIndex = 18;
            this.title.Text = "Symulator rozkazów procesora INTEL 8086";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonRANDOM
            // 
            this.buttonRANDOM.Location = new System.Drawing.Point(175, 128);
            this.buttonRANDOM.Name = "buttonRANDOM";
            this.buttonRANDOM.Size = new System.Drawing.Size(84, 24);
            this.buttonRANDOM.TabIndex = 19;
            this.buttonRANDOM.Text = "RANDOM";
            this.buttonRANDOM.UseVisualStyleBackColor = true;
            this.buttonRANDOM.Click += new System.EventHandler(this.buttonRANDOM_Click);
            // 
            // labelAutor
            // 
            this.labelAutor.AutoSize = true;
            this.labelAutor.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAutor.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelAutor.Location = new System.Drawing.Point(707, 426);
            this.labelAutor.Name = "labelAutor";
            this.labelAutor.Size = new System.Drawing.Size(80, 16);
            this.labelAutor.TabIndex = 20;
            this.labelAutor.Text = "Krystian Petek";
            this.labelAutor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAutor);
            this.Controls.Add(this.buttonRANDOM);
            this.Controls.Add(this.title);
            this.Controls.Add(this.buttonXCHG);
            this.Controls.Add(this.buttonCLEAR);
            this.Controls.Add(this.movLabel);
            this.Controls.Add(this.comboBoxFROM);
            this.Controls.Add(this.comboBoxTO);
            this.Controls.Add(this.buttonMOV);
            this.Controls.Add(this.dxText);
            this.Controls.Add(this.cxText);
            this.Controls.Add(this.bxText);
            this.Controls.Add(this.axText);
            this.Controls.Add(this.dxView);
            this.Controls.Add(this.cxView);
            this.Controls.Add(this.bxView);
            this.Controls.Add(this.axView);
            this.Controls.Add(this.dxLabel);
            this.Controls.Add(this.cxLabel);
            this.Controls.Add(this.bxLabel);
            this.Controls.Add(this.axLabel);
            this.Name = "Form1";
            this.Text = "Projekt ASK Krystian Petek";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label axLabel;
        private System.Windows.Forms.Label bxLabel;
        private System.Windows.Forms.Label cxLabel;
        private System.Windows.Forms.Label dxLabel;
        private System.Windows.Forms.TextBox axView;
        private System.Windows.Forms.TextBox bxView;
        private System.Windows.Forms.TextBox cxView;
        private System.Windows.Forms.TextBox dxView;
        private System.Windows.Forms.TextBox dxText;
        private System.Windows.Forms.TextBox axText;
        private System.Windows.Forms.TextBox bxText;
        private System.Windows.Forms.TextBox cxText;
        private System.Windows.Forms.ComboBox comboBoxFROM;
        private System.Windows.Forms.ComboBox comboBoxTO;
        private System.Windows.Forms.Label movLabel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button buttonCLEAR;
        private System.Windows.Forms.Button buttonXCHG;
        private System.Windows.Forms.Button buttonMOV;
        private System.Windows.Forms.Button buttonRANDOM;
        private System.Windows.Forms.Label labelAutor;
    }
}

