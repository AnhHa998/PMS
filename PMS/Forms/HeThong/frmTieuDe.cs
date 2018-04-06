using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PMS.Services;
using PMS.Entities;
using DevExpress.Common.Grid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using System.Collections.Generic;
using Libraries.BLL.FormHeThong;
using System.Reflection;
using System.Linq;

namespace PMS.UI.Forms.HeThong
{
    public partial class frmTieuDe : XtraForm
    {
        private int _userID = -1;
        string[] strIDColumns = new string[] { "IdFileName", "IdTitleVn", "IdTitleEn", "IdSize","Stt","MaTruong","TrangThai", "IdFrom", "IdAn"};
        string[] strFieldColumns = new string[] { "ID", "Tiếng việt", "Tiếng anh", "Kích cỡ","STT","Mã trường","Trạng thái","Tên form","Dùng"};
        int[] iSizeColumns = new int[] {100,120,120,70,50,80,80,150,60};
        public frmTieuDe()
        {
            InitializeComponent();
        }
              
        private void InitData()
        {
            bindingSourceTieuDe.DataSource = DataServices.TieuDe.GetAll();
            gridControlTieuDe.DataSource = bindingSourceTieuDe;          
        }

        private void frmXemNguoiDung_Load(object sender, EventArgs e)
        {
            ShowFile();
            InitData();
        }


        private void ShowFile()
        {
            AppGridView.InitGridView(gridViewTieuDe, true, false, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false);
            AppGridView.ShowField(gridViewTieuDe, strIDColumns, strFieldColumns, iSizeColumns);
            AppGridView.ShowEditor(gridViewTieuDe, NewItemRowPosition.Top);
            AppGridView.AlignHeader(gridViewTieuDe, strIDColumns, DevExpress.Utils.HorzAlignment.Center);
            AppGridView.ReadOnlyColumn(gridViewTieuDe, new string[] { "IdFileName" });
            AppGridView.RegisterControlField(gridViewTieuDe, "IdFrom", repositoryItemCheckedComboBoxEditIdFrom);
            Load_IdFrom();      
        }

        private void Load_IdFrom()
        {
           // repositoryItemCheckedComboBoxEditIdFrom.SelectAllItemCaption = "Tất cả";
           // repositoryItemCheckedComboBoxEditIdFrom.TextEditStyle = TextEditStyles.Standard;
           // repositoryItemCheckedComboBoxEditIdFrom.Items.Clear();
           //List<AppForm>lstChucNang= GetForms();
           // List<CheckedListBoxItem> lstLoaiLop = new List<CheckedListBoxItem>();
           // string strItems = string.Empty;
           // for (int i = 0; i < lstChucNang.Count; i++)
           // {
           //     strItems = lstChucNang[i].Name;
           //     lstLoaiLop.Add(new CheckedListBoxItem(lstChucNang[i].Name, strItems, CheckState.Unchecked, true));
           // }
           // repositoryItemCheckedComboBoxEditIdFrom.Items.AddRange(lstLoaiLop.ToArray());
           // repositoryItemCheckedComboBoxEditIdFrom.SeparatorChar = ';';
        }

        private void btnLamTuoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitData();
            Cursor.Current = Cursors.Default;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewTieuDe.FocusedRowHandle = -1;
            TList<TaiKhoan> listAppUser = bindingSourceTieuDe.DataSource as TList<TaiKhoan>;
            if (listAppUser != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn lưu các thay đổi không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bindingSourceTieuDe.EndEdit();
                        TList<PMS.Entities.HeThong> listAppSystems = DataServices.HeThong.GetByUserId(_userID);
                        foreach (TaiKhoan user in listAppUser)
                        {
                            PMS.Entities.HeThong objHeThong = listAppSystems.Find(p => p.UserId == _userID && p.ParentId == user.MaTaiKhoan);
                            if (user.Chon)
                            {
                                if (objHeThong == null)
                                    listAppSystems.Add(new PMS.Entities.HeThong() { UserId = _userID, ParentId = user.MaTaiKhoan });
                            }
                            else
                            {
                                if (objHeThong != null)
                                    objHeThong.MarkToDelete();
                            }
                        }
                        if (listAppSystems.IsValid)
                        {
                            DataServices.HeThong.Save(listAppSystems);
                            DevExpress.XtraEditors.XtraMessageBox.Show("Bạn đã lưu các thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("Có {0} dòng dữ liệu không hợp lệ.", listAppSystems.InvalidItems.Count), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch
                    {
                        XtraMessageBox.Show("Đã xảy ra lỗi trong quá trình lưu các thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        
    }
}