using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    partial class frmQLNhanSu
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
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnHopDong = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnPhongBan = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panelViewQLNhanSu = new System.Windows.Forms.Panel();
            this.header.SuspendLayout();
            this.menuChucNangQLNS.SuspendLayout();
            this.panel13.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(221, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý nhân sự";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuChucNangQLNS
            // 
            this.menuChucNangQLNS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.menuChucNangQLNS.Controls.Add(this.panel13);
            this.menuChucNangQLNS.Controls.Add(this.panel12);
            this.menuChucNangQLNS.Controls.Add(this.panel11);
            this.menuChucNangQLNS.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuChucNangQLNS.Location = new System.Drawing.Point(0, 60);
            this.menuChucNangQLNS.Name = "menuChucNangQLNS";
            this.menuChucNangQLNS.Size = new System.Drawing.Size(1479, 60);
            this.menuChucNangQLNS.TabIndex = 2;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnHopDong);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(296, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(148, 60);
            this.panel13.TabIndex = 2;
            // 
            // btnHopDong
            // 
            this.btnHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHopDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnHopDong.Location = new System.Drawing.Point(0, 0);
            this.btnHopDong.Name = "btnHopDong";
            this.btnHopDong.Size = new System.Drawing.Size(148, 60);
            this.btnHopDong.TabIndex = 1;
            this.btnHopDong.Text = "Hợp đồng";
            this.btnHopDong.UseVisualStyleBackColor = false;
            this.btnHopDong.Click += new System.EventHandler(this.btnHopDong_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnPhongBan);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(148, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(148, 60);
            this.panel12.TabIndex = 1;
            // 
            // btnPhongBan
            // 
            this.btnPhongBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPhongBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnPhongBan.Location = new System.Drawing.Point(0, 0);
            this.btnPhongBan.Name = "btnPhongBan";
            this.btnPhongBan.Size = new System.Drawing.Size(148, 60);
            this.btnPhongBan.TabIndex = 1;
            this.btnPhongBan.Text = "Phòng ban";
            this.btnPhongBan.UseVisualStyleBackColor = false;
            this.btnPhongBan.Click += new System.EventHandler(this.btnPhongBan_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnNhanVien);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(148, 60);
            this.panel11.TabIndex = 0;
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnNhanVien.Location = new System.Drawing.Point(0, 0);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(148, 60);
            this.btnNhanVien.TabIndex = 0;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panel10.Controls.Add(this.panelViewQLNhanSu);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 120);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1479, 617);
            this.panel10.TabIndex = 3;
            // 
            // panelViewQLNhanSu
            // 
            this.panelViewQLNhanSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewQLNhanSu.Location = new System.Drawing.Point(0, 0);
            this.panelViewQLNhanSu.Name = "panelViewQLNhanSu";
            this.panelViewQLNhanSu.Size = new System.Drawing.Size(1479, 617);
            this.panelViewQLNhanSu.TabIndex = 1;
            // 
            // frmQLNhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1479, 737);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.menuChucNangQLNS);
            this.Controls.Add(this.header);
            this.Name = "frmQLNhanSu";
            this.Text = "Quản lý nhân sự";
            this.Load += new System.EventHandler(this.frmQLNhanSu_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.menuChucNangQLNS.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label label1;
        private Panel menuChucNangQLNS;
        private Panel panel13;
        private Panel panel12;
        private Button btnPhongBan;
        private Panel panel11;
        private Button btnNhanVien;
        private Panel panel10;
        private Button btnHopDong;
        private Panel panelViewQLNhanSu;
    }
}