using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using PMS_Data;
using PMS_Object;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XuLyChung.XuLyDuLieu;
using XuLyGiaoDienDevExpress.ComboBox;

namespace PMS.Forms.HeThong
{
    public partial class frmChucNang : XtraForm
    {
        #region Biến toàn cục
        ChucNang_Data _dataChucNang = new ChucNang_Data();
        LoaiChucNang_Data _dataLoaiChucNang = new LoaiChucNang_Data();
        ChucNang _cnDuocChon;
        int _maLonNhat;
        #endregion

        public frmChucNang()
        {
            InitializeComponent();
        }

        #region Hàm xử lý
        void InRaMessageBox (object obj)
        {
            MessageBox.Show(((TreeListNode)obj)["TrangThaiThayDoi"].ToString());
        }

        void LuuThayDoi (object obj)
        {
            ChucNang cn = (ChucNang)obj;
            switch(cn.TrangThaiThayDoi)
            {
                case TrangThaiDuLieu.CapNhat:
                    _dataChucNang.CapNhat(cn);
                    break;
                case TrangThaiDuLieu.Them:
                    _dataChucNang.Them(cn);
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void frmChucNang_Load(object sender, System.EventArgs e)
        {
            #region Init loại chức năng
            AppRepositoryItemGridLookUpEdit.Init(repoLookupEditLoaiChucNang
                , new string[] { "TenLoai"}
                , new string[] { "Tên loại" }
                , new int[] { 100 }
                , "MaLoai", "TenLoai", 120, 200);
            repoLookupEditLoaiChucNang.DataSource = new LoaiChucNang_Data().LayDuLieu();
            cboPhanLoai.EditValue = 1;
            #endregion
            #region Init repo chức năng
            AppRepositoryItemGridLookUpEdit.Init(repoLookUpEditTenForm
                , new string[] { "Name", "FullName" }
                , new string[] { "Name", "FullName" }
                , new int[] { 150, 350 }
                , "FullName", "Name", 530, 400);

            repoLookUpEditTenForm.DataSource = Core.Manager.AppPlugin.Plugins; //bsChucNang;
            #endregion
            #region Init chức năng
            AppTreeList.Init(treeListChucNang
                , new string[] { "TenChucNang", "TenForm", "ThuTu", "PhanLoai", "HinhAnh", "MdiForm", "AnhChup", "TrangThai" }
                , new string[] { "Tên chức năng", "Vị trí", "Thứ tự", "Loại", "Biểu tượng", "MDI", "Ảnh chụp", "Trạng thái" }
                , new int[] { 250, 300, 40, 40, 50, 30, 50, 40 }, "MaChucNang", "MaChucNangCha" );
            treeListChucNang.Columns["TenForm"].ColumnEdit = repoLookUpEditTenForm;
            treeListChucNang.Columns["PhanLoai"].ColumnEdit = repoLookupEditLoaiChucNang;
            treeListChucNang.Columns["HinhAnh"].ColumnEdit = repoImageEditHinhAnh;
            treeListChucNang.Columns["AnhChup"].ColumnEdit = repoImageEditHinhAnh;
            List<ChucNang> list = new ChucNang_Data().LayDuLieu();
            bsChucNang.DataSource = list;
            treeListChucNang.ExpandAll();
            _maLonNhat = list[list.Count - 1].MaChucNang;
            #endregion
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AppTreeList.VisitTree(treeListChucNang, InRaMessageBox);
            //AppTreeList.VisitTree(treeListChucNang, LuuThayDoi);
            treeListChucNang.PostEditor();
            treeListChucNang.CloseEditor();
            bsChucNang.EndEdit();
            List<ChucNang> list = bsChucNang.DataSource as List<ChucNang>;
            XuLyDanhSach.DuyetDanhSach(list, LuuThayDoi);
        }

        private void treeListChucNang_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            TrangThaiDuLieu tt = (TrangThaiDuLieu)e.Node["TrangThaiThayDoi"];
            if (tt != TrangThaiDuLieu.Them && tt != TrangThaiDuLieu.Xoa) e.Node["TrangThaiThayDoi"] = TrangThaiDuLieu.CapNhat;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeListChucNang.FocusedNode["TrangThaiThayDoi"] = TrangThaiDuLieu.Xoa;
            treeListChucNang.FocusedNode.Visible = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<ChucNang> listChucNang = bsChucNang.DataSource as List<ChucNang>;
            if (listChucNang != null)
            {
                ChucNang cn = new ChucNang();
                //cn.TenChucNang = >> Tạo node trước, chỉnh sửa sau
                _maLonNhat++;
                cn.MaChucNang = _maLonNhat;
                cn.ChucNangCha = (int)cboPhanLoai.EditValue == 1 ? null : _cnDuocChon;
                cn.LoaiChucNang = _dataLoaiChucNang.LayDuLieu((int)cboPhanLoai.EditValue);
                cn.TrangThai = true;
                cn.ThuTu = 0;
                cn.TrangThaiThayDoi = TrangThaiDuLieu.Them;
                //cn.MdiForm = cboPhanLoai.EditValue.ToString() == "Item";
                //cn.Validate();
                //if (cn.IsValid)
                //{
                listChucNang.Add(cn);
                try
                {
                    //if (listChucNang.IsValid)
                    //DataServices.ChucNang.Save(listChucNang);
                    treeListChucNang.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Đã xảy ra lỗi trong quá trình thêm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //}
            }
        }

        private void btnLamTuoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void treeListChucNang_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                List<ChucNang> list = bsChucNang.DataSource as List<ChucNang>;
                _cnDuocChon = list.Find(cn => cn.MaChucNang == (int)e.Node.GetValue("MaChucNang"));
            }
        }
    }
}
