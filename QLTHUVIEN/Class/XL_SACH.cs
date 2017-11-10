using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;


namespace QLTHUVIEN
{
    class XL_SACH : XL_BANG
    {
        #region cac ham khoi tao
        public XL_SACH() : base("SACH") { }
        public XL_SACH(string pChuoi_SQL) : base("SACH", pChuoi_SQL) { }
        #endregion
        #region Cac ham xu ky su kien
        public void Tim(DataRow p_Dong_dieu_kien)
        {
            string chuoi_DK = "";
            ArrayList mang_DK = new ArrayList();
            if (p_Dong_dieu_kien["MaSach"] != null)
                mang_DK.Add("MaSach LIKE '*" + p_Dong_dieu_kien["MaSach"] + "*");
            if (p_Dong_dieu_kien["TenNXB"] != null)
                mang_DK.Add("TenNXB LIKE '*" + p_Dong_dieu_kien["TenNXB"] + "*'");
            if (mang_DK.Count > 0)
            {
                for (int i = 0; i < mang_DK.Count; i++)
                    if (i == 0) chuoi_DK = mang_DK[i].ToString();
                    else chuoi_DK += "AND" + mang_DK[i];
            }
            Loc_du_lieu(chuoi_DK);
        }
        #endregion
    }
}
