namespace PMS_Object
{
    public class UI_GridLookupEdit
    {
        string _gridLookupID;
        string _nullText;
        string _columnField;
        string _columnName;
        string _columnWidth;
        string _displayMember;
        string _valueMember;
        string _selectStore;

        public string GridLookupID { get => _gridLookupID; set => _gridLookupID = value; }
        public string NullText { get => _nullText; set => _nullText = value; }
        public string ColumnField { get => _columnField; set => _columnField = value; }
        public string ColumnName { get => _columnName; set => _columnName = value; }
        public string ColumnWidth { get => _columnWidth; set => _columnWidth = value; }
        public string DisplayMember { get => _displayMember; set => _displayMember = value; }
        public string ValueMember { get => _valueMember; set => _valueMember = value; }
        public string SelectStore { get => _selectStore; set => _selectStore = value; }
    }
}
