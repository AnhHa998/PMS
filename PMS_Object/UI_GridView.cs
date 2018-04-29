using DevExpress.XtraGrid.Columns;

namespace PMS_Object
{
    public class UI_GridView
    {
        string _gridViewID;
        bool _multiSelect;
        string _multiSelectMode;
        bool _showDetailButtons;
        bool _showGroupPanel;
        string _newItemRowText;
        string _groupPanelText;
        int _wordWrapHeader;
        string _columnFields;
        string _columnNames;
        string _columnWidths;
        string _hideFields;
        string _readOnlyFields;
        string _fixedFields;
        FixedStyle FixedStyle;

        public string GridViewID { get => _gridViewID; set => _gridViewID = value; }
        public bool MultiSelect { get => _multiSelect; set => _multiSelect = value; }
        public string MultiSelectMode { get => _multiSelectMode; set => _multiSelectMode = value; }
        public bool ShowDetailButtons { get => _showDetailButtons; set => _showDetailButtons = value; }
        public bool ShowGroupPanel { get => _showGroupPanel; set => _showGroupPanel = value; }
        public string NewItemRowText { get => _newItemRowText; set => _newItemRowText = value; }
        public string GroupPanelText { get => _groupPanelText; set => _groupPanelText = value; }
        public int WordWrapHeader { get => _wordWrapHeader; set => _wordWrapHeader = value; }
        public string ColumnFields { get => _columnFields; set => _columnFields = value; }
        public string ColumnNames { get => _columnNames; set => _columnNames = value; }
        public string ColumnWidths { get => _columnWidths; set => _columnWidths = value; }
        public string HideFields { get => _hideFields; set => _hideFields = value; }
        public string ReadOnlyFields { get => _readOnlyFields; set => _readOnlyFields = value; }
        public string FixedFields { get => _fixedFields; set => _fixedFields = value; }
        public FixedStyle FixedStyle1 { get => FixedStyle; set => FixedStyle = value; }
    }
}
