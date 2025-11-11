using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    partial class frmMainNhanVien
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
        /// 
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnHopDong = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnBangLuong = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBoSungKhauTru = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnBangCong = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnThongTinCaNhan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelView = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.label1.Location = new System.Drawing.Point(111, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(100)))));
            this.panelMenu.Controls.Add(this.panel7);
            this.panelMenu.Controls.Add(this.panel8);
            this.panelMenu.Controls.Add(this.panel9);
            this.panelMenu.Controls.Add(this.panel4);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.panel6);
            this.panelMenu.Controls.Add(this.panel5);
            this.panelMenu.Controls.Add(this.panel3);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(290, 731);
            this.panelMenu.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 370);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(290, 50);
            this.panel7.TabIndex = 10;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnHopDong);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 320);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(290, 50);
            this.panel8.TabIndex = 9;
            // 
            // btnHopDong
            // 
            this.btnHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHopDong.ForeColor = System.Drawing.Color.White;
            this.btnHopDong.Location = new System.Drawing.Point(0, 0);
            this.btnHopDong.Name = "btnHopDong";
            this.btnHopDong.Size = new System.Drawing.Size(290, 50);
            this.btnHopDong.TabIndex = 8;
            this.btnHopDong.Text = "Hợp đồng";
            this.btnHopDong.UseVisualStyleBackColor = false;
            this.btnHopDong.Click += new System.EventHandler(this.btnHopDong_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnBangLuong);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 270);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(290, 50);
            this.panel9.TabIndex = 8;
            // 
            // btnBangLuong
            // 
            this.btnBangLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnBangLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBangLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBangLuong.ForeColor = System.Drawing.Color.White;
            this.btnBangLuong.Location = new System.Drawing.Point(0, 0);
            this.btnBangLuong.Name = "btnBangLuong";
            this.btnBangLuong.Size = new System.Drawing.Size(290, 50);
            this.btnBangLuong.TabIndex = 1;
            this.btnBangLuong.Text = "Bảng lương";
            this.btnBangLuong.UseVisualStyleBackColor = false;
            this.btnBangLuong.Click += new System.EventHandler(this.btnBangLuong_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDangXuat);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 631);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(290, 100);
            this.panel4.TabIndex = 7;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(100)))));
            this.btnDangXuat.Location = new System.Drawing.Point(73, 28);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(145, 45);
            this.btnDangXuat.TabIndex = 9;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBoSungKhauTru);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 50);
            this.panel2.TabIndex = 6;
            // 
            // btnBoSungKhauTru
            // 
            this.btnBoSungKhauTru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnBoSungKhauTru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBoSungKhauTru.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoSungKhauTru.ForeColor = System.Drawing.Color.White;
            this.btnBoSungKhauTru.Location = new System.Drawing.Point(0, 0);
            this.btnBoSungKhauTru.Name = "btnBoSungKhauTru";
            this.btnBoSungKhauTru.Size = new System.Drawing.Size(290, 50);
            this.btnBoSungKhauTru.TabIndex = 9;
            this.btnBoSungKhauTru.Text = "Khoản bổ sung, khấu trừ";
            this.btnBoSungKhauTru.UseVisualStyleBackColor = false;
            this.btnBoSungKhauTru.Click += new System.EventHandler(this.btnBoSungKhauTru_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnBangCong);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 170);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(290, 50);
            this.panel6.TabIndex = 3;
            // 
            // btnBangCong
            // 
            this.btnBangCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnBangCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBangCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBangCong.ForeColor = System.Drawing.Color.White;
            this.btnBangCong.Location = new System.Drawing.Point(0, 0);
            this.btnBangCong.Name = "btnBangCong";
            this.btnBangCong.Size = new System.Drawing.Size(290, 50);
            this.btnBangCong.TabIndex = 1;
            this.btnBangCong.Text = "Bảng công";
            this.btnBangCong.UseVisualStyleBackColor = false;
            this.btnBangCong.Click += new System.EventHandler(this.btnBangCong_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnThongTinCaNhan);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 120);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(290, 50);
            this.panel5.TabIndex = 2;
            // 
            // btnThongTinCaNhan
            // 
            this.btnThongTinCaNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnThongTinCaNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongTinCaNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTinCaNhan.ForeColor = System.Drawing.Color.White;
            this.btnThongTinCaNhan.Location = new System.Drawing.Point(0, 0);
            this.btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            this.btnThongTinCaNhan.Size = new System.Drawing.Size(290, 50);
            this.btnThongTinCaNhan.TabIndex = 0;
            this.btnThongTinCaNhan.Text = "Thông tin cá nhân";
            this.btnThongTinCaNhan.UseVisualStyleBackColor = false;
            this.btnThongTinCaNhan.Click += new System.EventHandler(this.btnThongTinCaNhan_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 120);
            this.panel3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackgroundImage = global::QUANLYNHANSU.Properties.Resources.Ảnh_chụp_màn_hình_2025_10_27_143933;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(100, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 81);
            this.panel1.TabIndex = 3;
            // 
            // panelView
            // 
            this.panelView.BackColor = System.Drawing.Color.White;
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(290, 0);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(1127, 731);
            this.panelView.TabIndex = 1;
            // 
            // frmMainNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1417, 731);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelMenu);
            this.Name = "frmMainNhanVien";
            this.Text = "Trang chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainNhanVien_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Button btnBangLuong;
        private System.Windows.Forms.Button btnBangCong;
        private System.Windows.Forms.Button btnThongTinCaNhan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private Panel panel1;
        private Panel panel4;
        private Button btnDangXuat;
        private Button btnBoSungKhauTru;
        private Button btnHopDong;
        private Panel panel8;
        private Panel panel9;
        private Panel panel2;
        private Panel panel6;
        private Panel panel5;
        private Panel panel7;
    }
}