using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PMS_Data
{
    public class CoSoDuLieu
    {
        const string strStoredDanhSachThamSo = "sp_LayDanhSachThamSo";
        const string strStoredDanhSachThuocTinh = "sp_LayDanhSachThuocTinh";
        const string strStoredDanhSachBang = "sp_LayDanhSachBang";
        const string strStoredDanhSachView = "sp_LayDanhSachView";
        const string strDanhSachThuocTinhTieuDeLuoi = "sp_GetDanhSachThuocTinh_TieuDeLuoi";

        public static DataTable LayDanhSachBang()
        {
            DataTable tbl = new DataTable();
            tbl = DataProvider.ExecQueryStore(strStoredDanhSachBang);
            return tbl;
        }

        public static DataTable LayDanhSachThuocTinhTieuDeLuoi()
        {
            DataTable tbl = new DataTable();
            tbl = DataProvider.ExecQueryStore(strDanhSachThuocTinhTieuDeLuoi);
            return tbl;
        }

        public static DataTable LayDanhSachView()
        {
            DataTable tbl = new DataTable();
            tbl = DataProvider.ExecQueryStore(strStoredDanhSachView);
            return tbl;
        }

        public static DataTable LayDanhSachThuocTinh(string strTenBang)
        {
            DataTable tbl = new DataTable();
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@TenTable";
            par.Value = strTenBang;
            lstParameter.Add(par);
            tbl = DataProvider.ExecQueryStore(strStoredDanhSachThuocTinh, lstParameter);
            return tbl;
        }
        
        public static DataTable LayDanhSachThamSo(string strTenStore)
        {
            DataTable tbl = new DataTable();
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@TenStore",strTenStore);
            tbl = DataProvider.ExecQueryStore(strStoredDanhSachThamSo, ls);
            return tbl;
        }

        public static List<string> lstParameter(string strTenBang)
        {
            List<string> Lst = new List<string>();
            foreach (DataRow item in LayDanhSachThuocTinh(strTenBang).Rows)
            {
                Lst.Add(item["name"].ToString());   //tên thuộc tính trong bảng
            }
            return Lst;
        }
    }
}
