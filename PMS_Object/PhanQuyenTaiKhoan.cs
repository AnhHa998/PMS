using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_Object
{
    public class PhanQuyenTaiKhoan
    {
        string _tenDangNhap;
        Quyen _nhomQuyen;

        public string TenDangNhap { get => _tenDangNhap; set => _tenDangNhap = value; }
        public Quyen NhomQuyen { get => _nhomQuyen; set => _nhomQuyen = value; }
    }
}
