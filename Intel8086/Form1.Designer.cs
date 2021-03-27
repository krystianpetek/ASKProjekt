
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
            this.SuspendLayout();
            // 
            // axLabel
            // 
            this.axLabel.AutoSize = true;
            this.axLabel.Location = new System.Drawing.Point(22, 13);
            this.axLabel.Name = "axLabel";
            this.axLabel.Size = new System.Drawing.Size(22, 15);
            this.axLabel.TabIndex = 0;
            this.axLabel.Text = "AX";
            this.axLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // bxLabel
            // 
            this.bxLabel.AutoSize = true;
            this.bxLabel.Location = new System.Drawing.Point(22, 32);
            this.bxLabel.Name = "bxLabel";
            this.bxLabel.Size = new System.Drawing.Size(21, 15);
            this.bxLabel.TabIndex = 1;
            this.bxLabel.Text = "BX";
            // 
            // cxLabel
            // 
            this.cxLabel.AutoSize = true;
            this.cxLabel.Location = new System.Drawing.Point(22, 51);
            this.cxLabel.Name = "cxLabel";
            this.cxLabel.Size = new System.Drawing.Size(22, 15);
            this.cxLabel.TabIndex = 2;
            this.cxLabel.Text = "CX";
            // 
            // dxLabel
            // 
            this.dxLabel.AutoSize = true;
            this.dxLabel.Location = new System.Drawing.Point(22, 70);
            this.dxLabel.Name = "dxLabel";
            this.dxLabel.Size = new System.Drawing.Size(22, 15);
            this.dxLabel.TabIndex = 3;
            this.dxLabel.Text = "DX";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dxLabel);
            this.Controls.Add(this.cxLabel);
            this.Controls.Add(this.bxLabel);
            this.Controls.Add(this.axLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label axLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label bxLabel;
        private System.Windows.Forms.Label cxLabel;
        private System.Windows.Forms.Label dxLabel;
    }
}

