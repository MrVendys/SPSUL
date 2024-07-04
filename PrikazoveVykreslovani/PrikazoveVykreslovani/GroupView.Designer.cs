namespace PrikazoveVykreslovani
{
    partial class GroupView
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

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.command2 = new PrikazoveVykreslovani.Command();
            this.command3 = new PrikazoveVykreslovani.Command();
            this.command1 = new PrikazoveVykreslovani.Command();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 144);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.command2);
            this.flowLayoutPanel1.Controls.Add(this.command3);
            this.flowLayoutPanel1.Controls.Add(this.command1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(153, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 131);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // command2
            // 
            this.command2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.command2.Location = new System.Drawing.Point(2, 2);
            this.command2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.command2.Name = "command2";
            this.command2.Size = new System.Drawing.Size(378, 39);
            this.command2.TabIndex = 1;
            // 
            // command3
            // 
            this.command3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.command3.Location = new System.Drawing.Point(2, 45);
            this.command3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.command3.Name = "command3";
            this.command3.Size = new System.Drawing.Size(378, 39);
            this.command3.TabIndex = 2;
            // 
            // command1
            // 
            this.command1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.command1.Location = new System.Drawing.Point(2, 88);
            this.command1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.command1.Name = "command1";
            this.command1.Size = new System.Drawing.Size(378, 39);
            this.command1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(153, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Název skupiny";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GroupView";
            this.Size = new System.Drawing.Size(535, 193);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Command command1;
        private System.Windows.Forms.Label label1;
        private Command command2;
        private Command command3;
    }
}
