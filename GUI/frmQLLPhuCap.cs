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
    public partial class frmQLLPhuCap : Form
    {
        PhuCapBLL pcbll = new PhuCapBLL();
        PhuCap_NhanVienBLL pcnvbll = new PhuCap_NhanVienBLL();
        public frmQLLPhuCap()
        {
            InitializeComponent();
        }
        private void hienThiDSPC()
        {
            dgvPhuCap.DataSource = pcbll.LayDanhSachPC();
        }
        private void hienThiDSPCNV()
        {
            dgvPhuCapNhanVien.DataSource = pcnvbll.LayDanhSach();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaPC.Clear();
            txtTenPC.Clear();
            txtTienPC.Clear();

            btnThemPC.Enabled = true;
            btnSuaPC.Enabled = true;
            btnXoaPC.Enabled = true;
            btnLuuPC.Enabled = true;

            btnLoc.Enabled = true;
            btnThemPCNV.Enabled = true;
            btnXoaPCNV.Enabled = true;
            btnLuuPCNV.Enabled = true;

            hienThiDSPC();
            hienThiDSPCNV();
        }
        private void hienThiComboBoxPC()
        {
            try
            {
                DataTable dt = pcbll.LayDanhSachPC();  
                cbPhuCap.DataSource = dt;
                cbPhuCap.DisplayMember = "TenPhuCap"; 
                cbPhuCap.ValueMember = "MaPhuCap";   
                cbPhuCap.SelectedIndex = -1;     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phụ cấp: " + ex.Message);
            }
        }
        private void frmQLLPhuCap_Load(object sender, EventArgs e)
        {
            txtMaPC.Enabled = false;
            txtTenPC.Enabled = false;
            txtTienPC.Enabled = false;
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            cbPhuCap.Enabled = false;

            hienThiDSPC();
            hienThiDSPCNV();
            hienThiComboBoxPC();

            cbPhuCap.DisplayMember = "TenPhuCap";
            cbPhuCap.ValueMember = "MaPhuCap";
        }
        private void batBtn()
        {
            btnThemPC.Enabled = true;
            btnSuaPC.Enabled = true;
            btnXoaPC.Enabled = true;
            btnLuuPC.Enabled = true;

            btnLoc.Enabled = true;
            btnThemPCNV.Enabled = true;
            btnXoaPCNV.Enabled = true;
            btnLuuPCNV.Enabled = true;
        }
        private void tatBtn()
        {
            btnThemPC.Enabled = false;
            btnSuaPC.Enabled=false;
            btnLuuPC.Enabled = false;
            btnXoaPC.Enabled=false;

            btnLoc.Enabled=false;
            btnThemPCNV.Enabled=false;
            btnXoaPCNV.Enabled=false;
            btnLuuPCNV.Enabled = false;
        }
        //Phụ cấp
        private void ClearFormPC()
        {
            txtMaPC.Clear();
            txtTenPC.Clear();
            txtTienPC.Clear();
        }
        private void btnThemPC_Click(object sender, EventArgs e)
        {
            txtMaPC.Enabled = true;
            txtTenPC.Enabled = true;
            txtTienPC.Enabled = true;

            tatBtn();
            btnThemPC.Enabled = true;
            btnLuuPC.Enabled = true;

            txtMaPC.Focus();
        }
        private void btnLuuPC_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra rỗng, định dạng, trùng lặp
                if (string.IsNullOrWhiteSpace(txtMaPC.Text) || string.IsNullOrWhiteSpace(txtTenPC.Text) || string.IsNullOrWhiteSpace(txtTienPC.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin phụ cấp!");
                    return;
                }
                if (!int.TryParse(txtTienPC.Text, out int tienPC) || tienPC <= 1000)
                {
                    MessageBox.Show("Tiền phụ cấp phải là số nguyên lớn hơn 1000!");
                    txtTienPC.Focus();
                    return;
                }
                DataTable dtPC = pcbll.LayDanhSachPC();
                foreach (DataRow row in dtPC.Rows)
                {
                    if (row["MaPhuCap"].ToString().Equals(txtMaPC.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Mã phụ cấp đã tồn tại!");
                        txtMaPC.Focus();
                        return;
                    }
                    if (row["TenPhuCap"].ToString().Equals(txtTenPC.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Tên phụ cấp đã tồn tại!");
                        txtTenPC.Focus();
                        return;
                    }
                }
                //
                pcbll.Them(txtMaPC.Text, txtTenPC.Text, Convert.ToDecimal(txtTienPC.Text));
                MessageBox.Show("Thêm phụ cấp thành công!");
                hienThiDSPC();
                hienThiComboBoxPC();
                ClearFormPC();
                batBtn();
                btnLuuPC.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phụ cấp: " + ex.Message);
            }
        }
        private void dgvPhuCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaPC.Text = dgvPhuCap.Rows[e.RowIndex].Cells["MaPhuCap"].Value.ToString();
                txtTenPC.Text = dgvPhuCap.Rows[e.RowIndex].Cells["TenPhuCap"].Value.ToString();
                txtTienPC.Text = dgvPhuCap.Rows[e.RowIndex].Cells["TienPhuCap"].Value.ToString();
            }
            tatBtn();
            btnSuaPC.Enabled = true;
            btnXoaPC.Enabled = true;
        }
        private void btnSuaPC_Click(object sender, EventArgs e)
        {
            try
            {
                pcbll.Sua(txtMaPC.Text, txtTenPC.Text, Convert.ToDecimal(txtTienPC.Text));
                MessageBox.Show("Cập nhật phụ cấp thành công!");
                hienThiDSPC();
                hienThiComboBoxPC();
                ClearFormPC();
                batBtn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }
        private void btnXoaPC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    pcbll.Xoa(txtMaPC.Text);
                    MessageBox.Show("Xóa phụ cấp thành công!");
                    hienThiDSPC();
                    hienThiComboBoxPC();
                    ClearFormPC();
                    batBtn();
                    btnLoc.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }


        //Phụ cấp - Nhân viên
        private void ClearFormPCNV()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            cbPhuCap.SelectedIndex = -1;
        }
        private void dgvPhuCapNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tatBtn();
            btnXoaPCNV.Enabled = true;
        }

        private void btnThemPCNV_Click(object sender, EventArgs e)
        {
            tatBtn();
            btnThemPCNV.Enabled = true;
            btnLuuPCNV.Enabled = true;
            btnLoc.Enabled = true;

            txtMaNV.Enabled = true;
            txtMaNV.Focus();
        }
        private void locNhanVien(string maNv)
        {
            try
            {
                var dt = pcnvbll.LayNhanVien(maNv);

                dgvPhuCapNhanVien.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    dgvPhuCapNhanVien.DataSource = dt;
                    txtTenNV.Text = dt.Rows[0]["HoTen"].ToString();
                }
                else
                {
                    MessageBox.Show("Nhân viên chưa có phụ cấp!");
                    txtTenNV.Text = pcnvbll.LayHoTenNV(maNv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc: " + ex.Message);
            }
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            if (!string.IsNullOrEmpty(maNV))
            {
                locNhanVien(maNV);
                cbPhuCap.Enabled = true;
                btnLuuPCNV.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã nhân viên để lọc!");
            }
        }

        private void btnLuuPCNV_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                string maPhuCap = cbPhuCap.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(maPhuCap))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên và loại phụ cấp!");
                    return;
                }

                DataTable dt = pcnvbll.LayNhanVien(maNV);
                bool daCo = dt.AsEnumerable().Any(row => row["MaPhuCap"].ToString() == maPhuCap);
                if (daCo)
                {
                    MessageBox.Show("Nhân viên đã có phụ cấp này!");
                    cbPhuCap.Focus();
                    return;
                }

                pcnvbll.Them(maPhuCap, maNV);
                MessageBox.Show("Thêm phụ cấp cho nhân viên thành công!");

                hienThiDSPCNV();
                ClearFormPCNV();
                batBtn();
                btnLuuPCNV.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnXoaPCNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string maNV = dgvPhuCapNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
                    string maPhuCap = dgvPhuCapNhanVien.CurrentRow.Cells["MaPhuCap"].Value.ToString();

                    pcnvbll.Xoa(maPhuCap, maNV);
                    MessageBox.Show("Xóa phụ cấp thành công!");
                    hienThiDSPCNV();
                    ClearFormPCNV();
                    batBtn();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
