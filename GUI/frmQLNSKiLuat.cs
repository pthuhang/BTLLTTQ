using QUANLYNHANSU.BLL;
using QUANLYNHANSU.DAL;
using QUANLYNHANSU.Models;
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
    public partial class frmQLNSKiLuat : Form
    {
        private KiLuatBLL kiluatBLL = new KiLuatBLL();
        private KiLuat_NhanVienBLL klNV_BLL = new KiLuat_NhanVienBLL();
        private string currentAction = "";

        public frmQLNSKiLuat()
        {
            InitializeComponent();
        }

        private void frmQLNSKiLuat_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            dgvKiLuat.ReadOnly = true;
            dgvKiLuat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKiLuat.AllowUserToAddRows = false;
            dgvKiLuat.CellClick += dgvKiLuat_CellClick;
            EnableForm(false);
            SetDefaultButtonState();
        }
        private void EnableForm (bool enable)
        {
            txtMaKiLuat.Enabled = enable;
            txtMaNV.Enabled = enable;
            txtNoiDung.Enabled = enable;
            txtTienKL.Enabled = enable;
            dtpNgayKL.Enabled = enable;
        }
        private void SetDefaultButtonState()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
        }
        private void HienThiDanhSach()
        {
            DataTable dt = klNV_BLL.LayDanhSach();
            dgvKiLuat.DataSource = dt;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();
            txtMaKiLuat.Focus();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKiLuat.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentAction = "Sua";
            EnableForm(true);
            txtMaKiLuat.Enabled = false; // Không cho sửa mã
            txtMaNV.Enabled = false;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKiLuat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maKL = dgvKiLuat.CurrentRow.Cells["MaKiLuat"].Value.ToString();
            string maNV = dgvKiLuat.CurrentRow.Cells["MaNV"].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa kỷ luật {maKL} của nhân viên {maNV} không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    klNV_BLL.Xoa(maKL, maNV);
                    kiluatBLL.Xoa(maKL);
                    HienThiDanhSach();
                    ClearForm();
                    MessageBox.Show("Xóa kỷ luật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvKiLuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKiLuat.Rows[e.RowIndex];
                txtMaKiLuat.Text = row.Cells["MaKiLuat"].Value.ToString();
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtNoiDung.Text = row.Cells["NoiDung"].Value.ToString();
                dtpNgayKL.Value = Convert.ToDateTime(row.Cells["NgayKiLuat"].Value);
                txtTienKL.Text = row.Cells["TienPhat"].Value.ToString();
            }
        }
        private void ClearForm()
        {
            txtMaKiLuat.Clear();
            txtMaNV.Clear();
            dtpNgayKL.Value = DateTime.Now;
            txtNoiDung.Clear();
            txtTienKL.Clear();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maKL = txtMaKiLuat.Text.Trim();
                string maNV = txtMaNV.Text.Trim();
                string noiDung = txtNoiDung.Text.Trim();
                DateTime ngayKL = dtpNgayKL.Value;
                decimal tienPhat;

                if (!decimal.TryParse(txtTienKL.Text.Trim(), out tienPhat))
                {
                    MessageBox.Show("Tiền phạt không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ===== Kiểm tra dữ liệu cơ bản =====
                if (string.IsNullOrEmpty(maKL))
                {
                    MessageBox.Show("Vui lòng nhập Mã Kỷ Luật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng nhập Mã Nhân Viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentAction == "Them")
                {
                    // Kiểm tra trùng mã
                    if (kiluatBLL.KiemTraTrungMa(maKL))
                    {
                        MessageBox.Show($" Mã kỷ luật '{maKL}' đã tồn tại!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (klNV_BLL.KiemTraTrung(maKL, maNV))
                    {
                        MessageBox.Show("Nhân viên này đã có kỷ luật với mã này rồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm mới
                    kiluatBLL.Them(maKL, noiDung, tienPhat);
                    klNV_BLL.Them(maKL, maNV, ngayKL, tienPhat);

                    MessageBox.Show("Thêm kỷ luật mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentAction == "Sua")
                {
                    kiluatBLL.CapNhat(maKL, noiDung, tienPhat);
                    klNV_BLL.CapNhat(maKL, maNV, ngayKL, tienPhat);

                    MessageBox.Show("Cập nhật kỷ luật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa trước khi Lưu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Làm mới
                HienThiDanhSach();
                ClearForm();
                EnableForm(false);
                currentAction = "";
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu kỷ luật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            try
            {
                string maNV = txtMaNVTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng nhập Mã nhân viên cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = klNV_BLL.LayDanhSach();

                // Lọc dữ liệu theo mã nhân viên
                var ketQua = dt.AsEnumerable()
                               .Where(row => row.Field<string>("MaNV").Equals(maNV, StringComparison.OrdinalIgnoreCase));

                if (ketQua.Any())
                {
                    dgvKiLuat.DataSource = ketQua.CopyToDataTable();
                }
                else
                {
                    dgvKiLuat.DataSource = null;
                    MessageBox.Show("Không tìm thấy nhân viên có mã: " + maNV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = 0, nam = 0;
                int.TryParse(txtThangLoc.Text.Trim(), out thang);
                int.TryParse(txtNamLoc.Text.Trim(), out nam);

                DataTable dt = klNV_BLL.LayDanhSach();
                var ketQua = dt.AsEnumerable();

                if (thang > 0)
                    ketQua = ketQua.Where(row => ((DateTime)row["NgayKiLuat"]).Month == thang);

                if (nam > 0)
                    ketQua = ketQua.Where(row => ((DateTime)row["NgayKiLuat"]).Year == nam);

                if (ketQua.Any())
                {
                    dgvKiLuat.DataSource = ketQua.CopyToDataTable();
                }
                else
                {
                    dgvKiLuat.DataSource = null;
                    MessageBox.Show("Không có kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
        }

        private void XemDSKL_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiDanhSach();
                txtMaNVTimKiem.Clear();
                ClearForm();
                EnableForm(false);
                SetDefaultButtonState();
                MessageBox.Show("Đã tải lại danh sách tất cả khen thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message);
            }
        }
    }
}
