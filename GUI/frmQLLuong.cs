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
    public partial class frmQLLuong : Form
    {
        public frmQLLuong()
        {
            InitializeComponent();
        }

        private void MoFormCon(Form childForm)
        {
            panelViewQLLuong.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelViewQLLuong.Controls.Add(childForm);
            panelViewQLLuong.Tag = childForm;

            childForm.Show();
        }
        private void HighlightTab(Button selectedButton)
        {
            Button[] tabs = { btnPhuCap, btnBangLuong };

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

        private void frmQLLuong_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            StyleButton(btnPhuCap);
            StyleButton(btnBangLuong);
        }

        private void btnPhuCap_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLLPhuCap());
            HighlightTab(btnPhuCap);
        }

        private void btnBangLuong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLLBangLuong());
            HighlightTab(btnBangLuong);
        }
    }
}
