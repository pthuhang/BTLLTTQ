using System.Drawing;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    partial class frmLogin
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
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.paBoxDangNhap = new System.Windows.Forms.Panel();
            this.chbHienMK = new System.Windows.Forms.CheckBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblTenDagNhap = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblDangNhapHeThong = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paBoxDangNhap.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 450);
            this.panel2.TabIndex = 1;
            // 
            // paBoxDangNhap
            // 
            this.paBoxDangNhap.BackColor = System.Drawing.Color.White;
            this.paBoxDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paBoxDangNhap.Controls.Add(this.chbHienMK);
            this.paBoxDangNhap.Controls.Add(this.txtMatKhau);
            this.paBoxDangNhap.Controls.Add(this.txtTenDangNhap);
            this.paBoxDangNhap.Controls.Add(this.lblTenDagNhap);
            this.paBoxDangNhap.Controls.Add(this.lblMatKhau);
            this.paBoxDangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBoxDangNhap.Location = new System.Drawing.Point(100, 140);
            this.paBoxDangNhap.Name = "paBoxDangNhap";
            this.paBoxDangNhap.Size = new System.Drawing.Size(600, 170);
            this.paBoxDangNhap.TabIndex = 7;
            // 
            // chbHienMK
            // 
            this.chbHienMK.AutoSize = true;
            this.chbHienMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHienMK.Location = new System.Drawing.Point(418, 115);
            this.chbHienMK.Name = "chbHienMK";
            this.chbHienMK.Size = new System.Drawing.Size(114, 20);
            this.chbHienMK.TabIndex = 17;
            this.chbHienMK.Text = "Hiện mật khẩu";
            this.chbHienMK.UseVisualStyleBackColor = true;
            this.chbHienMK.CheckedChanged += new System.EventHandler(this.chbHienMK_CheckedChanged);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMatKhau.Location = new System.Drawing.Point(211, 87);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(321, 22);
            this.txtMatKhau.TabIndex = 16;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTenDangNhap.Location = new System.Drawing.Point(211, 37);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(321, 22);
            this.txtTenDangNhap.TabIndex = 15;
            // 
            // lblTenDagNhap
            // 
            this.lblTenDagNhap.AutoSize = true;
            this.lblTenDagNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDagNhap.Location = new System.Drawing.Point(66, 37);
            this.lblTenDagNhap.Name = "lblTenDagNhap";
            this.lblTenDagNhap.Size = new System.Drawing.Size(124, 20);
            this.lblTenDagNhap.TabIndex = 14;
            this.lblTenDagNhap.Text = "Tên đăng nhập:";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.Location = new System.Drawing.Point(66, 87);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(82, 20);
            this.lblMatKhau.TabIndex = 13;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(0, 0);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 20);
            this.lblThongBao.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.btnDangNhap);
            this.panel4.Controls.Add(this.lblThongBao);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(100, 310);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(700, 140);
            this.panel4.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(245, 25);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(180, 40);
            this.btnDangNhap.TabIndex = 13;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.AliceBlue;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(700, 140);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(100, 170);
            this.panel6.TabIndex = 6;
            // 
            // lblDangNhapHeThong
            // 
            this.lblDangNhapHeThong.AutoSize = true;
            this.lblDangNhapHeThong.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDangNhapHeThong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblDangNhapHeThong.Location = new System.Drawing.Point(71, 60);
            this.lblDangNhapHeThong.Name = "lblDangNhapHeThong";
            this.lblDangNhapHeThong.Size = new System.Drawing.Size(462, 54);
            this.lblDangNhapHeThong.TabIndex = 0;
            this.lblDangNhapHeThong.Text = "Đăng nhập hệ thống";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.lblDangNhapHeThong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(100, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 140);
            this.panel1.TabIndex = 2;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.paBoxDangNhap);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmLogin";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.paBoxDangNhap.ResumeLayout(false);
            this.paBoxDangNhap.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel paBoxDangNhap;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblThongBao;
        private Button btnDangNhap;
        private Label lblDangNhapHeThong;
        private Panel panel1;
        private CheckBox chbHienMK;
        private TextBox txtMatKhau;
        private TextBox txtTenDangNhap;
        private Label lblTenDagNhap;
        private Label lblMatKhau;
    }
}