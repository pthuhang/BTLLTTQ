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
    public partial class frmQLTaiKhoanCaNhan : Form
    {
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        public frmQLTaiKhoanCaNhan()
        {
            InitializeComponent();
        }

        private void frmQLTaiKhoanCaNhan_Load(object sender, EventArgs e)
        {
            DataTable dt = tkBLL.LayDanhSach();
            if (dt.Rows.Count > 0)
            {
                txtMaNgDung.Text = dt.Rows[0]["MaNguoiDung"].ToString();
                txtMaNV.Text = dt.Rows[0]["MaNV"].ToString();
                txtTenDangNhap.Text = dt.Rows[0]["TenDangNhap"].ToString();
                txtMatKhau.Text = dt.Rows[0]["MatKhau"].ToString();
                cbVaiTro.Text = dt.Rows[0]["VaiTro"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNguoiDung = txtMaNgDung.Text.Trim();
            string maNhanVien = txtMaNV.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string vaiTro = cbVaiTro.Text.Trim();

            if (tkBLL.UpdateOne(maNguoiDung, maNhanVien, tenDangNhap, matKhau, vaiTro))
            {
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
