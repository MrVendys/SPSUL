﻿namespace PrikazoveVykreslovani
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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent() {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.načístToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skupinbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přidatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvas1 = new PrikazoveVykreslovani.Canvas();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(818, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(444, 780);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.skupinbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1274, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.načístToolStripMenuItem,
            this.uložitToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // načístToolStripMenuItem
            // 
            this.načístToolStripMenuItem.Name = "načístToolStripMenuItem";
            this.načístToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.načístToolStripMenuItem.Text = "Načíst";
            this.načístToolStripMenuItem.Click += new System.EventHandler(this.načístToolStripMenuItem_Click);
            // 
            // uložitToolStripMenuItem
            // 
            this.uložitToolStripMenuItem.Name = "uložitToolStripMenuItem";
            this.uložitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uložitToolStripMenuItem.Text = "Uložit";
            this.uložitToolStripMenuItem.Click += new System.EventHandler(this.uložitToolStripMenuItem_Click);
            // 
            // skupinbaToolStripMenuItem
            // 
            this.skupinbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přidatToolStripMenuItem});
            this.skupinbaToolStripMenuItem.Name = "skupinbaToolStripMenuItem";
            this.skupinbaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.skupinbaToolStripMenuItem.Text = "Skupina";
            // 
            // přidatToolStripMenuItem
            // 
            this.přidatToolStripMenuItem.Name = "přidatToolStripMenuItem";
            this.přidatToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.přidatToolStripMenuItem.Text = "Přidat";
            this.přidatToolStripMenuItem.Click += new System.EventHandler(this.přidatToolStripMenuItem_Click);
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.canvas1.Location = new System.Drawing.Point(12, 27);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(800, 800);
            this.canvas1.TabIndex = 0;
            this.canvas1.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas1_Paint);
            this.canvas1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas1_MouseDown);
            this.canvas1.MouseLeave += new System.EventHandler(this.canvas1_MouseLeave);
            this.canvas1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas1_MouseMove);
            this.canvas1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 861);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem načístToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uložitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skupinbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přidatToolStripMenuItem;
        private Canvas canvas1;
    }
}

