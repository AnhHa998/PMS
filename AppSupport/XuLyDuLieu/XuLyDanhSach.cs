using System.Collections.Generic;

namespace XuLyChung.XuLyDuLieu
{
    public class XuLyDanhSach
    {
        public static void DuyetDanhSach<T> (List<T> danh_sach, AppSupport.ConTroHam.void_object ham)
        {
            foreach (T t in danh_sach)
            {
                ham(t);
            }
        }

    }
}
