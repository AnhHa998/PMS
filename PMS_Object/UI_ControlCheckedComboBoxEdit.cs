namespace PMS_Object
{
    public class UI_ControlCheckedComboBoxEdit : UI_Control
    {
        UI_CheckedComboBoxEdit _checkedComboBox;

        public string CheckedComboBoxID { get => _checkedComboBox.CheckedComboBoxID; set => _checkedComboBox.CheckedComboBoxID = value; }
        public UI_CheckedComboBoxEdit CheckedComboBox { get => _checkedComboBox; set => _checkedComboBox = value; }
    }
}
