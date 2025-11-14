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
    public partial class frmQLTTCaNhan : Form
    {
        private string tenDangNhap;
        private string maNV;
        public frmQLTTCaNhan(string tenDangNhap, string maNV)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
            this.maNV = maNV;
        }
        public frmQLTTCaNhan()
        {
            InitializeComponent();
        }

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
            pViewQLTTCaNhan.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pViewQLTTCaNhan.Controls.Add(childForm);
            pViewQLTTCaNhan.Tag = childForm;

            childForm.Show();
        }
        private void frmQLTTCaNhan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            StyleButton(btnThongTinCaNhan);
            StyleButton(btnBangCong);
            StyleButton(btnBangLuong);
            StyleButton(btnHopDong);
            StyleButton(btnBoSungKhauTru);
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmThongTinCaNhan(tenDangNhap));
            HighlightTab(btnThongTinCaNhan);
        }
        private void btnBangCong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmBangCong(maNV));
            HighlightTab(btnBangCong);
        }
        private void btnBoSungKhauTru_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmBoSungKhauTru(maNV));
            HighlightTab(btnBoSungKhauTru);
        }
        private void btnHopDong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmHopDong(tenDangNhap));
            HighlightTab(btnHopDong);
        }
        private void btnBangLuong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmBangLuong(maNV));
            HighlightTab(btnBangLuong);
        }
    }
}
