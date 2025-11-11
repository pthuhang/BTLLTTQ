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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void CaiDatButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(39, 58, 115);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Height = 50;
            btn.Cursor = Cursors.Hand;

            // Hiệu ứng hover
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(58, 87, 176);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(39, 58, 115);
            };
        }
        

        private void MoFormCon(Form childForm)
        {
            // Xóa form con cũ trong panel (nếu có)
            panelView.Controls.Clear();

            // Cấu hình form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm form con vào panel
            panelView.Controls.Add(childForm);
            panelView.Tag = childForm;

            // Hiển thị form con
            childForm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            StyleButton(btnQLNhanSu);
            StyleButton(btnQLCong);
            StyleButton(btnQLLuong);
            StyleButton(btnQLTaiKhoan);
        }
        private void btnQLNhanSu_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLNhanSu());
            HighlightTab(btnQLNhanSu);
        }

        private void btnQLCong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLCong());
            HighlightTab(btnQLCong);
        }

        private void btnQLLuong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLLuong());
            HighlightTab(btnQLLuong);
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLTaiKhoan());
            HighlightTab(btnQLTaiKhoan);
        }
        //Link label Đăng xuất
        private void llbDangXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();

                frmLogin loginForm = new frmLogin();
                loginForm.Show();

            }
        }
        private void HighlightTab(Button selectedButton)
        {
            // Danh sách các nút tab
            Button[] tabs = { btnQLNhanSu, btnQLLuong, btnQLCong, btnQLTaiKhoan };

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
