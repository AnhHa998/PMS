namespace PMS_Object
{
    public class UI_ControlGridLookupEdit : UI_Control
    {
        UI_GridLookupEdit _gridLookup;

        public string GridLookupID { get => _gridLookup.GridLookupID; set => _gridLookup.GridLookupID = value; }
        public UI_GridLookupEdit GridLookup { get => _gridLookup; set => _gridLookup = value; }
    }
}
