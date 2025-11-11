using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.GUI
{
    public partial class frmThongTinCaNhan : Form
    {
        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            label1.Left = (panel5.ClientSize.Width - label1.Width) / 2;
            label1.Top = (panel5.ClientSize.Height - label1.Height) / 2;

            label22.Left = (panel8.ClientSize.Width - label22.Width) / 2;
            label22.Top = (panel8.ClientSize.Height - label22.Height) / 2;

            label23.Left = (panel29.ClientSize.Width - label23.Width) / 2;
            label23.Top = (panel29.ClientSize.Height - label23.Height) / 2;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
