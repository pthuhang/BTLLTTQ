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
    public partial class frmQLNhanSu : Form
    {
        NhanVienBLL nvBLL = new NhanVienBLL();
        public frmQLNhanSu()
        {
            InitializeComponent();
        }
        private void MoFormCon(Form childForm)
        {
            // Xóa form cũ trong panel nếu có
            panelViewQLNhanSu.Controls.Clear();

            // Thiết lập form con để hiển thị trong panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm form con vào panel
            panelViewQLNhanSu.Controls.Add(childForm);
            panelViewQLNhanSu.Tag = childForm;

            childForm.Show();
        }

        private void frmQLNhanSu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            StyleButton(btnNhanVien);
            StyleButton(btnPhongBan);
            StyleButton(btnHopDong);
            StyleButton(btnKhen);
            StyleButton(btnKiLuat);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLNSNhanVien());
            HighlightTab(btnNhanVien);
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLNSPhongBan());
            HighlightTab(btnPhongBan);
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLNSHopDong());
            HighlightTab(btnHopDong);
        }

        private void btnKhen_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLNSKhenThuong());
            HighlightTab(btnKhen);
        }

        private void btnKiLuat_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLNSKiLuat());
            HighlightTab(btnKiLuat);
        }
        private void HighlightTab(Button selectedButton)
        {
            // Danh sách các nút tab
            Button[] tabs = { btnNhanVien, btnPhongBan, btnHopDong, btnKhen, btnKiLuat };

            // Reset màu tất cả tab
            foreach (Button btn in tabs)
            {
                btn.BackColor = Color.FromArgb(33, 150, 243); // Màu xanh mặc định
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
            }

            // Làm nổi bật tab được chọn
            selectedButton.BackColor = Color.MediumSeaGreen; // Màu nổi bật (hoặc màu bạn chọn)
            selectedButton.ForeColor = Color.White;
        }

    }
}
