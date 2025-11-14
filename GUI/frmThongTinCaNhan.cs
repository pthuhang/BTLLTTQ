using QUANLYNHANSU.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    public partial class frmThongTinCaNhan : Form
    {
        private NhanVienBLL bll = new NhanVienBLL();
        private TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        private string tenDangNhap;
        public frmThongTinCaNhan(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            label1.Left = (panel5.ClientSize.Width - label1.Width) / 2;
            label1.Top = (panel5.ClientSize.Height - label1.Height) / 2;

            label22.Left = (panel8.ClientSize.Width - label22.Width) / 2;
            label22.Top = (panel8.ClientSize.Height - label22.Height) / 2;

            label23.Left = (panel29.ClientSize.Width - label23.Width) / 2;
            label23.Top = (panel29.ClientSize.Height - label23.Height) / 2;
            txtMatKhau.UseSystemPasswordChar = true;
            btnShowHide.FlatStyle = FlatStyle.Flat;
            btnShowHide.FlatAppearance.BorderSize = 0;
            btnShowHide.BackColor = Color.White;
            btnShowHide.TabStop = false; // không hiện viền khi focus
            btnShowHide.Cursor = Cursors.Hand;

            HienThiThongTinCaNhan();


            EnableForm(false);
        }
        private void HienThiThongTinCaNhan()
        {
            DataTable dt = bll.LayNhanVienTheoTenDangNhap(tenDangNhap);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtMaNV.Text = row["MaNV"].ToString();
                txtHoTen.Text = row["HoTen"].ToString();
                bool gioiTinh = Convert.ToBoolean(row["GioiTinh"]);
                txtGioiTinh.Text = gioiTinh ? "Nam" : "Nữ";
                if (DateTime.TryParse(row["NgaySinh"].ToString(), out DateTime ns))
                    dtpNgaySinh.Value = ns;
                txtDiaChi.Text = row["DiaChi"].ToString();
                txtSDT.Text = row["SDT"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtChucVu.Text = row["ChucVu"].ToString();
                txtTrinhDo.Text = row["TenTrinhDo"].ToString();
                txtPhongBan.Text = row["TenPhongBan"].ToString();
                txtCCCD.Text = row["CCCD"].ToString();
                txtSoBH.Text = row["SoBaoHiemXaHoi"].ToString();
                txtMucDongBH.Text = row["MucDong"].ToString();
                txtSTK.Text = row["SoTaiKhoan"].ToString();
                txtTrangThai.Text = row["TrangThai"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DataTable dtb = tkBLL.LayTaiKhoanTheoTenDangNhap(tenDangNhap);
            if (dtb.Rows.Count > 0)
            {
                DataRow row = dtb.Rows[0];
                txtMaNgDung.Text = row["MaNguoiDung"].ToString();
                txtTenDangNhap.Text = row["TenDangNhap"].ToString();
                txtMatKhau.Text = row["MatKhau"].ToString();
                txtVaiTro.Text = row["VaiTro"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản của nhân viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
                private void EnableForm(bool enable)
                {
                    // Khóa/Mở toàn bộ control nhập liệu
                    txtMaNV.ReadOnly = !enable;
                    txtHoTen.ReadOnly = !enable;
                    txtGioiTinh.ReadOnly = !enable;
                    dtpNgaySinh.Enabled = enable;
                    txtSDT.ReadOnly = !enable;
                    txtCCCD.ReadOnly = !enable;
                    txtDiaChi.ReadOnly = !enable;
                    txtEmail.ReadOnly = !enable;
                    txtTrangThai.ReadOnly = !enable;
                    txtPhongBan.ReadOnly = !enable;
                    txtTrinhDo.ReadOnly = !enable;
                    txtChucVu.ReadOnly = !enable;
                    txtSoBH.ReadOnly = !enable;
                    txtMucDongBH.ReadOnly = !enable;
                    txtSTK.ReadOnly = !enable;
                    txtTrangThai.ReadOnly = !enable;
                    txtMaNgDung.ReadOnly = !enable;
                    txtTenDangNhap.ReadOnly = !enable;
                    txtMatKhau.ReadOnly = !enable;
                    txtVaiTro.ReadOnly = !enable;
                }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            txtVaiTro.ReadOnly = true;  
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string vaiTro = txtVaiTro.Text.Trim();

                if (string.IsNullOrWhiteSpace(tenDangNhap))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool result = tkBLL.CapNhatTaiKhoan(tenDangNhap, matKhau, vaiTro);
                if (result)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhau.ReadOnly = true;
                    btnLuu.Enabled = false;
                }
                else
                {

                }
                {
                    MessageBox.Show("Không thể cập nhật tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool isPasswordVisible = false;
        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Đang hiện → ẩn lại
                txtMatKhau.UseSystemPasswordChar = true;
                btnShowHide.Text = "👁"; // biểu tượng mắt mở
                isPasswordVisible = false;
            }
            else
            {
                // Đang ẩn → hiện lên
                txtMatKhau.UseSystemPasswordChar = false;
                btnShowHide.Text = "🙈"; // biểu tượng mắt nhắm
                isPasswordVisible = true;
            }
        }

    }
}
