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
    public partial class frmBangCong : Form
    {
        private LoaiCong_NhanVienBLL lcnvBll = new LoaiCong_NhanVienBLL();
        private NhanVienBLL nvBll = new NhanVienBLL();
        private string maNV;
        public frmBangCong(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }
        private void frmBangCong_Load(object sender, EventArgs e)
        {
            label1.Left = (panel8.ClientSize.Width - label1.Width) / 2;
            label1.Top = (panel8.ClientSize.Height - label1.Height) / 2;

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Mã nhân viên chưa được truyền vào form!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }   

            LoadBangCong();
        }  
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cbThang.SelectedItem == null || cbNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Tháng và Năm!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadBangCong();
        }

        private void LoadBangCong()
        {
            int thang = Convert.ToInt32(cbThang.SelectedItem);
            int nam = Convert.ToInt32(cbNam.SelectedItem);

            try
            {
                DataTable dt = lcnvBll.LayBangCongTheoThangNam(maNV, thang, nam);

                if (dt == null || dt.Rows.Count == 0)
                {
                    dgvBangCong.DataSource = null;
                    return;
                }

                dgvBangCong.DataSource = dt;

                dgvBangCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBangCong.ReadOnly = true;
                dgvBangCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvBangCong.Columns["MaNV"].HeaderText = "Mã nhân viên";
                dgvBangCong.Columns["HoTen"].HeaderText = "Họ tên nhân viên";
                dgvBangCong.Columns["Ngaylam"].HeaderText = "Ngày làm";
                dgvBangCong.Columns["GioVao"].HeaderText = "Giờ vào";
                dgvBangCong.Columns["GioRa"].HeaderText = "Giờ ra";
                dgvBangCong.Columns["TenLoaiCong"].HeaderText = "Loại công";
                dgvBangCong.Columns["HeSo"].HeaderText = "Hệ số";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải bảng công: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
