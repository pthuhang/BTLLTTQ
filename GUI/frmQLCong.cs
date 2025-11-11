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
    public partial class frmQLCong : Form
    {
        NhanVienBLL nvBLL = new NhanVienBLL();
        public frmQLCong()
        {
            InitializeComponent();
        }
        private void MoFormCon(Form childForm)
        {
            // Xóa form cũ trong panel nếu có
            panelViewQLCong.Controls.Clear();

            // Thiết lập form con để hiển thị trong panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

             //Thêm form con vào panel
            panelViewQLCong.Controls.Add(childForm);
            panelViewQLCong.Tag = childForm;

            childForm.Show();
        }
        private void frmQLCong_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            StyleButton(btnLoaiCong);
            StyleButton(btnTangCa);
            StyleButton(btnDuLieuChamCong);
        }

        private void btnLoaiCong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLCLoaiCong());
            HighlightTab(btnLoaiCong);
        }

        private void btnTangCa_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLCTangCa());
            HighlightTab(btnTangCa);
        }

        private void btnDuLieuChamCong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQLCDuLieuChamCong());
            HighlightTab(btnDuLieuChamCong);

        }

        private void HighlightTab(Button selectedButton)
        {
            Button[] tabs = { btnLoaiCong, btnTangCa, btnDuLieuChamCong };

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



    }
}
