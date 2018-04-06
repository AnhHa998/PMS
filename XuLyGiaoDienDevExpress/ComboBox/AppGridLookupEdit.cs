using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System.Drawing;

namespace XuLyGiaoDienDevExpress.ComboBox
{
    public static class AppGridLookupEdit
    {
        /// <summary>
        /// Cai dat luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="autoFilter"></param>
        /// <param name="autoPopup"></param>
        /// <param name="textEditStyle"></param>
        public static void InitGridLookUp(GridLookUpEdit grid, bool autoFilter, bool autoPopup, TextEditStyles textEditStyle)
        {
            //Show filter
            grid.Properties.View.OptionsView.ShowAutoFilterRow = autoFilter;
            grid.Properties.TextEditStyle = textEditStyle;
            grid.Properties.ImmediatePopup = autoPopup;
            grid.Properties.PopupFilterMode = PopupFilterMode.Contains;
            //grid.Properties.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < grid.Properties.View.Columns.Count; i++)
                grid.Properties.View.Columns[i].Visible = false;
        }

        /// <summary>
        ///  Cai dat luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="autoFilter"></param>
        public static void InitGridLookUp(GridLookUpEdit grid, bool autoFilter, TextEditStyles textEditStyle)
        {
            //Show filter
            grid.Properties.View.OptionsView.ShowAutoFilterRow = autoFilter;
            grid.Properties.TextEditStyle = textEditStyle;
            grid.Properties.PopupFilterMode = PopupFilterMode.Contains;
            //grid.Properties.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < grid.Properties.View.Columns.Count; i++)
                grid.Properties.View.Columns[i].Visible = false;
        }

        /// <summary>
        ///  Cai dat luoi
        /// </summary>
        /// <param name="grid">GridLookupEdit cần khởi tạo</param>
        /// <param name="showFields">Tên các thuộc tính cần thể hiện</param>
        /// <param name="showFieldNames">Tên cột cho các thuộc tính cần thể hiện</param>
        /// <param name="valueMember">Tên thuộc tính giá trị</param>
        /// <param name="displayMember">Tên thuộc tính thể hiện</param>
        /// <param name="width">Chiều rộng popup</param>
        /// <param name="height">Chiều cao popup</param>
        public static void InitGridLookUp(GridLookUpEdit grid, string[] showFields, string[] showFieldNames, int[] columnWidth, string valueMember, string displayMember, int width, int height)
        {
            //Show filter
            grid.Properties.View.OptionsView.ShowAutoFilterRow = true;
            grid.Properties.TextEditStyle = TextEditStyles.Standard;
            grid.Properties.PopupFilterMode = PopupFilterMode.Contains;
            grid.Properties.NullText = string.Empty;
            grid.Properties.View.OptionsView.ColumnAutoWidth = true;
            grid.Properties.ValueMember = valueMember;
            grid.Properties.DisplayMember = displayMember;

            for (int i = 0; i < grid.Properties.View.Columns.Count; i++)
                grid.Properties.View.Columns[i].Visible = false;

            for (int i = 0; i < showFields.Length; i++)
            {
                grid.Properties.View.Columns.AddField(showFields[i]);
                grid.Properties.View.Columns[showFields[i]].Visible = true;
                grid.Properties.View.Columns[showFields[i]].Caption = showFieldNames[i];
                grid.Properties.View.Columns[showFields[i]].Width = columnWidth[i];
                grid.Properties.View.Columns[showFields[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }

            grid.Properties.PopupFormSize = new Size(width, height);

            //int j = 0;  //Cách này buộc showField phải đúng thứ tự với field mặc định của grid
            //for (int i = 0; i < grid.Properties.View.Columns.Count; i++)
            //{
            //    if(grid.Properties.View.Columns[i].FieldName.Equals(showFields[j]))
            //    {
            //        //grid.Properties.View.Columns.AddField(showFields[j]);
            //        grid.Properties.View.Columns[showFields[j]].Visible = true;
            //        grid.Properties.View.Columns[showFields[j]].Caption = showFieldNames[j];
            //        grid.Properties.View.Columns[showFields[j]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            //        j++;
            //    }
            //    else grid.Properties.View.Columns[i].Visible = false;
            //}

        }


        /// <summary>
        /// Thiet lap kich co popup cho form
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void InitPopupFormSize(GridLookUpEdit grid, int width, int height)
        {
            grid.Properties.PopupFormSize = new Size(width, height);
        }

        /// <summary>
        /// Hien thi field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        public static void ShowField(GridLookUpEdit grid, string[] fieldName, string[] caption)
        {
            grid.Properties.View.OptionsView.ColumnAutoWidth = true;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Properties.View.Columns.AddField(fieldName[i]);
                grid.Properties.View.Columns[fieldName[i]].Visible = true;
                grid.Properties.View.Columns[fieldName[i]].Caption = caption[i];
                grid.Properties.View.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        /// <summary>
        /// Hien thi field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        public static void ShowField(GridLookUpEdit grid, string[] fieldName, string[] caption, int[] width)
        {
            grid.Properties.View.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Properties.View.Columns.AddField(fieldName[i]);
                grid.Properties.View.Columns[fieldName[i]].Visible = true;
                grid.Properties.View.Columns[fieldName[i]].Caption = caption[i];
                grid.Properties.View.Columns[fieldName[i]].Width = width[i];
                grid.Properties.View.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        /// <summary>
        /// An di cac cot, dung sau ShowField
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        public static void HideField(GridLookUpEdit grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Properties.View.Columns[fieldName[i]].Visible = false;
        }

        /// <summary>
        /// Lấy ra đối tượng đang được chọn trong GridLookupEdit
        /// </summary>
        /// <param name="cbo"> GridLookupEdit chứa đối tượng cần lấy </param>
        public static object GetSelectedItem(GridLookUpEdit cbo)
        {
            System.Windows.Forms.BindingSource bs = cbo.Properties.DataSource as System.Windows.Forms.BindingSource;
            return bs[cbo.Properties.GetIndexByKeyValue(cbo.EditValue.ToString())];
        }

        /// <summary>
        /// Cho phép chọn một dòng trong GridLookupEdit
        /// </summary>
        /// <param name="cbo"> GridLookupEdit chứa dòng cần chọn </param>
        /// /// <param name="index"> Chỉ số dòng cần chọn </param>
        public static void SetSelectedIndex(GridLookUpEdit cbo, int index)
        {
            cbo.EditValue = cbo.Properties.GetKeyValue(index);
        }
    }
}
