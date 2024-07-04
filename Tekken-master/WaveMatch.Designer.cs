namespace Tekken
{
    partial class WaveMatch
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
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.countdownLbl = new System.Windows.Forms.Label();
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.freqScroll = new System.Windows.Forms.TrackBar();
            this.ampScroll = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ampScroll)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 424);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(817, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.countdownLbl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 322);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // countdownLbl
            // 
            this.countdownLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.countdownLbl.Location = new System.Drawing.Point(0, 0);
            this.countdownLbl.Name = "countdownLbl";
            this.countdownLbl.Size = new System.Drawing.Size(817, 322);
            this.countdownLbl.TabIndex = 0;
            this.countdownLbl.Text = "3";
            this.countdownLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // countdownTimer
            // 
            this.countdownTimer.Interval = 1000;
            this.countdownTimer.Tick += new System.EventHandler(this.countdownTimer_Tick);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(13, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Amplitude";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "Frequency";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // freqScroll
            // 
            this.freqScroll.Location = new System.Drawing.Point(136, 337);
            this.freqScroll.Maximum = 36;
            this.freqScroll.Minimum = 16;
            this.freqScroll.Name = "freqScroll";
            this.freqScroll.Size = new System.Drawing.Size(693, 45);
            this.freqScroll.TabIndex = 7;
            this.freqScroll.Value = 16;
            this.freqScroll.Scroll += new System.EventHandler(this.freqScroll_Scroll);
            // 
            // ampScroll
            // 
            this.ampScroll.Location = new System.Drawing.Point(136, 373);
            this.ampScroll.Maximum = 36;
            this.ampScroll.Minimum = 10;
            this.ampScroll.Name = "ampScroll";
            this.ampScroll.Size = new System.Drawing.Size(693, 45);
            this.ampScroll.TabIndex = 8;
            this.ampScroll.Value = 10;
            this.ampScroll.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // WaveMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 459);
            this.Controls.Add(this.ampScroll);
            this.Controls.Add(this.freqScroll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Name = "WaveMatch";
            this.Text = "WaveMatch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaveMatch_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.freqScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ampScroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label countdownLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar freqScroll;
        private System.Windows.Forms.TrackBar ampScroll;
    }
}