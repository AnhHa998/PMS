using DevExpress.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.HeThong.frmMain());
            //System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> listParam = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();
            //listParam.Add(new System.Data.SqlClient.SqlParameter("@TenChucNang", "điển"));
            //listParam.Add(new System.Data.SqlClient.SqlParameter("@MaChucNang", "Module"));
            //System.Data.DataTable tb = PMS_Data.DataProvider.ExecQueryStore("sp_ChucNang_Lay", listParam);    

        }
    }
}
