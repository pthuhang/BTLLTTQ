using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    partial class frmQLThuongPhat
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

        void StyleButton(Button btn)
        {
            btn.BackColor = ColorTranslator.FromHtml("#1E88E5");
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Size = new Size(150, 40);

        }
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuChucNangQLNS = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnKiLuat = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnKhenThuong = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panelViewQLThuongPhat = new System.Windows.Forms.Panel();
            this.header.SuspendLayout();
            this.menuChucNangQLNS.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(100)))));
            this.header.Controls.Add(this.label1);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1479, 60);
            this.header.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(489, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khen thưởng và kỉ luật";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuChucNangQLNS
            // 
            this.menuChucNangQLNS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.menuChucNangQLNS.Controls.Add(this.panel12);
            this.menuChucNangQLNS.Controls.Add(this.panel11);
            this.menuChucNangQLNS.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuChucNangQLNS.Location = new System.Drawing.Point(0, 60);
            this.menuChucNangQLNS.Name = "menuChucNangQLNS";
            this.menuChucNangQLNS.Size = new System.Drawing.Size(1479, 60);
            this.menuChucNangQLNS.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnKiLuat);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(148, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(148, 60);
            this.panel12.TabIndex = 1;
            // 
            // btnKiLuat
            // 
            this.btnKiLuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnKiLuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKiLuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnKiLuat.Location = new System.Drawing.Point(0, 0);
            this.btnKiLuat.Name = "btnKiLuat";
            this.btnKiLuat.Size = new System.Drawing.Size(148, 60);
            this.btnKiLuat.TabIndex = 1;
            this.btnKiLuat.Text = "Kỉ luật";
            this.btnKiLuat.UseVisualStyleBackColor = false;
            this.btnKiLuat.Click += new System.EventHandler(this.btnKiLuat_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnKhenThuong);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(148, 60);
            this.panel11.TabIndex = 0;
            // 
            // btnKhenThuong
            // 
            this.btnKhenThuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnKhenThuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKhenThuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnKhenThuong.Location = new System.Drawing.Point(0, 0);
            this.btnKhenThuong.Name = "btnKhenThuong";
            this.btnKhenThuong.Size = new System.Drawing.Size(148, 60);
            this.btnKhenThuong.TabIndex = 0;
            this.btnKhenThuong.Text = "Khen thưởng";
            this.btnKhenThuong.UseVisualStyleBackColor = false;
            this.btnKhenThuong.Click += new System.EventHandler(this.btnKhenThuong_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panel10.Controls.Add(this.panelViewQLThuongPhat);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 120);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1479, 617);
            this.panel10.TabIndex = 3;
            // 
            // panelViewQLThuongPhat
            // 
            this.panelViewQLThuongPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewQLThuongPhat.Location = new System.Drawing.Point(0, 0);
            this.panelViewQLThuongPhat.Name = "panelViewQLThuongPhat";
            this.panelViewQLThuongPhat.Size = new System.Drawing.Size(1479, 617);
            this.panelViewQLThuongPhat.TabIndex = 1;
            // 
            // frmQLThuongPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1479, 737);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.menuChucNangQLNS);
            this.Controls.Add(this.header);
            this.Name = "frmQLThuongPhat";
            this.Text = "Quản lý chấm công";
            this.Load += new System.EventHandler(this.frmQLThuongPhat_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.menuChucNangQLNS.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label label1;
        private Panel menuChucNangQLNS;
        private Panel panel12;
        private Button btnKiLuat;
        private Panel panel11;
        private Button btnKhenThuong;
        private Panel panel10;
        private Panel panelViewQLThuongPhat;
    }
}