using System.Drawing;

namespace PMS_Object
{
    public class ChucNang : PMSObject
    {
        int _maChucNang;
        ChucNang _parent;
        int _thuTu;
        LoaiChucNang _loaiChucNang;
        string _tenChucNang;
        string _tenForm;
        Image _hinhAnh;
        Image _hinhAnhForm;
        
        bool _trangThai;

        public ChucNang() : base()
        {}

        public ChucNang(int maChucNang, ChucNang parent, int thuTu, LoaiChucNang loaiChucNang, string tenChucNang
            , string tenForm, Image hinhAnh, Image hinhAnhForm, bool trangThai) : base()
        {
            _maChucNang = maChucNang;
            _parent = parent;
            _thuTu = thuTu;
            _loaiChucNang = loaiChucNang;
            _tenChucNang = tenChucNang;
            _tenForm = tenForm;
            _hinhAnh = hinhAnh;
            _hinhAnhForm = hinhAnhForm;
            _trangThai = trangThai;
        }

        public int MaChucNang { get => _maChucNang; set => _maChucNang = value; }
        public int MaChucNangCha {
            get =>  _parent == null ? 0 : _parent._maChucNang;
            set { if (_parent != null) _parent._maChucNang = value; }
        }
        public ChucNang ChucNangCha { get => _parent; set => _parent = value; }
        public int ThuTu { get => _thuTu; set => _thuTu = value; }
        public int PhanLoai
        {
            get => _loaiChucNang == null ? -1 : _loaiChucNang.MaLoai;
            set { if (_loaiChucNang != null) _loaiChucNang.MaLoai = value; }
        }
        public LoaiChucNang LoaiChucNang { get => _loaiChucNang; set => _loaiChucNang = value; }
        public string TenChucNang { get => _tenChucNang; set => _tenChucNang = value; }
        public string TenForm { get => _tenForm; set => _tenForm = value; }
        public Image HinhAnh { get => _hinhAnh; set => _hinhAnh = value; }
        public Image AnhChup { get => _hinhAnhForm; set => _hinhAnhForm = value; }
        public bool TrangThai { get => _trangThai; set => _trangThai = value; }

        #region Hàm xử lý
        
        #endregion
    }
}

