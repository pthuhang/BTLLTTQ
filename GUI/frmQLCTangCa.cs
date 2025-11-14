using QUANLYNHANSU.BLL;
using QUANLYNHANSU.DAL;
using QUANLYNHANSU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    public partial class frmQLCTangCa : Form
    {
        private TangCa_NhanVienBLL nvtcbll = new TangCa_NhanVienBLL();
        private string currentAction = "";
        public frmQLCTangCa()
        {
            InitializeComponent();
            dgvTangCa.CellClick += dgvTangCa_CellClick;
        }

        private void frmQLCTangCa_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            dgvTangCa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTangCa.ReadOnly = true;
            dgvTangCa.AllowUserToAddRows = false;
            EnableForm(false);
        }
        private void EnableForm(bool enable)
        {
            txtMaNV.Enabled = enable;
            txtSoGioTC.Enabled = enable;
            dtpNgayTC.Enabled = enable;
        }
        private void HienThiDanhSach()
        {
            DataTable dt = nvtcbll.LayDanhSach();
            dgvTangCa.DataSource = dt;
        }

        private void ClearForm()
        {
            txtMaNV.Clear();
            dtpNgayTC.Value = DateTime.Now;
            txtSoGioTC.Clear();
        }

        private void dgvTangCa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvTangCa.Rows[e.RowIndex];
                    
                    txtMaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? "";
                    dtpNgayTC.Value = row.Cells["NgayTangCa"].Value != null ? Convert.ToDateTime(row.Cells["NgayTangCa"].Value) : DateTime.Now;
                    txtSoGioTC.Text = row.Cells["SoGioTangCa"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();

            txtMaNV.Enabled = true;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.");
                return;
            }

            currentAction = "Sua";
            EnableForm(true);

            // Không cho sửa khóa chính
            txtMaNV.Enabled = false;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            nvtcbll.Xoa(dtpNgayTC.Value,txtMaNV.Text.Trim());
            HienThiDanhSach();
            ClearForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string soGio = txtSoGioTC.Text.Trim();

            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(soGio))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!int.TryParse(soGio, out int soGioTC) || soGioTC <= 0)
            {
                MessageBox.Show("Số giờ tăng ca phải là số nguyên dương!");
                return;
            }

            DateTime ngay = dtpNgayTC.Value;

            if (currentAction == "Them")
            {
                if (nvtcbll.KiemTraTonTai(ngay, maNV))
                {
                    MessageBox.Show("Đã có dữ liệu tăng ca này!");
                    ClearForm();
                    EnableForm(false);
                    currentAction = "";
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    return;
                }

                nvtcbll.Them(maNV, soGioTC, ngay);
                MessageBox.Show("Thêm thành công!");
            }
            else if (currentAction == "Sua")
            {
                nvtcbll.Sua(maNV, ngay, soGioTC);
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Bạn cần chọn Thêm hoặc Sửa trước.");
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
