using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Windows.Forms;
namespace PMS.Forms.HeThong
{
    public partial class frmNhomQuyen : XtraForm
    {
        public frmNhomQuyen()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void frmNhomQuyen_Load(object sender, EventArgs e)
        {
            //#region Init GridView
            //AppGridView.InitGridView(gridViewNhomQuyen, true, false, GridMultiSelectMode.RowSelect, false, false, "Nhấn vào đây để thêm dòng mới");
            //AppGridView.ShowField(gridViewNhomQuyen, new string[] { "TenNhomQuyen", "GhiChu", "QlNhomQuyen","LoaiLop"}
            //    , new string[] { "Tên nhóm quyền", "Ghi chú", "Nhóm quyền quản lý","Loại lớp" }
            //    , new int[] { 300, 300, 300,300 });
            //AppGridView.ShowEditor(gridViewNhomQuyen, NewItemRowPosition.Top);
            //AppGridView.RegisterControlField(gridViewNhomQuyen, "QlNhomQuyen", repositoryItemCheckedComboBoxEditNhomQuyenQL);
            //AppGridView.RegisterControlField(gridViewNhomQuyen, "LoaiLop", repositoryItemCheckedComboBoxEditLoaiLop);
            //#endregion

            #region Init Datasource
            //Nhóm quyền
            Load_NhomQuyen();
            //Loại lớp
            Load_LoaiLop();

            #endregion
        }

        private void Load_LoaiLop()
        {
            //repositoryItemCheckedComboBoxEditLoaiLop.SelectAllItemCaption = "Tất cả";
            //repositoryItemCheckedComboBoxEditLoaiLop.TextEditStyle = TextEditStyles.Standard;
            //repositoryItemCheckedComboBoxEditLoaiLop.Items.Clear();
            //TList<LoaiLop> tLoailop = DataServices.LoaiLop.GetAll();
            //List<CheckedListBoxItem> lstLoaiLop = new List<CheckedListBoxItem>();
            //string strItems = string.Empty;
            //for (int i = 0; i < tLoailop.Count; i++)
            //{
            //    strItems = tLoailop[i].MaQuanLy + " - " + tLoailop[i].TenLoaiLop;
            //    lstLoaiLop.Add(new CheckedListBoxItem(tLoailop[i].MaQuanLy, strItems, CheckState.Unchecked, true));
            //}
            //repositoryItemCheckedComboBoxEditLoaiLop.Items.AddRange(lstLoaiLop.ToArray());
            //repositoryItemCheckedComboBoxEditLoaiLop.SeparatorChar = ';';
        }

        private void Load_NhomQuyen()
        {
            //bindingSourceNhomQuyen.DataSource = DataServices.NhomQuyen.GetAll();
            //repositoryItemCheckedComboBoxEditNhomQuyenQL.SelectAllItemCaption = "Tất cả";
            //repositoryItemCheckedComboBoxEditNhomQuyenQL.TextEditStyle = TextEditStyles.Standard;
            //repositoryItemCheckedComboBoxEditNhomQuyenQL.Items.Clear();
            //TList<NhomQuyen> tList = DataServices.NhomQuyen.GetAll();

            //List<CheckedListBoxItem> list = new List<CheckedListBoxItem>();
            //foreach (NhomQuyen obj in tList)
            //{
            //    list.Add(new CheckedListBoxItem(obj.MaNhomQuyen, obj.TenNhomQuyen + " - " + obj.GhiChu, CheckState.Unchecked, true));
            //}
            //repositoryItemCheckedComboBoxEditNhomQuyenQL.Items.AddRange(list.ToArray());
            //repositoryItemCheckedComboBoxEditNhomQuyenQL.SeparatorChar = ';';
        }
        

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //NhomQuyen obj = bindingSourceNhomQuyen.Current as NhomQuyen;
            //if (obj != null)
            //{
            //    if (obj.IsNew)
            //    {
            //        bindingSourceNhomQuyen.Remove(obj);
            //        gridViewNhomQuyen.RefreshData();
            //    }
            //    else
            //    {
            //        obj.CancelChanges();
            //        gridViewNhomQuyen.RefreshData();
            //    }
            //}
        }

        private void btnLamTuoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Nhóm quyền
            Load_NhomQuyen();
            //Loai lop
            Load_LoaiLop();
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            Cursor.Current = Cursors.Default;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridViewNhomQuyen.FocusedRowHandle = -1;
            //TList<NhomQuyen> listNhomQuyen = bindingSourceNhomQuyen.DataSource as TList<NhomQuyen>;
            //if (listNhomQuyen != null)
            //{
            //    if (XtraMessageBox.Show("Bạn có muốn lưu các thay đổi không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //    {
            //        try
            //        {
            //            if (listNhomQuyen.IsValid)
            //            {
            //                bindingSourceNhomQuyen.EndEdit();
            //                DataServices.NhomQuyen.Save(listNhomQuyen);
            //                XtraMessageBox.Show("Bạn đã lưu các thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //                XtraMessageBox.Show(string.Format("Có {0} dòng chứa dữ liệu không hợp lệ.", listNhomQuyen.InvalidItems.Count), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        catch
            //        {
            //            XtraMessageBox.Show("Đã xảy ra lỗi trong quá trình lưu các thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void gridViewNhomQuyen_KeyDown(object sender, KeyEventArgs e)
        {
            //AppGridView.CopyCell(gridViewNhomQuyen, e);
        }

        private void gridViewNhomQuyen_KeyUp(object sender, KeyEventArgs e)
        {
           // AppGridView.DeleteSelectedRows(gridViewNhomQuyen, e);
        }

        private void gridViewNhomQuyen_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //NhomQuyen objNhomQuyen = e.Row as NhomQuyen;
            //if (objNhomQuyen != null)
            //{
            //    objNhomQuyen.AddValidationRuleHandler(RuleCheckDuplicate, "TenNhomQuyen");
            //    if (objNhomQuyen.IsValid)
            //        e.Valid = true;
            //    else
            //    {
            //        XtraMessageBox.Show(objNhomQuyen.Error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        e.Valid = false;
            //    }
            //}
            //if (e.Valid == true)
            //    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //else
            //{
            //    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    return;
            //}
        }

        private void gridViewNhomQuyen_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void frmNhomQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridControlNhomQuyen.Dispose();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AppGridView.DeleteSelectedRows(gridViewNhomQuyen);
        }

        private void frmNhomQuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
                this.Close();
        }

        private void frmNhomQuyen_Activated(object sender, EventArgs e)
        {
            
        }

        private void frmNhomQuyen_Deactivate(object sender, EventArgs e)
        {
        }
    }
}