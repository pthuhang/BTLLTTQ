using QUANLYNHANSU.BLL;
using QUANLYNHANSU.DAL;
using QUANLYNHANSU.Models;
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
    public partial class frmQLCLoaiCong : Form
    {

        private LoaiCongBLL LoaiCongBll = new LoaiCongBLL();


        private string currentAction = "";
        public frmQLCLoaiCong()
        {
            InitializeComponent();
        }
        private void HienThiDanhSach()
        {
            dgvLoaiCong.DataSource = LoaiCongBll.LayDanhSach();
        }
        private void frmQLCLoaiCong_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            EnableForm(false);

        }
        private void EnableForm(bool enable)
        {
            txtMaLC.Enabled = enable;
            txtTenLC.Enabled = enable;
            txtHeSoCong.Enabled = enable;
        }
        

        private void ClearForm()
        {
            txtMaLC.Clear();
            txtTenLC.Clear();
            txtHeSoCong.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            currentAction = "Them";
            EnableForm(true);
            ClearForm();
            txtMaLC.Focus();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void dgvLoaiCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLoaiCong.Rows[e.RowIndex];
            if (row.Cells["MaLoaiCong"].Value == null) return;

            txtMaLC.Text = row.Cells["MaLoaiCong"].Value.ToString();
            txtTenLC.Text = row.Cells["TenLoaiCong"].Value?.ToString();
            txtHeSoCong.Text = row.Cells["HeSo"]?.Value.ToString();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLC.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.");
                return;
            }

            currentAction = "Sua";
            EnableForm(true);

            // Không cho sửa khóa chính
            txtMaLC.Enabled = false;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLC.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn loại công cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa loại công này?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoaiCongBll.Xoa(txtMaLC.Text.Trim());
                HienThiDanhSach();
                ClearForm();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaLC.Text.Trim();
                string ten = txtTenLC.Text.Trim();
                decimal heSo;

                if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten)
                    || !decimal.TryParse(txtHeSoCong.Text.Trim(), out heSo))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng!");
                    return;
                }

                if (currentAction == "Them")
                {
                    if (LoaiCongBll.KiemTraTonTai(ma))
                    {
                        MessageBox.Show("Mã loại công đã tồn tại.");
                        return;
                    }

                    LoaiCongBll.Them(ma, ten, heSo);
                    MessageBox.Show("Thêm loại công thành công.");
                }
                else if (currentAction == "Sua")
                {
                    LoaiCongBll.CapNhat(ma, ten, heSo);
                    MessageBox.Show("Sửa loại công thành công.");
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
