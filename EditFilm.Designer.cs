
namespace ProiectBD
{
    partial class EditFilm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.An = new System.Windows.Forms.TextBox();
            this.Durata = new System.Windows.Forms.TextBox();
            this.Tara = new System.Windows.Forms.TextBox();
            this.Limba = new System.Windows.Forms.TextBox();
            this.Regizor = new System.Windows.Forms.TextBox();
            this.Titlu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Descriere = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(495, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(510, 350);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick_1);
            // 
            // An
            // 
            this.An.Location = new System.Drawing.Point(147, 81);
            this.An.Name = "An";
            this.An.Size = new System.Drawing.Size(187, 27);
            this.An.TabIndex = 29;
            // 
            // Durata
            // 
            this.Durata.Location = new System.Drawing.Point(147, 122);
            this.Durata.Name = "Durata";
            this.Durata.Size = new System.Drawing.Size(187, 27);
            this.Durata.TabIndex = 28;
            // 
            // Tara
            // 
            this.Tara.Location = new System.Drawing.Point(147, 160);
            this.Tara.Name = "Tara";
            this.Tara.Size = new System.Drawing.Size(187, 27);
            this.Tara.TabIndex = 27;
            // 
            // Limba
            // 
            this.Limba.Location = new System.Drawing.Point(147, 200);
            this.Limba.Name = "Limba";
            this.Limba.Size = new System.Drawing.Size(187, 27);
            this.Limba.TabIndex = 26;
            // 
            // Regizor
            // 
            this.Regizor.Location = new System.Drawing.Point(147, 332);
            this.Regizor.Name = "Regizor";
            this.Regizor.Size = new System.Drawing.Size(187, 27);
            this.Regizor.TabIndex = 24;
            this.Regizor.TextChanged += new System.EventHandler(this.Regizor_TextChanged);
            // 
            // Titlu
            // 
            this.Titlu.Location = new System.Drawing.Point(147, 36);
            this.Titlu.Name = "Titlu";
            this.Titlu.Size = new System.Drawing.Size(187, 27);
            this.Titlu.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Regizor";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Descriere";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Limba";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tara ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Durata";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "An aparitie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Titlu";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 30;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Descriere
            // 
            this.Descriere.Location = new System.Drawing.Point(147, 238);
            this.Descriere.Name = "Descriere";
            this.Descriere.Size = new System.Drawing.Size(187, 78);
            this.Descriere.TabIndex = 31;
            this.Descriere.Text = "";
            // 
            // EditFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 499);
            this.Controls.Add(this.Descriere);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.An);
            this.Controls.Add(this.Durata);
            this.Controls.Add(this.Tara);
            this.Controls.Add(this.Limba);
            this.Controls.Add(this.Regizor);
            this.Controls.Add(this.Titlu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EditFilm";
            this.Text = "EditFilm";
            this.Load += new System.EventHandler(this.EditFilm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox An;
        private System.Windows.Forms.TextBox Durata;
        private System.Windows.Forms.TextBox Tara;
        private System.Windows.Forms.TextBox Limba;
        private System.Windows.Forms.TextBox Regizor;
        private System.Windows.Forms.TextBox Titlu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox Descriere;
    }
}