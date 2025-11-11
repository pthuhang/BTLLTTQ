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
            HienThiDanhSach();
            dgvHopDong.ReadOnly = true;
            dgvHopDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHopDong.AllowUserToAddRows = false;

            EnableForm(false);
            SetDefaultButtonState();
            btnLuu.Enabled = false;
        }
        private void EnableForm(bool enable)
        {
            txtMaHD.Enabled=enable;
            txtMaNV.Enabled=enable;
            txtThoiHan.Enabled=enable;
            txtHSLuong.Enabled=enable;
            dtpNgayBD.Enabled=enable;
            dtpNgayKT.Enabled=enable;
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
            DataTable dt = dal.LayDanhSachHopDong();
            dgvHopDong.DataSource = dt;

            dgvHopDong.Columns["MaHopDong"].HeaderText = "Mã Hợp Đồng";
            dgvHopDong.Columns["ThoiHan"].HeaderText = "Thời Hạn";
            dgvHopDong.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
            dgvHopDong.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
            dgvHopDong.Columns["HeSoLuong"].HeaderText = "Hệ Số Lương";
            dgvHopDong.Columns["MaNV"].HeaderText = "Mã Nhân Viên";

            dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
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
            txtMaHD.Enabled = false; // không cho sửa mã hợp đồng
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
        private void ClearForm()
        {
            txtMaHD.Clear();
            txtThoiHan.Clear();
            txtHSLuong.Clear();
            txtMaNV.Clear();
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
            txtMaHD.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txtMaHD.Text.Trim();
                string thoiHan = txtThoiHan.Text.Trim();
                string maNV = txtMaNV.Text.Trim();
                DateTime ngayBD = dtpNgayBD.Value;
                DateTime ngayKT = dtpNgayKT.Value;

                if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng nhập Mã hợp đồng và Mã nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(txtHSLuong.Text.Trim(), out float heSoLuong))
                {
                    MessageBox.Show("Hệ số lương không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ngayKT < ngayBD)
                {
                    MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!", "Lỗi ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xử lý theo hành động
                if (currentAction == "Them")
                {
                    if (bll.TonTaiNV(maHD))
                    {
                        MessageBox.Show($"Mã hợp đồng '{maHD}' đã tồn tại!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!dal.KiemTraMaNVTonTai(maNV))
                    {
                        MessageBox.Show($"Mã nhân viên '{maNV}' không tồn tại trong hệ thống!", "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bll.Them(maHD, thoiHan, ngayBD, ngayKT, heSoLuong, maNV);
                    MessageBox.Show("Thêm hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentAction == "Sua")
                {
                    bll.CapNhat(maHD, thoiHan, ngayBD, ngayKT, heSoLuong, maNV);
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
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
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
                txtHSLuong.Text = row.Cells["HeSoLuong"].Value?.ToString();
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();

            }
        }

        //Tìm kiếm hợp đồng
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHDTimKiem.Text.Trim(); 
            string maNV = txtMaNVTimKiem.Text.Trim(); 

            DataTable dt = bll.TimKiemHopDong(maHD, maNV);

            if (dt.Rows.Count > 0)
            {
                dgvHopDong.DataSource = dt; // hiển thị kết quả lên DataGridView
            }
            else
            {
                MessageBox.Show("Không tìm thấy hợp đồng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHopDong.DataSource = null;
            }
        }

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
                SetDefaultButtonState();
                MessageBox.Show("Đã tải lại danh sách tất cả hợp đồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message);
            }
        }
    }
}
