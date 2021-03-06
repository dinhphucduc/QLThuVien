﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QLTHUVIEN
{
    class XL_BANG: DataTable
    {
        #region Bien cuc bo
        public static String Chuoi_lien_ket;
        private SqlDataAdapter mBo_doc_ghi = new SqlDataAdapter();
        private SqlConnection mKet_noi;
        public String chuoi_csdl;
        private String mChuoi_SQL;
        private String mTen_bang;
        #endregion
        #region Cac thuoc tinh
        public String Chuoi_SQL
        {
            get { return mChuoi_SQL; }
            set { mChuoi_SQL = value; }
        }
        public String Ten_bang
        {
            get { return mTen_bang; }
            set { mTen_bang = value; }
        }
        public int So_dong
        {
            get { return this.DefaultView.Count; }
        }
        #endregion
        #region Cac phuong thuc khoi tao
        public XL_BANG() : base() { }
        // tao moi bang voi pTen_bang
        public XL_BANG(String pTen_bang)
        {
            mTen_bang = pTen_bang;
            Doc_bang();
        }
        //Tao moi bang voi cau truy van
        public XL_BANG(String pTen_bang, String pChuoi_SQL)
        {
            mTen_bang = pTen_bang;
            mChuoi_SQL = pChuoi_SQL;
            Doc_bang();
        }
        #endregion
        #region Lay du lieu bang
        public void Doc_bang()
        {
            if (mChuoi_SQL == null)
                mChuoi_SQL = "select * from " + mTen_bang;
            if (mKet_noi == null)
                mKet_noi = new SqlConnection(Chuoi_lien_ket);
            try
            {
                mBo_doc_ghi = new SqlDataAdapter(mChuoi_SQL, mKet_noi);
                mBo_doc_ghi.FillSchema(this, SchemaType.Mapped);
                mBo_doc_ghi.Fill(this);
                mBo_doc_ghi.RowUpdated += new SqlRowUpdatedEventHandler(mBo_doc_ghi_RowUpdated);
                SqlCommandBuilder Bo_phat_sinh = new SqlCommandBuilder(mBo_doc_ghi);
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public Boolean Ghi()
        {
            Boolean ket_qua = true;
            try
            {
                mBo_doc_ghi.Update(this);
                this.AcceptChanges();
            }
            catch(SqlException e)
            {
                this.RejectChanges();
                ket_qua = false;
            }
            return ket_qua;
        }
        public void Loc_du_lieu(String pDieu_kien)
        {
            try
            {
                this.DefaultView.RowFilter = pDieu_kien;
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public int Thuc_hien_lenh(String Lenh)
        {
            try
            {
                SqlCommand Cau_lenh = new SqlCommand(Lenh, mKet_noi);
                mKet_noi.Open();
                int ket_qua = Cau_lenh.ExecuteNonQuery();
                mKet_noi.Close();
                return ket_qua;
            }
            catch
            {
                return -1;
            }
        }
        public Object Thuc_hien_lenh_tinh_toan(String Lenh)
        {
            try
            {
                SqlCommand Cau_lenh = new SqlCommand(Lenh, mKet_noi);
                mKet_noi.Open();
                Object ket_qua = Cau_lenh.ExecuteScalar();
                mKet_noi.Close();
                return ket_qua;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region Xu ly su kien
        private void mBo_doc_ghi_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if((e.Status==UpdateStatus.Continue)&&(e.StatementType==StatementType.Insert))
            {
                SqlCommand cmd = new SqlCommand("select @@IDENTITY", mKet_noi);
                e.Row.ItemArray[0] = cmd.ExecuteScalar();
                e.Row.AcceptChanges();
            }
        }
        #endregion
    }
}
