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
        public frmQLLPhuCap()
        {
            InitializeComponent();
        }

        private void frmQLLPhuCap_Load(object sender, EventArgs e)
        {
            txtMaPC.Enabled = false;
            txtTenPC.Enabled = false;
            txtTienPC.Enabled = false;

            hienThiDanhSach();
        }
        //
        private void hienThiDanhSach()
        {
            dgvPhuCap.DataSource = pcbll.LayDanhSach();
        }
        private void HighlightButton(Button selectedButton)
        {
            Button[] buttons = { btnThem, btnSua, btnXoa, btnLuu };
            foreach (Button btn in buttons)
            {
                btn.Enabled = true;
                btn.BackColor = Color.FromArgb(0, 120, 215);
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Cursor = Cursors.Hand;
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Gray; 
            }
            selectedButton.BackColor = Color.MediumSeaGreen;
            selectedButton.ForeColor = Color.White;
        }
        private void ClearForm()
        {
            txtMaPC.Clear();
            txtTenPC.Clear();
            txtTienPC.Clear();
        }


        //Them, sua, xoa:
        private void btnThem_Click(object sender, EventArgs e)
        {
            HighlightButton(btnThem);

            txtMaPC.Enabled = true;
            txtTenPC.Enabled = true;
            txtTienPC.Enabled = true;

            txtMaPC.Focus();

            try
            {
                pcbll.Them(txtMaPC.Text, txtTenPC.Text, decimal.Parse(txtTienPC.Text));
                MessageBox.Show("Thêm phụ cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiDanhSach();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phụ cấp: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPC.Text)) { MessageBox.Show("Chọn 1 phụ cấp"); return; }
            try
            {
                pcbll.Sua(txtMaPC.Text, txtTenPC.Text,
                              decimal.Parse(txtTienPC.Text));
                MessageBox.Show("Cập nhật thành công!");
                hienThiDanhSach();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    pcbll.Xoa(txtMaPC.Text);
                    MessageBox.Show("Xóa thành công!");
                    hienThiDanhSach();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
