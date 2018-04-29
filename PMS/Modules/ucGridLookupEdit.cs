using DevExpress.XtraEditors;
using PMS_Data;
using PMS_Object;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using XuLyChung;
using XuLyGiaoDienDevExpress.ComboBox;

namespace PMS.Modules
{
    public partial class ucGridLookupEdit : XtraUserControl
    {

        #region Thành phần mà đối tượng bên ngoài sử dụng
        UI_ControlGridLookupEdit _moduleControl;
        public event EventHandler EditValueChanged;

        public UI_ControlGridLookupEdit ModuleControl
        {
            get => _moduleControl;
            set
            {
                _moduleControl = value;
                this.Location = new System.Drawing.Point(_moduleControl.X, _moduleControl.Y);
                this.Name = _moduleControl.ModuleName;
                this.lblNamHoc.Text = _moduleControl.ModuleName;
                this.Size = new System.Drawing.Size(_moduleControl.Width, _moduleControl.Height);
            }
        }
        #endregion

        public ucGridLookupEdit()
        {
            InitializeComponent();
        }

        private void ucGridLookupEdit_Load(object sender, EventArgs e)
        {
            UI_GridLookupEdit gridLookup = _moduleControl.GridLookup;
            string[] columnFields = gridLookup.ColumnField.Split(BienToanCuc.SEPERATOR_CHARACTER);
            string[] columnNames = gridLookup.ColumnName.Split(BienToanCuc.SEPERATOR_CHARACTER);
            string[] arrStr = gridLookup.ColumnWidth.Split(BienToanCuc.SEPERATOR_CHARACTER);
            int[] columnWidths = new int[arrStr.Length];
            for (int i = 0; i < columnWidths.Length; i++)
            {
                columnWidths[i] = int.Parse(arrStr[i]);
            }
            int popupWidth = 300;       //sẽ làm sau
            int popupHeight = 300;     //sẽ làm sau
            object defaultValue = "sẽ làm sau";

            AppGridLookupEdit.Init(cboNamHoc, columnFields, columnNames, columnWidths, gridLookup.ValueMember, gridLookup.DisplayMember
                , popupWidth, popupHeight, gridLookup.NullText, defaultValue);

            bsData.DataSource = DataProvider.ExecQueryStore(gridLookup.SelectStore);
        }

        private void cboNamHoc_EditValueChanged(object sender, EventArgs e)
        {
            PMSEventArgs evt = new PMSEventArgs();
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter(_moduleControl.ParameterName,(string)cboNamHoc.EditValue));
            evt.ListParameter = list;
            this.EditValueChanged(sender, evt);
        }

    }
}
