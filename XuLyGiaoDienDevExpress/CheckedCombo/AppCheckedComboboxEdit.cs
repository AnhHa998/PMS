
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using PMS.Entities;
using PMS.Services;



namespace DevExpress.Common.CheckedCombo
{
    public static class AppCheckedComboboxEdit
    {
        /// <summary>
        /// Khởi tạo dữ liệu cho ChecedComboBoxEdit
        /// </summary>
        /// <param name="ckb">CheckedComboBoxEdit càn khởi tạo</param>
        /// <param name="checkMode">ChecState: check hay không</param>
        /// <param name="loai">LoaiDuLieu cần khởi tạo</param>
        public static void InitCheckedComboBoxEdit(CheckedComboBoxEdit ckb, CheckState checkMode, LoaiDuLieu loai, string ma_truong)
        {
            ckb.Properties.NullText = "(Chưa chọn)";
            ckb.Properties.SelectAllItemCaption = "[Tất cả]";
            ckb.Properties.TextEditStyle = TextEditStyles.Standard;
            ckb.Properties.Items.Clear();

            List<CheckedListBoxItem> _list = new List<CheckedListBoxItem>();

            switch (loai)
            {
                
                case LoaiDuLieu.Bac_LoaiHinh:
                    VList<ViewBacDaoTaoLoaiHinh> _vListBacDaoTaoLoaiHinh = DataServices.ViewBacDaoTaoLoaiHinh.GetAll();
                    _vListBacDaoTaoLoaiHinh.Sort("MaBacLoaiHinh");
                    foreach (ViewBacDaoTaoLoaiHinh v in _vListBacDaoTaoLoaiHinh)
                    {
                        _list.Add(new CheckedListBoxItem(v.MaBacLoaiHinh, v.TenBacLoaiHinh, checkMode, true));
                    }
                    break;
                case LoaiDuLieu.HocHam:
                    TList<HocHam> _tListHocHam;
                    _tListHocHam = DataServices.HocHam.GetAll();
                    foreach (HocHam hh in _tListHocHam)
                    {
                        _list.Add(new CheckedListBoxItem(hh.MaHocHam, hh.TenHocHam, checkMode, true));
                    }
                    break;
                case LoaiDuLieu.KhoaDonVi:
                    VList<ViewKhoa> _vListKhoa;
                    _vListKhoa = DataServices.ViewKhoa.GetAll();
                    _vListKhoa.Sort("TenKhoa");
                    foreach (ViewKhoa v in _vListKhoa)
                    {
                        _list.Add(new CheckedListBoxItem(v.MaKhoa, v.TenKhoa, checkMode, true));
                    }
                    break;
                case LoaiDuLieu.NgachLuong:
                    TList<NgachCongChuc> _tListNgachCongChuc;
                    _tListNgachCongChuc = DataServices.NgachCongChuc.GetAll();
                    foreach (NgachCongChuc ngach in _tListNgachCongChuc)
                    {
                        _list.Add(new CheckedListBoxItem(ngach.MaQuanLy, ngach.TenNgach, checkMode, true));
                    }
                    break;
                default:
                    return;
            }
            
            ckb.Properties.Items.AddRange(_list.ToArray());
            ckb.Properties.SeparatorChar = ';';
        }

        /// <summary>
        /// Khởi tạo dữ liệu cho ChecedComboBoxEdit
        /// </summary>
        /// <param name="ckb">CheckedComboBoxEdit càn khởi tạo</param>
        /// <param name="list">List<CheckedListBoxItem> danh sách các phần tử cần đưa vào</param>
        public static void InitCheckedComboBoxEdit(CheckedComboBoxEdit ckb, List<CheckedListBoxItem> list)
        {
            ckb.Properties.NullText = "(Chưa chọn)";
            ckb.Properties.SelectAllItemCaption = "[Tất cả]";
            ckb.Properties.TextEditStyle = TextEditStyles.Standard;
            ckb.Properties.Items.Clear();
            ckb.Properties.Items.AddRange(list.ToArray());
            ckb.Properties.SeparatorChar = ';';
            ckb.CheckAll();
        }
    }
}

