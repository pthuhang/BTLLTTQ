using QUANLYNHANSU.BLL;
using QUANLYNHANSU.DAL;
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
    public partial class frmBangLuong : Form
    {
        private BangLuongBLL blBLL = new BangLuongBLL();
        private string maNV;
        public frmBangLuong(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void frmBangLuong_Load(object sender, EventArgs e)
        {
            label1.Left = (panel8.ClientSize.Width - label1.Width) / 2;
            label1.Top = (panel8.ClientSize.Height - label1.Height) / 2;
            SetupDataGridView(dgvBangLuong);

        }
        private void SetupDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

            if (cbThang.SelectedItem == null || cbNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Tháng và Năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int thang = Convert.ToInt32(cbThang.SelectedItem);
            int nam = Convert.ToInt32(cbNam.SelectedItem);
            try
            {
                DataTable dtBL = blBLL.LayBangLuong(thang, nam, maNV);
                dgvBangLuong.DataSource = dtBL;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
