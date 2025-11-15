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
        private void EnableForm(bool enabled)
        {
            txtMaPB.Enabled = enabled;
            txtTenPB.Enabled = enabled;
            txtMaTruongPhong.Enabled = enabled;
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
            dgvPhongBan.DataSource = bll.LayDanhSach();
            dgvPhongBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ClearForm()
        {
            txtMaPB.Clear();
            txtTenPB.Clear();
            txtMaTruongPhong.Clear();
            txtMaPB.Focus();
        }
        private void frmQLNSPhongBan_Load(object sender, EventArgs e)
        {
            PhongBanBLL bllPB = new PhongBanBLL();
            cbTenPhongTimKiem.DataSource = bllPB.LayDanhSach();
            cbTenPhongTimKiem.DisplayMember = "TenPhongBan";
            cbTenPhongTimKiem.ValueMember = "MaPhongBan";
            cbTenPhongTimKiem.SelectedIndex = -1;

            HienThiDanhSach();
            EnableForm(false);
            btnLuu.Enabled = false;
            batBtn();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();
            batBtn();
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidatePhongBan())
                return;
            try
            {
                string maPB = txtMaPB.Text.Trim();
                string tenPB = txtTenPB.Text.Trim();
                string maNVTP = txtMaTruongPhong.Text.Trim();


                if (currentAction == "Them")
                {
                    if (bll.KiemTraTonTaiMa(maPB))
                    {
                        MessageBox.Show("Mã phòng ban đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaPB.Focus();
                        return;
                    }

                    if (bll.KiemTraTonTaiTen(tenPB, maPB))
                    {
                        MessageBox.Show("Tên phòng ban đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTenPB.Focus();
                        return;
                    }
                    bll.Them(maPB, tenPB, maNVTP);
                    MessageBox.Show("Thêm phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentAction == "Sua")
                {
                    if (bll.KiemTraTonTaiTen(tenPB, maPB))
                    {
                        MessageBox.Show("Tên phòng ban đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTenPB.Focus();
                        return;
                    }
                    bll.CapNhat(maPB, tenPB, maNVTP);
                    MessageBox.Show("Cập nhật phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void cbTenPhongTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenPhongTimKiem.SelectedIndex == -1) return;

            string maPhongBan = cbTenPhongTimKiem.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maPhongBan)) return;

            cbTenPhongTimKiem.Enabled = false;
            dgvNVPhongBan.DataSource = null;

            // Chạy query ở background thread
            DataTable dt = await Task.Run(() => bllNV.LayNhanVienTheoPhongBan(maPhongBan));

            dgvNVPhongBan.DataSource = dt;
            cbTenPhongTimKiem.Enabled = true;
            //try
            //{
            //    if (cbTenPhongTimKiem.SelectedIndex == -1)
            //        return;

            //    string maPhongBan = cbTenPhongTimKiem.SelectedValue?.ToString();
            //    if (string.IsNullOrEmpty(maPhongBan))
            //        return;

            //    DataTable dt = bllNV.LayNhanVienTheoPhongBan(maPhongBan);

            //    dgvNVPhongBan.AutoGenerateColumns = true;
            //    dgvNVPhongBan.DataSource = dt;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi hiển thị nhân viên theo phòng ban: " + ex.Message);
            //}
        }


        //-----VALIDATE-----
        private bool ValidatePhongBan()
        {
            ePLoiValidate.Clear();
            bool ok = true;

            // Mã phòng ban
            if (string.IsNullOrWhiteSpace(txtMaPB.Text))
            {
                ePLoiValidate.SetError(txtMaPB, "Mã phòng ban không được để trống!");
                ok = false;
            }
            else if (txtMaPB.Text.Length > 10)
            {
                ePLoiValidate.SetError(txtMaPB, "Mã phòng ban không vượt quá 10 ký tự!");
                ok = false;
            }

            // Tên phòng ban
            if (string.IsNullOrWhiteSpace(txtTenPB.Text))
            {
                ePLoiValidate.SetError(txtTenPB, "Tên phòng ban không được để trống!");
                ok = false;
            }
            else if (txtTenPB.Text.Length > 50)
            {
                ePLoiValidate.SetError(txtTenPB, "Tên phòng ban không vượt quá 50 ký tự!");
                ok = false;
            }

            // Mã trưởng phòng (có thể null)
            if (!string.IsNullOrWhiteSpace(txtMaTruongPhong.Text) && txtMaTruongPhong.Text.Length > 10)
            {
                ePLoiValidate.SetError(txtMaTruongPhong, "Mã trưởng phòng không vượt quá 10 ký tự!");
                ok = false;
            }

            return ok;
        }

    }
}
