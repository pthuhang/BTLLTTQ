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
using Excel = Microsoft.Office.Interop.Excel;

namespace QUANLYNHANSU.GUI
{
    public partial class frmQLNSNhanVien : Form
    {
        private NhanVienBLL bll = new NhanVienBLL();
        private PhongBanBLL bllPB = new PhongBanBLL();
        private TrinhDoBLL bllTD = new TrinhDoBLL();

        private string currentAction = "";
        private bool isLoading;

        public frmQLNSNhanVien()
        {
            InitializeComponent();
        }
        private void frmQLNSNhanVien_Load(object sender, EventArgs e)
        {
            isLoading = true;

            cbGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cbTrangThai.Items.AddRange(new string[] { "Đang làm việc", "Đã thôi việc" });

            cbPhongBan.DataSource = bllPB.LayDanhSach();
            cbPhongBan.DisplayMember = "TenPhongBan";
            cbPhongBan.ValueMember = "MaPhongBan";

            cbTrinhDo.DataSource = bllTD.LayDanhSach();
            cbTrinhDo.DisplayMember = "TenTrinhDo";
            cbTrinhDo.ValueMember = "MaTrinhDo";

            HienThiDanhSach();

            EnableForm(false);
            SetDefaultButtonState();
            LoadComboBoxLoc();

            isLoading = false;
        }
        private void LoadComboBoxLoc()
        {
            DataTable dtTrinhDo = bllTD.LayDanhSach();
            cbLocTrinhDo.DataSource = dtTrinhDo;
            cbLocTrinhDo.DisplayMember = "TenTrinhDo";
            cbLocTrinhDo.ValueMember = "MaTrinhDo";
            cbLocTrinhDo.SelectedIndex = -1;

            DataTable dtChucVu = bll.LayDanhSachChucVu();
            cbLocChucVu.DataSource = dtChucVu;
            cbLocChucVu.DisplayMember = "ChucVu";
            cbLocChucVu.ValueMember = "ChucVu";
            cbLocChucVu.SelectedIndex = -1;

            DataTable dtPhongBan = bllPB.LayDanhSach();
            cbLocPhongBan.DataSource = dtPhongBan;
            cbLocPhongBan.DisplayMember = "TenPhongBan";
            cbLocPhongBan.ValueMember = "MaPhongBan";
            cbLocPhongBan.SelectedIndex = -1;
        }

