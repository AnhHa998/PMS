using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_Object
{
    public class PhanQuyenChucNang
    {
        ChucNang _chucNang;
        Quyen _nhomQuyen;

        public ChucNang ChucNang { get => _chucNang; set => _chucNang = value; }
        public Quyen NhomQuyen { get => _nhomQuyen; set => _nhomQuyen = value; }
    }
}
