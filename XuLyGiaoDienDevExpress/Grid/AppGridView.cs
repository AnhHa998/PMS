﻿using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace XuLyGiaoDienDevExpress.Grid
{
    public static class AppGridView
    {
        #region Hap map
        private static Hashtable HASH;

        private static void InitHashMap()
        {
            if(HASH == null)
            {
                HASH = new Hashtable();
                HASH.Add("RowSelect", GridMultiSelectMode.RowSelect);
                HASH.Add("CellSelect", GridMultiSelectMode.CellSelect);
                HASH.Add("CheckBoxRowSelect", GridMultiSelectMode.CheckBoxRowSelect);
                HASH.Add("None", FixedStyle.None);
                HASH.Add("Left", FixedStyle.Left);
                HASH.Add("Right", FixedStyle.Right);
                HASH.Add("Default", HorzAlignment.Default);
                HASH.Add("Center", HorzAlignment.Center);
                HASH.Add("Near", HorzAlignment.Near);
                HASH.Add("Far", HorzAlignment.Far);
            }
        }
        #endregion

        /// <summary>
        /// Init luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="autoFilter"></param>
        /// <param name="multiSelect"></param>
        /// <param name="selectMode"></param>
        /// <param name="detailButton"></param>
        /// <param name="groupPanel"></param>
        public static void Init(GridView grid, bool autoFilter, bool multiSelect, GridMultiSelectMode selectMode, bool detailButton, bool groupPanel)
        {
            //Show filter
            grid.OptionsView.ShowAutoFilterRow = autoFilter;
            //Show multi select
            grid.OptionsSelection.MultiSelect = multiSelect;
            //Show multi select mode
            grid.OptionsSelection.MultiSelectMode = selectMode;
            //Show detail button
            grid.OptionsView.ShowDetailButtons = detailButton;
            //Show group panel
            grid.OptionsView.ShowGroupPanel = groupPanel;

            grid.GroupPanelText = "Kéo và thả tên cột vào đây để gom nhóm.";

            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].Visible = false;
        }

        /// <summary>
        /// Cai dat luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="autoFilter"></param>
        /// <param name="multiSelect"></param>
        /// <param name="selectMode"></param>
        /// <param name="detailButton"></param>
        /// <param name="groupPanel"></param>
        /// <param name="textNewRow"></param>
        public static void Init(GridView grid, bool autoFilter, bool multiSelect, GridMultiSelectMode selectMode, bool detailButton, bool groupPanel, string textNewRow)
        {
            //Show filter
            grid.OptionsView.ShowAutoFilterRow = autoFilter;
            //Show multi select
            grid.OptionsSelection.MultiSelect = multiSelect;
            //Show multi select mode
            grid.OptionsSelection.MultiSelectMode = selectMode;
            //Show detail button
            grid.OptionsView.ShowDetailButtons = detailButton;
            //Show group panel
            grid.OptionsView.ShowGroupPanel = groupPanel;
            //Show text new row
            if(textNewRow != null && textNewRow.Trim() != "")
            {
                ShowEditor(grid, NewItemRowPosition.Top);
                grid.NewItemRowText = textNewRow;
            }

            grid.GroupPanelText = "Kéo và thả tên cột vào đây để gom nhóm.";

            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].Visible = false;
        }

        
        public static void Init (GridView grid, bool multiSelect, string multiSelectMode, bool showDetailButton, bool showGroupPanel
            , int wordWrapHeader, string newItemRowText, string groupPanelText, string columnFields, string columnNames, string columnWidths
            , string hideFields, string readOnlyFields, string fixedFields, string fixedStyle)
        {
            InitHashMap();

            grid.OptionsView.ShowAutoFilterRow = true;
            grid.OptionsSelection.MultiSelect = multiSelect;
            grid.OptionsSelection.MultiSelectMode = (GridMultiSelectMode)HASH[multiSelectMode]; 
            grid.OptionsView.ShowDetailButtons = showDetailButton;
            grid.OptionsView.ShowGroupPanel = showGroupPanel;

            ShowEditor(grid, NewItemRowPosition.Top);
            if (newItemRowText != null && newItemRowText.Trim() != "")
            {
                ShowEditor(grid, NewItemRowPosition.Top);
                grid.NewItemRowText = newItemRowText;
            }

            if (groupPanelText != null && groupPanelText.Trim() != "") grid.GroupPanelText = groupPanelText;

            for (int i = 0; i < grid.Columns.Count; i++) grid.Columns[i].Visible = false;

            string[] strArrFieldName = columnFields.Split(';');
            string[] strArrCaption = columnNames.Split(';');

            string[] strArrWidth = columnWidths.Split(';');
            int[] iArrWidth = new int[strArrWidth.Length];
            for (int i = 0; i < strArrWidth.Length; i++) iArrWidth[i] = int.Parse(strArrWidth[i]);

            string[] strArrHideField = hideFields.Split(';');
            string[] strArrReadOnlyField = readOnlyFields.Split(';');
            string[] strArrFixedField = fixedFields.Split(';');

            ShowField(grid, strArrFieldName, strArrCaption, iArrWidth);
            HideField(grid, strArrHideField);
            ReadOnlyColumn(grid, strArrReadOnlyField);
            FixedField(grid, strArrFixedField, fixedStyle.Trim() == "" ? FixedStyle.None : (FixedStyle)HASH[fixedStyle]);

            WordWrapHeader(grid, wordWrapHeader);
        }

        /// <summary>
        /// Hien thi editor cho phep edit
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="pos"></param>
        public static void ShowEditor(GridView grid, NewItemRowPosition pos)
        {
            //Show edit
            grid.FocusedRowHandle = grid.RowCount - 1;
            grid.OptionsView.NewItemRowPosition = pos;
        }

        /// <summary>
        /// Tinh tong gia tri trong cot
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="displayFormat"></param>
        /// <param name="summaryType"></param>
        public static void SummaryField(GridView grid, string fieldName, string displayFormat, DevExpress.Data.SummaryItemType summaryType)
        {
            grid.OptionsView.ShowFooter = true;
            grid.Columns[fieldName].SummaryItem.FieldName = fieldName;
            grid.Columns[fieldName].SummaryItem.DisplayFormat = displayFormat;
            grid.Columns[fieldName].SummaryItem.SummaryType = summaryType;
        }

        /// <summary>
        /// Tinh tong gia tri trong nhieu cot
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="displayFormat"></param>
        /// <param name="summaryType"></param>
        public static void SummaryField(GridView grid, string[] fieldNames, string displayFormat, DevExpress.Data.SummaryItemType summaryType)
        {
            grid.OptionsView.ShowFooter = true;
            for (int i = 0; i < fieldNames.Length; i++)
            {
                grid.Columns[fieldNames[i]].SummaryItem.FieldName = fieldNames[i];
                grid.Columns[fieldNames[i]].SummaryItem.DisplayFormat = displayFormat;
                grid.Columns[fieldNames[i]].SummaryItem.SummaryType = summaryType;
            }
        }

        /// <summary>
        /// Hien lai cac cot da bi an
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        public static void ShowField(GridView grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].Visible = true;
        }

        /// <summary>
        /// Hien thi cac field trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        public static void ShowField(GridView grid, string[] fieldName, string[] caption)
        {
            grid.OptionsView.ColumnAutoWidth = true;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns.AddField(fieldName[i]);
                grid.Columns[fieldName[i]].Visible = true;
                grid.Columns[fieldName[i]].Caption = caption[i];
                grid.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        /// <summary>
        /// Hien thi cac field trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        public static void ShowField(GridView grid, string[] fieldName, string[] caption, int[] width)
        {
            if (fieldName == null) return;
            grid.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < fieldName.Length; i++)
            {
                if (fieldName[i].Trim() == "") continue;
                grid.Columns.AddField(fieldName[i]);
                grid.Columns[fieldName[i]].Visible = true;
                grid.Columns[fieldName[i]].Caption = caption[i];
                grid.Columns[fieldName[i]].Width = width[i];
                grid.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        /// <summary>
        /// Hien thi cac field trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        public static void ShowField(GridView grid, List<string> fieldName, List<string> caption, List<int> width)
        {
            grid.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < fieldName.Count; i++)
            {
                grid.Columns.AddField(fieldName[i]);
                grid.Columns[fieldName[i].ToString()].Visible = true;
                grid.Columns[fieldName[i].ToString()].Caption = caption[i];
                grid.Columns[fieldName[i].ToString()].Width = width[i];
                grid.Columns[fieldName[i].ToString()].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        /// <summary>
        /// Set column width cho cac field trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        public static void SetColumnWidth(GridView grid, string[] fieldName, int[] width)
        {
            grid.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < fieldName.Length; i++)
            {
                //grid.Columns[fieldName[i]].Visible = true;
                grid.Columns[fieldName[i]].Width = width[i];
                grid.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        /// <summary>
        /// Chi dinh cac filed khong duoc phep edit
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        public static void ReadOnlyColumn(GridView grid, string[] fieldName)
        {
            if (fieldName == null) return;
            for (int i = 0; i < fieldName.Length; i++)
            {
                if (fieldName[i].Trim() == "") continue;
                grid.Columns[fieldName[i]].OptionsColumn.AllowEdit = false;
            }
        }

        /// <summary>
        /// Khong cho phep edit toan bo cot tren luoi
        /// </summary>
        /// <param name="grid"></param>
        public static void ReadOnlyColumn(GridView grid)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].OptionsColumn.AllowEdit = false;
        }

        /// <summary>
        /// Cho phep edit toan bo cot tren luoi
        /// </summary>
        /// <param name="grid"></param>
        public static void AllowEditColumn(GridView grid)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].OptionsColumn.AllowEdit = true;
        }

        /// <summary>
        /// Chi dinh cac filed khong duoc phep edit
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        public static void AllowEditColumn(GridView grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].OptionsColumn.AllowEdit = true;

        }

        /// <summary>
        /// Thiet lap co dinh cac field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="style"></param>
        public static void FixedField(GridView grid, string[] fieldName, FixedStyle style)
        {
            if (fieldName == null) return;
            for (int i = 0; i < fieldName.Length; i++)
            {
                if (fieldName[i].Trim() == "") continue;
                grid.Columns[fieldName[i]].Fixed = style;
            }
        }

        /// <summary>
        /// Chi dinh cac field khong sort
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        public static void UnSortField(GridView grid, string[] fieldName)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        }

        /// <summary>
        /// Gan control RepositoryItem vao mot cell trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlField(GridView grid, string fieldName, DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Gan control RepositoryItemDateEdit vao mot cell trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlField(GridView grid, string fieldName, DevExpress.XtraEditors.Repository.RepositoryItemDateEdit item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Gan control RepositoryItemImageEdit vao mot cell trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlField(GridView grid, string fieldName, DevExpress.XtraEditors.Repository.RepositoryItemImageEdit item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Gan control RepositoryItemTextEdit vao mot cell trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlField(GridView grid, string fieldName, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        public static void RegisterControlField(GridView grid, string fieldName, DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Gan control RepositoryItemSpinEdit vao mot cell trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlField(GridView grid, string fieldName, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Gan cac control RepositoryItem[] vao cac cell trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlField(GridView grid, string[] fieldName, DevExpress.XtraEditors.Repository.RepositoryItem[] item)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].ColumnEdit = item[i];
        }

        /// <summary>
        /// Dinh dang field trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="align"></param>
        public static void AlignField(GridView grid, string[] fieldName, DevExpress.Utils.HorzAlignment align)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].AppearanceCell.TextOptions.HAlignment = align;
        }

        /// <summary>
        /// Dinh dang tieu de cac field trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="align"></param>
        public static void AlignHeader(GridView grid, string[] fieldName, HorzAlignment align)
        {
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].AppearanceHeader.TextOptions.HAlignment = align;
        }

        public static void AlignHeader(GridView grid, string fieldName, string style)
        {
            string[] arrFieldName = fieldName.Split(';');
            HorzAlignment alignStyle = style.Trim() == "" ? HorzAlignment.Default : (HorzAlignment)HASH[style];
            for (int i = 0; i < arrFieldName.Length; i++)
                grid.Columns[arrFieldName[i]].AppearanceHeader.TextOptions.HAlignment = alignStyle;
        }

        /// <summary>
        /// Copy du lieu mot cell va paste vao cac cell co trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="e"></param>
        public static void CopyCell(GridView grid, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.UnicodeText))
                {
                    string text = (string)iData.GetData(DataFormats.UnicodeText);
                    Array.ForEach(grid.GetSelectedCells(), cell =>
                    {
                        try
                        {
                            cell.Column.View.SetRowCellValue(cell.RowHandle, cell.Column, text);
                            cell.Column.View.RefreshData();
                        }
                        catch { return; }
                    });
                }
            }
        }

        /// <summary>
        /// Xoa cac dong da chon trong luoi
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="e"></param>
        public static void DeleteSelectedRows(GridView grid, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (grid.RowCount > 0)
                    if (grid.GetSelectedRows().Length > 0)
                        if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng đã chọn không ?", grid.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            grid.DeleteSelectedRows();
        }

        /// <summary>
        /// Xoa cac dong da chon trong luoi
        /// </summary>
        /// <param name="grid"></param>
        public static void DeleteSelectedRows(GridView grid)
        {
            if (grid.RowCount > 0)
                if (grid.GetSelectedRows().Length > 0)
                    if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng đã chọn không ?", grid.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        grid.DeleteSelectedRows();
        }

        /// <summary>
        /// Dinh dang field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="formatType"></param>
        /// <param name="formatString"></param>
        public static void FormatDataField(GridView grid, string fieldName, DevExpress.Utils.FormatType formatType, string formatString)
        {
            if (formatType == DevExpress.Utils.FormatType.Custom)
                grid.Columns[fieldName].DisplayFormat.Format = new BaseFormatter();
            grid.Columns[fieldName].DisplayFormat.FormatString = formatString;
        }

        /// <summary>
        /// Dinh dang nhieu field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="formatType"></param>
        /// <param name="formatString"></param>
        public static void FormatDataField(GridView grid, string[] fieldNames, DevExpress.Utils.FormatType formatType, string formatString)
        {
            for (int i = 0; i < fieldNames.Length; i++)
            {
                if (formatType == DevExpress.Utils.FormatType.Custom)
                    grid.Columns[fieldNames[i]].DisplayFormat.Format = new BaseFormatter();
                grid.Columns[fieldNames[i]].DisplayFormat.FormatString = formatString;
            }
        }

        /// <summary>
        /// Dinh dang mau cho filed
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="foreColor"></param>
        public static void ForeColorFieldAppearance(GridView grid, string fieldName, Color foreColor)
        {
            grid.Columns[fieldName].AppearanceCell.ForeColor = foreColor;
        }

        /// <summary>
        /// Dinh dang background cho field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="backColor"></param>
        public static void BackColorFieldAppearance(GridView grid, string fieldName, Color backColor)
        {
            grid.Columns[fieldName].AppearanceCell.BackColor = backColor;
        }

        /// <summary>
        /// Dinh dang background cho field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="backColor"></param>
        public static void BackColorFieldAppearance(GridView grid, string[] fieldNames, Color backColor)
        {
            for (int i = 0; i < fieldNames.Length; i++)
            {
                grid.Columns[fieldNames[i]].AppearanceCell.BackColor = backColor;
            }
        }

        /// <summary>
        /// Dinh dang background cho field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        /// <param name="font"></param>
        public static void FieldAppearance(GridView grid, string fieldName, Color foreColor, Color backColor, Font font)
        {
            grid.Columns[fieldName].AppearanceCell.ForeColor = foreColor;
            grid.Columns[fieldName].AppearanceCell.BackColor = backColor;
            grid.Columns[fieldName].AppearanceCell.Font = font;
        }

        /// <summary>
        /// Dinh dang background cho field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        /// <param name="font"></param>
        public static void FieldAppearance(GridView grid, string[] fieldNames, Color foreColor, Color backColor, Font font)
        {
            for (int i = 0; i < fieldNames.Length; i++)
            {
                grid.Columns[fieldNames[i]].AppearanceCell.ForeColor = foreColor;
                grid.Columns[fieldNames[i]].AppearanceCell.BackColor = backColor;
                grid.Columns[fieldNames[i]].AppearanceCell.Font = font;
            }
        }

        /// <summary>
        /// Dinh dang field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="font"></param>
        public static void FieldAppearance(GridView grid, string fieldName, Font font)
        {
            grid.Columns[fieldName].AppearanceCell.Font = font;
        }

        /// <summary>
        /// Dinh dang field voi dieu kien kem theo
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="condition"></param>
        /// <param name="color"></param>
        /// <param name="value"></param>
        public static void ConditionsAdjustment(GridView grid, string fieldName, FormatConditionEnum condition, Color color, object value)
        {
            StyleFormatCondition cn = new StyleFormatCondition(condition, grid.Columns[fieldName], null, value);
            cn.Appearance.BackColor = color;
            grid.FormatConditions.Add(cn);
        }

        /// <summary>
        /// Dinh dang field voi dieu kien ap dung cho row
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="condition"></param>
        /// <param name="applyToRow"></param>
        /// <param name="color"></param>
        /// <param name="value"></param>
        public static void ConditionsAdjustment(GridView grid, string fieldName, FormatConditionEnum condition, bool applyToRow, Color color, object value)
        {
            StyleFormatCondition cn = new StyleFormatCondition(condition, grid.Columns[fieldName], null, value);
            cn.Appearance.BackColor = color;
            cn.ApplyToRow = applyToRow;
            grid.FormatConditions.Add(cn);
        }

        /// <summary>
        /// Kiểm tra một dòng trong GridView có phải là dòng mới được thêm vào hay không
        /// </summary>
        /// <param name="grid">GridView cần kiểm</param>
        /// <param name="rowIndex">Dòng cần kiểm</param>
        /// <returns>true nếu là dòng mới, ngược lại là fase</returns>
        public static bool IsNewRow(GridView grid, int rowIndex)
        {
            int visibleIndex = grid.GetVisibleIndex(rowIndex);
            int dataControllerRowIndex = grid.DataController.GetControllerRowHandle(visibleIndex);
            return grid.DataController.GetListSourceRowIndex(dataControllerRowIndex) == GridControl.InvalidRowHandle;
        }

        ///// <summary>
        ///// Kiem tra du lieu 1 field co bi trung hay khong
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="dt"></param>
        ///// <param name="fieldName"></param>
        ///// <param name="value"></param>
        ///// <param name="e"></param>
        ///// <param name="errorType"></param>
        //public static void DuplicateValidateRow(GridView grid, DataTable dt, string fieldName, object value, DevExpress.XtraEditors.DXErrorProvider.ErrorType errorType, ValidateRowEventArgs e)
        //{
        //    if (grid.Columns.View.ActiveFilter.IsEmpty)
        //    {
        //        if (dt.Select(string.Format("{0}='{1}'", fieldName, value)).Length > 1)
        //        {
        //            e.Valid = false;
        //            grid.Columns.View.SetColumnError(grid.Columns[fieldName], string.Format("{0} hiện tại đã có.", value), errorType);
        //        }
        //        else
        //            e.Valid = true;
        //    }
        //}

        ///// <summary>
        ///// Kiem tra du lieu 1 field co bi trung hay khong
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="count"></param>
        ///// <param name="fieldName"></param>
        ///// <param name="value"></param>
        ///// <param name="errorType"></param>
        ///// <param name="e"></param>
        //public static void DuplicateValidateRow(GridView grid, int count, string fieldName, object value, DevExpress.XtraEditors.DXErrorProvider.ErrorType errorType, ValidateRowEventArgs e)
        //{
        //    if (grid.Columns.View.ActiveFilter.IsEmpty)
        //    {
        //        if (count > 1)
        //        {
        //            e.Valid = false;
        //            grid.Columns.View.SetColumnError(grid.Columns[fieldName], string.Format("{0} hiện tại đã có.", value), errorType);
        //        }
        //        else
        //            e.Valid = true;
        //    }
        //}

        ///// <summary>
        ///// Kiem tra du lieu 1 field co bi trung hay khong
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="dt"></param>
        ///// <param name="fieldName"></param>
        ///// <param name="value"></param>
        ///// <param name="errorText"></param>
        ///// <param name="errorType"></param>
        ///// <param name="e"></param>
        //public static void DuplicateValidateRow(GridView grid, DataTable dt, string fieldName, object value, string errorText, DevExpress.XtraEditors.DXErrorProvider.ErrorType errorType, ValidateRowEventArgs e)
        //{
        //    if (grid.Columns.View.ActiveFilter.IsEmpty)
        //    {
        //        if (dt.Select(string.Format("{0}='{1}'", fieldName, value)).Length > 1)
        //        {
        //            e.Valid = false;
        //            grid.Columns.View.SetColumnError(grid.Columns[fieldName], errorText, errorType);
        //        }
        //        else
        //            e.Valid = true;
        //    }
        //}

        ///// <summary>
        ///// Kiem tra du lieu 1 field co bi trung hay khong
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="count"></param>
        ///// <param name="fieldName"></param>
        ///// <param name="value"></param>
        ///// <param name="errorText"></param>
        ///// <param name="errorType"></param>
        ///// <param name="e"></param>
        //public static void DuplicateValidateRow(GridView grid, int count, string fieldName, object value, string errorText, DevExpress.XtraEditors.DXErrorProvider.ErrorType errorType, ValidateRowEventArgs e)
        //{
        //    if (grid.Columns.View.ActiveFilter.IsEmpty)
        //    {
        //        if (count > 1)
        //        {
        //            e.Valid = false;
        //            grid.Columns.View.SetColumnError(grid.Columns[fieldName], errorText, errorType);
        //        }
        //        else
        //            e.Valid = true;
        //    }
        //}

        ///// <summary>
        ///// Kiem tra du lieu tren 1 field co bi trung lap khong truoc khi luu vao database
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="count"></param>
        ///// <param name="fieldName"></param>
        ///// <param name="value"></param>
        ///// <param name="errorText"></param>
        ///// <param name="errorType"></param>
        ///// <returns></returns>
        //public static bool IsDuplicateValidateRow(GridView grid, int count, string fieldName, object value, string errorText, DevExpress.XtraEditors.DXErrorProvider.ErrorType errorType)
        //{
        //    if (grid.Columns.View.ActiveFilter.IsEmpty)
        //    {
        //        if (count > 1)
        //        {
        //            grid.Columns.View.SetColumnError(grid.Columns[fieldName], errorText, errorType);
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Kiem tra du lieu tren 1 field co bi trung lap khong truoc khi luu vao database
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="dt"></param>
        ///// <param name="fieldName"></param>
        ///// <param name="errorType"></param>
        ///// <returns></returns>
        //public static bool IsDuplicateValidateRow(GridView grid, DataTable dt, string fieldName, DevExpress.XtraEditors.DXErrorProvider.ErrorType errorType)
        //{
        //    Hashtable ht = new Hashtable();
        //    if (grid.Columns.View.ActiveFilter.IsEmpty)
        //    {
        //        foreach (DataRow r in dt.Rows)
        //        {
        //            if (!ht.Contains(r[fieldName]))
        //                ht.Add(r[fieldName], r[fieldName]);
        //            else
        //                grid.Columns.View.SetColumnError(grid.Columns[fieldName], string.Format("{0} hiện tại đã có.", r[fieldName]), errorType);
        //        }
        //    }
        //    return dt.Rows.Count == ht.Count;
        //}

        ///// <summary>
        ///// Kiem tra du lieu tren 1 field co bi trung lap khong truoc khi luu vao database
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="dt"></param>
        ///// <param name="fieldName"></param>
        ///// <param name="errorText"></param>
        ///// <param name="errorType"></param>
        ///// <returns></returns>
        //public static bool IsDuplicateValidateRow(GridView grid, DataTable dt, string fieldName, string errorText ,DevExpress.XtraEditors.DXErrorProvider.ErrorType errorType)
        //{
        //    Hashtable ht = new Hashtable();
        //    if (grid.Columns.View.ActiveFilter.IsEmpty)
        //    {
        //        foreach (DataRow r in dt.Rows)
        //        {
        //            if (!ht.Contains(r[fieldName]))
        //                ht.Add(r[fieldName], r[fieldName]);
        //            else
        //                grid.Columns.View.SetColumnError(grid.Columns[fieldName], errorText, errorType);
        //        }
        //    }
        //    return dt.Rows.Count == ht.Count;
        //}

        ///// <summary>
        ///// Kiem tra gia tri mot cot khong thong bao loi
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="dt"></param>
        ///// <param name="fieldName"></param>
        ///// <returns></returns>
        //public static bool IsDuplicateValidateRow(GridView grid, DataTable dt, string fieldName)
        //{
        //    Hashtable ht = new Hashtable();
        //    if (grid.Columns.View.ActiveFilter.IsEmpty)
        //    {
        //        foreach (DataRow r in dt.Rows)
        //        {
        //            if (!ht.Contains(r[fieldName]))
        //                ht.Add(r[fieldName], r[fieldName]);
        //        }
        //    }
        //    return dt.Rows.Count == ht.Count;
        //}

        ///// <summary>
        ///// Kiem tra trung o mot cot khong hien thi loi
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="dt"></param>
        ///// <param name="fieldName"></param>
        ///// <param name="value"></param>
        ///// <param name="e"></param>
        ///// <returns></returns>
        //public static bool IsDuplicateValidateRow(GridView grid, DataTable dt, string fieldName, object value, ValidateRowEventArgs e)
        //{
        //    if (grid.Columns.View.ActiveFilter.IsEmpty)
        //    {
        //        if (dt.Select(string.Format("{0}='{1}'", fieldName, value)).Length > 1)
        //            e.Valid = false;
        //        else
        //        {
        //            e.Valid = true;
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// Mac dinh merge tat ca, chi dinh cot ko merge.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        public static void MergeCell(GridView grid, string[] fieldName)
        {
            grid.OptionsView.AllowCellMerge = true;
            for (int i = 0; i < fieldName.Length; i++)
                grid.Columns[fieldName[i]].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
        }

        /// <summary>
        /// An cac cot, dung sau phuong thuc ShowField
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        public static void HideField(GridView grid, string[] fieldName)
        {
             if (fieldName == null) return;
            for (int i = 0; i < fieldName.Length; i++)
            {
                if (fieldName[i].Trim() == "") continue;
                grid.Columns[fieldName[i]].Visible = false;
            }
        }

        public static void UnHideField(GridView grid, string[] fieldName)
        {
            if (fieldName == null) return;
            for (int i = 0; i < fieldName.Length; i++)
            {
                if (fieldName[i].Trim() == "") continue;
                grid.Columns[fieldName[i]].Visible = true;
            }
        }

        /// <summary>
        /// Format cell theo dinh dang
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        public static void FormatTypeColumn(GridView grid, string[] fieldName, FormatType type)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].DisplayFormat.FormatType = type;
                //grid.Columns[fieldName[i]].DisplayFormat.FormatString = "D";
                //grid.Columns[fieldName[i]].ColumnEdit.
                //grid.Columns.View.SetColumnError(grid.Columns[i], string.Format("{0} không đúng định dạng");
            }
            //return true;
        }

        //CancelUpdateCurrentRow
        public static void CancelUpdateCurrentRow(GridControl gridControl)
        {
            ColumnView view = (ColumnView)gridControl.FocusedView;
            if (view.IsEditing)
                view.HideEditor();
            view.CancelUpdateCurrentRow();
        }

        /// <summary>
        /// Cho biết dòng và cột của ô được double click
        /// </summary>
        /// <param name="grid">GridView được doubleclick</param>
        /// <param name="pt">Point của con trỏ chuột tại nơi doubleclick</param>
        /// <param name="rowIndex">Index của dòng được doublelick (nếu doublelick trong lưới)</param>
        /// <param name="columnName">Tên cột được doublelick (nếu doublelick trong lưới)</param>
        public static void DoDoubleClick(GridView grid, Point pt, ref int rowIndex, ref string columnName)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = grid.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                rowIndex = info.RowHandle;
                columnName = colCaption;
                //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"> Loại đối tượng </typeparam>
        /// <param name="view"></param>
        /// <returns></returns>
        public static List<T> GetFilteredData<T>(ColumnView view)
        {
            List<T> resp = new List<T>();
            for (int i = 0; i < view.DataRowCount; i++)
            {
                int rowHandle = view.GetVisibleRowHandle(i);
                resp.Add((T)view.GetRow(rowHandle));
            }
            return resp;
        }

        /// <summary>
        /// Check tất cả các checkbox có cùng giá trị tại một số cột
        /// </summary>
        /// <param name="grid">GridView chứa dữ liệu</param>
        /// <param name="tenCotCheckBox">Tên cột </param>
        /// <param name="tenCotGiaTriGiongNhau"></param>
        public static void CheckAll(GridView grid, string tenCotCheckBox, string[] tenCotGiaTriGiongNhau, int dongDuocChon)
        {
            if (grid == null || tenCotCheckBox == null || tenCotGiaTriGiongNhau == null || dongDuocChon <= 0) return;
            if ((bool)grid.GetRowCellValue(dongDuocChon, tenCotCheckBox)) return;   //Check rồi thì bỏ qua 
            bool giongNhau;
            ////Lan lên trên:
            //for (int i = dongDuocChon; i >= 0; i--)
            //{
            //    giongNhau = true;
            //    for (int j = 0; j < tenCotGiaTriGiongNhau.Length; j++)
            //    {
            //        giongNhau &= grid.GetRowCellValue(i, tenCotGiaTriGiongNhau[j]).Equals(grid.GetRowCellValue(i, tenCotGiaTriGiongNhau[j])); //1 cột không giống thì false
            //    }
            //    if (giongNhau) grid.SetRowCellValue(i, tenCotCheckBox, true);
            //    else break;
            //}
            ////Lan xuống dưới:
            //for (int i = dongDuocChon; i < grid.RowCount; i++)
            //{
            //    giongNhau = true;
            //    for (int j = 0; j < tenCotGiaTriGiongNhau.Length; j++)
            //    {
            //        giongNhau &= grid.GetRowCellValue(dongDuocChon, tenCotGiaTriGiongNhau[j]).Equals(grid.GetRowCellValue(i, tenCotGiaTriGiongNhau[j])); //1 cột không giống thì false
            //    }
            //    if (giongNhau) grid.SetRowCellValue(i, tenCotCheckBox, true);
            //    else break;
            //}
            for (int i = 0; i < grid.RowCount; i++)
            {
                giongNhau = true;
                for (int j = 0; j < tenCotGiaTriGiongNhau.Length; j++)
                {
                    giongNhau &= grid.GetRowCellValue(dongDuocChon, tenCotGiaTriGiongNhau[j]).Equals(grid.GetRowCellValue(i, tenCotGiaTriGiongNhau[j])); //1 cột không giống thì false
                }
                grid.SetRowCellValue(i, tenCotCheckBox, giongNhau);
            }
        }

        public static void WordWrapHeader(GridView grid, int height)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            AutoHeightHelper a = new AutoHeightHelper(grid, height);
            a.EnableColumnPanelAutoHeight();
        }

    }
}
