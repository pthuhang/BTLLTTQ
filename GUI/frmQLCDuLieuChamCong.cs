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
using Excel = Microsoft.Office.Interop.Excel;

namespace QUANLYNHANSU.GUI
{
    public partial class frmQLCDuLieuChamCong : Form
    {
        private LoaiCongBLL lcBll = new LoaiCongBLL();
        private LoaiCong_NhanVienBLL lcnvBll = new LoaiCong_NhanVienBLL();
        private NhanVienBLL nvBll = new NhanVienBLL();

        private string currentAction = "";
        public frmQLCDuLieuChamCong()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQLCDuLieuChamCong_Load(object sender, EventArgs e)
        {
            cmbTrangThai.Items.AddRange(new string[] { "Nửa ngày", "Cả ngày" });
            LoadDanhSach();
            EnableForm(false);
            dgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChamCong.ReadOnly = true;
        }
        private void LoadDanhSach()
        {
            dgvChamCong.DataSource = lcnvBll.LayDanhSach();
        }
        private void EnableForm(bool enable)
        {
            txtMaNV.Enabled = enable;
            txtMaLoaiCong.Enabled = enable;
            dtpNgayChamCong.Enabled = enable;
            dtpGioVao.Enabled = enable;
            dtpGioRa.Enabled = enable;
            txtHeSo.Enabled = enable;
            cmbTrangThai.Enabled = enable;
        }
        private void ClearForm()
        {
            txtMaNV.Clear();
            txtHoTenNV.Clear();
            txtMaLoaiCong.Clear();
            txtHeSo.Clear();
            cmbTrangThai.SelectedIndex = -1;
            dtpNgayChamCong.Value = DateTime.Now;
            dtpGioVao.Value = DateTime.Now;
            dtpGioRa.Value = DateTime.Now;
        }
        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvChamCong.Rows[e.RowIndex];

            txtMaLoaiCong.Text = row.Cells["MaLoaiCong"].Value.ToString();
            txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
            txtHoTenNV.Text = nvBll.LayNhanVienTheoMa(txtMaNV.Text)?.Rows[0]["HoTen"].ToString();
            dtpNgayChamCong.Value = Convert.ToDateTime(row.Cells["NgayLam"].Value);
            dtpGioVao.Value = DateTime.Today.Add((TimeSpan)row.Cells["GioVao"].Value);
            dtpGioRa.Value = DateTime.Today.Add((TimeSpan)row.Cells["GioRa"].Value);
            txtHeSo.Text = row.Cells["HeSoC"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();

            txtMaNV.Enabled = true;
            txtMaLoaiCong.Enabled = true;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" || txtMaLoaiCong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa.");
                return;
            }
            currentAction = "Sua";
            EnableForm(true);

            txtMaNV.Enabled = false;
            txtMaLoaiCong.Enabled = false;
            txtHeSo.Enabled = false;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" || txtMaLoaiCong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            lcnvBll.Xoa(txtMaLoaiCong.Text.Trim(), txtMaNV.Text.Trim());
            LoadDanhSach();
            ClearForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string maLoai = txtMaLoaiCong.Text.Trim();

            if (maNV == "" || maLoai == "")
            {
                MessageBox.Show("Mã NV và mã loại công không được để trống.");
                return;
            }

            DateTime ngay = dtpNgayChamCong.Value;
            TimeSpan gioVao = dtpGioVao.Value.TimeOfDay;
            TimeSpan gioRa = dtpGioRa.Value.TimeOfDay;

            if (!decimal.TryParse(txtHeSo.Text.Trim(), out decimal heSo))
            {
                MessageBox.Show("Hệ số không hợp lệ.");
                return;
            }

            if (currentAction == "Them")
            {
                if (!lcBll.KiemTraTonTai(maLoai))
                {
                    MessageBox.Show("Mã loại công không tồn tại.");
                    return;
                }

                if (lcnvBll.KiemTraTonTai(maLoai, maNV))
                {
                    MessageBox.Show("Dữ liệu chấm công này đã tồn tại.");
                    return;
                }

                lcnvBll.Them(maLoai, maNV, ngay, gioVao, gioRa);

                MessageBox.Show("Thêm thành công.");
            }
            else if (currentAction == "Sua")
            {
                lcnvBll.Sua(maLoai, maNV, ngay, gioVao, gioRa);
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa trước.");
                return;
            }

            LoadDanhSach();
            ClearForm();
            EnableForm(false);

            currentAction = "";
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvChamCong.DataSource;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;

                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                worksheet.Name = "ChamCong";

                // Ghi tiêu đề cột
                for (int i = 1; i <= dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dt.Columns[i - 1].ColumnName;
                }

                // Ghi dữ liệu
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j]?.ToString();
                    }
                }

                // Định dạng
                Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dt.Columns.Count]];
                headerRange.Font.Bold = true;
                worksheet.Columns.AutoFit();

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "DuLieuChamCong.xlsx"
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
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNVLoc.Text.Trim();
            string ngay = txtNgay.Text.Trim();
            string thang = txtThang.Text.Trim();
            string nam = txtNam.Text.Trim();

            // Kiểm tra nếu người dùng không nhập gì
            if (string.IsNullOrEmpty(maNV) && string.IsNullOrEmpty(ngay) &&
                string.IsNullOrEmpty(thang) && string.IsNullOrEmpty(nam))
            {
                MessageBox.Show("Vui lòng nhập Mã nhân viên hoặc Ngày/Tháng/Năm để lọc!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Gọi hàm lọc từ BLL
                DataTable dt = lcnvBll.LocLoaiCongNV(maNV, ngay, thang, nam);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvChamCong.DataSource = null;
                    return;
                }

                dgvChamCong.DataSource = dt;
                MessageBox.Show($"Đã tìm thấy {dt.Rows.Count} dòng dữ liệu phù hợp.",
                                "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
