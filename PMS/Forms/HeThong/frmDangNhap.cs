using DevExpress.XtraEditors;
using PMS_Data;
using PMS_Object;
using System;
using System.Windows.Forms;

namespace PMS.Forms.HeThong
{
    public partial class frmDangNhap : XtraForm
    {
        private TaiKhoan_Data _dataTaiKhoan = new TaiKhoan_Data();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap()
        {
            #region Kiem tra dieu kien
            if (string.IsNullOrEmpty(txtTenTruyCap.Text.Trim()))
            {
                XtraMessageBox.Show("Bạn chưa nhập tên truy cập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTruyCap.Focus();
                return;
            }
            #endregion

            try
            {
                TaiKhoan.TAI_KHOAN_HIEN_TAI = _dataTaiKhoan.LayDuLieu(txtTenTruyCap.Text, txtMatKhau.Text);
                if (TaiKhoan.TAI_KHOAN_HIEN_TAI == null)
                {
                    XtraMessageBox.Show("Không tìm thấy tên truy cập trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTruyCap.Focus();
                    
                }
                else if (TaiKhoan.TAI_KHOAN_HIEN_TAI.MatKhau == "")   //Sai mật khẩu vẫn lấy ra tài khoản như mật khẩu sẽ là chuỗi rỗng
                {
                    XtraMessageBox.Show("Sai mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                }
                else if ( ! TaiKhoan.TAI_KHOAN_HIEN_TAI.TrangThai )
                {
                    XtraMessageBox.Show("Tên truy cập này đang bị khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTruyCap.Focus();
                    return;
                }
                else
                {
                    Close();
                    //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(UserInfo.User.SkinName);
                    //UserInfo.SkinName = UserInfo.User.SkinName;
                    Core.AppSystem.InitControl();
                    //UserInfo.LoginType = UserTypes.None;
                    frmThongTin frm = new frmThongTin { MdiParent = frmMain.Instance };
                    frm.Show();
                }
                //if (UserInfo.IsSystemLogin(txtTenTruyCap.Text, txtMatKhau.Text))
                //{
                //    Close();
                //    //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(UserInfo.SkinName);
                //    AppSystem.InitSystem();
                //    UserInfo.LoginType = UserTypes.System;
                //    frmThongTin frm = new frmThongTin { MdiParent = frmMain.Instance };
                //    frm.Show();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //SqlHelper help = new SqlHelper(AppConnection.ConnectionString);
            //if (help.CheckConnection())
            //{
                try
                {
                    DangNhap();
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
            //else
            //{
                //using (frmConfig frm = new frmConfig())
                //{
                //    frm.ShowDialog(this);
                //}
            //}
            Cursor.Current = Cursors.Default;
        }

        private void txtTenTruyCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtMatKhau.Focus();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Cursor.Current = Cursors.WaitCursor;
                //SqlHelper help = new SqlHelper(AppConnection.ConnectionString);
                //if (help.CheckConnection())
                //{
                    try
                    {
                        DangNhap();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //XtraMessageBox.Show("Đã xảy ra lỗi khi kết nối đến server.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                //}
                //else
                //    this.SettingApplication();
                Cursor.Current = Cursors.Default;
            }
        }

        //private void SettingApplication()
        //{
        //    using (frmConfig frm = new frmConfig())
        //    {
        //        frm.ShowDialog(this);
        //    }
        //}

        private void txtTenTruyCap_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.R)
            //    this.SettingApplication();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.R)
            //    this.SettingApplication();
        }
    }
}