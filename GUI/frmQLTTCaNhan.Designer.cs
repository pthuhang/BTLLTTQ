using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    partial class frmQLTTCaNhan
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
            this.btnBangLuong = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnBoSungKhauTru = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnBangCong = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnThongTinCaNhan = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pViewQLTTCaNhan = new System.Windows.Forms.Panel();
            this.btnHopDong = new System.Windows.Forms.Button();
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
            this.label1.Size = new System.Drawing.Size(246, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin cá nhân";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuChucNangQLNS
            // 
            this.menuChucNangQLNS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.menuChucNangQLNS.Controls.Add(this.btnHopDong);
            this.menuChucNangQLNS.Controls.Add(this.btnBangLuong);
            this.menuChucNangQLNS.Controls.Add(this.panel13);
            this.menuChucNangQLNS.Controls.Add(this.panel12);
            this.menuChucNangQLNS.Controls.Add(this.panel11);
            this.menuChucNangQLNS.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuChucNangQLNS.Location = new System.Drawing.Point(0, 60);
            this.menuChucNangQLNS.Name = "menuChucNangQLNS";
            this.menuChucNangQLNS.Size = new System.Drawing.Size(1479, 60);
            this.menuChucNangQLNS.TabIndex = 2;
            // 
            // btnBangLuong
            // 
            this.btnBangLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnBangLuong.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBangLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnBangLuong.Location = new System.Drawing.Point(444, 0);
            this.btnBangLuong.Name = "btnBangLuong";
            this.btnBangLuong.Size = new System.Drawing.Size(148, 60);
            this.btnBangLuong.TabIndex = 3;
            this.btnBangLuong.Text = "Bảng lương";
            this.btnBangLuong.UseVisualStyleBackColor = false;
            this.btnBangLuong.Click += new System.EventHandler(this.btnBangLuong_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnBoSungKhauTru);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(296, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(148, 60);
            this.panel13.TabIndex = 2;
            // 
            // btnBoSungKhauTru
            // 
            this.btnBoSungKhauTru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnBoSungKhauTru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBoSungKhauTru.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnBoSungKhauTru.Location = new System.Drawing.Point(0, 0);
            this.btnBoSungKhauTru.Name = "btnBoSungKhauTru";
            this.btnBoSungKhauTru.Size = new System.Drawing.Size(148, 60);
            this.btnBoSungKhauTru.TabIndex = 1;
            this.btnBoSungKhauTru.Text = "Bổ sung, khấu trừ";
            this.btnBoSungKhauTru.UseVisualStyleBackColor = false;
            this.btnBoSungKhauTru.Click += new System.EventHandler(this.btnBoSungKhauTru_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnBangCong);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(148, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(148, 60);
            this.panel12.TabIndex = 1;
            // 
            // btnBangCong
            // 
            this.btnBangCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnBangCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBangCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnBangCong.Location = new System.Drawing.Point(0, 0);
            this.btnBangCong.Name = "btnBangCong";
            this.btnBangCong.Size = new System.Drawing.Size(148, 60);
            this.btnBangCong.TabIndex = 1;
            this.btnBangCong.Text = "Bảng công";
            this.btnBangCong.UseVisualStyleBackColor = false;
            this.btnBangCong.Click += new System.EventHandler(this.btnBangCong_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnThongTinCaNhan);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(148, 60);
            this.panel11.TabIndex = 0;
            // 
            // btnThongTinCaNhan
            // 
            this.btnThongTinCaNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnThongTinCaNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongTinCaNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnThongTinCaNhan.Location = new System.Drawing.Point(0, 0);
            this.btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            this.btnThongTinCaNhan.Size = new System.Drawing.Size(148, 60);
            this.btnThongTinCaNhan.TabIndex = 0;
            this.btnThongTinCaNhan.Text = "Thông tin cá nhân";
            this.btnThongTinCaNhan.UseVisualStyleBackColor = false;
            this.btnThongTinCaNhan.Click += new System.EventHandler(this.btnThongTinCaNhan_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panel10.Controls.Add(this.pViewQLTTCaNhan);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 120);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1479, 617);
            this.panel10.TabIndex = 3;
            // 
            // pViewQLTTCaNhan
            // 
            this.pViewQLTTCaNhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pViewQLTTCaNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pViewQLTTCaNhan.Location = new System.Drawing.Point(0, 0);
            this.pViewQLTTCaNhan.Name = "pViewQLTTCaNhan";
            this.pViewQLTTCaNhan.Size = new System.Drawing.Size(1479, 617);
            this.pViewQLTTCaNhan.TabIndex = 1;
            // 
            // btnHopDong
            // 
            this.btnHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(216)))));
            this.btnHopDong.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHopDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnHopDong.Location = new System.Drawing.Point(592, 0);
            this.btnHopDong.Name = "btnHopDong";
            this.btnHopDong.Size = new System.Drawing.Size(148, 60);
            this.btnHopDong.TabIndex = 4;
            this.btnHopDong.Text = "Hợp đồng";
            this.btnHopDong.UseVisualStyleBackColor = false;
            this.btnHopDong.Click += new System.EventHandler(this.btnHopDong_Click);
            // 
            // frmQLTTCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1479, 737);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.menuChucNangQLNS);
            this.Controls.Add(this.header);
            this.Name = "frmQLTTCaNhan";
            this.Text = "Quản lý nhân sự";
            this.Load += new System.EventHandler(this.frmQLTTCaNhan_Load);
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
        private Button btnBangCong;
        private Panel panel11;
        private Button btnThongTinCaNhan;
        private Panel panel10;
        private Button btnBoSungKhauTru;
        private Panel pViewQLTTCaNhan;
        private Button btnBangLuong;
        private Button btnHopDong;
    }
}