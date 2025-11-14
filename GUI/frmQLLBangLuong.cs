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
    public partial class frmQLLBangLuong : Form
    {
        private BangLuongBLL bll = new BangLuongBLL();
        public frmQLLBangLuong()
        {
            InitializeComponent();
        }
        private void frmQLLBangLuong_Load(object sender, EventArgs e)
        {
            cbThang.Enabled = false;
            cbNam.Enabled = false;
            dgvBangLuong.DataSource = bll.LayDanhSachBangLuong();
            btnTao.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            if (maNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                return;
            }
            MessageBox.Show("Đã hiển thị các bảng lương của nhân viên!");
            dgvBangLuong.DataSource = bll.LayBangLuongNhanVien(maNV);
        }

        private void bnTaoBL_Click(object sender, EventArgs e)
        {
            cbThang.Enabled = true;
            cbNam.Enabled = true;

            btnTao.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            int thang = int.Parse(cbThang.Text);
            int nam = int.Parse(cbNam.Text);

            bool taoMoi = bll.TaoBangLuong(maNV, thang, nam);
            if (taoMoi)
                MessageBox.Show("Đã tạo bảng lương mới!");
            else
                MessageBox.Show("Bảng lương tháng này đã tồn tại!");

            cbThang.SelectedIndex = -1;
            dgvBangLuong.DataSource = bll.LayDanhSachBangLuong();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvBangLuong.DataSource = bll.LayDanhSachBangLuong();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvBangLuong.DataSource;
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
                    FileName = "BangLuong.xlsx"
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
    }
}
