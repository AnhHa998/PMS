namespace PMS_Object
{
    public class UI_CheckedComboBoxEdit
    {
        string _checkedComboBoxID;
        string _nullText;
        string _selectAllItemCaption;
        string _separatorChar;
        string _value;
        string _description;
        bool _checkAll;
        string _selectStore;

        public string CheckedComboBoxID { get => _checkedComboBoxID; set => _checkedComboBoxID = value; }
        public string NullText { get => _nullText; set => _nullText = value; }
        public string SelectAllItemCaption { get => _selectAllItemCaption; set => _selectAllItemCaption = value; }
        public string SeparatorChar { get => _separatorChar; set => _separatorChar = value; }
        public string Value { get => _value; set => _value = value; }
        public string Description { get => _description; set => _description = value; }
        public bool CheckAll { get => _checkAll; set => _checkAll = value; }
        public string SelectStore { get => _selectStore; set => _selectStore = value; }
    }
}
