using QUANLYNHANSU.BLL;
using QUANLYNHANSU.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    public partial class frmQLTaiKhoanNhanVien : Form
    {
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        private string currentAction = "";
        public frmQLTaiKhoanNhanVien()
        {
            InitializeComponent();
        }
        private void frmQLTaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNgDung.ReadOnly = true;
            cbVaiTro.Items.AddRange(new string[] { "Quản trị viên", "Người dùng" });
            HienThiDanhSach();
            EnableForm(false);
            batBtn();

        }
        private void HienThiDanhSach()
        {
            dgvTaiKhoanNhanVien.DataSource = tkBLL.LayDanhSach(); 
            if (dgvTaiKhoanNhanVien.Columns["MatKhau"] != null)
                dgvTaiKhoanNhanVien.Columns["MatKhau"].Visible = false;

        }

        private void EnableForm(bool enable)
        {
            txtMaNgDung.Enabled = enable;
            txtMaNV.Enabled = enable;
            txtTenDangNhap.Enabled = enable;
            txtMatKhau.Enabled = enable;
            cbVaiTro.Enabled = enable;
        }

        private void ClearForm()
        {
            txtMaNgDung.Clear();
            txtMaNV.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cbVaiTro.SelectedIndex = -1;
        }
        private void batBtn()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnThoat.Enabled = true;
        }

        //--=--Thêm, sửa, xóa
        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNgDung.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentAction = "Sua";
            EnableForm(true);
            txtMaNgDung.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;

            MessageBox.Show("Bạn có thể chỉnh sửa thông tin tài khoản. Nhấn 'Lưu' để cập nhật.", "Hướng dẫn");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maND = txtMaNgDung.Text.Trim();
                if (string.IsNullOrEmpty(maND))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản {maND} không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tkBLL.Xoa(maND);
                    MessageBox.Show("Đã xóa thành công!");
                    HienThiDanhSach();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }

            currentAction = "";
            EnableForm(false);
            batBtn();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateTaiKhoan()) return;
            try
            {
                string maNV = txtMaNV.Text.Trim();
                string tenDN = txtTenDangNhap.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string vaiTro = cbVaiTro.Text;
                MessageBox.Show("MaNV = '" + maNV + "'");


                string maND = tkBLL.TaoMaTK(maNV);

                if (!tkBLL.KiemTraNhanVien(maNV))
                {
                    MessageBox.Show("Nhân viên này không tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentAction == "Them")
                {
                    if (tkBLL.KiemTraTonTai(maNV))
                    {
                        MessageBox.Show("Nhân viên này đã có tài khoản! Không thể tạo thêm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (tkBLL.KiemTraTenDangNhap(tenDN, maND))
                    {
                        MessageBox.Show("Tên đăng nhập này đã được sử dụng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tkBLL.Them(maND, maNV, tenDN, matKhau, vaiTro);
                    MessageBox.Show("Thêm tài khoản mới thành công!");
                }
                else if (currentAction == "Sua")
                {
                    if (tkBLL.KiemTraTenDangNhap(tenDN, maND))
                    {
                        MessageBox.Show("Tên đăng nhập đã được sử dụng bởi tài khoản khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    tkBLL.CapNhat(maND, maNV, tenDN, matKhau, vaiTro);
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa trước khi lưu!");
                    return;
                }

                HienThiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu tài khoản: " + ex.Message);
            }


            ClearForm();
            EnableForm(false);
            batBtn();
            currentAction = "";
        }
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoanNhanVien.Rows[e.RowIndex];
                txtMaNgDung.Text = row.Cells["MaNguoiDung"].Value.ToString();
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                cbVaiTro.Text = row.Cells["VaiTro"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateTaiKhoan()
        {
            ePLoiValidate.Clear();
            bool ok = true;

            // TenDangNhap
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                ePLoiValidate.SetError(txtTenDangNhap, "Tên đăng nhập không được để trống!");
                ok = false;
            }
            else if (txtTenDangNhap.Text.Length > 30)
            {
                ePLoiValidate.SetError(txtTenDangNhap, "Tên đăng nhập không vượt quá 30 ký tự!");
                ok = false;
            }

            // MatKhau
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                ePLoiValidate.SetError(txtMatKhau, "Mật khẩu không được để trống!");
                ok = false;
            }
            else if (txtMatKhau.Text.Length > 50)
            {
                ePLoiValidate.SetError(txtMatKhau, "Mật khẩu không vượt quá 50 ký tự!");
                ok = false;
            }

            //MaNV
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                ePLoiValidate.SetError(txtMaNV, "Mã nhân viên không được để trống!");
                ok = false;
            }
            else if (txtMaNV.Text.Length > 10)
            {
                ePLoiValidate.SetError(txtMaNV, "Mã nhân viên không vượt quá 10 ký tự!");
                ok = false;
            }

            // VaiTro 
            // VaiTro (bắt buộc chọn)
            if (string.IsNullOrWhiteSpace(cbVaiTro.Text))
            {
                ePLoiValidate.SetError(cbVaiTro, "Vui lòng chọn vai trò!");
                ok = false;
            }


            return ok;
        }

        private void dgvTaiKhoanNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvTaiKhoanNhanVien.Rows.Count)
                return;

            DataGridViewRow row = dgvTaiKhoanNhanVien.Rows[e.RowIndex];

            txtMaNgDung.Text = row.Cells["MaNguoiDung"].Value?.ToString() ?? "";
            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
            txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString() ?? "";
            txtMaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? "";

            string vaiTro = row.Cells["VaiTro"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(vaiTro))
            {
                cbVaiTro.SelectedItem = cbVaiTro.Items.Cast<string>().FirstOrDefault(x => x == vaiTro);
            }
            else
            {
                cbVaiTro.SelectedIndex = -1;
            }
        }

    }
}

