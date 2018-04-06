using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.Drawing;

namespace XuLyGiaoDienDevExpress.ComboBox
{
    public static class AppRepositoryItemGridLookUpEdit
    {
        /// <summary>
        /// Thiet lap cau hinh luoi
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="autoFilter"></param>
        /// <param name="autoPopup"></param>
        /// <param name="textEditStyle"></param>
        public static void Init(RepositoryItemGridLookUpEdit repo, bool autoPopup, TextEditStyles textEditStyle)
        {
            //Show filter
            repo.View.OptionsView.ShowAutoFilterRow = true;
            repo.TextEditStyle = textEditStyle;
            repo.ImmediatePopup = autoPopup;
            repo.PopupFilterMode = PopupFilterMode.Contains;
            //grid.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < repo.View.Columns.Count; i++)
                repo.View.Columns[i].Visible = false;
        }
        
        /// <summary>
        /// Thiết lập cấu hình RepositoryItemGridLookUpEdit
        /// </summary>
        /// <param name="repo">RepositoryItemGridLookUpEdit cần thiết lập</param>
        /// <param name="showFields">Tên các cột trong datasource</param>
        /// <param name="showFieldNames">Tên các cột hiển thị</param>
        /// <param name="columnWidths">Chiều rộng các cột</param>
        /// <param name="valueMember">Giá trị để chọn</param>
        /// <param name="displayMember">Giá trị để hiển thị</param>
        /// <param name="width">Chiều rộng lưới</param>
        /// <param name="height">Chiều dài lưới</param>
        public static void Init(RepositoryItemGridLookUpEdit repo, string[] showFields, string[] showFieldNames
            , int[] columnWidths, string valueMember, string displayMember, int width, int height)
        {
            //Show filter
            repo.View.OptionsView.ShowAutoFilterRow = true;
            repo.TextEditStyle = TextEditStyles.Standard;
            repo.ImmediatePopup = true;
            repo.PopupFilterMode = PopupFilterMode.Contains;

            repo.ValueMember = valueMember;
            repo.DisplayMember = displayMember;
            repo.NullText = string.Empty;

            //grid.BestFitMode = BestFitMode.BestFit;
           
            foreach (GridColumn col in repo.View.Columns)
            {
                col.Visible = false;
            }

            ShowField(repo, showFields, showFieldNames, columnWidths);
            repo.PopupFormSize = new Size(width, height);
        }

        /// <summary>
        /// Thiet lap kich co popup cho form
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void InitPopupFormSize(RepositoryItemGridLookUpEdit grid, int width, int height)
        {
            grid.PopupFormSize = new Size(width, height);
        }

        /// <summary>
        /// Chỉ định các cột trong lưới được hiển thị
        /// </summary>
        /// <param name="grid">RepositoryItemGridLookUpEdit cần chỉ định</param>
        /// <param name="fieldName">Tên các cột trong datasource</param>
        /// <param name="caption">Tên các cột hiển thị</param>
        /// /// <param name="width">Chiều rộng các cột</param>
        public static void ShowField(RepositoryItemGridLookUpEdit grid, string[] fieldName, string[] caption, int[] width)
        {
            grid.View.OptionsView.ColumnAutoWidth = true;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.View.Columns.AddField(fieldName[i]);
                grid.View.Columns[fieldName[i]].Visible = true;
                grid.View.Columns[fieldName[i]].Caption = caption[i];
                grid.View.Columns[fieldName[i]].Width = width[i];
                grid.View.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }
    
        /// <summary>
        /// An di cac cot, dung sau ShowField
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        public static void HideField(RepositoryItemGridLookUpEdit grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.View.Columns[fieldName[i]].Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="visible"></param>
        public static void ShowAssignField(RepositoryItemGridLookUpEdit grid, string[] fieldName, bool visible)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.View.Columns[fieldName[i]].Visible = visible;
        }

    }
}
