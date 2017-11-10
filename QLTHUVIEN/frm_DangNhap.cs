using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLTHUVIEN
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }



        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            txtServerName.Text= "localhost";
            cbAuthentication.SelectedIndex = 0;
        }

        private void cbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hide = true;
            if (cbAuthentication == 0)
                hide = false;
            txtUserName.Enable = hide;
            txtPassword.Enable = hide;
        }

        private void btDangnhap_Click(object sender, EventArgs e)
        {
            if (cbAuthentication.SelectedIndex == 0)
                LOP.XL_BANG.Chuoi_lien_ket = "Data Source=" + txtServerName.Text + ";Initial Catalog=QLTHUVIEN;Intergrated Scurity=True";
            else
                LOP.XL_BANG.Chuoi_lien_ket = "Data Source=" + txtServerName.Text + ";Initial Catalog=QLTHUVIEN;User ID=" + txtUserName.Text + ";Password=" + txtPasswoed.text;
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

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
