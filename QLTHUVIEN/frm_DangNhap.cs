using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTHUVIEN
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            txtServerName.Text = "localhost";
            cbAuthentication.SelectedIndex = 0;
        }

        private void cbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hide = true;
            if (cbAuthentication.SelectedIndex == 0)
                hide = false;
            txtUserName.Enabled = hide;
            txtPassword.Enabled = hide;
        }

        private void btDangnhap_Click(object sender, EventArgs e)
        {
            if (cbAuthentication.SelectedIndex == 0)
                LOP.XL_BANG.Chuoi_lien_ket = "Data Source=" + txtServerName.Text + ";Initial Catalog=QLTHUVIEN;Intergrated Scurity=True";
            else
                LOP.XL_BANG.Chuoi_lien_ket = "Data Source=" + txtServerName.Text + ";Initial Catalog=QLTHUVIEN;User ID=" + txtUserName.Text + ";Password=" + txtPassword.text;
            sqlConnection cnn = new sqlConnection(LOP.XL_BANG.Chuoi_lien_ket);
            try
            {
                cnn.Open();
                MessageBox.Show("Ket noi thanh cong!");
                cnn.Close();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


