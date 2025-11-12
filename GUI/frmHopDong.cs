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
    public partial class frmHopDong : Form
    {
        private HopDongBLL hopDongBLL = new HopDongBLL();
        private string tenDangNhap;
        public frmHopDong(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            label1.Left = (panel8.ClientSize.Width - label1.Width) / 2;
            HienThiThongTinCaNhan();

            EnableForm(false);
        }
        private void HienThiThongTinCaNhan()
        {
            DataTable dt = hopDongBLL.LayHopDong(tenDangNhap);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtMaHD.Text = row["MaHopDong"].ToString();
                txtMaNV.Text = row["MaNV"].ToString();
                txtThoiHan.Text = row["ThoiHan"].ToString();
                txtNoiDung.Text= row["NoiDung"].ToString() ;
                txtLanKi.Text = row["LanKi"].ToString();
                txtHSLuong.Text = row["HeSoLuong"].ToString();
                if (DateTime.TryParse(row["NgayBatDau"].ToString(), out DateTime nbd))
                    dtpNgayBD.Value = nbd;
                if (DateTime.TryParse(row["NgayKetThuc"].ToString(), out DateTime nkt))
                    dtpNgayKT.Value = nkt;
                txtLuongCB.Text = row["LuongCoBan"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin hop dong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void EnableForm(bool enable)
        {
            // Khóa/Mở toàn bộ control nhập liệu
            txtMaNV.ReadOnly = !enable;
            txtMaHD.ReadOnly = !enable;
            dtpNgayBD.Enabled = enable;
            dtpNgayKT.Enabled = enable;
            txtNoiDung.ReadOnly = !enable;
            txtLanKi.ReadOnly = !enable;
            txtThoiHan.ReadOnly = !enable;
            txtHSLuong.ReadOnly = !enable;
            txtLuongCB.ReadOnly = !enable;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
