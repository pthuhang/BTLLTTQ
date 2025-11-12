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
                cbGioiTinh.Text = row["GioiTinh"].ToString();
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
        }
        private void EnableForm(bool enable)
        {
            // Khóa/Mở toàn bộ control nhập liệu
            txtMaNV.ReadOnly = !enable;
            txtHoTen.ReadOnly = !enable;
            cbGioiTinh.Enabled = enable;
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
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
