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
    public partial class frmMainNhanVien : Form
    {
        private string tenDangNhap; // biến lưu tên người đăng nhập
        private string maNV;

        public frmMainNhanVien(string maNV, string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;

            label1.Text = "Xin chào, " + tenDangNhap + "!";
            label1.Left = (panel3.ClientSize.Width - label1.Width) / 2;

        }
        //public frmMainNhanVien()
        //{
        //    InitializeComponent();
        //}
        //---
        private void HighlightTab(Button selectedButton)
        {
            Button[] tabs = { btnThongTinCaNhan, btnBangCong, btnBangLuong, btnHopDong, btnBoSungKhauTru };

            foreach (Button btn in tabs)
            {
                btn.BackColor = Color.FromArgb(33, 150, 243);
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
            }

            selectedButton.BackColor = Color.MediumSeaGreen;
            selectedButton.ForeColor = Color.White;
        }
        private void MoFormCon(Form childForm)
        {
            panelView.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelView.Controls.Add(childForm);
            panelView.Tag = childForm;

            childForm.Show();
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmThongTinCaNhan(tenDangNhap));
                HighlightTab(btnThongTinCaNhan);
        }

        private void btnBangCong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmBangCong());
            HighlightTab(btnBangCong);
        }

        private void btnBoSungKhauTru_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmBoSungKhauTru(maNV));
            HighlightTab(btnBoSungKhauTru);
        }

        private void btnBangLuong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmBangLuong());
            HighlightTab(btnBangLuong);
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmHopDong(tenDangNhap));
            HighlightTab(btnHopDong);
        }

        private void frmMainNhanVien_Load(object sender, EventArgs e)
        {
            StyleButton(btnThongTinCaNhan);
            StyleButton(btnBangCong);
            StyleButton(btnBangLuong);
            StyleButton(btnBoSungKhauTru);
            StyleButton(btnHopDong);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất không?",
            "Xác nhận đăng xuất",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }


}

}
