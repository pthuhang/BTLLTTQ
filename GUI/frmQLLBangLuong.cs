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



    }
}
