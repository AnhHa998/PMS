using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using PMS.Entities;
using PMS.Services;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DevExpress.Common.CheckedCombo
{
    public static class AppRepositoryItemCheckedComboBoxEdit
    {
        public static void Init(RepositoryItemCheckedComboBoxEdit repo, CheckState check, LoaiDuLieu loai)
        {
            repo.SelectAllItemCaption = "[Tất cả]";
            repo.TextEditStyle = TextEditStyles.Standard;
            repo.Items.Clear();
            List<CheckedListBoxItem> _list = new List<CheckedListBoxItem>();
            _list.Add(new CheckedListBoxItem(-1, "[Không xét]"));

            switch (loai)
            {
                case LoaiDuLieu.BacDaoTao:
                    VList<ViewBacDaoTao> _vBacDaoTao = new VList<ViewBacDaoTao>();
                    _vBacDaoTao = DataServices.ViewBacDaoTao.GetAll();
                    _vBacDaoTao.Sort("TenBacDaoTao");
                    foreach (ViewBacDaoTao v in _vBacDaoTao)
                    {
                        _list.Add(new CheckedListBoxItem(v.MaBacDaoTao, v.TenBacDaoTao, check, true));
                    }
                    break;
                case LoaiDuLieu.ChucVu:
                    TList<ChucVu> _tChucVu = new TList<ChucVu>();
                    _tChucVu = DataServices.ChucVu.GetAll();
                    _tChucVu.Sort("TenChucVu");
                    foreach (ChucVu t in _tChucVu)
                    {
                        _list.Add(new CheckedListBoxItem(t.MaChucVu, t.TenChucVu, check, true));
                    }
                    break;
                case LoaiDuLieu.HocHam:
                    TList<HocHam> _tHocHam = new TList<HocHam>();
                    _tHocHam = DataServices.HocHam.GetAll();
                    _tHocHam.Sort("TenHocHam");
                    foreach (HocHam t in _tHocHam)
                    {
                        _list.Add(new CheckedListBoxItem(t.MaHocHam, t.TenHocHam, check, true));
                    }
                    break;
                case LoaiDuLieu.HocVi:
                    TList<HocVi> _tHocVi = new TList<HocVi>();
                    _tHocVi = DataServices.HocVi.GetAll();
                    _tHocVi.Sort("TenHocVi");
                    foreach (HocVi t in _tHocVi)
                    {
                        _list.Add(new CheckedListBoxItem(t.MaHocVi, t.TenHocVi, check, true));
                    }
                    break;
                case LoaiDuLieu.HinhThucDangKy:
                    TList<HinhThucDaoTao> _tHinhThucDangKy = new TList<HinhThucDaoTao>();
                    _tHinhThucDangKy = DataServices.HinhThucDaoTao.GetAll();
                    _tHinhThucDangKy.Sort("TenHinhThucDaoTao");
                    foreach (HinhThucDaoTao t in _tHinhThucDangKy)
                    {
                        _list.Add(new CheckedListBoxItem(t.MaHinhThucDaoTao, t.TenHinhThucDaoTao, check, true));
                    }
                    break;
                case LoaiDuLieu.LoaiGiangVien:
                    TList<LoaiGiangVien> _tLoaiGiangVien = new TList<LoaiGiangVien>();
                    _tLoaiGiangVien = DataServices.LoaiGiangVien.GetAll();
                    _tLoaiGiangVien.Sort("TenLoaiGiangVien");
                    foreach (LoaiGiangVien t in _tLoaiGiangVien)
                    {
                        _list.Add(new CheckedListBoxItem(t.MaLoaiGiangVien, t.TenLoaiGiangVien, check, true));
                    }
                    break;
                case LoaiDuLieu.LoaiNhanVien:
                    TList<LoaiNhanVien> _tLoaiNhanVien = new TList<LoaiNhanVien>();
                    _tLoaiNhanVien = DataServices.LoaiNhanVien.GetAll();
                    _tLoaiNhanVien.Sort("TenLoaiNhanVien");
                    foreach (LoaiNhanVien t in _tLoaiNhanVien)
                    {
                        _list.Add(new CheckedListBoxItem(t.MaLoaiNhanVien, t.TenLoaiNhanVien, check, true));
                    }
                    break;
                case LoaiDuLieu.NgachLuong:
                    TList<NgachCongChuc> _tNgachCongChuc = new TList<NgachCongChuc>();
                    _tNgachCongChuc = DataServices.NgachCongChuc.GetAll();
                    _tNgachCongChuc.Sort("MaQuanLy");
                    foreach (NgachCongChuc t in _tNgachCongChuc)
                    {
                        _list.Add(new CheckedListBoxItem(t.MaQuanLy, t.MaQuanLy + " - " + t.TenNgach, check, true));
                    }
                    break;
                default:
                    return;
            }
            
            repo.Items.AddRange(_list.ToArray());
            repo.SeparatorChar = ';';

            //Toàn bộ repo đều có chung kiểu Validate:
            repo.Validating += new System.ComponentModel.CancelEventHandler(repositoryItemCheckedComboBoxEditLoaiNhanVien_Validating);
        }

        /// <summary>
        /// Độ rộng và cao khi mở
        /// </summary>
        /// <param name="sender"> CheckedComboBoxEdit cần thiết lập </param>
        /// <param name="width"> chiều rộng </param>
        /// <param name="height"> chiều cao </param>
        public static void PopupSize(object sender, int width, int height)
        {
            (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow.Width = width;
            (sender as DevExpress.Utils.Win.IPopupControl).PopupWindow.Height = height;
        }
        
        private static void repositoryItemCheckedComboBoxEditLoaiNhanVien_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RepositoryItemCheckedComboBoxEdit cbo = (RepositoryItemCheckedComboBoxEdit)sender;
            foreach (CheckedListBoxItem item in cbo.Items)
            {
                if (item.Value.Equals("-1"))
                {
                    foreach (CheckedListBoxItem item2 in cbo.Items)
                    {
                        if (!item2.Value.Equals("-1"))
                        {
                            item2.CheckState = CheckState.Unchecked;
                        }
                    }
                    break;
                }
            }
        }

    }
}
