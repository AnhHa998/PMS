using System.Collections.Generic;

namespace PMS_Object
{
    public class Quyen : PMSObject
    {
        string _maQuyen;
        string _tenQuyen;
        string _ghiChu;
        List<ChucNang> _dsChucNang;

        public string MaQuyen { get => _maQuyen; set => _maQuyen = value; }
        public string TenQuyen { get => _tenQuyen; set => _tenQuyen = value; }
        public string GhiChu { get => _ghiChu; set => _ghiChu = value; }
        public List<ChucNang> DsChucNang { get => _dsChucNang; set => _dsChucNang = value; }

        public Quyen() { }

        public Quyen(string ma_quyen, string ten_quyen, string ghi_chu)
        {
            _maQuyen = ma_quyen;
            _tenQuyen = ten_quyen;
            _ghiChu = ghi_chu;
        }

        #region Hàm xử lý
        
        #endregion
    }
}
