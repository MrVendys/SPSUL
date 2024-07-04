namespace Tekken
{
    partial class Game
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
            this.fighterpctbx = new System.Windows.Forms.PictureBox();
            this.opponentpctbx = new System.Windows.Forms.PictureBox();
            this.consolelbl = new System.Windows.Forms.Label();
            this.fightbtn = new System.Windows.Forms.Button();
            this.fighterpgbr = new System.Windows.Forms.ProgressBar();
            this.opponentpgbr = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fighterpctbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opponentpctbx)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fighterpctbx
            // 
            this.fighterpctbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fighterpctbx.Location = new System.Drawing.Point(12, 15);
            this.fighterpctbx.Name = "fighterpctbx";
            this.fighterpctbx.Size = new System.Drawing.Size(300, 300);
            this.fighterpctbx.TabIndex = 0;
            this.fighterpctbx.TabStop = false;
            // 
            // opponentpctbx
            // 
            this.opponentpctbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opponentpctbx.Location = new System.Drawing.Point(1114, 15);
            this.opponentpctbx.Name = "opponentpctbx";
            this.opponentpctbx.Size = new System.Drawing.Size(300, 300);
            this.opponentpctbx.TabIndex = 1;
            this.opponentpctbx.TabStop = false;
            // 
            // consolelbl
            // 
            this.consolelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consolelbl.Location = new System.Drawing.Point(3, 0);
            this.consolelbl.Name = "consolelbl";
            this.consolelbl.Size = new System.Drawing.Size(1399, 42);
            this.consolelbl.TabIndex = 2;
            this.consolelbl.Text = "label1\\nasd";
            // 
            // fightbtn
            // 
            this.fightbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fightbtn.Location = new System.Drawing.Point(649, 219);
            this.fightbtn.Name = "fightbtn";
            this.fightbtn.Size = new System.Drawing.Size(75, 75);
            this.fightbtn.TabIndex = 3;
            this.fightbtn.Text = "Fight";
            this.fightbtn.UseVisualStyleBackColor = true;
            this.fightbtn.Click += new System.EventHandler(this.fightbtn_Click);
            // 
            // fighterpgbr
            // 
            this.fighterpgbr.Location = new System.Drawing.Point(12, 321);
            this.fighterpgbr.Name = "fighterpgbr";
            this.fighterpgbr.Size = new System.Drawing.Size(300, 35);
            this.fighterpgbr.TabIndex = 4;
            // 
            // opponentpgbr
            // 
            this.opponentpgbr.Location = new System.Drawing.Point(1114, 321);
            this.opponentpgbr.Name = "opponentpgbr";
            this.opponentpgbr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.opponentpgbr.RightToLeftLayout = true;
            this.opponentpgbr.Size = new System.Drawing.Size(300, 35);
            this.opponentpgbr.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 49);
            this.label1.TabIndex = 6;
            this.label1.Text = "55";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1114, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 49);
            this.label2.TabIndex = 7;
            this.label2.Text = "556";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel1.Controls.Add(this.consolelbl);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 477);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1402, 211);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 700);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opponentpgbr);
            this.Controls.Add(this.fighterpgbr);
            this.Controls.Add(this.fightbtn);
            this.Controls.Add(this.opponentpctbx);
            this.Controls.Add(this.fighterpctbx);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fighterpctbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opponentpctbx)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox fighterpctbx;
        private System.Windows.Forms.PictureBox opponentpctbx;
        private System.Windows.Forms.Label consolelbl;
        private System.Windows.Forms.Button fightbtn;
        private System.Windows.Forms.ProgressBar fighterpgbr;
        private System.Windows.Forms.ProgressBar opponentpgbr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}