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
    public partial class frmBoSungKhauTru : Form
    {
        private TangCa_NhanVienBLL tangCaBll = new TangCa_NhanVienBLL();
        private Khen_NhanVienBLL khenBll = new Khen_NhanVienBLL();
        private KiLuat_NhanVienBLL kiLuatBll = new KiLuat_NhanVienBLL();
        private string maNV;
        public frmBoSungKhauTru(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void frmBoSungKhauTru_Load(object sender, EventArgs e)
        {
            label1.Left = (panel8.ClientSize.Width - label1.Width) / 2; 
            SetupDataGridView(dgvTangCa);
            SetupDataGridView(dgvKhenThuong);
            SetupDataGridView(dgvKiLuat);
            LoadTatCaKhauTru();
        }
        private void SetupDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadTatCaKhauTru()
        {
            try
            {
                DataTable dtTangCa = tangCaBll.LayTCNhanVienTheoMa(maNV);
                dgvTangCa.DataSource = dtTangCa;
                DataTable dtKhenThuong = khenBll.LayKTTheoMaNhanVien(maNV);
                dgvKhenThuong.DataSource = dtKhenThuong;
                DataTable dtKiLuat = kiLuatBll.LayKLTheoMaNhanVien(maNV);
                dgvKiLuat.DataSource = dtKiLuat;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                // Tăng ca
                DataTable dtTangCa = tangCaBll.LayTangCa(thang, nam, maNV);
                dgvTangCa.DataSource = dtTangCa;

                // Khen thưởng
                DataTable dtKhenThuong = khenBll.GetKhenThuongByMaNV_ThangNam(maNV, thang, nam);
                dgvKhenThuong.DataSource = dtKhenThuong;

                // Kỷ luật
                DataTable dtKiLuat = kiLuatBll.GetKiLuatByMaNV_ThangNam(maNV, thang, nam);
                dgvKiLuat.DataSource = dtKiLuat;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
