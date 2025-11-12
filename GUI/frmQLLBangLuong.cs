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


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            if (maNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                return;
            }

            decimal luong = bll.TinhLuongThucLinh(maNV);
            MessageBox.Show($"Lương thực lĩnh của nhân viên {maNV} là: {luong:N0} VNĐ");
        }

        private void bnTaoBL_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            int thang = int.Parse(comboBox1.Text);
            int nam = int.Parse(comboBox2.Text);

            bool taoMoi = bll.TaoBangLuong(maNV, thang, nam);
            if (taoMoi)
                MessageBox.Show("Đã tạo bảng lương mới!");
            else
                MessageBox.Show("Bảng lương tháng này đã tồn tại!");
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvBangLuong.DataSource = bll.LayDanhSachBangLuong();
        }

        private void frmQLLBangLuong_Load(object sender, EventArgs e)
        {
            dgvBangLuong.DataSource = bll.LayDanhSachBangLuong();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
