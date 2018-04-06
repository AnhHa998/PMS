using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_Object
{
    public class TaiKhoan
    {
        string _tenDangNhap;
        string _matKhau;
        string _hoTen;
        bool _trangThai;
        DateTime _ngayTao;
        List<Quyen> _dsQuyen;
        public static TaiKhoan TAI_KHOAN_HIEN_TAI;

        public string TenDangNhap { get => _tenDangNhap; set => _tenDangNhap = value; }
        public string MatKhau { get => _matKhau; set => _matKhau = value; }
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public bool TrangThai { get => _trangThai; set => _trangThai = value; }
        public DateTime NgayTao { get => _ngayTao; set => _ngayTao = value; }
        public List<Quyen> DsQuyen { get => _dsQuyen; set => _dsQuyen = value; }

        public bool KiemTraDangNhap (string ten_dang_nhap, string mat_khau)
        {
            bool taiKhoanTonTai = false;    //Kiểm tra đăng nhập
            if (taiKhoanTonTai)
            {
                _dsQuyen = null;            //Lấy danh sách quyền
            }
            return taiKhoanTonTai;
        }

    }
}
