using PMS_Object;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XuLyChung.XuLyDuLieu;

namespace PMS_Data
{
    public class Quyen_Data : PMSData
    {
        //private string[] _columnNames = { "Mã học vị", "Tên học vị", "HRM ID" };
        private ChucNang_Data _dataChucNang = new ChucNang_Data();

        public List<Quyen> LayDuLieu()
        {
            DataTable dtQuyen = DataProvider.ExecQueryStore("sp_Quyen_LayDuLieu");
            List<Quyen> lsQuyen = new List<Quyen>();
            if (dtQuyen != null && dtQuyen.Rows.Count > 0)
            {
                foreach (DataRow dr in dtQuyen.Rows)
                {
                    Quyen q = new Quyen();
                    q.MaQuyen = (string)XuLyKieuDuLieu.ThayTheNull(dr["MaQuyen"], typeof(string));
                    q.TenQuyen = (string)XuLyKieuDuLieu.ThayTheNull(dr["TenQuyen"], typeof(string));
                    q.GhiChu = (string)XuLyKieuDuLieu.ThayTheNull(dr["GhiChu"], typeof(string));
                    q.DsChucNang = _dataChucNang.LayDuLieu(q);
                    lsQuyen.Add(q);
                }
            }
            return lsQuyen;
        }

        public Quyen LayDuLieu (int ma_quyen)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@MaQuyen", ma_quyen));
            DataTable dtQuyen = DataProvider.ExecQueryStore("sp_Quyen_LayQuyen", lstParameter);
            Quyen q = null;
            if (dtQuyen != null && dtQuyen.Rows.Count > 0)
            {
                q = new Quyen();
                //tk.ID = (int)dt.Rows[0]["ID"];
                //tk.ThuTu = (int)dt.Rows[0]["ThuTu"];
                //tk.ChucNangCha = LayDuLieu((int)dt.Rows[0]["ParentID"]);
                //tk.TenQuyen = (string)dt.Rows[0]["TenQuyen"];
                //tk.TenForm = (string)dt.Rows[0]["TenForm"];
                //tk.KieuForm = (string)dt.Rows[0]["KieuForm"];
                //tk.PhanLoai = (string)dt.Rows[0]["PhanLoai"];
                //tk.IsMenu = (bool)dt.Rows[0]["IsMenu"];
            }
            return q;
        }

        public List<Quyen> LayDuLieu (TaiKhoan tai_khoan)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@TenDangNhap", tai_khoan.TenDangNhap));
            DataTable dtQuyen = DataProvider.ExecQueryStore("sp_Quyen_LayTheoTaiKhoan", lstParameter);
            List<Quyen> lsQuyen = new List<Quyen>();
            if (dtQuyen != null && dtQuyen.Rows.Count > 0)
            {
                foreach (DataRow dr in dtQuyen.Rows)
                {
                    Quyen q = new Quyen();
                    q.MaQuyen = (string)XuLyKieuDuLieu.ThayTheNull(dr["MaQuyen"], typeof(string));
                    q.TenQuyen = (string)XuLyKieuDuLieu.ThayTheNull(dr["TenQuyen"], typeof(string));
                    q.GhiChu = (string)XuLyKieuDuLieu.ThayTheNull(dr["GhiChu"], typeof(string));
                    q.DsChucNang = _dataChucNang.LayDuLieu(q);
                    lsQuyen.Add(q);
                }
            }
            return lsQuyen;
        }

        public override void CapNhat(PMSObject obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Them(PMSObject obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Xoa(object ma)
        {
            throw new System.NotImplementedException();
        }

        protected override PMSObject PhanTichDataRow(DataRow dr)
        {
            throw new System.NotImplementedException();
        }
    }
}
