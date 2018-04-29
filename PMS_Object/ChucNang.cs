using System.Drawing;

namespace PMS_Object
{
    public class ChucNang : PMSModule
    {
        //ChucNang _chucNangBacTren;
        string _maChucNangBacTren;
        LoaiChucNang _loaiChucNang;
        Image _hinhAnh;
        Image _hinhAnhForm;
        bool _batDauNhom;
        string _maGridView;
        string _selectStore;
        string _insertStore;
        string _updateStore;
        string _deleteStore;
        bool _trangThai;

        public ChucNang() : base()
        {}

        public ChucNang(string maChucNang, string maBacTren, int thuTu, LoaiChucNang loaiChucNang, string tenChucNang
            , string tenForm, Image hinhAnh, Image hinhAnhForm, bool trangThai) : base()
        {
            _moduleID = maChucNang;
            _maChucNangBacTren = maBacTren;
            _order = thuTu;
            _loaiChucNang = loaiChucNang;
            _moduleName = tenChucNang;
            _GUIName = tenForm;
            _hinhAnh = hinhAnh;
            _hinhAnhForm = hinhAnhForm;
            _trangThai = trangThai;
        }

        //public ChucNang ChucNangBacTren { get => _chucNangBacTren; set => _chucNangBacTren = value; }

        public string MaChucNangBacTren { get => _maChucNangBacTren; set => _maChucNangBacTren = value; }

        public string PhanLoai
        {
            get => _loaiChucNang == null ? "" : _loaiChucNang.MaLoai;
            set { if (_loaiChucNang != null) _loaiChucNang.MaLoai = value; }
        }
        public LoaiChucNang LoaiChucNang { get => _loaiChucNang; set => _loaiChucNang = value; }
        public Image HinhAnh { get => _hinhAnh; set => _hinhAnh = value; }
        public Image AnhChup { get => _hinhAnhForm; set => _hinhAnhForm = value; }
        public bool TrangThai { get => _trangThai; set => _trangThai = value; }
        public string MaGridView { get => _maGridView; set => _maGridView = value; }
        public string SelectStore { get => _selectStore; set => _selectStore = value; }
        public string InsertStore { get => _insertStore; set => _insertStore = value; }
        public string UpdateStore { get => _updateStore; set => _updateStore = value; }
        public string DeleteStore { get => _deleteStore; set => _deleteStore = value; }
        

        #region Hàm xử lý

        #endregion
    }
}

