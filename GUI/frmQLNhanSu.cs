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
            panelViewQLNhanSu.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelViewQLNhanSu.Controls.Add(childForm);
            panelViewQLNhanSu.Tag = childForm;

            childForm.Show();
        }
        private void HighlightTab(Button selectedButton)
        {
            Button[] tabs = { btnNhanVien, btnPhongBan, btnHopDong};

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
        private void frmQLNhanSu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            StyleButton(btnNhanVien);
            StyleButton(btnPhongBan);
            StyleButton(btnHopDong);
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

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLTaiKhoanNhanVien());
            HighlightTab(btnTaiKhoan);
        }
    }
}
