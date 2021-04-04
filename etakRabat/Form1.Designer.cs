
namespace etakRabat
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
            this.labelETAK = new System.Windows.Forms.Label();
            this.buttonOblicz = new System.Windows.Forms.Button();
            this.richTextBoxKwota = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOblicz = new System.Windows.Forms.RichTextBox();
            this.labelKwota = new System.Windows.Forms.Label();
            this.labelOblicz = new System.Windows.Forms.Label();
            this.labelRabat = new System.Windows.Forms.Label();
            this.richTextBoxRabat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelETAK
            // 
            this.labelETAK.AutoSize = true;
            this.labelETAK.Location = new System.Drawing.Point(328, 263);
            this.labelETAK.Name = "labelETAK";
            this.labelETAK.Size = new System.Drawing.Size(81, 15);
            this.labelETAK.TabIndex = 1;
            this.labelETAK.Text = "Krystian Petek";
            this.labelETAK.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonOblicz
            // 
            this.buttonOblicz.Location = new System.Drawing.Point(98, 201);
            this.buttonOblicz.Name = "buttonOblicz";
            this.buttonOblicz.Size = new System.Drawing.Size(141, 62);
            this.buttonOblicz.TabIndex = 2;
            this.buttonOblicz.Text = "Oblicz";
            this.buttonOblicz.UseVisualStyleBackColor = true;
            this.buttonOblicz.Click += new System.EventHandler(this.buttonOblicz_Click);
            // 
            // richTextBoxKwota
            // 
            this.richTextBoxKwota.AcceptsTab = true;
            this.richTextBoxKwota.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxKwota.Location = new System.Drawing.Point(98, 46);
            this.richTextBoxKwota.Name = "richTextBoxKwota";
            this.richTextBoxKwota.Size = new System.Drawing.Size(298, 40);
            this.richTextBoxKwota.TabIndex = 4;
            this.richTextBoxKwota.Text = "";
            this.richTextBoxKwota.TextChanged += new System.EventHandler(this.richTextBoxKwota_TextChanged);
            // 
            // richTextBoxOblicz
            // 
            this.richTextBoxOblicz.Enabled = false;
            this.richTextBoxOblicz.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxOblicz.Location = new System.Drawing.Point(98, 137);
            this.richTextBoxOblicz.Name = "richTextBoxOblicz";
            this.richTextBoxOblicz.Size = new System.Drawing.Size(298, 40);
            this.richTextBoxOblicz.TabIndex = 5;
            this.richTextBoxOblicz.Text = "";
            this.richTextBoxOblicz.TextChanged += new System.EventHandler(this.richTextBoxOblicz_TextChanged);
            // 
            // labelKwota
            // 
            this.labelKwota.AutoSize = true;
            this.labelKwota.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelKwota.Location = new System.Drawing.Point(10, 52);
            this.labelKwota.Name = "labelKwota";
            this.labelKwota.Size = new System.Drawing.Size(84, 30);
            this.labelKwota.TabIndex = 6;
            this.labelKwota.Text = "KWOTA";
            // 
            // labelOblicz
            // 
            this.labelOblicz.AutoSize = true;
            this.labelOblicz.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelOblicz.Location = new System.Drawing.Point(10, 140);
            this.labelOblicz.Name = "labelOblicz";
            this.labelOblicz.Size = new System.Drawing.Size(79, 30);
            this.labelOblicz.TabIndex = 7;
            this.labelOblicz.Text = "WYNIK";
            // 
            // labelRabat
            // 
            this.labelRabat.AutoSize = true;
            this.labelRabat.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRabat.Location = new System.Drawing.Point(10, 95);
            this.labelRabat.Name = "labelRabat";
            this.labelRabat.Size = new System.Drawing.Size(75, 30);
            this.labelRabat.TabIndex = 9;
            this.labelRabat.Text = "RABAT";
            // 
            // richTextBoxRabat
            // 
            this.richTextBoxRabat.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxRabat.Location = new System.Drawing.Point(98, 92);
            this.richTextBoxRabat.Name = "richTextBoxRabat";
            this.richTextBoxRabat.Size = new System.Drawing.Size(298, 40);
            this.richTextBoxRabat.TabIndex = 8;
            this.richTextBoxRabat.Text = "";
            this.richTextBoxRabat.TextChanged += new System.EventHandler(this.richTextBoxRabat_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 287);
            this.Controls.Add(this.labelRabat);
            this.Controls.Add(this.richTextBoxRabat);
            this.Controls.Add(this.labelOblicz);
            this.Controls.Add(this.labelKwota);
            this.Controls.Add(this.richTextBoxOblicz);
            this.Controls.Add(this.richTextBoxKwota);
            this.Controls.Add(this.buttonOblicz);
            this.Controls.Add(this.labelETAK);
            this.Name = "Form1";
            this.Text = "RABAT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOblicz;
        private System.Windows.Forms.Label labelRabat;
        private System.Windows.Forms.RichTextBox richTextBoxKwota;
        private System.Windows.Forms.Label labelKwota;
        private System.Windows.Forms.Label labelETAK;
        private System.Windows.Forms.Label labelOblicz;
        private System.Windows.Forms.RichTextBox richTextBoxOblicz;
        private System.Windows.Forms.RichTextBox richTextBoxRabat;
    }
}