        private void EnableForm(bool enable)
        {
            // Khóa/Mở toàn bộ control nhập liệu
            txtMaNV.Enabled = enable;
            txtHoTen.Enabled = enable;
            cbGioiTinh.Enabled = enable;
            dtpNgaySinh.Enabled = enable;
            txtSDT.Enabled = enable;
            txtCCCD.Enabled = enable;
            txtDiaChi.Enabled = enable;
            txtEmail.Enabled = enable;
            cbTrangThai.Enabled = enable;
            cbPhongBan.Enabled = enable;
            cbTrinhDo.Enabled = enable;
            txtChucVu.Enabled = enable;
            txtSoBH.Enabled = enable;
            txtMucDongBH.Enabled = enable;
            txtSTK.Enabled = enable;
        }
        private void ClearForm()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            cbGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Clear();
            txtCCCD.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            cbTrangThai.SelectedIndex = -1;
            cbPhongBan.SelectedIndex = -1;
            cbTrinhDo.SelectedIndex = -1;
            txtChucVu.Clear();
            txtSoBH.Clear();
            txtMucDongBH.Clear();
            txtSTK.Clear();
        }
        private void SetDefaultButtonState()
        {
            // Trạng thái ban đầu: chỉ bật 4 nút chính
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
        }
        private void HienThiDanhSach()
        {
            dgvNhanVien.DataSource = bll.LayDanhSach();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //thêm, sửa, xóa

        private void btnThemMoi_Click(object sender, EventArgs e)
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
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 nhân viên để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentAction = "Sua";
            EnableForm(true);
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNV.Enabled = false; // Không cho sửa mã nhân viên
            MessageBox.Show("Bạn có thể chỉnh sửa thông tin nhân viên. Nhấn 'Lưu' sau khi hoàn tất.", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text;
                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để xóa!");
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {maNV} không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bll.Xoa(maNV);
                    HienThiDanhSach();
                    ClearForm();
                    btnLuu.Enabled = false;
                    MessageBox.Show("Đã xóa thành công!");
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
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                object value = row.Cells["GioiTinh"].Value;
                if (value != null && value != DBNull.Value)
                {
                    cbGioiTinh.Text = Convert.ToBoolean(value) ? "Nam" : "Nữ";
                }
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                cbPhongBan.SelectedValue = row.Cells["MaPhongBan"].Value.ToString();
                cbTrinhDo.SelectedValue = row.Cells["MaTrinhDo"].Value.ToString();
                txtChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                txtSoBH.Text = row.Cells["SoBaoHiemXaHoi"].Value.ToString();
                txtMucDongBH.Text = row.Cells["MucDong"].Value.ToString();
                txtSTK.Text = row.Cells["SoTaiKhoan"].Value.ToString();

                btnSua.Enabled = true;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // ======= Lấy dữ liệu từ form =======
                string maNV = txtMaNV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                bool gioiTinh = cbGioiTinh.Text == "Nam";
                DateTime ngaySinh = dtpNgaySinh.Value;
                string sdt = txtSDT.Text.Trim();
                string cccd = txtCCCD.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string email = txtEmail.Text.Trim();
                string trangThai = cbTrangThai.Text;
                string maPhongBan = cbPhongBan.SelectedValue?.ToString();
                string maTrinhDo = cbTrinhDo.SelectedValue?.ToString();
                string chucVu = txtChucVu.Text.Trim();
                decimal luongCB = 0, mucDong = 0;
                decimal.TryParse(txtMucDongBH.Text, out mucDong);
                string soBH = txtSoBH.Text.Trim();
                string stk = txtSTK.Text.Trim();

                // ======= Kiểm tra dữ liệu cơ bản =======
                if (string.IsNullOrWhiteSpace(maNV))
                {
                    MessageBox.Show("Vui lòng nhập Mã nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(hoTen))
                {
                    MessageBox.Show("Vui lòng nhập Họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool result = false;

                // ======= Thực hiện thao tác Thêm hoặc Sửa =======
                if (currentAction == "Them")
                {
                    DataTable dt = bll.LayDanhSach();
                    bool daTonTai = dt.AsEnumerable().Any(row => row.Field<string>("MaNV") == maNV);
                    if (daTonTai)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    bll.Them(maNV, hoTen, gioiTinh, ngaySinh, sdt, cccd, diaChi, email,
                    trangThai, maPhongBan, maTrinhDo, chucVu, 

                    soBH, mucDong, stk);
                    MessageBox.Show("Thêm nhân viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
                }
                else if (currentAction == "Sua")
                {
                    bll.CapNhat(maNV, hoTen, gioiTinh, ngaySinh, sdt, cccd, diaChi, email,
                           trangThai, maPhongBan, maTrinhDo, chucVu,
                           soBH, mucDong, stk);

                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                    HienThiDanhSach();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn Thêm hoặc Sửa trước khi Lưu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearForm();
            EnableForm(false);
            SetDefaultButtonState();

            currentAction = "";
            btnLuu.Enabled = false;
        }
        //
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNVTimKiem = txtMaNVTimKiem.Text.Trim();
                string tenNVTimKiem = txtHoTenTimKiem.Text.Trim();
                if (string.IsNullOrWhiteSpace(maNVTimKiem)) maNVTimKiem = null;
                if (string.IsNullOrWhiteSpace(tenNVTimKiem)) tenNVTimKiem = null;
                DataTable dt = bll.TimKiem(maNVTimKiem, tenNVTimKiem);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Tìm thấy " + dt.Rows.Count + " kết quả!");
                    dgvNhanVien.Columns.Clear();
                    dgvNhanVien.AutoGenerateColumns = true;
                    dgvNhanVien.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên phù hợp!");
                    dgvNhanVien.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
        //
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvNhanVien.DataSource;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                worksheet.Name = "Danh sách nhân viên";
                for (int i = 1; i <= dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j]?.ToString();
                    }
                }
                worksheet.Rows[1].Font.Bold = true;
                worksheet.Columns.AutoFit();
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "DanhSachNhanVien.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();
                    MessageBox.Show("Xuất Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiDanhSach();
                txtMaNVTimKiem.Clear();
                txtHoTenTimKiem.Clear();
                ClearForm();
                EnableForm(false);
                SetDefaultButtonState();

                isLoading = true;
                cbLocTrinhDo.SelectedIndex = -1;
                cbLocChucVu.SelectedIndex = -1;
                cbLocPhongBan.SelectedIndex = -1;
                cbLocTrangThai.SelectedIndex  = -1;
                cbLocGioiTinh.SelectedIndex = -1;
                isLoading = false;

                MessageBox.Show("Đã tải lại danh sách tất cả nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message);
            }
        }
        //Lọc
        private void cmbLocTrinhDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            cbLocChucVu.SelectedIndex = -1;
            cbLocPhongBan.SelectedIndex = -1;
            cbLocTrangThai.SelectedIndex = -1;
            cbLocGioiTinh.SelectedIndex = -1;
            try
            {
                if (cbLocTrinhDo.SelectedIndex == -1)
                    return;

                string tenTrinhDo = cbLocTrinhDo.Text;

                if (string.IsNullOrEmpty(tenTrinhDo)) return;

                DataTable dt = bll.LocTheoTrinhDo(tenTrinhDo);
                dgvNhanVien.DataSource = dt;
                MessageBox.Show($"Tìm thấy {dt.Rows.Count} nhân viên có trình độ này!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc theo trình độ: " + ex.Message);
            }
        }
        private void cbLocGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            cbLocTrinhDo.SelectedIndex = -1;
            cbLocChucVu.SelectedIndex = -1;
            cbLocPhongBan.SelectedIndex = -1;
            cbLocTrangThai.SelectedIndex = -1;
            try
            {
                if (cbLocGioiTinh.SelectedIndex == -1)
                    return;

                string gioiTinh = cbLocGioiTinh.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(gioiTinh)) return;

                DataTable dt = bll.LocTheoGioiTinh(gioiTinh);
                dgvNhanVien.DataSource = dt;

                MessageBox.Show($"Tìm thấy {dt.Rows.Count} nhân viên giới tính {gioiTinh}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc theo giới tính: " + ex.Message);
            }
        }

        private void cbLocChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            cbLocTrinhDo.SelectedIndex = -1;
            cbLocPhongBan.SelectedIndex = -1;
            cbLocTrangThai.SelectedIndex = -1;
            cbLocGioiTinh.SelectedIndex = -1;
            try
            {
                if (cbLocChucVu.SelectedIndex == -1)
                    return;

                string chucVu = cbLocChucVu.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(chucVu)) return;

                DataTable dt = bll.LocTheoChucVu(chucVu);
                dgvNhanVien.DataSource = dt;

                MessageBox.Show($"Tìm thấy {dt.Rows.Count} nhân viên có chức vụ {chucVu}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc theo chức vụ: " + ex.Message);
            }
        }

