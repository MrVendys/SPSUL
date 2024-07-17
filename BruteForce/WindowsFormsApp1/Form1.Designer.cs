namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.passLabel = new System.Windows.Forms.Label();
            this.passText = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.vyzkLabel = new System.Windows.Forms.Label();
            this.celkLabel = new System.Windows.Forms.Label();
            this.aktLabel = new System.Windows.Forms.Label();
            this.vyzkText = new System.Windows.Forms.Label();
            this.celkText = new System.Windows.Forms.Label();
            this.aktText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Délka hesla:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(201, 11);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 34);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "5";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(356, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generovat Heslo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Abeceda:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(201, 69);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(407, 147);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "abcdefghijklmnopqrstuvwxyz0123456789";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(356, 235);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(253, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "Hackni bruteforce";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // passLabel
            // 
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passLabel.Location = new System.Drawing.Point(16, 265);
            this.passLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(159, 23);
            this.passLabel.TabIndex = 6;
            this.passLabel.Text = "Vygenerované heslo: ";
            // 
            // passText
            // 
            this.passText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passText.Location = new System.Drawing.Point(176, 265);
            this.passText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(159, 23);
            this.passText.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 293);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Maximum = 1000000000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(588, 46);
            this.progressBar1.TabIndex = 8;
            // 
            // vyzkLabel
            // 
            this.vyzkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vyzkLabel.Location = new System.Drawing.Point(16, 342);
            this.vyzkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vyzkLabel.Name = "vyzkLabel";
            this.vyzkLabel.Size = new System.Drawing.Size(291, 34);
            this.vyzkLabel.TabIndex = 9;
            this.vyzkLabel.Text = "Vyzkoušené kombinace:";
            // 
            // celkLabel
            // 
            this.celkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.celkLabel.Location = new System.Drawing.Point(16, 377);
            this.celkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.celkLabel.Name = "celkLabel";
            this.celkLabel.Size = new System.Drawing.Size(300, 34);
            this.celkLabel.TabIndex = 10;
            this.celkLabel.Text = "Celkový počet kombinací:";
            // 
            // aktLabel
            // 
            this.aktLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aktLabel.Location = new System.Drawing.Point(16, 411);
            this.aktLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aktLabel.Name = "aktLabel";
            this.aktLabel.Size = new System.Drawing.Size(241, 34);
            this.aktLabel.TabIndex = 11;
            this.aktLabel.Text = "Aktuální kombinace:";
            // 
            // vyzkText
            // 
            this.vyzkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vyzkText.Location = new System.Drawing.Point(315, 342);
            this.vyzkText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vyzkText.Name = "vyzkText";
            this.vyzkText.Size = new System.Drawing.Size(295, 34);
            this.vyzkText.TabIndex = 12;
            // 
            // celkText
            // 
            this.celkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.celkText.Location = new System.Drawing.Point(323, 377);
            this.celkText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.celkText.Name = "celkText";
            this.celkText.Size = new System.Drawing.Size(287, 34);
            this.celkText.TabIndex = 13;
            // 
            // aktText
            // 
            this.aktText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aktText.Location = new System.Drawing.Point(265, 411);
            this.aktText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aktText.Name = "aktText";
            this.aktText.Size = new System.Drawing.Size(265, 34);
            this.aktText.TabIndex = 14;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.time.Location = new System.Drawing.Point(583, 430);
            this.time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(0, 24);
            this.time.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 462);
            this.Controls.Add(this.time);
            this.Controls.Add(this.aktText);
            this.Controls.Add(this.celkText);
            this.Controls.Add(this.vyzkText);
            this.Controls.Add(this.aktLabel);
            this.Controls.Add(this.celkLabel);
            this.Controls.Add(this.vyzkLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label passText;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label vyzkLabel;
        private System.Windows.Forms.Label celkLabel;
        private System.Windows.Forms.Label aktLabel;
        private System.Windows.Forms.Label vyzkText;
        private System.Windows.Forms.Label celkText;
        private System.Windows.Forms.Label aktText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label time;
    }
}

