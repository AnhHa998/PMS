using PMS_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XuLyChung.XuLyDuLieu;
using XuLyChung.XuLyHinhAnh;

namespace PMS_Data
{
    public class Module_Data : PMSData
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
            PMSModule cn = new PMSModule();
            //cn.ModuleID = (string)XuLyKieuDuLieu.ThayTheNull(dr["ModuleID"], typeof(string));
            //cn.Order = (int)XuLyKieuDuLieu.ThayTheNull(dr["Order"], typeof(int));
            //cn.PMSModuleBacTren = LayDuLieu((string)XuLyKieuDuLieu.ThayTheNull(dr["MaChucNangBacTren"], typeof(string)));
            //cn.ModuleName = (string)XuLyKieuDuLieu.ThayTheNull(dr["ModuleName"], typeof(string));
            //cn.GUIName = (string)XuLyKieuDuLieu.ThayTheNull(dr["GUIName"], typeof(string));
            //cn.LoaiPMSModule = new LoaiPMSModule_Data().LayDuLieu((string)dr["PhanLoai"]);
            //cn.HinhAnh = AppImage.Base64StringToImage((string)XuLyKieuDuLieu.ThayTheNull(dr["HinhAnh"], null));
            //cn.MaGridView = (string)XuLyKieuDuLieu.ThayTheNull(dr["IDGridView"], typeof(string));
            //cn.SelectStore = (string)XuLyKieuDuLieu.ThayTheNull(dr["SelectStore"], typeof(string));
            //cn.InsertStore = (string)XuLyKieuDuLieu.ThayTheNull(dr["InsertStore"], typeof(string));
            //cn.DeleteStore = (string)XuLyKieuDuLieu.ThayTheNull(dr["DeleteStore"], typeof(string));
            //cn.UpdateStore = (string)XuLyKieuDuLieu.ThayTheNull(dr["UpdateStore"], typeof(string));
            //cn.TrangThai = (bool)XuLyKieuDuLieu.ThayTheNull(dr["TrangThai"], typeof(bool));
            return cn;
        }
        #endregion

        public List<PMSModule> LayDuLieu()
        {
            DataTable dt = DataProvider.ExecQueryStore("sp_Module_LayTatCa");
            List<PMSModule> lsPMSModule = new List<PMSModule>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lsPMSModule.Add((PMSModule)PhanTichDataRow(dr));
                }
            }
            return lsPMSModule;
        }

        public PMSModule LayDuLieu(string ma)
        {
            DataTable dt = DataProvider.ExecQueryStore("sp_Module_LayTheoMa", new SqlParameter("@MaChucNang", ma));
            if (dt != null && dt.Rows.Count > 0)
            {
                return (PMSModule)PhanTichDataRow(dt.Rows[0]);
            }
            return null;
        }
    
        public List<PMSModule> LayModuleCungCapDuLieu(string ma_module_phu_thuoc)
        {
            DataTable dt = DataProvider.ExecQueryStore("sp_Module_LayTheoModuleCanThiet", new SqlParameter("@ModuleID", ma_module_phu_thuoc));
            List<PMSModule> lsPMSModule = new List<PMSModule>();
            PMSModule module;
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string loaiModule = (string)dr["LoaiModule"];
                    switch (loaiModule)
                    {
                        case "GridLookupEdit":
                            module = new UI_ControlGridLookupEdit();
                            UI_ControlGridLookupEdit controlGrid = (UI_ControlGridLookupEdit)module;
                            controlGrid.ParameterName = (string)dr["ParameterName"];
                            controlGrid.X = (int)dr["X"];
                            controlGrid.Y = (int)dr["Y"];
                            controlGrid.Width = (int)dr["Width"];
                            controlGrid.Height = (int)dr["Height"];
                            UI_GridLookupEdit grid = new UI_GridLookupEdit();
                            grid.NullText = (string)dr["NullText"];
                            grid.ColumnField = (string)dr["ColumnField"];
                            grid.ColumnName = (string)dr["ColumnName"];
                            grid.ColumnWidth = (string)dr["ColumnWidth"];
                            grid.DisplayMember = (string)dr["DisplayMember"];
                            grid.ValueMember = (string)dr["ValueMember"];
                            grid.SelectStore = (string)dr["SelectStore"];
                            //grid.DefaultValue
                            controlGrid.GridLookup = grid;
                            break;
                        case "CheckedComboBoxEdit":
                            module = new UI_ControlCheckedComboBoxEdit();
                            UI_ControlCheckedComboBoxEdit controlCheck = (UI_ControlCheckedComboBoxEdit)module;
                            controlCheck.ParameterName = (string)dr["ParameterName"];
                            controlCheck.X = (int)dr["X"];
                            controlCheck.Y = (int)dr["Y"];
                            controlCheck.Width = (int)dr["Width"];
                            controlCheck.Height = (int)dr["Height"];
                            UI_CheckedComboBoxEdit check = new UI_CheckedComboBoxEdit();
                            check.NullText = (string)dr["NullText"];
                            check.SelectAllItemCaption = (string)dr["SelectAllItemCaption"];
                            check.SeparatorChar = (string)dr["SeparatorChar"];
                            check.Value = (string)dr["Value"];
                            check.Description = (string)dr["Description"];
                            check.CheckAll = (bool)dr["CheckAll"];
                            check.SelectStore = (string)dr["SelectStore"];
                            //check.DefaultValue
                            controlCheck.CheckedComboBox = check;
                            break;
                        default:
                            module = new PMSModule();
                            break;
                    }
                    module.ModuleID = (string)dr["ModuleID"];
                    module.ModuleName = (string)dr["ModuleName"];
                    module.GUIName = (string)dr["GUIName"];
                    module.Order = (int)dr["Order"];
                    lsPMSModule.Add(module);
                }
            }
            return lsPMSModule;
        }

        public override void Them(PMSObject obj)
        {
            PMSModule cn = (PMSModule)obj;
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            try
            {
                //lstParameter.Add(new SqlParameter("@MaChucNang", cn.ModuleID));
                //lstParameter.Add(new SqlParameter("@MaChucNangBacTren", cn.MaChucNangBacTren));
                //lstParameter.Add(new SqlParameter("@TenPMSModule", cn.ModuleName));
                //lstParameter.Add(new SqlParameter("@TenForm", cn.GUIName));
                //lstParameter.Add(new SqlParameter("@ThuTu", cn.Order));
                //lstParameter.Add(new SqlParameter("@PhanLoai", cn.PhanLoai));
                ////lstParameter.Add(new SqlParameter("@MdiForm", cn.MdiForm));
                //lstParameter.Add(new SqlParameter("@HinhAnh", AppImage.ImageToBase64String(cn.HinhAnh, ImageFormat.Png)));
                //lstParameter.Add(new SqlParameter("@HinhAnhForm", AppImage.ImageToBase64String(cn.AnhChup, ImageFormat.Png)));
                //lstParameter.Add(new SqlParameter("@IDGridView", cn.MaGridView));
                //lstParameter.Add(new SqlParameter("@SelectStore", cn.SelectStore));
                //lstParameter.Add(new SqlParameter("@InsertStore", cn.InsertStore));
                //lstParameter.Add(new SqlParameter("@DeleteStore", cn.DeleteStore));
                //lstParameter.Add(new SqlParameter("@UpdateStore", cn.UpdateStore));
                //lstParameter.Add(new SqlParameter("@TrangThai", cn.TrangThai));
                DataProvider.ExecNonQueryStore("sp_Module_Them", lstParameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void CapNhat(PMSObject cn)
        {
            try
            {
                List<SqlParameter> lstParameter = new List<SqlParameter>();
                //lstParameter.Add(new SqlParameter("@MaChucNang", cn.ModuleID));
                //lstParameter.Add(new SqlParameter("@MaChucNangBacTren", cn.MaChucNangBacTren));
                //lstParameter.Add(new SqlParameter("@TenPMSModule", cn.ModuleName));
                //lstParameter.Add(new SqlParameter("@TenForm", cn.GUIName));
                //lstParameter.Add(new SqlParameter("@ThuTu", cn.Order));
                //lstParameter.Add(new SqlParameter("@PhanLoai", cn.PhanLoai));
                //lstParameter.Add(new SqlParameter("@HinhAnh", AppImage.ImageToBase64String(cn.HinhAnh, ImageFormat.Png)));
                //lstParameter.Add(new SqlParameter("@HinhAnhForm", AppImage.ImageToBase64String(cn.AnhChup, ImageFormat.Png)));
                //lstParameter.Add(new SqlParameter("@IDGridView", cn.MaGridView));
                //lstParameter.Add(new SqlParameter("@SelectStore", cn.SelectStore));
                //lstParameter.Add(new SqlParameter("@InsertStore", cn.InsertStore));
                //lstParameter.Add(new SqlParameter("@DeleteStore", cn.DeleteStore));
                //lstParameter.Add(new SqlParameter("@UpdateStore", cn.UpdateStore));
                //lstParameter.Add(new SqlParameter("@TrangThai", cn.TrangThai));
                DataProvider.ExecNonQueryStore("sp_Module_CapNhat", lstParameter);
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

    }
}

