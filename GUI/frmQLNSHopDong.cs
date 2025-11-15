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
    public partial class frmQLNSHopDong : Form
    {
        private HopDongBLL bll = new HopDongBLL();
        private HopDongDAL dal = new HopDongDAL();
        private string currentAction = "";
        public frmQLNSHopDong()
        {
            InitializeComponent();
        }
        private void frmQLNSHopDong_Load(object sender, EventArgs e)
        {
            txtMaHD.ReadOnly = true;
            txtThoiHan.ReadOnly = true;
            HienThiDanhSach();
            dgvHopDong.ReadOnly = true;
            dgvHopDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHopDong.AllowUserToAddRows = false;

            EnableForm(false);
            batBtn();
            btnLuu.Enabled = false;
        }
        private void ClearForm()
        {
            txtMaHD.Clear();
            txtThoiHan.Clear();
            txtHSLuong.Clear();
            txtMaNV.Clear();
            txtLanKi.Clear();
            txtNoiDung.Clear();
            txtLuongCoBan.Clear();
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
            txtMaHD.Focus();
        }
        private void EnableForm(bool enable)
        {
            txtMaHD.Enabled=enable;
            txtMaNV.Enabled=enable;
            txtThoiHan.Enabled=enable;
            txtNoiDung.Enabled=enable;
            txtLanKi.Enabled= enable;
            txtHSLuong.Enabled=enable;
            dtpNgayBD.Enabled=enable;
            dtpNgayKT.Enabled=enable;
            txtLuongCoBan.Enabled=enable;
        }
        private void batBtn()
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
        }
        private void HienThiDanhSach()
        {
            DataTable dt = dal.LayDanhSachHopDong();
            dgvHopDong.DataSource = dt;

            dgvHopDong.Columns["MaHopDong"].HeaderText = "Mã Hợp Đồng";
            dgvHopDong.Columns["ThoiHan"].HeaderText = "Thời Hạn";
            dgvHopDong.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
            dgvHopDong.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
            dgvHopDong.Columns["NoiDung"].HeaderText = "Nội dung";
            dgvHopDong.Columns["LanKi"].HeaderText = "Lần kí";
            dgvHopDong.Columns["HeSoLuong"].HeaderText = "Hệ Số Lương";
            dgvHopDong.Columns["LuongCoBan"].HeaderText = "Lương cơ bản";
            dgvHopDong.Columns["MaNV"].HeaderText = "Mã Nhân Viên";

            dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //-----THÊM, SỬA, XÓA-----
        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dtpNgayBD.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentAction = "Sua";
            EnableForm(true);
            txtMaHD.ReadOnly = true; 
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvHopDong.CurrentRow != null)
            {
                string maHD = dgvHopDong.CurrentRow.Cells["MaHopDong"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa hợp đồng {maHD} không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bll.Xoa(maHD);
                        MessageBox.Show("Xóa hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDanhSach();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateHopDong())
                return;
            try
            {

                string maNV = txtMaNV.Text.Trim();
                string noiDung = txtNoiDung.Text.Trim();
                string lanKi = txtLanKi.Text.Trim();
                DateTime ngayBD = dtpNgayBD.Value;
                DateTime ngayKT = dtpNgayKT.Value;
                decimal luongCB = Convert.ToDecimal(txtLuongCoBan.Text.Trim());

                int tongThang = ((ngayKT.Year - ngayBD.Year) * 12) + ngayKT.Month - ngayBD.Month;
                int nam = tongThang / 12;
                int thang = tongThang % 12;

                string thoiHan = (nam > 0 ? nam + " năm " : "") + (thang > 0 ? thang + " tháng" : "");
                txtThoiHan.Text = thoiHan;

                float heSoLuong = 0;
                if (!float.TryParse(txtHSLuong.Text.Trim(), out heSoLuong))
                {
                    MessageBox.Show("Hệ số lương không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maHD = bll.TaoMaHD(maNV, ngayBD, ngayKT);

                if (!bll.KiemTraNhanVienTonTai(maNV))
                {
                    MessageBox.Show("Nhân viên không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Xử lý theo hành động
                if (currentAction == "Them")
                {
                    if (bll.KiemTraHopDongTonTai(maNV, ngayBD, ngayKT))
                    {
                        MessageBox.Show("Nhân viên đã có hợp đồng trong khoảng thời gian này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bll.Them(maHD, thoiHan, ngayBD, ngayKT,noiDung, lanKi, heSoLuong, luongCB, maNV);

                    MessageBox.Show("Thêm hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentAction == "Sua")
                {
                    if (bll.KiemTraHopDongTonTai(maNV, ngayBD, ngayKT, maHD))
                    {
                        MessageBox.Show("Nhân viên đã có hợp đồng trùng khoảng thời gian này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bll.CapNhat(maHD, thoiHan, ngayBD, ngayKT,noiDung, lanKi, heSoLuong,luongCB, maNV);

                    MessageBox.Show("Cập nhật hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa trước khi Lưu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HienThiDanhSach();
                ClearForm();
                EnableForm(false);
                btnLuu.Enabled = false;
                batBtn();
                currentAction = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MaHopDong"].Value?.ToString();
                dtpNgayBD.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
                dtpNgayKT.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
                txtThoiHan.Text = row.Cells["ThoiHan"].Value?.ToString();
                txtNoiDung.Text = row.Cells["NoiDung"].Value?.ToString();
                txtLanKi.Text = row.Cells["LanKi"].Value?.ToString();
                txtHSLuong.Text = row.Cells["HeSoLuong"].Value?.ToString();
                txtLuongCoBan.Text = row.Cells["LuongCoBan"].Value?.ToString();
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();

            }
        }

        //Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHDTimKiem.Text.Trim(); 
            string maNV = txtMaNVTimKiem.Text.Trim(); 

            DataTable dt = bll.TimKiemHopDong(maHD, maNV);

            if (dt.Rows.Count > 0)
            {
                dgvHopDong.DataSource = dt; 
            }
            else
            {
                MessageBox.Show("Không tìm thấy hợp đồng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHopDong.DataSource = null;
            }
        }

        // LỌC
        private void btnHopDongSapHetHan_Click(object sender, EventArgs e)
        {
            try
            {
                int soNgay = 30; 
                DataTable dt = bll.LayHopDongSapHetHan(soNgay);
                dgvHopDong.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có hợp đồng nào sắp hết hạn trong 30 ngày tới.", "Thông báo");
                }
                else
                {
                    MessageBox.Show($"Có {dt.Rows.Count} hợp đồng sắp hết hạn trong {soNgay} ngày tới.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hợp đồng sắp hết hạn: " + ex.Message);
            }
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiDanhSach();
                txtMaNVTimKiem.Clear();
                txtMaHDTimKiem.Clear();
                ClearForm();
                EnableForm(false);
                batBtn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message);
            }
        }

        //-----Validate-----
        private bool ValidateHopDong()
        {
            ePLoiValidate.Clear();
            bool ok = true;

            // Thời hạn
            if (!string.IsNullOrWhiteSpace(txtThoiHan.Text) && txtThoiHan.Text.Length > 50)
            {
                ePLoiValidate.SetError(txtThoiHan, "Thời hạn không vượt quá 50 ký tự!");
                ok = false;
            }

            // Ngày bắt đầu
            if (!dtpNgayBD.Checked)
            {
                ePLoiValidate.SetError(dtpNgayBD, "Vui lòng chọn ngày bắt đầu hợp đồng!");
                ok = false;
            }

            // Ngày kết thúc
            if (dtpNgayKT.Checked && dtpNgayKT.Value < dtpNgayBD.Value)
            {
                ePLoiValidate.SetError(dtpNgayKT, "Ngày kết thúc phải sau ngày bắt đầu!");
                ok = false;
            }

            // Nội dung
            if (!string.IsNullOrWhiteSpace(txtNoiDung.Text) && txtNoiDung.Text.Length > 300)
            {
                ePLoiValidate.SetError(txtNoiDung, "Nội dung không vượt quá 300 ký tự!");
                ok = false;
            }

            // Hệ số lương
            if (!string.IsNullOrWhiteSpace(txtHSLuong.Text))
            {
                if (!float.TryParse(txtHSLuong.Text, out float hs) || hs < 0)
                {
                    ePLoiValidate.SetError(txtHSLuong, "Hệ số lương phải là số >= 0!");
                    ok = false;
                }
            }

            // Lương cơ bản
            if (!string.IsNullOrWhiteSpace(txtLuongCoBan.Text))
            {
                if (!decimal.TryParse(txtLuongCoBan.Text, out decimal luong) || luong < 0)
                {
                    ePLoiValidate.SetError(txtLuongCoBan, "Lương cơ bản phải >= 0!");
                    ok = false;
                }
            }

            // Mã nhân viên (có thể null, nhưng nếu nhập phải <=10 ký tự)
            if (!string.IsNullOrWhiteSpace(txtMaNV.Text) && txtMaNV.Text.Length > 10)
            {
                ePLoiValidate.SetError(txtMaNV, "Mã nhân viên không vượt quá 10 ký tự!");
                ok = false;
            }

            return ok;
        }

    }
}
