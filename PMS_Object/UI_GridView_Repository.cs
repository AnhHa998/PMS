namespace PMS_Object
{
    public class UI_GridView_Repository
    {
        string _gridViewID;     //--> Khóa ngoại tham chiếu tới UI_GridView
        string _repositoryID;   //--> Khóa ngoại tham chiếu tới UI_Repository
        string _fieldName;		//--> Tên MỘT field trong UI_Gridview.ColumnFields được gắn
        int _popupWidth;		//--> Chiều rộng cửa sổ popup
        int _popupHeight;       //--> Chiều cao cửa sổ popup

        public string GridViewID { get => _gridViewID; set => _gridViewID = value; }
        public string RepositoryID { get => _repositoryID; set => _repositoryID = value; }
        public string FieldName { get => _fieldName; set => _fieldName = value; }
        public int PopupWidth { get => _popupWidth; set => _popupWidth = value; }
        public int PopupHeight { get => _popupHeight; set => _popupHeight = value; }
    }
}
