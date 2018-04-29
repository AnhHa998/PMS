using System;
using DevExpress.XtraEditors;
using PMS.Core;

namespace PMS.Forms.HeThong
{
    public partial class frmNavigationEx : XtraForm
    {
        public frmNavigationEx()
        {
            InitializeComponent();
        }

        private void frmNavigationEx_Load(object sender, EventArgs e)
        {
            AppSystem sys = new AppSystem();
            sys.LoadModules(this, navBarControl, pContainer, simageCollection);
            if (navBarControl.Groups.Count > 0)
            {
                if (navBarControl.Groups[0].ItemLinks.Count > 0)
                    navBarControl.Groups[0].ItemLinks[0].PerformClick();
            }
        }
    }
}