namespace PMS_Object
{
    public class HocVi
    {
        string _maHocVi;    // Tương ứng với AcademicTitleID bên CoreUis.dbo.psc_Dic_AcademicTitles
        string _tenHocVi;
        string _HRMID;       // Primary key bên HRM

        public string MaHocVi { get => _maHocVi; set => _maHocVi = value; }
        public string TenHocVi { get => _tenHocVi; set => _tenHocVi = value; }
        public string HRMID { get => _HRMID; set => _HRMID = value; }
    }
}

