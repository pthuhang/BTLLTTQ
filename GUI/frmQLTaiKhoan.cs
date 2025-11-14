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
    public partial class frmQLTaiKhoan : Form
    {
        public frmQLTaiKhoan()
        {
            InitializeComponent();
        }
        private void MoFormCon(Form childForm)
        {
            panelViewQLTaiKhoan.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelViewQLTaiKhoan.Controls.Add(childForm);
            panelViewQLTaiKhoan.Tag = childForm;

            childForm.Show();
        }
        private void HighlightTab(Button selectedButton)
        {
            Button[] tabs = { btnTaiKhoanCN, btnTaiKhoanNV };

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
        private void frmQLTaiKhoan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            StyleButton(btnTaiKhoanCN);
            StyleButton(btnTaiKhoanNV);
        }


        private void btnTaiKhoanNV_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLTaiKhoanNhanVien());
            HighlightTab(btnTaiKhoanNV);
        }
    }
}
