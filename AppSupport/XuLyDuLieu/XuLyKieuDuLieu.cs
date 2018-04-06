using System;

namespace XuLyChung.XuLyDuLieu
{
    public class XuLyKieuDuLieu
    {
        public static object ThayTheNull (object bien_gia_tri_gan, Type kieu_du_lieu)
        {
            if(bien_gia_tri_gan == null || bien_gia_tri_gan.GetType().Equals(Type.GetType("System.DBNull")))
            {
                if (kieu_du_lieu == null) return null;
                if (kieu_du_lieu.Equals(typeof(string))) return "";
                if (kieu_du_lieu.Equals(typeof(int))) return 0;
                if (kieu_du_lieu.Equals(typeof(long))) return 0;
                if (kieu_du_lieu.Equals(typeof(float))) return 0;
                if (kieu_du_lieu.Equals(typeof(double))) return 0;
                if (kieu_du_lieu.Equals(typeof(bool))) return false;
                if (kieu_du_lieu.Equals(typeof(DateTime))) return DateTime.Now;
                return null;
            }
            else
            {
                return bien_gia_tri_gan;
            }
        }

    }
}
