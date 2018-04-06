using PMS_Object;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XuLyChung.XuLyDuLieu;

namespace PMS_Data
{
    public class LoaiChucNang_Data : PMSData
    {
        //private string[] _columnNames = { "Mã học vị", "Tên học vị", "HRM ID" };

        #region Hàm xử lý
        private void BoSungTenCot (ref DataTable dt, string[] columnNames) {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = columnNames[i];
            }
        }
        protected override PMSObject PhanTichDataRow(DataRow dr)
        {
            LoaiChucNang lcn = new LoaiChucNang();
            lcn.MaLoai = (int)XuLyKieuDuLieu.ThayTheNull(dr["MaLoai"], typeof(int));
            lcn.TenLoai = (string)XuLyKieuDuLieu.ThayTheNull(dr["TenLoai"], typeof(string));
            lcn.LoaiChucNangCha = LayDuLieu((int)(dr["LoaiChucNangCha"].ToString() == "" ? 0 : dr["LoaiChucNangCha"]));
            return lcn;
        }
        #endregion

        public List<LoaiChucNang> LayDuLieu()
        {
            List<LoaiChucNang> list = null;
            DataTable dt = DataProvider.ExecQueryStore("sp_LoaiChucNang_LayDuLieu");
            LoaiChucNang lcn = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                list = new List<LoaiChucNang>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add((LoaiChucNang)PhanTichDataRow(row));
                }
            }
            return list;
        }

        public LoaiChucNang LayDuLieu(int id)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@MaLoaiChucNang", id));
            DataTable dt = DataProvider.ExecQueryStore("sp_LoaiChucNang_LayTheoMa", lstParameter);
            if (dt != null && dt.Rows.Count > 0)
            {
                return (LoaiChucNang)PhanTichDataRow(dt.Rows[0]);
            }
            return null;
        }

        public override void Them(PMSObject obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
