using PMS_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XuLyChung.XuLyDuLieu;

namespace PMS_Data
{
    public class TaiKhoan_Data
    {
        //private string[] _columnNames = { "Mã học vị", "Tên học vị", "HRM ID" };
        private Quyen_Data _dataQuyen = new Quyen_Data();

        #region
        private void BoSungTenCot (ref DataTable dt, string[] columnNames) {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = columnNames[i];
            }
        }
        #endregion

        public DataTable LayDuLieu ()
        {
            //List<SqlParameter> lstParameter = new List<SqlParameter>();
            //lstParameter.Add(new SqlParameter("@GroupID", quyen.MaQuyen));
            DataTable dt = DataProvider.ExecQueryStore("sp_TaiKhoan_LayToanBo");
            //BoSungTenCot(ref dt, _columnNames);
            return dt;
        }

        public TaiKhoan LayDuLieu (string ten_dang_nhap, string mat_khau)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@TenDangNhap", ten_dang_nhap)); 
            lstParameter.Add(new SqlParameter("@MatKhau", mat_khau));   //Sai mật khẩu vẫn lấy ra tài khoản như mật khẩu sẽ NULL
            DataTable dtTaiKhoan = DataProvider.ExecQueryStore("sp_TaiKhoan_LayTheoTenDangNhapMatKhau", lstParameter);
            TaiKhoan tk = null;
            if (dtTaiKhoan != null && dtTaiKhoan.Rows.Count > 0)
            {
                tk = new TaiKhoan();
                tk.TenDangNhap = (string)XuLyKieuDuLieu.ThayTheNull(dtTaiKhoan.Rows[0]["TenDangNhap"], typeof(string));
                tk.MatKhau = (string)XuLyKieuDuLieu.ThayTheNull(dtTaiKhoan.Rows[0]["MatKhau"], typeof(string));
                tk.HoTen = (string)XuLyKieuDuLieu.ThayTheNull(dtTaiKhoan.Rows[0]["HoTen"], typeof(string));
                tk.NgayTao = (DateTime)XuLyKieuDuLieu.ThayTheNull(dtTaiKhoan.Rows[0]["NgayTao"], typeof(DateTime));
                tk.DsQuyen = _dataQuyen.LayDuLieu(tk);
                tk.TrangThai = (bool)XuLyKieuDuLieu.ThayTheNull(dtTaiKhoan.Rows[0]["TrangThai"], typeof(bool));
            }
            return tk;
        }
    }
}
