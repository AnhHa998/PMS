using DevExpress.XtraBars;
using System;
using System.Windows.Forms;

namespace PMS.Forms.HeThong
{
    public partial class frmThongTin : DevExpress.XtraEditors.XtraForm
    {
        //public ViewNamHoc v;
        //public PMS.Forms.NghiepVu.frmCoVanHocTap  frm;
        //int i = 1;
        public frmThongTin()
        {
            InitializeComponent();
            //getHocKyCurrent();
            // v = bindingSourceNamHoc.Current as ViewNamHoc;;
            //i = 5;
            //cbonamhoc.Properties.DisplayMember = "_namHoc";
            //cbonamhoc.Properties.ValueMember = "_namHoc";

            //cbonamhoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("_namHoc", "")});

            //cbhocky.Properties.DisplayMember = "MaHocKy";
            //cbhocky.Properties.ValueMember = "MaHocKy";

            //cbnamhoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            //new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaHocKy", "")});

            //bindingSourceNamHoc.DataSource = DataServices.ViewNamHoc.GetAll();
            //getNamHocCurrent();
        }

        private void linkDoiMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //using (frmDoiMatKhau frm = new frmDoiMatKhau()) { frm.ShowDialog(this); }
        }

        private void frmThongTin_Load(object sender, EventArgs e)
        {
            ////Gắn tên đăng nhập để lưu log
            //PMS.Data.Utility.userID = UserInfo.UserName;

            //lblHoTen.Text = UserInfo.FullName;
            //lblNhomQuyen.Text = UserInfo.GroupName;
            //lblUser.Text = UserInfo.UserName;
            //lblThoiGian.Text = DateTime.Now.ToString();
            //frmMain.Instance.ItemDangXuat.Caption = UserInfo.UserName;
            //if (UserInfo.LoginType == UserTypes.None)
            //    frmMain.Instance.DangXuat.Width = 35 + UserInfo.UserName.Length;
            //else
            //    frmMain.Instance.DangXuat.Width = 80;
            //frmMain.Instance.DangXuat.Hint = UserInfo.UserName;
            //frmMain.Instance.DangXuat.Visibility = BarItemVisibility.Always;
        }

    }
}