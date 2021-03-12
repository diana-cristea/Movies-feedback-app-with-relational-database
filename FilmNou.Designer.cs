
namespace ProiectBD
{
    partial class FilmNou
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Titlu = new System.Windows.Forms.TextBox();
            this.Regizor = new System.Windows.Forms.TextBox();
            this.Descriere = new System.Windows.Forms.TextBox();
            this.Limba = new System.Windows.Forms.TextBox();
            this.Tara = new System.Windows.Forms.TextBox();
            this.Durata = new System.Windows.Forms.TextBox();
            this.An = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scrieti informatiile filmului pe care doriti sa il adaugati";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Titlu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "An aparitie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Durata";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tara ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Limba";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Descriere";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Regizor principal";
            // 
            // Titlu
            // 
            this.Titlu.Location = new System.Drawing.Point(174, 83);
            this.Titlu.Name = "Titlu";
            this.Titlu.Size = new System.Drawing.Size(125, 27);
            this.Titlu.TabIndex = 8;
            this.Titlu.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Regizor
            // 
            this.Regizor.Location = new System.Drawing.Point(174, 320);
            this.Regizor.Name = "Regizor";
            this.Regizor.Size = new System.Drawing.Size(125, 27);
            this.Regizor.TabIndex = 10;
            // 
            // Descriere
            // 
            this.Descriere.Location = new System.Drawing.Point(174, 282);
            this.Descriere.Name = "Descriere";
            this.Descriere.Size = new System.Drawing.Size(125, 27);
            this.Descriere.TabIndex = 11;
            // 
            // Limba
            // 
            this.Limba.Location = new System.Drawing.Point(174, 247);
            this.Limba.Name = "Limba";
            this.Limba.Size = new System.Drawing.Size(125, 27);
            this.Limba.TabIndex = 12;
            this.Limba.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // Tara
            // 
            this.Tara.Location = new System.Drawing.Point(174, 207);
            this.Tara.Name = "Tara";
            this.Tara.Size = new System.Drawing.Size(125, 27);
            this.Tara.TabIndex = 13;
            // 
            // Durata
            // 
            this.Durata.Location = new System.Drawing.Point(174, 169);
            this.Durata.Name = "Durata";
            this.Durata.Size = new System.Drawing.Size(125, 27);
            this.Durata.TabIndex = 14;
            // 
            // An
            // 
            this.An.Location = new System.Drawing.Point(174, 128);
            this.An.Name = "An";
            this.An.Size = new System.Drawing.Size(125, 27);
            this.An.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 16;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FilmNou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 451);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.An);
            this.Controls.Add(this.Durata);
            this.Controls.Add(this.Tara);
            this.Controls.Add(this.Limba);
            this.Controls.Add(this.Descriere);
            this.Controls.Add(this.Regizor);
            this.Controls.Add(this.Titlu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FilmNou";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Titlu;
        private System.Windows.Forms.TextBox Regizor;
        private System.Windows.Forms.TextBox Descriere;
        private System.Windows.Forms.TextBox Limba;
        private System.Windows.Forms.TextBox Tara;
        private System.Windows.Forms.TextBox Durata;
        private System.Windows.Forms.TextBox An;
        private System.Windows.Forms.Button button1;
    }
}