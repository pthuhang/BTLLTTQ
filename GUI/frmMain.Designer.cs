using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    partial class frmMain
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnQLTaiKhoan = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnThuongPhat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnQLLuong = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnQLCong = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnQLNhanSu = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelView = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(100)))));
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.panel10);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.panel7);
            this.panelMenu.Controls.Add(this.panel6);
            this.panelMenu.Controls.Add(this.panel5);
            this.panelMenu.Controls.Add(this.panel4);
            this.panelMenu.Controls.Add(this.panel3);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(290, 731);
            this.panelMenu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnQLTaiKhoan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 370);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 50);
            this.panel2.TabIndex = 12;
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnQLTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQLTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnQLTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.Size = new System.Drawing.Size(290, 50);
            this.btnQLTaiKhoan.TabIndex = 3;
            this.btnQLTaiKhoan.Text = "Quản lý tài khoản";
            this.btnQLTaiKhoan.UseVisualStyleBackColor = false;
            this.btnQLTaiKhoan.Click += new System.EventHandler(this.btnQLTaiKhoan_Click_1);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnThuongPhat);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 320);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(290, 50);
            this.panel10.TabIndex = 11;
            // 
            // btnThuongPhat
            // 
            this.btnThuongPhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnThuongPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThuongPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuongPhat.ForeColor = System.Drawing.Color.White;
            this.btnThuongPhat.Location = new System.Drawing.Point(0, 0);
            this.btnThuongPhat.Name = "btnThuongPhat";
            this.btnThuongPhat.Size = new System.Drawing.Size(290, 50);
            this.btnThuongPhat.TabIndex = 2;
            this.btnThuongPhat.Text = "Khen thưởng và kỉ luật";
            this.btnThuongPhat.UseVisualStyleBackColor = false;
            this.btnThuongPhat.Click += new System.EventHandler(this.btnThuongPhat_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDangXuat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 631);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 100);
            this.panel1.TabIndex = 8;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(100)))));
            this.btnDangXuat.Location = new System.Drawing.Point(73, 28);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(145, 45);
            this.btnDangXuat.TabIndex = 9;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnQLLuong);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 270);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(290, 50);
            this.panel7.TabIndex = 4;
            // 
            // btnQLLuong
            // 
            this.btnQLLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnQLLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQLLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLLuong.ForeColor = System.Drawing.Color.White;
            this.btnQLLuong.Location = new System.Drawing.Point(0, 0);
            this.btnQLLuong.Name = "btnQLLuong";
            this.btnQLLuong.Size = new System.Drawing.Size(290, 50);
            this.btnQLLuong.TabIndex = 1;
            this.btnQLLuong.Text = "Quản lý lương";
            this.btnQLLuong.UseVisualStyleBackColor = false;
            this.btnQLLuong.Click += new System.EventHandler(this.btnQLLuong_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnQLCong);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 220);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(290, 50);
            this.panel6.TabIndex = 3;
            // 
            // btnQLCong
            // 
            this.btnQLCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnQLCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQLCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLCong.ForeColor = System.Drawing.Color.White;
            this.btnQLCong.Location = new System.Drawing.Point(0, 0);
            this.btnQLCong.Name = "btnQLCong";
            this.btnQLCong.Size = new System.Drawing.Size(290, 50);
            this.btnQLCong.TabIndex = 1;
            this.btnQLCong.Text = "Quản lý công";
            this.btnQLCong.UseVisualStyleBackColor = false;
            this.btnQLCong.Click += new System.EventHandler(this.btnQLCong_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnQLNhanSu);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 170);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(290, 50);
            this.panel5.TabIndex = 2;
            // 
            // btnQLNhanSu
            // 
            this.btnQLNhanSu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.btnQLNhanSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQLNhanSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLNhanSu.ForeColor = System.Drawing.Color.White;
            this.btnQLNhanSu.Location = new System.Drawing.Point(0, 0);
            this.btnQLNhanSu.Name = "btnQLNhanSu";
            this.btnQLNhanSu.Size = new System.Drawing.Size(290, 50);
            this.btnQLNhanSu.TabIndex = 0;
            this.btnQLNhanSu.Text = "Quản lý nhân sự";
            this.btnQLNhanSu.UseVisualStyleBackColor = false;
            this.btnQLNhanSu.Click += new System.EventHandler(this.btnQLNhanSu_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 120);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(290, 50);
            this.panel4.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(40, 13, 40, 10);
            this.label2.Size = new System.Drawing.Size(290, 49);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chức năng quản lý";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 120);
            this.panel3.TabIndex = 0;
            this.panel3.Resize += new System.EventHandler(this.panel3_Resize);
            // 
            // panel8
            // 
            this.panel8.AllowDrop = true;
            this.panel8.BackgroundImage = global::QUANLYNHANSU.Properties.Resources.Ảnh_chụp_màn_hình_2025_10_27_143933;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Location = new System.Drawing.Point(100, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(82, 81);
            this.panel8.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(140)))));
            this.label1.Location = new System.Drawing.Point(112, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1417, 731);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelMenu);
            this.Name = "frmMain";
            this.Text = "Trang chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnQLLuong;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnQLCong;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnQLNhanSu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private Label label1;
        private Panel panel1;
        private Button btnDangXuat;
        private Panel panel8;
        private Panel panel10;
        private Panel panel2;
        private Button btnQLTaiKhoan;
        private Button btnThuongPhat;
    }
}
