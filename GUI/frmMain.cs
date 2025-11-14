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
        private string tenDangNhap;
        private string maNV;
        public frmMain(string tenDangNhap, string maNV)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
            this.maNV = maNV;

            label1.Text = "Xin chào, " + tenDangNhap + "!";
            label1.Left = (panel3.ClientSize.Width - label1.Width) / 2;

        }
        public frmMain()
        {
            InitializeComponent();
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
        private void HighlightTab(Button selectedButton)
        {
            Button[] tabs = { btnQLNhanSu, btnQLLuong, btnQLCong, btnThuongPhat, btnThongTinCaNhan };

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


        private void frmMain_Load(object sender, EventArgs e)
        {
            StyleButton(btnQLNhanSu);
            StyleButton(btnQLCong);
            StyleButton(btnQLLuong);
            StyleButton(btnThongTinCaNhan);
            StyleButton(btnThuongPhat);
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
        private void btnThuongPhat_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLThuongPhat());
            HighlightTab(btnThuongPhat);
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

        private void panel3_Resize(object sender, EventArgs e)
        {
            label1.Left = (panel3.ClientSize.Width - label1.Width) / 2;
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLTTCaNhan(tenDangNhap, maNV));
            HighlightTab(btnThongTinCaNhan);
        }
    }
}
