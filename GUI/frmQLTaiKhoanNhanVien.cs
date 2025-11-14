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
            cbVaiTro.Items.AddRange(new string[] { "Admin", "Nhân viên" });
            HienThiDanhSach();
            EnableForm(false);
            SetDefaultButtonState();

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
        private void SetDefaultButtonState()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnThoat.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNgDung.Focus();
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
            SetDefaultButtonState();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maND = txtMaNgDung.Text.Trim();
                string maNV = txtMaNV.Text.Trim();
                string tenDN = txtTenDangNhap.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string vaiTro = cbVaiTro.Text;

                if (string.IsNullOrWhiteSpace(maND) || string.IsNullOrWhiteSpace(tenDN))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                if (currentAction == "Them")
                {
                    DataTable dt = tkBLL.LayDanhSach();
                    bool daTonTai = dt.AsEnumerable().Any(r => r.Field<string>("MaNguoiDung") == maND);
                    if (daTonTai)
                    {
                        MessageBox.Show("Mã người dùng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    bool nhanVienDaCoTK = dt.AsEnumerable()
               .Any(r => r.Field<string>("MaNV") == maNV);
                    if (nhanVienDaCoTK)
                    {
                        MessageBox.Show("Nhân viên này đã có tài khoản! Không thể tạo thêm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tkBLL.Them(maND, maNV, tenDN, matKhau, vaiTro);
                    MessageBox.Show("Thêm tài khoản mới thành công!");
                }
                else if (currentAction == "Sua")
                {
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
            SetDefaultButtonState();
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

    }
}
