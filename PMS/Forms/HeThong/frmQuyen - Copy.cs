using DevExpress.Common.Grid;
using DevExpress.XtraEditors;
using PMS_Data;
using PMS_Object;
using System.Collections.Generic;
using XuLyChung.XuLyDuLieu;

namespace PMS.Forms.HeThong
{
    public partial class frmQuyen : XtraForm
    {
        Quyen_Data _dataQuyen = new Quyen_Data();
        List<string> _dsMaCanXoa = new List<string>();

        #region Hàm xử lý nghiệp vụ
        void ThaoTacDuLieu (object obj)
        {
            Quyen q = (Quyen)obj;
            switch (q.TrangThaiThayDoi)
            {
                case TrangThaiDuLieu.Them:
                    _dataQuyen.Them(q);
                    break;
                case TrangThaiDuLieu.CapNhat:
                    //_dataQuyen.CapNhat(q);
                    break;
            }
        }
        #endregion

        public frmQuyen()
        {
            InitializeComponent();
        }

        private void frmQuyen_Load(object sender, System.EventArgs e)
        {
            #region gridview
            AppGridView.Init(gridViewQuyen, true, false, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
                , true, true, "Nhấn vào đây để thêm dòng mới");
            AppGridView.ShowField(gridViewQuyen
                , new string[] { "MaQuyen", "TenQuyen", "GhiChu" }
                , new string[] { "Mã quyền", "Tên quyền", "Ghi chú" }
                , new int[] { 100, 200, 300 });
            bsQuyen.DataSource = _dataQuyen.LayDuLieu();
            #endregion
        }

        private void gridViewQuyen_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (AppGridView.IsNewRow(gridViewQuyen,e.RowHandle))
            {
                gridViewQuyen.SetRowCellValue(e.RowHandle, "TrangThaiThayDoi", TrangThaiDuLieu.Them);
            }
            else
            {
                gridViewQuyen.SetRowCellValue(e.RowHandle, "TrangThaiThayDoi", TrangThaiDuLieu.CapNhat);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _dsMaCanXoa.Add((string)gridViewQuyen.GetRowCellValue(gridViewQuyen.FocusedRowHandle, "MaQuyen"));
            AppGridView.DeleteSelectedRows(gridViewQuyen);
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<Quyen> list = bsQuyen.DataSource as List<Quyen>;
            XuLyDanhSach.DuyetDanhSach<Quyen>(list, ThaoTacDuLieu);
            foreach (string ma in _dsMaCanXoa)
            {
                //_dataQuyen.Xoa(ma);
            }
        }
    }
}
