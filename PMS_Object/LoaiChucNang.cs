using System.Drawing;

namespace PMS_Object
{
    public class LoaiChucNang : PMSObject
    {
        string _maLoai;
        string _tenLoai;
        LoaiChucNang _loaiCha;
        bool _MdiForm;

        public LoaiChucNang()
        { }

        public LoaiChucNang(string maLoai, string tenLoai, LoaiChucNang loaiCha)
        {
            _maLoai = maLoai;
            _tenLoai = tenLoai;
            _loaiCha = loaiCha;
        }
        
        public string MaLoai { get => _maLoai; set => _maLoai = value; }
        public string TenLoai { get => _tenLoai; set => _tenLoai = value; }
        public LoaiChucNang LoaiChucNangBacTren { get => _loaiCha; set => _loaiCha = value; }
        public bool MdiForm { get => _MdiForm; set => _MdiForm = value; }

        public override string ToString()
        {
            return _tenLoai;
        }
    }
}

