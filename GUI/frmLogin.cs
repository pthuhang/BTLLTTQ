using QUANLYNHANSU.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    public partial class frmLogin : Form
    {
        TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        
        public frmLogin()
        {
            InitializeComponent();
            // Đặt form ra giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
            // Đặt kích thước cố định
            this.Size = new System.Drawing.Size(650, 420);
            // Không cho resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Ẩn nút phóng to
            this.MaximizeBox = false;
        }
        //
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(user))
            {
                lblThongBao.Text = "Vui lòng nhập tên đăng nhập!";
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Visible = true;
                lblThongBao.Left = (paBoxDangNhap.Width - lblThongBao.Width) / 2;
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                lblThongBao.Text = "Vui lòng nhập  mật khẩu!";
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Visible = true;
                lblThongBao.Left = (paBoxDangNhap.Width - lblThongBao.Width) / 2;
                txtMatKhau.Focus();
                return;
            }

            DataRow userRow = taiKhoanBLL.DangNhap(user, pass);
            if (userRow != null)
            {
                string vaiTro = userRow["VaiTro"].ToString();
                string maNV = userRow["MaNV"].ToString();
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                if (vaiTro.Equals("Quản trị viên", StringComparison.OrdinalIgnoreCase))
                    new frmMain(user).Show();
                else
                    new frmMainNhanVien(maNV,user).Show();
            }
            else
            {
                lblThongBao.Visible = true;
                lblThongBao.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                lblThongBao.Left = (paBoxDangNhap.Width - lblThongBao.Width) / 2;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void chbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chbHienMK.Checked;
        }
    }
}
