using System.Data;

namespace PMS_Data
{
    public class HocVi_Data
    {
        private string[] _columnNames = { "Mã học vị", "Tên học vị", "HRM ID" };

        public DataTable LayDuLieu ()
        {
            DataTable dt = DataProvider.ExecQuery("Select * From HocVi");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = _columnNames[i];
            }
            return dt;
        }
    }
}
