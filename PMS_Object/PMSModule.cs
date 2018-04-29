using System.Collections.Generic;

namespace PMS_Object
{
    public class PMSModule : PMSObject
    {
        protected string _moduleID;
        protected string _moduleName;
        protected string _GUIName;
        protected int _order;
        List<PMSModule> _listModuleGetData; //Các module cần để lấy dữ liệu (in)
        List<PMSModule> _listModuleSetData; //Các module cần để trả dữ liệu (out)

        public string ModuleID { get => _moduleID; set => _moduleID = value; }
        public string ModuleName { get => _moduleName; set => _moduleName = value; }
        public string GUIName { get => _GUIName; set => _GUIName = value; }
        public int Order { get => _order; set => _order = value; }
        public List<PMSModule> ListModuleGetData { get => _listModuleGetData; set => _listModuleGetData = value; }
        public List<PMSModule> ListModuleSetData { get => _listModuleSetData; set => _listModuleSetData = value; }
    }
}