        private void cbLocPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            cbLocTrinhDo.SelectedIndex = -1;
            cbLocChucVu.SelectedIndex = -1;
            cbLocTrangThai.SelectedIndex = -1;
            cbLocGioiTinh.SelectedIndex = -1;
            try
            {
                if (cbLocPhongBan.SelectedIndex == -1)
                    return;

                string maPhongBan = cbLocPhongBan.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(maPhongBan))
                    return;

                DataTable dt = bll.LayNhanVienTheoPhongBan(maPhongBan);

                dgvNhanVien.DataSource = dt;

                MessageBox.Show($"Tìm thấy {dt.Rows.Count} nhân viên thuộc phòng ban này!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc theo phòng ban: " + ex.Message);
            }
        }

        private void cbLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            cbLocTrinhDo.SelectedIndex = -1;
            cbLocChucVu.SelectedIndex = -1;
            cbLocPhongBan.SelectedIndex = -1;
            cbLocGioiTinh.SelectedIndex = -1;
            try
            {
                if (cbLocTrangThai.SelectedIndex == -1)
                    return;

                string trangThai = cbLocTrangThai.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(trangThai)) return;

                DataTable dt = bll.LocTheoTrangThai(trangThai);
                dgvNhanVien.DataSource = dt;

                MessageBox.Show($"Tìm thấy {dt.Rows.Count} nhân viên có trạng thái {trangThai}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc theo trạng thái: " + ex.Message);
            }
        }
    }
}
