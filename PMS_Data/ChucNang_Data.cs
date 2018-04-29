using PMS_Object;
using System;
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
        Module_Data _dataModule = new Module_Data();

        #region Hàm xử lý
        protected override PMSObject PhanTichDataRow(DataRow dr)
        {
            ChucNang cn = new ChucNang();
            cn.ModuleID = (string)XuLyKieuDuLieu.ThayTheNull(dr["ModuleID"], typeof(string));
            cn.Order = (int)XuLyKieuDuLieu.ThayTheNull(dr["Order"], typeof(int));
            //cn.ChucNangBacTren = LayDuLieu((string)XuLyKieuDuLieu.ThayTheNull(dr["MaChucNangBacTren"], typeof(string)));
            cn.MaChucNangBacTren = (string)XuLyKieuDuLieu.ThayTheNull(dr["MaChucNangBacTren"], typeof(string));
            cn.ModuleName = (string)XuLyKieuDuLieu.ThayTheNull(dr["ModuleName"], typeof(string));
            cn.GUIName = (string)XuLyKieuDuLieu.ThayTheNull(dr["GUIName"], typeof(string));
            cn.LoaiChucNang = new LoaiChucNang_Data().LayDuLieu((string)dr["PhanLoai"]);
            cn.HinhAnh = AppImage.Base64StringToImage((string)XuLyKieuDuLieu.ThayTheNull(dr["HinhAnh"], null));
            cn.MaGridView = (string)XuLyKieuDuLieu.ThayTheNull(dr["IDGridView"], typeof(string));
            cn.SelectStore = (string)XuLyKieuDuLieu.ThayTheNull(dr["SelectStore"], typeof(string));
            cn.InsertStore = (string)XuLyKieuDuLieu.ThayTheNull(dr["InsertStore"], typeof(string));
            cn.DeleteStore = (string)XuLyKieuDuLieu.ThayTheNull(dr["DeleteStore"], typeof(string));
            cn.UpdateStore = (string)XuLyKieuDuLieu.ThayTheNull(dr["UpdateStore"], typeof(string));
            cn.TrangThai = (bool)XuLyKieuDuLieu.ThayTheNull(dr["TrangThai"], typeof(bool));
            cn.ListModuleGetData = _dataModule.LayModuleCungCapDuLieu(cn.ModuleID);
            return cn;
        }
        #endregion

        public List<ChucNang> LayDuLieu()
        {
            DataTable dt = DataProvider.ExecQueryStore("sp_ChucNang_LayTatCa");
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

        public ChucNang LayDuLieu(string ma)
        {
            DataTable dt = DataProvider.ExecQueryStore("sp_ChucNang_LayTheoMa", new SqlParameter("@MaChucNang", ma));
            if (dt != null && dt.Rows.Count > 0)
            {
                return (ChucNang)PhanTichDataRow(dt.Rows[0]);
            }
            return null;
        }
        
        public List<ChucNang> LayDuLieu(Quyen quyen)
        {
            DataTable dt = DataProvider.ExecQueryStore("sp_ChucNang_LayTheoQuyen", new SqlParameter("@MaQuyen", quyen.MaQuyen));
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

        public List<ChucNang> LayDuLieu (string ma_bac_tren, string ma_loai, bool trang_thai)
        {
            List<SqlParameter> lsParam = new List<SqlParameter>();
            lsParam.Add(new SqlParameter("@MaChucNang", ma_bac_tren));
            lsParam.Add(new SqlParameter("@MaLoaiChucNang", ma_loai));
            lsParam.Add(new SqlParameter("@TrangThai", trang_thai));
            DataTable dt = DataProvider.ExecQueryStore("sp_ChucNang_LayChucNangBacDuoi",lsParam);
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
                lstParameter.Add(new SqlParameter("@MaChucNang", cn.ModuleID));
                lstParameter.Add(new SqlParameter("@MaChucNangBacTren", cn.MaChucNangBacTren));
                lstParameter.Add(new SqlParameter("@TenChucNang", cn.ModuleName));
                lstParameter.Add(new SqlParameter("@TenForm", cn.GUIName));
                lstParameter.Add(new SqlParameter("@ThuTu", cn.Order));
                lstParameter.Add(new SqlParameter("@PhanLoai", cn.PhanLoai));
                //lstParameter.Add(new SqlParameter("@MdiForm", cn.MdiForm));
                lstParameter.Add(new SqlParameter("@HinhAnh", AppImage.ImageToBase64String(cn.HinhAnh, ImageFormat.Png)));
                lstParameter.Add(new SqlParameter("@HinhAnhForm", AppImage.ImageToBase64String(cn.AnhChup, ImageFormat.Png)));
                lstParameter.Add(new SqlParameter("@IDGridView", cn.MaGridView));
                lstParameter.Add(new SqlParameter("@SelectStore", cn.SelectStore));
                lstParameter.Add(new SqlParameter("@InsertStore", cn.InsertStore));
                lstParameter.Add(new SqlParameter("@DeleteStore", cn.DeleteStore));
                lstParameter.Add(new SqlParameter("@UpdateStore", cn.UpdateStore));
                lstParameter.Add(new SqlParameter("@TrangThai", cn.TrangThai));
                DataProvider.ExecNonQueryStore("sp_ChucNang_Them", lstParameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CapNhat(ChucNang cn)
        {
            try
            {
                List<SqlParameter> lstParameter = new List<SqlParameter>();
                lstParameter.Add(new SqlParameter("@MaChucNang", cn.ModuleID));
                lstParameter.Add(new SqlParameter("@MaChucNangBacTren", cn.MaChucNangBacTren));
                lstParameter.Add(new SqlParameter("@TenChucNang", cn.ModuleName));
                lstParameter.Add(new SqlParameter("@TenForm", cn.GUIName));
                lstParameter.Add(new SqlParameter("@ThuTu", cn.Order));
                lstParameter.Add(new SqlParameter("@PhanLoai", cn.PhanLoai));
                lstParameter.Add(new SqlParameter("@HinhAnh", AppImage.ImageToBase64String(cn.HinhAnh, ImageFormat.Png)));
                lstParameter.Add(new SqlParameter("@HinhAnhForm", AppImage.ImageToBase64String(cn.AnhChup, ImageFormat.Png)));
                lstParameter.Add(new SqlParameter("@IDGridView", cn.MaGridView));
                lstParameter.Add(new SqlParameter("@SelectStore", cn.SelectStore));
                lstParameter.Add(new SqlParameter("@InsertStore", cn.InsertStore));
                lstParameter.Add(new SqlParameter("@DeleteStore", cn.DeleteStore));
                lstParameter.Add(new SqlParameter("@UpdateStore", cn.UpdateStore));
                lstParameter.Add(new SqlParameter("@TrangThai", cn.TrangThai));
                DataProvider.ExecNonQueryStore("sp_ChucNang_CapNhat", lstParameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Xoa(object ma)
        {
            throw new System.NotImplementedException();
        }

        public override void CapNhat(PMS_Object.PMSObject obj)
        {
            throw new System.NotImplementedException();
        }

        //public void CapNhat(int ma_chuc_nang, int ma_chuc_nang_cha, string ten_chuc_nang, string ten_form, int thu_tu, int phan_loai
        //    , bool MDI, Image hinh_anh, Image anh_chup, bool trang_thai)
        //{
        //    List<SqlParameter> lstParameter = new List<SqlParameter>();
        //    lstParameter.Add(new SqlParameter("@MaChucNang", ma_chuc_nang));
        //    lstParameter.Add(new SqlParameter("@MaChucNangBacTren", ma_chuc_nang_cha));
        //    lstParameter.Add(new SqlParameter("@ModuleName", ten_chuc_nang));
        //    lstParameter.Add(new SqlParameter("@GUIName", ten_form));
        //    lstParameter.Add(new SqlParameter("@Order", thu_tu));
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

