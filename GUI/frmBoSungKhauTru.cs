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
    public partial class frmBoSungKhauTru : Form
    {
        TangCa_NhanVienBLL tangCaBLL = new TangCa_NhanVienBLL();
        Khen_NhanVienBLL khenBLL = new Khen_NhanVienBLL();
        private string maNV;
        public frmBoSungKhauTru(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void frmBoSungKhauTru_Load(object sender, EventArgs e)
        {
            label1.Left = (panel8.ClientSize.Width - label1.Width) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cbThang.SelectedItem == null || cbNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng và năm!");
                return;
            }
            int thang = int.Parse(cbThang.SelectedItem.ToString());
            int nam = int.Parse(cbNam.SelectedItem.ToString());
            DataTable dt = tangCaBLL.LayTangCa(thang, nam, maNV);
            dgvTangCa.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Bạn không có tăng ca trong tháng/năm này.");
            }
            DataTable dtb = khenBLL.GetKhenThuongByMaNV_ThangNam(maNV, thang, nam);
        }
    }
}
