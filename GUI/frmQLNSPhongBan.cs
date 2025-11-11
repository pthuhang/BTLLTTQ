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
    public partial class frmQLNSPhongBan : Form
    {
        private PhongBanBLL bll = new PhongBanBLL();
        NhanVienBLL bllNV = new NhanVienBLL();
        private string currentAction = "";

        public frmQLNSPhongBan()
        {
            InitializeComponent();
        }

        private void frmQLNSPhongBan_Load(object sender, EventArgs e)
        {
            PhongBanBLL bllPB = new PhongBanBLL();
            cbTenPhongTimKiem.DataSource = bllPB.LayDanhSach(); // trả về List hoặc DataTable
            cbTenPhongTimKiem.DisplayMember = "TenPhongBan";
            cbTenPhongTimKiem.ValueMember = "MaPhongBan";
            cbTenPhongTimKiem.SelectedIndex = -1;
            HienThiDanhSach();
            EnableForm(false);
            btnLuu.Enabled = false;
            SetDefaultButtonState();

        }

        private void EnableForm(bool enabled)
        {
            txtMaPB.Enabled = enabled;
            txtTenPB.Enabled = enabled;
            txtMaTruongPhong.Enabled = enabled;
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
            dgvPhongBan.DataSource = bll.LayDanhSach();
            dgvPhongBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            if (string.IsNullOrWhiteSpace(txtMaPB.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 phòng ban để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            currentAction = "Sua";
            EnableForm(true);
            txtMaPB.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhongBan.CurrentRow != null)
            {
                string maPB = dgvPhongBan.CurrentRow.Cells["MaPhongBan"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa phòng ban {maPB} không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bll.Xoa(maPB);
                        MessageBox.Show("Xóa phòng ban thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDanhSach();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ClearForm()
        {
            txtMaPB.Clear();
            txtTenPB.Clear();
            txtMaTruongPhong.Clear();
            txtMaPB.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maPB = txtMaPB.Text.Trim();
                string tenPB = txtTenPB.Text.Trim();
                string maNVTP = txtMaTruongPhong.Text.Trim();

                if (string.IsNullOrEmpty(maPB) || string.IsNullOrEmpty(tenPB))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã phòng ban và Tên phòng ban!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentAction == "Them")
                {
                    bll.Them(maPB, tenPB, maNVTP);
                    MessageBox.Show("Thêm phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentAction == "Sua")
                {
                    bll.CapNhat(maPB, tenPB, maNVTP);
                    MessageBox.Show("Cập nhật phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaPB.Text = dgvPhongBan.CurrentRow.Cells["MaPhongBan"].Value.ToString();
                txtTenPB.Text = dgvPhongBan.CurrentRow.Cells["TenPhongBan"].Value.ToString();
                txtMaTruongPhong.Text = dgvPhongBan.CurrentRow.Cells["MaTruongPhong"].Value.ToString();

                string maPB = txtMaPB.Text;
               
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTenPhongTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Bỏ qua nếu chưa chọn gì
                if (cbTenPhongTimKiem.SelectedIndex == -1)
                    return;

                string maPhongBan = cbTenPhongTimKiem.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maPhongBan))
                    return;

                DataTable dt = bllNV.LayNhanVienTheoPhongBan(maPhongBan);

                dgvNVPhongBan.AutoGenerateColumns = true;
                dgvNVPhongBan.DataSource = dt;

                //lblThongBao.Text = $"🔹 Có {dt.Rows.Count} nhân viên trong phòng này.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị nhân viên theo phòng ban: " + ex.Message);
            }
        }
    }
}
