using QUANLYNHANSU.BLL;
using QUANLYNHANSU.DAL;
using QUANLYNHANSU.Models;
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
    public partial class frmQLNSKhenThuong : Form
    {
        private KhenThuongBLL ktBLL = new KhenThuongBLL();
        private Khen_NhanVienBLL ktnvBLL = new Khen_NhanVienBLL();
        private string currentAction = "";

        public frmQLNSKhenThuong()
        {
            InitializeComponent();
        }

        private void frmQLNSKhenThuong_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            dgvKhenThuong.ReadOnly = true;
            dgvKhenThuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhenThuong.AllowUserToAddRows = false;
            dgvKhenThuong.CellClick += dgvKhenThuong_CellClick;
            EnableForm(false);
            SetDefaultButtonState();
        }
        private void EnableForm(bool enable)
        {
            txtMaKT.Enabled = enable;
            txtMaNV.Enabled = enable;
            txtNoiDung.Enabled = enable;
            dtpNgayKhen.Enabled = enable;
            txtTienKhen.Enabled = enable;
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
            DataTable dt = ktnvBLL.LayDanhSach();
            dgvKhenThuong.DataSource = dt;
        }

        private void dgvKhenThuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhenThuong.Rows[e.RowIndex];
                txtMaKT.Text = row.Cells["MaKhenThuong"].Value.ToString();
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtNoiDung.Text = row.Cells["NoiDung"].Value.ToString();
                dtpNgayKhen.Value = Convert.ToDateTime(row.Cells["NgayKhenThuong"].Value);
                txtTienKhen.Text = row.Cells["TienKhenThuong"].Value.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();
            txtMaKT.Focus();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKT.Text))
            {
                MessageBox.Show("Vui lòng chọn khen thưởng cần sửa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentAction = "Sua";
            EnableForm(true);

            txtMaKT.Enabled = true;
            txtMaNV.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhenThuong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa!", "Thông báo");
                return;
            }

            string maKT = dgvKhenThuong.CurrentRow.Cells["MaKhenThuong"].Value.ToString();
            string maNV = dgvKhenThuong.CurrentRow.Cells["MaNV"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa khen thưởng {maKT} của nhân viên {maNV} không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    ktnvBLL.Xoa(maKT, maNV);
                    ktBLL.Xoa(maKT);

                    HienThiDanhSach();
                    ClearForm();
                    MessageBox.Show("Xóa khen thưởng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }
        private void ClearForm()
        {
            txtMaKT.Clear();
            txtMaNV.Clear();
            dtpNgayKhen.Value = DateTime.Now;
            txtNoiDung.Clear();
            txtTienKhen.Clear();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maKT = txtMaKT.Text.Trim();
                string maNV = txtMaNV.Text.Trim();
                string noiDung = txtNoiDung.Text.Trim();
                DateTime ngayKT = dtpNgayKhen.Value;

                decimal tienKT;
                if (!decimal.TryParse(txtTienKhen.Text.Trim(), out tienKT))
                {
                    MessageBox.Show("Tiền khen thưởng không hợp lệ!", "Lỗi");
                    return;
                }

                if (string.IsNullOrEmpty(maKT) || string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Mã khen thưởng và Mã nhân viên không được để trống!", "Cảnh báo");
                    return;
                }

                if (currentAction == "Them")
                {
                    if (ktBLL.KiemTraTrungMa(maKT))
                    {
                        MessageBox.Show("Mã khen thưởng đã tồn tại!");
                        return;
                    }

                    if (ktnvBLL.KiemTraTrung(maKT, maNV))
                    {
                        MessageBox.Show("Nhân viên đã có khen thưởng này!");
                        return;
                    }

                    ktBLL.Them(maKT, noiDung, tienKT);
                    ktnvBLL.Them(maKT, maNV, ngayKT, tienKT);

                    MessageBox.Show("Thêm khen thưởng mới thành công!");
                }
                else if (currentAction == "Sua")
                {
                    ktBLL.CapNhat(maKT, noiDung, tienKT);
                    ktnvBLL.CapNhat(maKT, maNV, ngayKT, tienKT);

                    MessageBox.Show("Cập nhật khen thưởng thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa trước khi Lưu!");
                    return;
                }

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
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
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

                DataTable dt = ktnvBLL.LayDanhSach();

                // Lọc dữ liệu theo mã nhân viên
                var ketQua = dt.AsEnumerable()
                               .Where(row => row.Field<string>("MaNV").Equals(maNV, StringComparison.OrdinalIgnoreCase));

                if (ketQua.Any())
                {
                    dgvKhenThuong.DataSource = ketQua.CopyToDataTable();
                }
                else
                {
                    dgvKhenThuong.DataSource = null;
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

                DataTable dt = ktnvBLL.LayDanhSach();
                var ketQua = dt.AsEnumerable();

                if (thang > 0)
                    ketQua = ketQua.Where(row => ((DateTime)row["NgayKhenThuong"]).Month == thang);

                if (nam > 0)
                    ketQua = ketQua.Where(row => ((DateTime)row["NgayKhenThuong"]).Year == nam);

                if (ketQua.Any())
                {
                    dgvKhenThuong.DataSource = ketQua.CopyToDataTable();
                }
                else
                {
                    dgvKhenThuong.DataSource = null;
                    MessageBox.Show("Không có kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
        }

        private void btnXemDSKT_Click(object sender, EventArgs e)
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
