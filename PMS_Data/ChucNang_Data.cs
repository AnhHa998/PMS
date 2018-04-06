using PMS_Object;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using XuLyChung.XuLyDuLieu;
using XuLyChung.XuLyHinhAnh;

namespace PMS_Data
{
    public class ChucNang_Data : PMSData
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
            ChucNang cn = new ChucNang();
            cn.MaChucNang = (int)XuLyKieuDuLieu.ThayTheNull(dr["MaChucNang"], typeof(int));
            cn.ThuTu = (int)XuLyKieuDuLieu.ThayTheNull(dr["ThuTu"], typeof(int));
            cn.ChucNangCha = LayDuLieu((int)(dr["MaChucNangCha"].ToString() == "" ? 0 : dr["MaChucNangCha"]));
            cn.TenChucNang = (string)XuLyKieuDuLieu.ThayTheNull(dr["TenChucNang"], typeof(string));
            cn.TenForm = (string)XuLyKieuDuLieu.ThayTheNull(dr["TenForm"], typeof(string));
            //cn.MdiForm = (bool)AppDataType.ThayTheNull(dr["MdiForm"], typeof(bool));
            cn.LoaiChucNang = new LoaiChucNang_Data().LayDuLieu((int)dr["PhanLoai"]);
            cn.HinhAnh = AppImage.Base64StringToImage((string)XuLyKieuDuLieu.ThayTheNull(dr["HinhAnh"], null));
            cn.TrangThai = (bool)XuLyKieuDuLieu.ThayTheNull(dr["TrangThai"], typeof(bool));
            return cn;
        }
        #endregion

        public List<ChucNang> LayDuLieu()
        {
            DataTable dt = DataProvider.ExecQueryStore("sp_ChucNang_LayDuLieu");
            List<ChucNang> lsChucNang = new List<ChucNang>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lsChucNang.Add((ChucNang)PhanTichDataRow(dr));
                }
            }
            return lsChucNang;
        }

        public ChucNang LayDuLieu(int id)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@MaChucNang", id));
            DataTable dt = DataProvider.ExecQueryStore("sp_ChucNang_LayTheoMa", lstParameter);
            if (dt != null && dt.Rows.Count > 0)
            {
                return (ChucNang)PhanTichDataRow(dt.Rows[0]);
            }
            return null;
        }
        
        public List<ChucNang> LayDuLieu(Quyen quyen)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@MaQuyen", quyen.MaQuyen));
            DataTable dt = DataProvider.ExecQueryStore("sp_ChucNang_LayTheoQuyen", lstParameter);
            List<ChucNang> lsChucNang = new List<ChucNang>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lsChucNang.Add((ChucNang)PhanTichDataRow(dr));
                }
            }
            return lsChucNang;
        }

        public override void Them(PMSObject obj)
        {
            ChucNang cn = (ChucNang)obj;
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            try
            {
                lstParameter.Add(new SqlParameter("@MaChucNang", cn.MaChucNang));
                lstParameter.Add(new SqlParameter("@MaChucNangCha", cn.MaChucNangCha));
                lstParameter.Add(new SqlParameter("@TenChucNang", cn.TenChucNang));
                lstParameter.Add(new SqlParameter("@TenForm", cn.TenForm));
                lstParameter.Add(new SqlParameter("@ThuTu", cn.ThuTu));
                lstParameter.Add(new SqlParameter("@PhanLoai", cn.PhanLoai));
                //lstParameter.Add(new SqlParameter("@MdiForm", cn.MdiForm));
                lstParameter.Add(new SqlParameter("@HinhAnh", AppImage.ImageToBase64String(cn.HinhAnh, ImageFormat.Png)));
                lstParameter.Add(new SqlParameter("@HinhAnhForm", AppImage.ImageToBase64String(cn.AnhChup, ImageFormat.Png)));
                lstParameter.Add(new SqlParameter("@TrangThai", cn.TrangThai));
                DataProvider.ExecNonQueryStore("sp_ChucNang_Them", lstParameter);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public void CapNhat(ChucNang cn)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@MaChucNang", cn.MaChucNang));
            lstParameter.Add(new SqlParameter("@MaChucNangCha", cn.MaChucNangCha));
            lstParameter.Add(new SqlParameter("@TenChucNang", cn.TenChucNang));
            lstParameter.Add(new SqlParameter("@TenForm", cn.TenForm));
            lstParameter.Add(new SqlParameter("@ThuTu", cn.ThuTu));
            lstParameter.Add(new SqlParameter("@PhanLoai", cn.PhanLoai));
            //lstParameter.Add(new SqlParameter("@MdiForm", cn.MdiForm));
            lstParameter.Add(new SqlParameter("@HinhAnh", AppImage.ImageToBase64String(cn.HinhAnh, ImageFormat.Png)));
            lstParameter.Add(new SqlParameter("@HinhAnhForm", AppImage.ImageToBase64String(cn.AnhChup, ImageFormat.Png)));
            lstParameter.Add(new SqlParameter("@TrangThai", cn.TrangThai));
            try
            {
                DataProvider.ExecNonQueryStore("sp_ChucNang_Update", lstParameter);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        //public void CapNhat(int ma_chuc_nang, int ma_chuc_nang_cha, string ten_chuc_nang, string ten_form, int thu_tu, int phan_loai
        //    , bool MDI, Image hinh_anh, Image anh_chup, bool trang_thai)
        //{
        //    List<SqlParameter> lstParameter = new List<SqlParameter>();
        //    lstParameter.Add(new SqlParameter("@MaChucNang", ma_chuc_nang));
        //    lstParameter.Add(new SqlParameter("@MaChucNangCha", ma_chuc_nang_cha));
        //    lstParameter.Add(new SqlParameter("@TenChucNang", ten_chuc_nang));
        //    lstParameter.Add(new SqlParameter("@TenForm", ten_form));
        //    lstParameter.Add(new SqlParameter("@ThuTu", thu_tu));
        //    lstParameter.Add(new SqlParameter("@PhanLoai", phan_loai));
        //    lstParameter.Add(new SqlParameter("@MdiForm", MDI));
        //    lstParameter.Add(new SqlParameter("@HinhAnh", AppImage.ImageToBase64String(hinh_anh, ImageFormat.Png)));
        //    lstParameter.Add(new SqlParameter("@HinhAnhForm"
        //        , anh_chup == null ? null : Encoding.UTF8.GetString(AppImage.ImageToByteArray(anh_chup, ImageFormat.Png))));
        //    lstParameter.Add(new SqlParameter("@TrangThai", trang_thai));
        //    try
        //    {
        //        DataProvider.ExecNonQueryStore("sp_ChucNang_Update", lstParameter);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw;
        //    }
        //}

        
    }
}
